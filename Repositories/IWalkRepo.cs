using praticeAPI.Models.Domain;

namespace praticeAPI.Repositories
{
    public interface IWalkRepo
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn=null,string? filterQuery = null, string? orderBy = null,bool isAsc=true,int page=1,int pageSize=1000); 
        Task<Walk> GetAsync(Guid id);
        Task<Walk> UpdateAsync(Guid id,Walk walk);
        Task<Walk?> DeleteAsync(Guid id);

    }
}
