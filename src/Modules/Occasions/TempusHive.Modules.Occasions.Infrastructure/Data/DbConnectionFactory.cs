using System.Data.Common;
using Npgsql;
using TempusHive.Modules.Occasions.Application.Abstractions;

namespace TempusHive.Modules.Occasions.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource datasource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await datasource.OpenConnectionAsync();
    }
}
