
using TempusHive.Modules.Occasions.Domain.Abstractions;

namespace TempusHive.Modules.Occasions.Domain.Occasions;

public sealed class OccasionRescheduledDomainEvent(Guid occasionId, DateTime startsAtUtc, DateTime? endsAtUtc) : DomainEvent
{

    public Guid OccasionId { get; } = occasionId;

    public DateTime StartsAtUtc { get; } = startsAtUtc;

    public DateTime? EndsAtUtc { get; } = endsAtUtc;
}
