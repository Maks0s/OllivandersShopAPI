using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OllivandersShopAPI.Data.DataAccess.Repositories;
using OllivandersShopAPI.Data.DataAccess.Repositories.Abstractions;
using OllivandersShopAPI.Errors;
using OllivandersShopAPI.Mapper.Abstractions;
using OllivandersShopAPI.Models.DTO;
using System.Net;

namespace OllivandersShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WandsController : ControllerBase
    {
        private readonly ILogger<WandsController> _logger;
        private readonly IWandRepository _wandRepository;
        private readonly IMapper _mapper;

        public WandsController(ILogger<WandsController> logger,
            IWandRepository wandRepository,
            IMapper mapper)
        {
            _logger = logger;
            _wandRepository = wandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetWandDto>>> GetAllWands()
        {
            _logger.LogInformation("Getting all WANDS from DB");
            var wands = await _dbContext.Wands.ToListAsync();

            if(wands.Count == 0)
            {
                throw new ServerSideException("DB side error: DB is empty", Request.Path.Value);
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
                throw new NotFoundException($"WAND with ID:{id} not found", Request.Path.Value);
            }

            _logger.LogInformation("Map to DTO");
            var dto = _mapper.MapToGetWandDto(wand);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> PostWand([FromBody] PostWandDto dto)
        {
            var postResult = await _wandRepository.AddWandAsync(dto);

            return postResult.MatchFirst<ActionResult>(
                posted => CreatedAtAction(nameof(GetWandById), new { id = posted }, responseDto);
        });




                //CreatedAtAction(nameof(GetWandById), new { id = wandToAdd.Id}, responseDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> PutWand(int id, [FromBody] PutWandDto dto)
        {
            var updateResult = await _wandRepository.UpdateWandAsync(id, dto);

            return updateResult.MatchFirst<ActionResult>(
                deleted => NoContent(),
                error => Problem(
                    title: error.Code,
                    detail: error.Description,
                    statusCode: error.NumericType)
                );
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteWand(int id)
        {
            var deleteResult = await _wandRepository.DeleteWandAsync(id);

            return deleteResult.MatchFirst<ActionResult>(
                deleted => NoContent(),
                error => Problem(
                    title: error.Code,
                    detail: error.Description,
                    statusCode: error.NumericType)
                );
        }
    }
}
