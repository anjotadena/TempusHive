using TempusHive.Modules.Occasions.Domain.Abstractions;

namespace TempusHive.Modules.Occasions.Domain.Categories;

public sealed class CategoryCreatedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
