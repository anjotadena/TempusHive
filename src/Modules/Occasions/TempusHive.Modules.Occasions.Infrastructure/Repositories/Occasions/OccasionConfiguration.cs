using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TempusHive.Modules.Occasions.Domain.Categories;
using TempusHive.Modules.Occasions.Domain.Occasions;

namespace TempusHive.Modules.Occasions.Infrastructure.Repositories.Occasions;

internal sealed class OccasionConfiguration : IEntityTypeConfiguration<Occasion>
{
    public void Configure(EntityTypeBuilder<Occasion> builder)
    {
        builder.HasOne<Category>().WithMany();
    }
}
