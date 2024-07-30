using MediatR;

namespace Customer_Service.Domain.Core.Events;

/// <summary>
/// Defines a handler for domain events using MediatR.
/// </summary>
/// <typeparam name="TDomainEvent">The type of the domain event this handler will process.</typeparam>
public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    // This interface inherits from INotificationHandler<TDomainEvent>,
}
