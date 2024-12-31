using TempusHive.Modules.Events.Application.Abstractions.Messaging;

namespace TempusHive.Modules.Occasions.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
