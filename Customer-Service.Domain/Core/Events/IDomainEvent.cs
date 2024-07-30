using MediatR;

namespace Customer_Service.Domain.Core.Events;

/// <summary>
/// Represents a domain event that is used for communication with MediatR.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the unique identifier of the domain event.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Gets the timestamp when the domain event was created.
    /// </summary>
    DateTime CreatedOn { get; }

    /// <summary>
    /// Gets the type of the domain event.
    /// </summary>
    string EventType { get; }

    /// <summary>
    /// Gets the version of the domain event schema.
    /// </summary>
    int Version { get; }

    /// <summary>
    /// Gets additional metadata associated with the domain event.
    /// </summary>
    IDictionary<string, object> Metadata { get; }
}
