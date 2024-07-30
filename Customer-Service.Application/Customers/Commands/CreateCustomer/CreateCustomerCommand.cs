using Customer_Service.Application.Core.Authentication;
using Customer_Service.Application.Core.Data;
using Customer_Service.Application.Core.Emails;
using Customer_Service.Application.Core.Messaging;
using Customer_Service.Domain.Customers;
using Customer_Service.Domain.Customers.ValueObjects;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Logging;

namespace Customer_Service.Application.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand(
    string FirstName,
    string LastName,
    string Email, 
    string Address,
    string PhoneNumber) : ICommand;

/*internal sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateCustomerCommandHandler> _logger;

    public Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Name name = Name.Create(request.FirstName, request.LastName);
        Email email = Email.Create(request.Email);
        Address address = Address.Create(request)
    }
}*/

internal sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(customer => customer.FirstName).NotNull().NotEmpty().WithMessage("FirstName can't be null.");
    }
}
