namespace Customer_Service.Domain.Core.Events;

public record DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        Id = Guid.NewGuid();
        CreatedOn = DateTime.UtcNow;
    }

    public Guid Id { get; }

    public DateTime CreatedOn { get; }
}
