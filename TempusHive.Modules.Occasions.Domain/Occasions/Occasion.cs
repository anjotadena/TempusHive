namespace TempusHive.Modules.Occasions.Domain.Occasions;

public sealed class Occasion
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public DateTime StartsAtUtc { get; set; }

    public DateTime? EndsAtUtc { get; set; }

    public OccasionStatus Status { get; set; }
}
