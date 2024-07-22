using Customer_Service.Domain.Core.Events;

namespace Customer_Service.Domain.Core.BaseType;

public abstract class AggregateRoot<TId> : Entity<TId>
{
    protected AggregateRoot(TId id) : base(id) { }

    protected AggregateRoot() : base() { }

    private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

    public IReadOnlyCollection<>
}
