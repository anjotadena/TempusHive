using Microsoft.AspNetCore.Routing;

namespace TempusHive.Modules.Occasions.Presentation.Categories;

public static class CategoryEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateCategory.MapEndpoint(app);
    }
}
