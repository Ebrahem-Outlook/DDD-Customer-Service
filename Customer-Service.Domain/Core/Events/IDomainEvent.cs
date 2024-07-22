using MediatR;

namespace Customer_Service.Domain.Core.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccuerOn { get; }
}
