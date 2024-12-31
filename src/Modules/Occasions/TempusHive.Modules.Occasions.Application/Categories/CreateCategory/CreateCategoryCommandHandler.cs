using TempusHive.Modules.Occasions.Application.Abstractions;
using TempusHive.Modules.Occasions.Application.Abstractions.Messaging;
using TempusHive.Modules.Occasions.Domain.Abstractions;
using TempusHive.Modules.Occasions.Domain.Categories;

namespace TempusHive.Modules.Occasions.Application.Categories.CreateCategory;
internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name);

        categoryRepository.Insert(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
