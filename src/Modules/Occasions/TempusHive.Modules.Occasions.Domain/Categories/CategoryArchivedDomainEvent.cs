
using TempusHive.Common.Domain;

namespace TempusHive.Modules.Occasions.Domain.Categories;

public sealed class CategoryArchivedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
