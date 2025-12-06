using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.CustomActionFilter;
using Project1.Data;
using Project1.Models.Domain;
using Project1.Models.DTO;
using Project1.Repository;
using System.Drawing.Drawing2D;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly Project1DbContext _context;
        private readonly IRegionRepo _regionRepo;
        private readonly IMapper mapper;

        public RegionsController(Project1DbContext context, IRegionRepo regionRepo, IMapper mappers)
        {

            _context = context;
            _regionRepo = regionRepo;
            mapper = mappers;
        }
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await _regionRepo.GetAllSync();

            // mapp Models ==> DTOs
            return Ok(value: mapper.Map<List<RegionData>>(regions));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRegionById(Guid id)
        {
            // 1- Use Fine Method
            //var regions = this._context.Regions.Find(id);

            // 2- Use FirstOrDefault Method ( Linq )
            var regions = this._context.Regions.FirstOrDefault(r => r.Id == id);

            return regions != null ? Ok(regions) : NotFound();
        }


        // Add New region
        [HttpPost]
        public IActionResult Add([FromBody] RegionDto regionDto)
        {
            var RegionDomainModel = mapper.Map<Region>(regionDto);

            _context.Regions.Add(RegionDomainModel);
            _context.SaveChanges();

            var returnedRegionDto = mapper.Map<RegionDto>(regionDto);
            return CreatedAtAction(nameof(GetRegionById), new { id = RegionDomainModel.Id }, returnedRegionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] RegionDto regionDto)
        {
            var existingRegion = _context.Regions.Find(id);

            if (existingRegion == null)
            {
                return NotFound();
            }

            existingRegion.Code = regionDto.Code;
            existingRegion.Name = regionDto.Name;
            existingRegion.RegionImageUrl = regionDto.RegionImageUrl;
            _context.SaveChanges();

            var returnedRegionDto = new RegionDto
            {
                Id = existingRegion.Id,
                Code = existingRegion.Code,
                Name = existingRegion.Name,
                RegionImageUrl = existingRegion.RegionImageUrl
            };

            return Ok(returnedRegionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            var existingRegion = _context.Regions.Find(id);
            if (existingRegion == null)
            {
                return NotFound();
            }
            _context.Regions.Remove(existingRegion);
            _context.SaveChanges();
            return NoContent();
        }











        // Async Version
        [HttpGet]
        [Route("{id:guid}/async")]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            // 1- Use Fine Method
            //var regions = this._context.Regions.Find(id);

            // 2- Use FirstOrDefault Method ( Linq )
            var regions = await _regionRepo.GetRegionById(id);

            return regions != null ? Ok(regions) : NotFound();
        }


        // Add New region
        [HttpPost]
        [Route("async")]
        [ValidateModel]
        public async Task<IActionResult> AddAsync([FromBody] RegionDto regionDto)
        {
            // We use it if we don't use ValidateModel Action Filter

            //if(ModelState.IsValid == false)
            //{
            //    return BadRequest(ModelState);
            //}

            var RegionDomainModel = mapper.Map<Region>(regionDto);

            var addedRegion = await _regionRepo.Add(RegionDomainModel);

            var returnedRegionDto = mapper.Map<RegionDto>(addedRegion);
            return CreatedAtAction(nameof(GetRegionById), new { id = addedRegion.Id }, returnedRegionDto);
        }

        [HttpPut]
        [Route("{id:guid}/async")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] RegionDto regionDto)
        {
            var region = new Region
            {
                Code = regionDto.Code,
                Name = regionDto.Name,
                RegionImageUrl = regionDto.RegionImageUrl
            };
            var existingRegion = await _regionRepo.Update(id, region);

            if (existingRegion == null)
            {
                return NotFound();
            }

            var returnedRegionDto = new RegionDto
            {
                Id = existingRegion.Id,
                Code = existingRegion.Code,
                Name = existingRegion.Name,
                RegionImageUrl = existingRegion.RegionImageUrl
            };

            return Ok(returnedRegionDto);
        }

        [HttpDelete]
        [Route("{id:guid}/async")]
        public async Task<IActionResult> DeleteRegionAsync([FromRoute] Guid id)
        {
            var existingRegion = await _regionRepo.Delete(id);
            if (existingRegion == null)
            {
                return NotFound();
            }
             
            return NoContent();
        }
    }
}
