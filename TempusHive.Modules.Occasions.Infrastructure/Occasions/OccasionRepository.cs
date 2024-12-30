using TempusHive.Modules.Occasions.Domain.Occasions;
using TempusHive.Modules.Occasions.Infrastructure.Database;

namespace TempusHive.Modules.Occasions.Infrastructure.Occasions;
internal sealed class OccasionRepository(OccasionsDbContext context) : IOccasionRepository
{
    public void Insert(Occasion occasion)
    {
        context.Occasions.Add(occasion);
    }
}
