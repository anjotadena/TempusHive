﻿using FluentValidation;

namespace TempusHive.Modules.Occasions.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}