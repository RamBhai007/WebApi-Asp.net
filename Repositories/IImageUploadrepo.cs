using praticeAPI.Models.Domain;

namespace praticeAPI.Repositories
{
    public interface IImageUploadrepo
    {
        Task<Image> UploadAsync(Image image);
    }
}
