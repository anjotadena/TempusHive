using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TempusHive.Modules.Occasions.Api.Database;
using TempusHive.Modules.Occasions.Api.Occasions;

namespace TempusHive.Modules.Occasions.Api;

public static class OccasionsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateOccasion.MapEndpoint(app);
        GetOccasion.MapEndpoint(app);
    }

    public static IServiceCollection AddOccasionsModule(this IServiceCollection services, IConfiguration configuration)
    {
        string dbConnectionString = configuration.GetConnectionString("Database");

        if (string.IsNullOrEmpty(dbConnectionString))
        {
            throw new InvalidOperationException("The connection string 'Database' was not found or is empty.");
        }

        services.AddDbContext<OccasionsDbContext>(options => options
            .UseNpgsql(
                dbConnectionString,
                ngpsqlOptions => ngpsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Occasions)
            )
            .UseSnakeCaseNamingConvention());

        return services;
    }
}
