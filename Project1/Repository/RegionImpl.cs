using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Mappings;
using Project1.Models.Domain;

namespace Project1.Repository
{
    public class RegionImpl : IRegionRepo
    {
        private readonly Project1DbContext _context;
        private readonly AutoMapperprofiles mapper;

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

        public async Task<Region> GetRegionById(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(elm => elm.Id == id);

            if (region == null)
            {
                return null;
            }

            return region;
        }

        public async Task<Region> Update(Guid id, Region region)
        {
            var exisitRegion = await _context.Regions.FirstOrDefaultAsync(elm => elm.Id == id);


            if (exisitRegion == null)
            {
                return null;
            }

            exisitRegion.Name = region.Name;
            exisitRegion.Code = region.Code;
            exisitRegion.RegionImageUrl = region.RegionImageUrl;

            await _context.SaveChangesAsync();

            return exisitRegion;

        }
    }
}
