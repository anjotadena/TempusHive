using MediatR;

namespace TempusHive.Modules.Occasions.Application.Occasions.CreateOccasion;

public sealed record CreateOccasionCommand(
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : IRequest<Guid>;
