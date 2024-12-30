namespace TempusHive.Modules.Occasions.Application.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellation = default);
}
