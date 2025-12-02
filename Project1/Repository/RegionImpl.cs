using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models.Domain;

namespace Project1.Repository
{
    public class RegionImpl : IRegionRepo
    {
        private readonly Project1DbContext _context;

        public RegionImpl(Project1DbContext context)
        {

            _context = context;
        }

        public async Task<Region> Add(Region region)
        {
            await _context.AddAsync(region);
            _context.SaveChanges();

            return region;
        }

        public async Task<Region> Delete(Guid id)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(region => region.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            _context.Regions.Remove(existingRegion);
            await _context.SaveChangesAsync();

            return existingRegion;

        }

        public async Task<List<Region>> GetAllSync()
        {
            return await _context.Regions.ToListAsync();
        }

        public Task<Region> GetRegionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> Update(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
