using OllivandersShopAPI.Mapper.Abstractions;
using OllivandersShopAPI.Models;
using OllivandersShopAPI.Models.DTO;
using Riok.Mapperly.Abstractions;

namespace OllivandersShopAPI.Mapper
{
    [Mapper(AllowNullPropertyAssignment = false)]
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
        public partial Wand MapToWand(PostWandDto wandDto);
        public partial void MapToWandToUpdate(PutWandDto wandDto, Wand wand);
    }
}
