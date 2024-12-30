using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using TempusHive.Modules.Occasions.Application.Abstractions;
using TempusHive.Modules.Occasions.Domain.Occasions;
using TempusHive.Modules.Occasions.Infrastructure.Data;
using TempusHive.Modules.Occasions.Infrastructure.Database;
using TempusHive.Modules.Occasions.Infrastructure.Occasions;
using TempusHive.Modules.Occasions.Presentation.Occasions;

namespace TempusHive.Modules.Occasions.Infrastructure;

public static class OccasionsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        OccasionEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddOccasionsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
        });

        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

        services.AddInfrastructure(configuration);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        string dbConnectionString = configuration.GetConnectionString("Database");

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(dbConnectionString).Build();

        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.AddDbContext<OccasionsDbContext>(options => options
            .UseNpgsql(
                dbConnectionString,
                ngpsqlOptions => ngpsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Occasions)
            )
            .UseSnakeCaseNamingConvention());

        services.AddScoped<IOccasionRepository, OccasionRepository>();

        services.AddScoped<IUnitOfWork>(s => s.GetRequiredService<OccasionsDbContext>());
    }
}
