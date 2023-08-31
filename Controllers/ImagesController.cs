using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using praticeAPI.Models.Domain;
using praticeAPI.Models.DTO;
using praticeAPI.Repositories;

namespace praticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageUploadrepo image;

        public ImagesController(IImageUploadrepo image)
        {
            this.image = image;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageDTO request)
        {
            ValidateUpload(request);
            if (ModelState.IsValid)
            {
                var imageDomain = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName).ToLower(),
                    FileSize = request.File.Length,
                    FileName = request.FileName,
                    FileDescription =request.FileDescription
                };

                await image.UploadAsync(imageDomain);

                return Ok(imageDomain);
            }
            return BadRequest(ModelState);

        }

        private void ValidateUpload(ImageDTO request)
        {
            var allowedExtenstion = new string[]
            {
                ".jpg",
                ".jpeg",
                ".png"
            };
            if(!allowedExtenstion.Contains(Path.GetExtension(request.File.FileName))) 
            {
                ModelState.AddModelError("file", "Unsupported file Type");
            }
            if(request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File is more than 10MB.");
            }
        }
    }
}
