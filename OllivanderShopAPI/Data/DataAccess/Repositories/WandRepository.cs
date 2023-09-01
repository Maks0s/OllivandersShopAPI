using Azure.Core;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using OllivandersShopAPI.Data.DataAccess.Repositories.Abstractions;
using OllivandersShopAPI.Data.DataAccess.Repositories.EfDbContext;
using OllivandersShopAPI.Mapper.Abstractions;
using OllivandersShopAPI.Models;
using OllivandersShopAPI.Models.DTO;
using OllivandersShopAPI.Models.Errors;

namespace OllivandersShopAPI.Data.DataAccess.Repositories
{
    public class WandRepository : IWandRepository
    {
        private readonly OllivandersShopDbContext _dbContext;
        private readonly ILogger<WandRepository> _logger;
        private readonly IMapper _mapper;

        public WandRepository(
            OllivandersShopDbContext dbContext, 
            ILogger<WandRepository> logger,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ICollection<GetWandDto>>> GetAllWandsAsync()
        {
            _logger.LogInformation("Getting all WANDS from DB");
            var wands = await _dbContext.Wands.ToListAsync();

            if (wands.Count == 0)
            {
                var error = ShopAPIErrors.ServerSide("DB side error: DB is empty");
                _logger.LogError("{@errorName} - {@error}", nameof(ShopAPIErrors.ServerSide), error);
                return error;
            }

            _logger.LogInformation("Map to DTO");
            var dto = _mapper.MapToGetWandsDto(wands);

            return ErrorOrFactory.From(dto);
        }

        public async Task<ErrorOr<GetWandDto>> GetWandByIdAsync(int id)
        {
            _logger.LogInformation("Getting WAND from DB with id:{id}", id);
            var wand = await _dbContext.Wands.FindAsync(id);

            if (wand is null)
            {
                var error = ShopAPIErrors.NotFound($"WAND with ID:{id} not found");
                _logger.LogError("{@errorName} - {@error}", nameof(ShopAPIErrors.NotFound), error);
                return error;
            }

            _logger.LogInformation("Map to DTO");
            var dto = _mapper.MapToGetWandDto(wand);

            return dto;
        }

        public async Task<ErrorOr<Wand>> AddWandAsync(PostWandDto dto)
        {
            if (dto is null)
            {
                var error = ShopAPIErrors.IncorrectObjectSent("WAND to add is NULL");
                _logger.LogError("{@errorName} - {@error}", nameof(ShopAPIErrors.IncorrectObjectSent), error);
                return error;
            }

            _logger.LogInformation("Map from DTO");
            var wandToAdd = _mapper.MapToWand(dto);

            _logger.LogInformation("Adding WAND {@dto}", dto);
            await _dbContext.AddAsync(wandToAdd);
            await _dbContext.SaveChangesAsync();

            return wandToAdd;
        }

        public async Task<ErrorOr<Updated>> UpdateWandAsync(int id, PutWandDto dto)
        {
            var wandToUpdate = await _dbContext.Wands.FindAsync(id);

            if (wandToUpdate is null)
            {
                var error = ShopAPIErrors.NotFound($"WAND with ID:{id} not found");
                _logger.LogError("{@errorName} - {@error}", nameof(ShopAPIErrors.NotFound), error);
                return error;
            }
            if (dto is null)
            {
                var error = ShopAPIErrors.IncorrectObjectSent("WAND to add is NULL");
                _logger.LogError("{@errorName} - {@error}", nameof(ShopAPIErrors.IncorrectObjectSent), error);
                return error;
            }

            _logger.LogInformation("Map from DTO");
            _mapper.MapToWandToUpdate(dto, wandToUpdate);
            var responseDto = _mapper.MapToGetWandDto(wandToUpdate);

            _logger.LogInformation("Updating WAND {@responseDto}", responseDto);
            _dbContext.Wands.Update(wandToUpdate);
            await _dbContext.SaveChangesAsync();

            return Result.Updated;
        }

        public async Task<ErrorOr<Deleted>> DeleteWandAsync(int id)
        {
            var wandToDelete = await _dbContext.Wands.FindAsync(id);

            if (wandToDelete is null)
            {
                var error = ShopAPIErrors.IncorrectObjectSent("WAND to add is NULL");
                _logger.LogError("{@errorName} - {@error}", nameof(ShopAPIErrors.NotFound), error);
                return error;
            }

            var responseDto = _mapper.MapToGetWandDto(wandToDelete);

            _logger.LogInformation("Deleting WAND {@responseDto}", responseDto);
            _dbContext.Wands.Remove(wandToDelete);
            await _dbContext.SaveChangesAsync();

            return Result.Deleted;
        }
    }
}
