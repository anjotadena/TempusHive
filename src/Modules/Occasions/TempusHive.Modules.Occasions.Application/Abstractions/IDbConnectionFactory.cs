using System.Data.Common;

namespace TempusHive.Modules.Occasions.Application.Abstractions;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
