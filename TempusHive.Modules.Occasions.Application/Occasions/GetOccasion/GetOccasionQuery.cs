using MediatR;

namespace TempusHive.Modules.Occasions.Application.Occasions.GetOccasion;

public sealed record GetOccasionQuery(Guid OccasionId) : IRequest<OccasionResponse?>;
