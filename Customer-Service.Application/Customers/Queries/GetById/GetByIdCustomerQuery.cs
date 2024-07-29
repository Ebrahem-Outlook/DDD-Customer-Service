using Customer_Service.Application.Core.Messaging;
using Customer_Service.Domain.Customers;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer_Service.Application.Customers.Queries.GetById
{
    public sealed record GetByIdCustomerQuery(Guid Id) : ICommand<Customer>;

    internal sealed class GetByIdCustomerQueryHandler : ICommandHandler<GetByIdCustomerQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GetByIdCustomerQueryHandler> _logger;

        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository, ILogger<GetByIdCustomerQueryHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Customer> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                _logger.LogWarning("Invalid customer ID provided: {CustomerId}", request.Id);
                throw new ArgumentException("Customer ID cannot be empty", nameof(request.Id));
            }

            try
            {
                var customer = await _customerRepository.GetByIdAsync(request., cancellationToken);

                if (customer == null)
                {
                    _logger.LogInformation("Customer with ID {CustomerId} not found.", request.Id);
                    throw new KeyNotFoundException($"Customer with ID {request.Id} not found.");
                }

                _logger.LogInformation("Successfully retrieved customer with ID {CustomerId}.", request.Id);
                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customer with ID {CustomerId}.", request.Id);
                throw;
            }
        }
    }
}


