using System.Data.Common;
using Dapper;
using MediatR;
using TempusHive.Common.Application.Data;

namespace TempusHive.Modules.Occasions.Application.Occasions.GetOccasion;

internal sealed class GetOccasionQueryHandler(IDbConnectionFactory dbConnectionFactory) : IRequestHandler<GetOccasionQuery, OccasionResponse?>
{
    public async Task<OccasionResponse?> Handle(GetOccasionQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
            SELECT
                id as {nameof(OccasionResponse.Id)},
                title as {nameof(OccasionResponse.Title)},
                description as {nameof(OccasionResponse.Description)},
                location as {nameof(OccasionResponse.Location)},
                starts_at_utc as {nameof(OccasionResponse.StartsAtUtc)},
                ends_at_utc as {nameof(OccasionResponse.EndsAtUtc)}
            FROM occasions.occasions
            WHERE id = @OccasionId
            """;

        OccasionResponse occasion = await connection.QuerySingleOrDefaultAsync(sql, request);

        return occasion;
    }
}
