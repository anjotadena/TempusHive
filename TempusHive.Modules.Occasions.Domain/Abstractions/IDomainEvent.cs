namespace TempusHive.Modules.Occasions.Domain.Abstractions;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime OccuredOnUtc { get; }
}
