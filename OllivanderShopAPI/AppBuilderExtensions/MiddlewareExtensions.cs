using OllivandersShopAPI.Data.Seeder;

namespace OllivandersShopAPI.AppBuilderExtensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DataSeederMiddleware>();
        }
    }
}
