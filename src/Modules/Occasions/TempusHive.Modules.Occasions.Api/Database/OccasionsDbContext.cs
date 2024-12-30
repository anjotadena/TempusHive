using Microsoft.EntityFrameworkCore;
using TempusHive.Modules.Occasions.Api.Occasions;

namespace TempusHive.Modules.Occasions.Api.Database;

public sealed class OccasionsDbContext(DbContextOptions<OccasionsDbContext> options) : DbContext(options)
{
    internal DbSet<Occasion> Occasions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Occasions);
    }
}
