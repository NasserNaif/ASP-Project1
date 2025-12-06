using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Data;
using Project1.Models.Domain;
using Project1.Models.DTO;
using Project1.Repository;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepo repo;
        private readonly IMapper mapper;

        public WalksController(IMapper mappers, IWalkRepo repo)
        {
            this.repo = repo;
            mapper = mappers;
        }

        // GET All walks
        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {
            return Ok(mapper.Map<List<WalksDto>>(await repo.GetAll()));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walk = await repo.GetWalkById(id);
            
            return Ok(mapper.Map<WalksDto>(walk));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WalksDto walksDto)
        {
            var walkDomainModel = mapper.Map<Walk>(walksDto);
            var createdWalk = await repo.Create(walkDomainModel);
            var returnedWalkDto = mapper.Map<WalksDto>(createdWalk);
            return CreatedAtAction(nameof(GetWalkById), new { id = createdWalk.Id }, returnedWalkDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] WalksDto walksDto)
        {
            var walkDomainModel = mapper.Map<Walk>(walksDto);
            var updatedWalk = await repo.Update(id, walkDomainModel);
            var returnedWalkDto = mapper.Map<WalksDto>(updatedWalk);
            return Ok(returnedWalkDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedWalk = await repo.Delete(id);
            var returnedWalkDto = mapper.Map<WalksDto>(deletedWalk);
            return Ok(returnedWalkDto);
        }
    }
}
