using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project1.Models.Domain;
using Project1.Models.DTO;
using Project1.Repository;

namespace Project1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WalksController : ControllerBase
{
    private readonly ILogger<WalksController> logger;
    private readonly IMapper mapper;
    private readonly IWalkRepo repo;

    public WalksController(IMapper mappers, IWalkRepo repo, ILogger<WalksController> logger)
    {
        this.repo = repo;
        this.logger = logger;
        mapper = mappers;
    }

    // GET All walks
    [HttpGet]
    // role
    // [Authorize(Roles = "Writer")]
    // Apply filter on Name filed
    public async Task<IActionResult> GetWalks([FromQuery] PaginationDto pagination, [FromQuery] FilterDto? filter)
    {
        // Apply the logs on the API

        logger.LogInformation("Get Walks API Called");
        var walks = await repo.GetAll(pagination, filter);

        logger.LogInformation("Get Walks API Finished Successfully");
        logger.LogInformation($"Walks Data: {JsonSerializer.Serialize(walks)}");

        return Ok(mapper.Map<List<WalksDto>>(walks));
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