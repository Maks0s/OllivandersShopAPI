using ErrorOr;
using OllivandersShopAPI.Models.DTO;

namespace OllivandersShopAPI.Data.DataAccess.Repositories.Abstractions
{
    public interface IWandRepository
    {
        public Task<ErrorOr<ICollection<GetWandDto>>> GetAllWandsAsync();
        public Task<ErrorOr<GetWandDto>> GetWandByIdAsync(int id);
        public Task<ErrorOr<GetWandDto>> AddWandAsync(PostWandDto dto);
        public Task<ErrorOr<Updated>> UpdateWandAsync(int id, PutWandDto dto);
        public Task<ErrorOr<Deleted>> DeleteWandAsync(int id);
    }
}
