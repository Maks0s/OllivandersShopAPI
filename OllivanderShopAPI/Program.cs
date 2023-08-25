using Microsoft.EntityFrameworkCore;
using OllivandersShopAPI.AppBuilderExtensions;
using OllivandersShopAPI.Data.DataAccess.Repositories.EfDbContext;
using Serilog;

try
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateBootstrapLogger();

    var builder = WebApplication.CreateBuilder(args);

    Log.Information("Started app building");

    builder.Host.UseSerilog((_, loggerConfig) =>
    {
        var jsonConfig = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true, reloadOnChange: true)
            .Build();

        loggerConfig
            .ReadFrom.Configuration(jsonConfig);
    });

    builder.Services.AddDbContext<OllivandersShopDbContext>(options =>
	{
		options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
	});

	builder.Services.AddControllers();
    builder.Services.AddMapperly();

	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	var app = builder.Build();

    app.UseExceptionHandler("/error");

    #region Data seeding
    //app.UseDataSeeder();
    #endregion

    if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

    app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Crushed during the building");
}
finally
{
    Log.CloseAndFlush();
}
