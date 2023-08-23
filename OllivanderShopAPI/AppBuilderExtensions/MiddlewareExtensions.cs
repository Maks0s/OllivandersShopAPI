using OllivandersShopAPI.Data.Seeder;
using OllivandersShopAPI.Middleware;

namespace OllivandersShopAPI.AppBuilderExtensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DataSeederMiddleware>();
        }

        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionsHandlingMiddleware>();
        }
    }
}
