using MediatR;
using TempusHive.Modules.Occasions.Application.Abstractions;
using TempusHive.Modules.Occasions.Domain.Occasions;

namespace TempusHive.Modules.Occasions.Application.Occasions.CreateOccasion;

internal sealed class CreateOccasionCommandHandler(IOccasionRepository occasionRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateOccasionCommand, Guid>
{
    public async Task<Guid> Handle(CreateOccasionCommand request, CancellationToken cancellationToken)
    {
        var occasion = Occasion.Create(
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndsAtUtc
        );

        occasionRepository.Insert(occasion);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return occasion.Id;
    }
}
