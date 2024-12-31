
using TempusHive.Modules.Occasions.Domain.Abstractions;

namespace TempusHive.Modules.Occasions.Domain.Occasions;

public sealed class OccasionCancelledDomainEvent(Guid occasionId) : DomainEvent
{
    public Guid OccasionId { get; init; } = occasionId;
}
