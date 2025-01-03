using System.Data.Common;
using Npgsql;
using TempusHive.Common.Application.Data;

namespace TempusHive.Common.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource datasource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await datasource.OpenConnectionAsync();
    }
}
