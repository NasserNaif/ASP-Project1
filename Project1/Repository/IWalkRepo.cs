using Project1.Models.Domain;
using Project1.Models.DTO;

namespace Project1.Repository
{
    public interface IWalkRepo
    {
        public Task<List<Walk>> GetAll(PaginationDto paginationDto ,FilterDto? filter);
        public Task<Walk> GetWalkById(Guid id);

        public Task<Walk> Create(Walk walk);

        public Task<Walk> Update(Guid id, Walk walk);

        public Task<Walk> Delete(Guid id);
    }
}
