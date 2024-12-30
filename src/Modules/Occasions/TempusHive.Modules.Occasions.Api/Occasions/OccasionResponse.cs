namespace TempusHive.Modules.Occasions.Api.Occasions;

public sealed record OccasionResponse(Guid Id, string Title, string Description, string Location, DateTime StartsAtUtc, DateTime? EndsAtUtc);
