using OllivandersShopAPI.Mapper;
using OllivandersShopAPI.Mapper.Abstractions;

namespace OllivandersShopAPI.AppBuilderExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMapperly(this IServiceCollection services)
        {
            return services.AddSingleton<IMapper, MapperProfile>();
        }
    }
}
