namespace Customer_Service.Domain.Core.Events;

/// <summary>
/// Represents a domain event with a unique identifier, creation timestamp, event type, version, and metadata.
/// </summary>
public abstract record DomainEvent : IDomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class with default values.
    /// </summary>
    public DomainEvent()
        : this(Guid.NewGuid(), DateTime.UtcNow, "UnknownEventType", 1, [])
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class with specified values.
    /// </summary>
    /// <param name="id">The unique identifier of the event.</param>
    /// <param name="createdOn">The timestamp when the event was created.</param>
    /// <param name="eventType">The type of the event.</param>
    /// <param name="version">The version of the event schema.</param>
    /// <param name="metadata">Additional metadata associated with the event.</param>
    public DomainEvent(Guid id, DateTime createdOn, string eventType, int version, Dictionary<string, object> metadata)
    {
        Id = id;
        CreatedOn = createdOn;
        EventType = eventType;
        Version = version;
        Metadata = metadata ?? [];
    }

    /// <summary>
    /// Gets the unique identifier of the domain event.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the timestamp when the domain event was created.
    /// </summary>
    public DateTime CreatedOn { get; init; }

    /// <summary>
    /// Gets the type of the domain event.
    /// </summary>
    public string EventType { get; init; }

    /// <summary>
    /// Gets the version of the domain event schema.
    /// </summary>
    public int Version { get; init; }

    /// <summary>
    /// Gets additional metadata associated with the domain event.
    /// </summary>
    public IDictionary<string, object> Metadata { get; init; }

    /// <summary>
    /// Returns a string representation of the domain event.
    /// </summary>
    /// <returns>A string describing the domain event.</returns>
    public override string ToString()
    {
        var metadataString = Metadata.Count > 0
            ? $", Metadata: {string.Join(", ", Metadata.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}"
            : string.Empty;

        return $"{EventType} Event: {Id} at {CreatedOn}, Version: {Version}{metadataString}";
    }
}
