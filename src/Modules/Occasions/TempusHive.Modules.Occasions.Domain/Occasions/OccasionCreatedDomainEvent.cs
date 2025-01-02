using TempusHive.Common.Domain;

namespace TempusHive.Modules.Occasions.Domain.Occasions;

public sealed class OccasionCreatedDomainEvent(Guid occasionId) : DomainEvent
{
    public Guid OccasionId { get; init; } = occasionId;
}
