using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using TempusHive.Common.Application.Clock;
using TempusHive.Common.Application.Data;
using TempusHive.Common.Infrastructure.Clock;
using TempusHive.Common.Infrastructure.Data;

namespace TempusHive.Common.Infrastructure;

public static class InfrastractureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbConnectionString)
    {
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(dbConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
