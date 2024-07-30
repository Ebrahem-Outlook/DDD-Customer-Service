using Customer_Service.Domain.Core.Events;

namespace Customer_Service.Domain.Core.BaseType;

/// <summary>
/// Represents an aggregate root, which is an entity that manages domain events.
/// </summary>
/// <typeparam name="TId">The type of the identifier.</typeparam>
public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot<TId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the aggregate root.</param>
    protected AggregateRoot(TId id) : base(id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class.
    /// </summary>
    protected AggregateRoot() : base() { }

    private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

    /// <summary>
    /// Gets the domain events associated with the aggregate root.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

    /// <summary>
    /// Raises a new domain event.
    /// </summary>
    /// <param name="event">The domain event to raise.</param>
    public void RaiseDomainEvent(IDomainEvent @event) => domainEvents.Add(@event);

    /// <summary>
    /// Clears all domain events.
    /// </summary>
    public void ClearDomainEvent() => domainEvents.Clear();

    /// <summary>
    /// Removes a specific domain event.
    /// </summary>
    /// <param name="event">The domain event to remove.</param>
    public void RemoveDomainEvent(IDomainEvent @event) => domainEvents.Remove(@event);
}
