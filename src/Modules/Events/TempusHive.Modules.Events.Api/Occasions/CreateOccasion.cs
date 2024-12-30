using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TempusHive.Modules.Occasions.Api.Database;

namespace TempusHive.Modules.Occasions.Api.Occasions;

public static class CreateOccasion
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("occasions", async (Request request, OccasionsDbContext context) =>
        {
            var occasion = new Occasion
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                StartsAtUtc = request.StartsAtUtc,
                EndsAtUtc = request.EndsAtUtc,
                Status = OccasionStatus.Draft
            };

            context.Occasions.Add(occasion);

            await context.SaveChangesAsync();

            return Results.Ok(occasion.Id);
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
