using Microsoft.AspNetCore.Routing;

namespace TempusHive.Modules.Occasions.Presentation.Occasions;

public static class OccasionEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateOccasion.MapEndpoint(app);
        GetOccasion.MapEndpoint(app);
    }
}
