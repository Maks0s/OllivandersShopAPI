using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OllivandersShopAPI.Data;
using OllivandersShopAPI.Mapper.Abstractions;
using OllivandersShopAPI.Models;
using OllivandersShopAPI.Models.DTO;
using System.Net;

namespace OllivandersShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WandsController : ControllerBase
    {
        private readonly ILogger<WandsController> _logger;
        private readonly OllivandersShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public WandsController(ILogger<WandsController> logger, 
            OllivandersShopDbContext dbContext,
            IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetWandDto>>> GetAllWands()
        {
            _logger.LogInformation("Getting all WANDS from DB");
            var wands = await _dbContext.Wands.ToListAsync();

            if(wands.Count == 0)
            {
                _logger.LogError("DB side error: DB is empty");

                return Problem(title: "DB side error", detail: "DB is empty", statusCode: 500);
            }

            _logger.LogInformation("Map to DTO");
            var dto = _mapper.MapToGetWandsDto(wands);

            return Ok(dto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetWandDto>> GetWandById(int id)
        {
            _logger.LogInformation("Getting WAND from DB with id:{id}", id);
            var wand = await _dbContext.Wands.FindAsync(id);

            if(wand is null)
            {
                _logger.LogWarning("WAND with ID:{id} not found", id);
                return NotFound($"WAND with ID:{id} not found");
            }

            _logger.LogInformation("Map to DTO");
            var dto = _mapper.MapToGetWandDto(wand);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> PostWand([FromBody] PostWandDto dto)
        {
            if(dto is null)
            {
                _logger.LogWarning("Sent WAND is NULL");
                return BadRequest("WAND to add is NULL");
            }

            _logger.LogInformation("Map from DTO");
            var wandToAdd = _mapper.MapToWand(dto);

            _logger.LogInformation("Adding WAND {@dto}", dto);
            await _dbContext.AddAsync(wandToAdd);
            await _dbContext.SaveChangesAsync();

            var responseDto = _mapper.MapToGetWandDto(wandToAdd);

            return CreatedAtAction(nameof(GetWandById), new { id = wandToAdd.Id}, responseDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> PutWand(int id, [FromBody] PutWandDto dto)
        {
            var wandToUpdate = await _dbContext.Wands.FindAsync(id);

            if(wandToUpdate is null)
            {
                _logger.LogWarning("WAND with ID:{id} not found", id);
                return NotFound($"WAND with ID:{id} not found");
            }
            if (dto is null)
            {
                _logger.LogWarning("Sent WAND is NULL");
                return BadRequest("WAND to update is NULL");
            }

            _logger.LogInformation("Map from DTO");
            _mapper.MapToWandToUpdate(dto, wandToUpdate);
            var responseDto = _mapper.MapToGetWandDto(wandToUpdate);

            _logger.LogInformation("Updating WAND {@responseDto}", responseDto);
            _dbContext.Wands.Update(wandToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteWand(int id)
        {
            var wandToDelete = await _dbContext.Wands.FindAsync(id);

            if (wandToDelete is null)
            {
                _logger.LogWarning("WAND with ID:{id} not found", id);
                return NotFound($"WAND with ID:{id} not found");
            }

            var responseDto = _mapper.MapToGetWandDto(wandToDelete);

            _logger.LogInformation("Deleting WAND {@responseDto}", responseDto);
            _dbContext.Wands.Remove(wandToDelete);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
