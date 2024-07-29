using Customer_Service.Domain.Core.Events;

namespace Customer_Service.Domain.Customers.Events;

public sealed record CustomerUpdatedDomainEvent(Customer Customer) : DomainEvent();
