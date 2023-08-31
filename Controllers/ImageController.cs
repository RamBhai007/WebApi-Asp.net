using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using praticeAPI.Models.Domain;
using praticeAPI.Models.DTO;
using praticeAPI.Repositories;

namespace praticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepo image;

        public ImageController(IImageRepo image)
        {
            this.image = image;
        }
        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] imageUploadDTO imageUpload)
        {
            validateFileUpload(imageUpload);
            if(ModelState.IsValid)
            {
                var imageDomain = new Image
                {
                    file = imageUpload.file,
                    fileExtension = Path.GetExtension(imageUpload.file.FileName),
                    fileSize = imageUpload.file.Length,
                    FileName = imageUpload.file.FileName,
                    FileDescription = imageUpload.FileDescription
                };

                await image.UploadAsync(imageDomain);
                return Ok(imageDomain);
            }

        }
        private void validateFileUpload(imageUploadDTO imageUpload)
        {
            var allowedExtensions = new string[]
            {
                ".jpg",
                ".jpeg",
                ".png"
            };
            if (!allowedExtensions.Contains(Path.GetExtension(imageUpload.file.FileName)))
            {
                ModelState.AddModelError("file", "unSupported extension");
            }
            if(imageUpload.file.Length> 10485760)
            {
                ModelState.AddModelError("file", "File size extends more than 10MB");
            }
        }
    }
}
