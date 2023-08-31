using praticeAPI.Models.Domain;
using praticeAPI.Models.DTO;

namespace praticeAPI.Repositories
{
    public interface IImageRepo
    {
        Task<Image> UploadAsync(Image image);
    }
}
