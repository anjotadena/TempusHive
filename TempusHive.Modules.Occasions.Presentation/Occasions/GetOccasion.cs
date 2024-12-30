using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TempusHive.Modules.Occasions.Api;
using TempusHive.Modules.Occasions.Api.Occasions;

namespace TempusHive.Modules.Occasions.Presentation.Occasions;

internal static class GetOccasion
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("occasions/{id}", async (Guid id, ISender sender) =>
        {
            OccasionResponse occasion = await sender.Send(new GetOccasionQuery(id));

            return occasion is null ? Results.NotFound() : Results.Ok(occasion);
        })
        .WithTags(Tags.Occasions);
    }
}
