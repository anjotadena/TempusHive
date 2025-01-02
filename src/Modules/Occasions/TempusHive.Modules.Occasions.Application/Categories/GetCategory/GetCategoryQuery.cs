using TempusHive.Common.Application.Messaging;

namespace TempusHive.Modules.Occasions.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
