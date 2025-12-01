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
        public async Task<List<Region>> GetAllSync()
        {
            return await _context.Regions.ToListAsync();
        }
    }
}
