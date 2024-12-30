using MediatR;
using TempusHive.Modules.Occasions.Application.Abstractions;
using TempusHive.Modules.Occasions.Domain.Occasions;

namespace TempusHive.Modules.Occasions.Api.Occasions;

public sealed record CreateOccasionCommand(
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : IRequest<Guid>;

internal sealed class CreateOccasionCommandHandler(IOccasionRepository occasionRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateOccasionCommand, Guid>
{

    public async Task<Guid> Handle(CreateOccasionCommand request, CancellationToken cancellationToken)
    {
        var occasion = new Occasion
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            StartsAtUtc = request.StartsAtUtc,
            EndsAtUtc = request.EndsAtUtc,
            Status = OccasionStatus.Draft
        };

        occasionRepository.Insert(occasion);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return occasion.Id;
    }
}
