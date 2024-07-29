using Customer_Service.Application.Core.Messaging;
using Customer_Service.Domain.Core.BaseType.Result;
using Customer_Service.Domain.Customers;
using Microsoft.Extensions.Logging;

namespace Customer_Service.Application.Customers.Queries.GetAll;

internal sealed class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, Result<List<Customer>>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<GetAllCustomersQueryHandler> _logger;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, ILogger<GetAllCustomersQueryHandler> logger)
    {
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public async Task<Result<List<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request Start {RequestName}, {DateTime}", typeof(GetAllCustomersQuery).Name, DateTime.UtcNow);

        List<Customer>? customers = await _customerRepository.GetAllAsync(cancellationToken);

        if (customers is null)
        {
            _logger.LogError("There aren't customer in the database.");
            return new Result<List<Customer>>();
        }

        _logger.LogInformation("Request End {RequestName}, {DateTime}", typeof(GetAllCustomersQuery).Name, DateTime.UtcNow);

        return customers.;
    }
}
