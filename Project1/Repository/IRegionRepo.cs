using Project1.Models.Domain;

namespace Project1.Repository
{
    public interface IRegionRepo
    {
        public Task<List<Region>> GetAllSync();
    }
}
