using Microsoft.EntityFrameworkCore;
using TempusHive.Modules.Occasions.Application.Abstractions;
using TempusHive.Modules.Occasions.Domain.Categories;
using TempusHive.Modules.Occasions.Domain.Occasions;
using TempusHive.Modules.Occasions.Infrastructure.Repositories.Categories;
using TempusHive.Modules.Occasions.Infrastructure.Repositories.Occasions;

namespace TempusHive.Modules.Occasions.Infrastructure.Database;

public sealed class OccasionsDbContext(DbContextOptions<OccasionsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Occasion> Occasions { get; set; }
    
    internal DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Occasions);

        modelBuilder.ApplyConfiguration(new OccasionConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}
