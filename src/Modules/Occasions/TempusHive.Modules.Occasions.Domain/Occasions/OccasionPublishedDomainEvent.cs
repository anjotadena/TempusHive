using TempusHive.Modules.Occasions.Domain.Abstractions;

namespace TempusHive.Modules.Occasions.Domain.Occasions;

public sealed class OccasionPublishedDomainEvent(Guid occasionId) : DomainEvent
{
    public Guid OccasionsId { get; init; } = occasionId;
}
