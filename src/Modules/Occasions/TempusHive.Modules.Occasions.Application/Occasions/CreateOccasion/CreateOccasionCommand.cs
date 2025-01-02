using TempusHive.Common.Application.Messaging;

namespace TempusHive.Modules.Occasions.Application.Occasions.CreateOccasion;

public sealed record CreateOccasionCommand(
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : ICommand<Guid>;
