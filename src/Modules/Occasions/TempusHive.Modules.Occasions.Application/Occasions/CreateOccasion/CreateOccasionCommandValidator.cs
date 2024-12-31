using FluentValidation;

namespace TempusHive.Modules.Occasions.Application.Occasions.CreateOccasion;

internal sealed class CreateOccasionCommandValidator : AbstractValidator<CreateOccasionCommand>
{
    public CreateOccasionCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.StartsAtUtc).NotEmpty();
        RuleFor(c => c.EndsAtUtc)
            .Must((c, endsAtUtc) => endsAtUtc > c.StartsAtUtc)
            .When(c => c.EndsAtUtc.HasValue);
    }
}
