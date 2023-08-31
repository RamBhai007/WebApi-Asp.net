using praticeAPI.Models.Domain;

namespace praticeAPI.Repositories
{
    public interface IRegionRepo
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region> UpdateAsync(Guid id,Region region);
        Task<Region> DeleteAsync(Guid id);
    }
}
