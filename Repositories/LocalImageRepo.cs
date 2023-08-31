using praticeAPI.Data;
using praticeAPI.Models.Domain;

namespace praticeAPI.Repositories
{
    public class LocalImageRepo : IImageUploadrepo
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext applicationDbContext;

        public LocalImageRepo(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor,ApplicationDbContext applicationDbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Image> UploadAsync(Image image)
        {
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images",$"{ image.FileName}{image.FileExtension}");

            using var stream = new FileStream(localPath, FileMode.Create);

            await image.File.CopyToAsync(stream);

            var urlPath = $"{httpContextAccessor.HttpContext?.Request.Scheme}://{httpContextAccessor.HttpContext?.Request.Host}{httpContextAccessor.HttpContext?.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath= urlPath;
            await applicationDbContext.AddAsync(image);
            await applicationDbContext.SaveChangesAsync();

            return image;

        }
    }
}
