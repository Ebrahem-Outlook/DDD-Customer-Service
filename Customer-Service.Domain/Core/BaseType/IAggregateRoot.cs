using Customer_Service.Domain.Core.Events;

namespace Customer_Service.Domain.Core.BaseType;

/// <summary>
/// Defines the contract for an aggregate root that manages domain events.
/// </summary>
/// <typeparam name="TId">The type of the identifier.</typeparam>
public interface IAggregateRoot<TId>
{
    /// <summary>
    /// Gets the domain events associated with the aggregate root.
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Raises a new domain event.
    /// </summary>
    /// <param name="event">The domain event to raise.</param>
    void RaiseDomainEvent(IDomainEvent @event);

    /// <summary>
    /// Clears all domain events.
    /// </summary>
    void ClearDomainEvent();

    /// <summary>
    /// Removes a specific domain event.
    /// </summary>
    /// <param name="event">The domain event to remove.</param>
    void RemoveDomainEvent(IDomainEvent @event);
}
