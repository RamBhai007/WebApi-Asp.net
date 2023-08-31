using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using praticeAPI.Data;
using praticeAPI.Models.Domain;
namespace praticeAPI.Repositories
{
    public class SQLRegionRepo : IRegionRepo
    {
        private readonly ApplicationDbContext dbContext;
        public SQLRegionRepo(ApplicationDbContext dbContext )
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
        public async Task<Region?> GetAsync(Guid id)
        {
            return await dbContext.Regions.FindAsync(id);
        }
        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var obj =await dbContext.Regions.FindAsync(id);
            if(obj != null)
            {
                obj.Code = region.Code;
                obj.Name = region.Name;
                obj.ImageURL = region.ImageURL;

                await dbContext.SaveChangesAsync();
                return obj;
            }
            return null;
        }
        public async Task<Region> DeleteAsync(Guid id)
        {   
            var obj = await dbContext.Regions.FindAsync(id);
            if(obj != null )
            {
                dbContext.Regions.Remove(obj);
                await dbContext.SaveChangesAsync();
                return obj;
            }
            return null;
            
        }
    }
}