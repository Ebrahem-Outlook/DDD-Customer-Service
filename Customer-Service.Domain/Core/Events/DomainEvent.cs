namespace Customer_Service.Domain.Core.Events;

public record DomainEvent : IDomainEvent
{
    public DomainEvent() : this(Guid.NewGuid(), DateTime.UtcNow)
    {
    }

    private DomainEvent(Guid id, DateTime createdOn)
    {
        Id = id;
        CreatedOn = createdOn;
    }

    public Guid Id { get; }

    public DateTime CreatedOn { get; }
}
