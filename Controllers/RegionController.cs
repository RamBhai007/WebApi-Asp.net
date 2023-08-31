using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using praticeAPI.Data;
using praticeAPI.Models.Domain;
using praticeAPI.Models.DTO;
using praticeAPI.Repositories;
using System.Text.Json;

namespace praticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IRegionRepo regionRepo;
        private readonly IMapper mapper;
        private readonly ILogger<RegionController> logger1;

        public RegionController(ApplicationDbContext dbContext,IRegionRepo regionRepo,IMapper mapper,ILogger<RegionController> logger1)
        {
            this.dbContext = dbContext;
            this.regionRepo = regionRepo;
            this.mapper = mapper;
            this.logger1 = logger1;
        }
        [HttpGet]
        //[Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll()
        {
            
            logger1.LogInformation("Getall was invoked");
            var regionDomian = await regionRepo.GetAllAsync();
            logger1.LogInformation($"{JsonSerializer.Serialize(regionDomian)}");
            return Ok(mapper.Map<List<RegionDTO>>(regionDomian));

        }
        [HttpGet]
        [Route("{id}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> Get(Guid id)
        {
                var regionDomian = await regionRepo.GetAsync(id);
                if (regionDomian != null)
                {
                    //var regionDTO = new RegionDTO()
                    //{
                    //    Id = regionDomian.Id,
                    //    Code = regionDomian.Code,
                    //    Name = regionDomian.Name,
                    //    ImageURL = regionDomian.ImageURL
                    //};
                    var regionDTO = mapper.Map<RegionDTO>(regionDomian);
                    return Ok(regionDTO);
                }
                return NotFound();            
        }
        [HttpPost]
        //[Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Create([FromBody] AddRegionPost addRegionPost)
        {
            //var regionDomain = new Region
            //{
            //    Code = addRegionPost.Code,
            //    Name = addRegionPost.Name,
            //    ImageURL = addRegionPost.ImageURL
            //};


            if (!ModelState.IsValid)
            {
                return BadRequest();
                
            }
            var regionDomain = mapper.Map<Region>(addRegionPost);
            await regionRepo.CreateAsync(regionDomain);
            var regionDTO = mapper.Map<RegionDTO>(regionDomain);

            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    ImageURL = regionDomain.ImageURL
            //};
            return CreatedAtAction(nameof(Get), new { id = regionDomain.Id }, regionDTO);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionPost updateRegionPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //var RegionDomain = new Region
            //{
            //    Code= updateRegionPost.Code,
            //    Name = updateRegionPost.Name,   
            //    ImageURL = updateRegionPost.ImageURL
            //};
            var regionDomain = mapper.Map<Region>(updateRegionPost);
            var RegionDomain = await regionRepo.UpdateAsync(id, regionDomain);

            if(RegionDomain == null)
            {
                return NotFound();
            }

            //var RegionDTO = new RegionDTO
            //{
            //    Id = RegionDomain.Id,
            //    Code = RegionDomain.Code,
            //    Name = RegionDomain.Name,
            //    ImageURL = RegionDomain.ImageURL
            //};
            var regionDTO = mapper.Map<RegionDTO>(regionDomain);
            return Ok(regionDTO);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await regionRepo.DeleteAsync(id);
            if (regionDomain == null)
            {
                 return NotFound();
            }
            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    ImageURL = regionDomain.ImageURL
            //};
            var regionDTO = mapper.Map<RegionDTO>(regionDomain);
            return Ok(regionDTO);
           
        }
    }
}
