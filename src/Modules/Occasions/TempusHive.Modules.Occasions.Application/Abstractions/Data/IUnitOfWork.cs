namespace TempusHive.Modules.Occasions.Application.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellation = default);
}
