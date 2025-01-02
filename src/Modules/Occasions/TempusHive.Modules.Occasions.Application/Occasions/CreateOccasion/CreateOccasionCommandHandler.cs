using TempusHive.Common.Application.Clock;
using TempusHive.Common.Application.Messaging;
using TempusHive.Common.Domain;
using TempusHive.Modules.Occasions.Application.Abstractions.Data;
using TempusHive.Modules.Occasions.Domain.Categories;
using TempusHive.Modules.Occasions.Domain.Occasions;

namespace TempusHive.Modules.Occasions.Application.Occasions.CreateOccasion;

internal sealed class CreateOccasionCommandHandler(
    IDateTimeProvider dateTimeProvider,
    ICategoryRepository categoryRepository,
    IOccasionRepository occasionRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateOccasionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateOccasionCommand request, CancellationToken cancellationToken)
    {
        if (request.StartsAtUtc < dateTimeProvider.UtcNow)
        {
            return Result.Failure<Guid>(OccasionErrors.StartDateInPast);
        }

        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Failure<Guid>(CategoryErrors.NotFound(request.CategoryId));
        }

        Result<Occasion> result = Occasion.Create(
            category,
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndsAtUtc
        );

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        occasionRepository.Insert(result.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}
