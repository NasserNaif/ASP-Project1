using Microsoft.AspNetCore.Mvc;
using Project1.Models.Domain;

namespace Project1.Repository
{
    public interface IRegionRepo
    {
        public Task<List<Region>> GetAllSync();
        public Task<Region> GetRegionById(Guid id);

        public Task<Region> Add(Region region);

        public Task<Region> Update(Guid id,Region region);

        public Task<Region> Delete(Guid id);

    }
}
