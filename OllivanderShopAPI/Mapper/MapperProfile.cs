using OllivandersShopAPI.Mapper.Abstractions;
using OllivandersShopAPI.Models;
using OllivandersShopAPI.Models.DTO;
using Riok.Mapperly.Abstractions;

namespace OllivandersShopAPI.Mapper
{
    [Mapper]
    public partial class MapperProfile : IMapper
    {
        public partial GetWandDto MapToGetWandDto(Wand wand);
        public ICollection<GetWandDto> MapToGetWandsDto(ICollection<Wand> wands)
        {
            var wandDtos = new List<GetWandDto>();

            foreach (var wand in wands)
            {
                wandDtos.Add(MapToGetWandDto(wand));
            }

            return wandDtos;
        }
        public partial Wand MapToWand(PostWandDto wand);
        public partial Wand MapToWand(PutWandDto wand);
    }
}
