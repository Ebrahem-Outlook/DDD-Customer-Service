namespace Customer_Service.Domain.Customers;

public interface ICustomerRepository
{
    // Commands
    Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
    Task Update(Customer customer, CancellationToken cancellationToken = default);
    Task Delete(Customer customer, CancellationToken cancellationToken = default);

    // Queries.
    Task<List<Customer>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Customer?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<List<Customer>?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}
