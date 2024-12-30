using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TempusHive.Modules.Occasions.Api.Database;

namespace TempusHive.Modules.Occasions.Api.Occasions;

public static class GetOccasion
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("occasions/{id}", async (Guid id, OccasionsDbContext context) =>
        {
            OccasionResponse? occasion = await context.Occasions
                .Where(o => o.Id == id)
                .Select(e => new OccasionResponse(
                    e.Id,
                    e.Title,
                    e.Description,
                    e.Location,
                    e.StartsAtUtc,
                    e.EndsAtUtc
                ))
                .SingleOrDefaultAsync();

            return occasion is null ? Results.NotFound() : Results.Ok(occasion);
        })
        .WithTags(Tags.Occasions);
    }
}
