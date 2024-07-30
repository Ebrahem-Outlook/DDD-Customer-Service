using Customer_Service.Application.Core.Authentication;
using Customer_Service.Application.Core.Data;
using Customer_Service.Application.Core.Emails;
using Customer_Service.Application.Core.Messaging;
using Customer_Service.Domain.Core.BaseType.Result;
using Customer_Service.Domain.Customers;
using Microsoft.Extensions.Logging;

namespace Customer_Service.Application.Customers.Commands.DeleteCustomer;

public sealed record DeleteCustomerCommand(Guid CustomerId) : ICommand;

internal sealed class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteCustomerCommandHandler> _logger;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IJwtProvider jwtProvider, IEmailService emailService, IUnitOfWork unitOfWork, ILogger<DeleteCustomerCommandHandler> logger)
    {
        _customerRepository = customerRepository;
        _jwtProvider = jwtProvider;
        _emailService = emailService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
