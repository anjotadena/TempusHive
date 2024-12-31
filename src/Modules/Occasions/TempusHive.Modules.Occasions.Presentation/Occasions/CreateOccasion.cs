using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TempusHive.Modules.Occasions.Application.Occasions.CreateOccasion;
using TempusHive.Modules.Occasions.Domain.Abstractions;
using TempusHive.Modules.Occasions.Presentation.ApiResource;

namespace TempusHive.Modules.Occasions.Presentation.Occasions;

internal static class CreateOccasion
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("occasions", async (Request request, ISender sender) =>
        {
            var command = new CreateOccasionCommand(
                request.CategoryId,
                request.Title,
                request.Description,
                request.Location,
                request.StartsAtUtc,
                request.EndsAtUtc
            );

            Result<Guid> result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Occasions);
    }

    internal sealed class Request
    {
        public Guid CategoryId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartsAtUtc { get; set; }

        public DateTime? EndsAtUtc { get; set; }
    }
}
