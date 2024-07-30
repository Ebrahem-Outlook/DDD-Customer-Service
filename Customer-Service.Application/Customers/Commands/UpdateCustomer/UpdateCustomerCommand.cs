using Customer_Service.Application.Core.Messaging;

namespace Customer_Service.Application.Customers.Commands.UpdateCustomer;

public sealed record UpdateCustomerCommand(Guid CustomerId) : ICommand;
