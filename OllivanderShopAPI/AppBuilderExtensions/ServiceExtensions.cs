using OllivandersShopAPI.Data.DataAccess.Repositories;
using OllivandersShopAPI.Data.DataAccess.Repositories.Abstractions;
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

        public static IServiceCollection AddWandRepository(this IServiceCollection services)
        {
            return services.AddScoped<IWandRepository, WandRepository>();
        }
    }
}
