using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using praticeAPI.Models.DTO;
using praticeAPI.Repositories;

namespace praticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepo token;

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepo token)
        {
            this.userManager = userManager;
            this.token = token;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterReq registerReq)
        {

            var user = new IdentityUser
            {
                UserName = registerReq.Name,
                Email = registerReq.Name
            };
            var identityResult = await userManager.CreateAsync(user, registerReq.Password);

            if(identityResult.Succeeded)
            {
                if (registerReq.Roles != null && registerReq.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(user, registerReq.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was Registered succesfully");
                    }
                }
                
            }
            return BadRequest("Something Went Wrong");

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginReq loginReq)
        {
            var user= await userManager.FindByEmailAsync(loginReq.Name);
            if (user == null)
            {
                return BadRequest("No User Found");
            }
            var checkPass = await userManager.CheckPasswordAsync(user , loginReq.Password);
            if(checkPass)
            {
                // token creations

                var roles = await userManager.GetRolesAsync(user);
                if (roles != null)
                {
                    var jwtToken = token.CreateJWTToken(user, roles.ToList());
                    var responce = new LoginResponce
                    {
                        JwtToken = jwtToken,
                    };
                    return Ok(responce);
                }
            }
            return BadRequest("Incorrect Password");
        }

    }
}
