using Microsoft.EntityFrameworkCore;
using praticeAPI.Data;
using praticeAPI.Models.Domain;
using praticeAPI.Models.DTO;

namespace praticeAPI.Repositories
{
    public class SQLWalkRepo : IWalkRepo
    {
        
        private readonly ApplicationDbContext dbContext;

        public SQLWalkRepo(ApplicationDbContext DbContext) {
            
            dbContext = DbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var obj = await dbContext.Walks.FindAsync(id);
            if(obj == null)
            {
                return null;
            }
            dbContext.Walks.Remove(obj);
            await dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null,string? filterQuery = null, string? orderBy = null,bool isAsc=true, int page = 1, int pageSize = 1000)
        {
            var obj = dbContext.Walks.Include("Region").Include("Difficulty").AsQueryable();
            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    obj = obj.Where(x => x.Name.Contains(filterQuery));
                    
                }
            }

            if (string.IsNullOrWhiteSpace(orderBy) == false)
            {
                if(orderBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    obj = isAsc ? obj.OrderBy(x=>x.Name): obj.OrderByDescending(x=>x.Name);
                }
                else if (orderBy.Equals("lengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    obj = isAsc ? obj.OrderBy(x => x.LengthInKM) : obj.OrderByDescending(x => x.LengthInKM);
                }

            }

            var skip = (page - 1) * pageSize;

            return await obj.Skip(skip).Take(pageSize).ToListAsync();

        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstAsync(x => x.Id == id);
            
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var walkDTO = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(walkDTO != null)
            {
                walkDTO.Name = walk.Name;
                walkDTO.Description = walk.Description;
                walkDTO.LengthInKM = walk.LengthInKM;
                walkDTO.RegionID = walk.RegionID;
                walkDTO.DifficultyID = walk.DifficultyID;
                walkDTO.WalkImageURL= walk.WalkImageURL;
                await dbContext.SaveChangesAsync();
                return walkDTO;
            }

            return null;
        }
    }
}
