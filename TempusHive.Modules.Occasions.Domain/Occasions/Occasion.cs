using TempusHive.Modules.Occasions.Domain.Abstractions;

namespace TempusHive.Modules.Occasions.Domain.Occasions;

public sealed class Occasion : Entity
{
    public Occasion()
    {
    }

    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Location { get; private set; }

    public DateTime StartsAtUtc { get; private set; }

    public DateTime? EndsAtUtc { get; private set; }

    public OccasionStatus Status { get; private set; }

    public static Occasion Create(string title, string description, string location, DateTime startsAtUtc, DateTime? endsAtUtc)
    {
        var occasion = new Occasion
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Location = location,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc,
            Status = OccasionStatus.Draft
        };

        occasion.Raise(new OccasionCreatedDomainEvent(occasion.Id));

        return occasion;
    }
}
