using TempusHive.Modules.Occasions.Domain.Abstractions;
using TempusHive.Modules.Occasions.Domain.Categories;

namespace TempusHive.Modules.Occasions.Domain.Occasions;

public sealed class Occasion : Entity
{
    public Occasion()
    {
    }

    public Guid Id { get; private set; }

    public Guid CategoryId { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Location { get; private set; }

    public DateTime StartsAtUtc { get; private set; }

    public DateTime? EndsAtUtc { get; private set; }

    public OccasionStatus Status { get; private set; }

    public static Result<Occasion> Create(
        Category category,
        string title,
        string description,
        string location,
        DateTime startsAtUtc,
        DateTime? endsAtUtc)
    {
        if (endsAtUtc.HasValue && endsAtUtc < startsAtUtc)
        {
            return Result.Failure<Occasion>(OccasionErrors.EndDatePrecedesStartDate);
        }

        var occasion = new Occasion
        {
            Id = Guid.NewGuid(),
            CategoryId = category.Id,
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

    public Result Publish()
    {
        if (Status != OccasionStatus.Draft)
        {
            return Result.Failure(OccasionErrors.NotDraft);
        }

        Status = OccasionStatus.Published;

        Raise(new OccasionPublishedDomainEvent(Id));

        return Result.Success();
    }

    public void Reschedule(DateTime startsAtUtc, DateTime? endsAtUtc)
    {
        if (StartsAtUtc == startsAtUtc && EndsAtUtc == endsAtUtc)
        {
            return;
        }

        StartsAtUtc = startsAtUtc;
        EndsAtUtc = endsAtUtc;

        Raise(new OccasionRescheduledDomainEvent(Id, StartsAtUtc, EndsAtUtc));
    }

    public Result Cancel(DateTime utcNow)
    {
        if (Status == OccasionStatus.Cancelled)
        {
            return Result.Failure(OccasionErrors.AlreadyCanceled);
        }

        if (StartsAtUtc < utcNow)
        {
            return Result.Failure(OccasionErrors.AlreadyStarted);
        }

        Status = OccasionStatus.Cancelled;

        Raise(new OccasionCancelledDomainEvent(Id));

        return Result.Success();
    }
}
