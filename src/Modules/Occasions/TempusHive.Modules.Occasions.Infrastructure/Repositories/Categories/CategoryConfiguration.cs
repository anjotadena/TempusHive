using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TempusHive.Modules.Occasions.Domain.Categories;

namespace TempusHive.Modules.Occasions.Infrastructure.Repositories.Categories;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Configure entity here...
    }
}
