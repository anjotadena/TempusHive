using Microsoft.EntityFrameworkCore;
using TempusHive.Modules.Occasions.Infrastructure.Database;

namespace TempusHive.Api.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplicationMigration<OccasionsDbContext>(scope);
    }

    private static void ApplicationMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
