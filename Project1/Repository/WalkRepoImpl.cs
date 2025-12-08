using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models.Domain;
using System.Diagnostics.Eventing.Reader;
using Project1.Models.DTO;

namespace Project1.Repository
{
    public class WalkRepoImpl : IWalkRepo
    {
        private readonly Project1DbContext dbContext;

        public WalkRepoImpl(Project1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> Create(Walk walk)
        {
            var addedWalk = await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return addedWalk.Entity;
        }

        public async Task<Walk> Delete(Guid id)
        {
            var deletedWalk = await dbContext.Walks.FirstOrDefaultAsync(elm => elm.Id == id);

            if (deletedWalk == null)
                throw new KeyNotFoundException($"Walk with id {id} was not found.");

            dbContext.Walks.Remove(deletedWalk);
            await dbContext.SaveChangesAsync();
            return deletedWalk;
        }

        public async Task<List<Walk>> GetAll(PaginationDto paginationDto, FilterDto? filter)
        {
            // With Filter
            var walks =  dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();


            if (filter != null)
            {


                // Filtring
                if (!string.IsNullOrWhiteSpace(filter.FilterOn) && !string.IsNullOrWhiteSpace(filter.FilterQuery))
                {
                    if (filter.FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                        walks = walks.Where(x => x.Name.Contains(filter.FilterQuery));
                    }
                }
                
                
                // sorting 
                if (!string.IsNullOrWhiteSpace(filter.SortBy))
                {
                    if (filter.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                        walks = walks.OrderBy(x => x.Name);
                    }
                    
                    else if (filter.SortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                    {
                        walks = filter.IsAscending ?  walks.OrderBy(x => x.LengthInKm) :  walks.OrderByDescending(x => x.LengthInKm);
                    }
                        
                }

            }
            
            // apply pagination 
            int skip = (paginationDto.PageNumber - 1) * paginationDto.PageSize;

            return await walks.Skip(skip).Take(paginationDto.PageSize).ToListAsync();

            // OLD: Without Filter
            //return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetWalkById(Guid id)
        {
            var walk = await dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);

            if (walk == null)
                throw new KeyNotFoundException($"Walk with id {id} was not found.");

            return walk;
        }

        public async Task<Walk> Update(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);

            if (existingWalk == null)
                throw new KeyNotFoundException($"Walk with id {id} was not found.");


            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;


            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
