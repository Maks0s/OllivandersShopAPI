using OllivandersShopAPI.Models;
using OllivandersShopAPI.Models.DTO;

namespace OllivandersShopAPI.Mapper.Abstractions
{
    public interface IMapper
    {
        GetWandDto MapToGetWandDto(Wand wand);
        ICollection<GetWandDto> MapToGetWandsDto(ICollection<Wand> wands);
        Wand MapToWand(PostWandDto wand);
        Wand MapToWand(PutWandDto wand);
    }
}