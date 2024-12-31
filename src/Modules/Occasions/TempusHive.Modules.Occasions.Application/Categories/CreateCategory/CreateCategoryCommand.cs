using TempusHive.Modules.Occasions.Application.Abstractions.Messaging;

namespace TempusHive.Modules.Occasions.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : ICommand<Guid>;
