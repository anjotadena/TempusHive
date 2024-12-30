namespace TempusHive.Modules.Occasions.Application.Occasions.GetOccasion;

public sealed record OccasionResponse(Guid Id, string Title, string Description, string Location, DateTime StartsAtUtc, DateTime? EndsAtUtc);
