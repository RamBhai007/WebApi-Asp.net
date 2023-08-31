using Microsoft.AspNetCore.Identity;

namespace praticeAPI.Repositories
{
    public interface ITokenRepo
    {
        string CreateJWTToken(IdentityUser user,List<string> roles);
    }
}
