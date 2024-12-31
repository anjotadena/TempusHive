using Microsoft.EntityFrameworkCore;
using TempusHive.Modules.Occasions.Domain.Categories;
using TempusHive.Modules.Occasions.Infrastructure.Database;

namespace TempusHive.Modules.Occasions.Infrastructure.Repositories.Categories;

internal sealed class CategoryRepository(OccasionsDbContext context) : ICategoryRepository
{
    public async Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Categories.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public void Insert(Category category)
    {
        context.Categories.Add(category);
    }
}
