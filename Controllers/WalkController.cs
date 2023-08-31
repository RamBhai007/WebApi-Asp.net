using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using praticeAPI.Models.Domain;
using praticeAPI.Models.DTO;
using praticeAPI.Repositories;

namespace praticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WalkController : ControllerBase
    {
        private readonly IMapper mapper;

        public WalkController(IMapper mapper, IWalkRepo walkRepo)
        {
            this.mapper = mapper;
            WalkRepo = walkRepo;
        }

        public IWalkRepo WalkRepo { get; }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkPost addWalkPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var walkDomain = mapper.Map<Walk>(addWalkPost);
            await WalkRepo.CreateAsync(walkDomain);
            return Ok(mapper.Map<WalkDTO>(walkDomain));
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? orderBy, [FromQuery] bool? isAsc, [FromQuery] int? page= 1,int? pageSize = 100 )
        {
            var walkDomain = await WalkRepo.GetAllAsync(filterOn, filterQuery, orderBy, isAsc ?? true,page?? 1,pageSize?? 100);

            var walkDTO = mapper.Map<List<WalkDTO>>(walkDomain);
            return Ok(walkDTO.ToList());
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var walkDomain = await WalkRepo.GetAsync(id);
            if (walkDomain != null)
            {
                var walkDTO = mapper.Map<WalkDTO>(walkDomain);
                return Ok(walkDTO);
            }
            return NotFound();

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkPost updateWalkPost)
        {
            var walkDomain = mapper.Map<Walk>(updateWalkPost);

            walkDomain = await WalkRepo.UpdateAsync(id, walkDomain);

            if (walkDomain != null)
            {
                var walkDTO = mapper.Map<WalkDTO>(walkDomain);
                return Ok(walkDTO);
            }
            return NotFound();

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walkDomain = await WalkRepo.DeleteAsync(id);
            if (walkDomain != null)
            {
                return Ok(mapper.Map<WalkDTO>(walkDomain));
            }
            return NotFound();
        }
    }
}
