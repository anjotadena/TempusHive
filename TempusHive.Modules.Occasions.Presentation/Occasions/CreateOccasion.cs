using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TempusHive.Modules.Occasions.Application.Occasions.CreateOccasion;

namespace TempusHive.Modules.Occasions.Presentation.Occasions;

internal static class CreateOccasion
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("occasions", async (Request request, ISender sender) =>
        {
            var command = new CreateOccasionCommand(
                request.Title,
                request.Description,
                request.Location,
                request.StartsAtUtc,
                request.EndsAtUtc
            );

            Guid occasionId = await sender.Send(command);

            return Results.Ok(occasionId);
        })
        .WithTags(Tags.Occasions);
    }

    internal sealed class Request
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartsAtUtc { get; set; }

        public DateTime? EndsAtUtc { get; set; }
    }
}
