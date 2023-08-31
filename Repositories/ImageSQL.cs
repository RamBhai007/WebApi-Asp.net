using praticeAPI.Data;
using praticeAPI.Models.Domain;

namespace praticeAPI.Repositories
{
    public class ImageSQL : IImageRepo
    {
        private readonly IWebHostEnvironment webHost;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ImageSQL(IWebHostEnvironment webHost,ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.webHost = webHost;
            this.applicationDbContext = applicationDbContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Image> UploadAsync(Image image)
        {
            var localPath = Path.Combine(webHost.ContentRootPath, "Images", 
                image.FileName,image.fileExtension);
            //upload image to local path
            using var stream = new FileStream(localPath, FileMode.Create);
            await image.file.CopyToAsync(stream);

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.fileExtension}";

            image.filePath = urlFilePath;

            await applicationDbContext.images.AddAsync(image);
            await applicationDbContext.SaveChangesAsync();

            return image;

            

        }

        
    }
}
