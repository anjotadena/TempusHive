using Microsoft.EntityFrameworkCore;
using TempusHive.Modules.Occasions.Application.Abstractions;
using TempusHive.Modules.Occasions.Domain.Occasions;

namespace TempusHive.Modules.Occasions.Infrastructure.Database;

public sealed class OccasionsDbContext(DbContextOptions<OccasionsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Occasion> Occasions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Occasions);
    }
}
