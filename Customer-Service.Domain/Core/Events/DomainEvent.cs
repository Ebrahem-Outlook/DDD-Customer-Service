namespace Customer_Service.Domain.Core.Events;

public record DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        Id = Guid.NewGuid();
        OccuerOn = DateTime.UtcNow;
    }

    public Guid Id { get; }

    public DateTime OccuerOn { get; }
}
