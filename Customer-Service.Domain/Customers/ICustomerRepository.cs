namespace Customer_Service.Domain.Customers;

public interface ICustomerRepository
{
    // Commands
    Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
    void Update(Customer customer);
    void Delete(Customer customer);

    // Queries.
    Task<List<Customer>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Customer?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<List<Customer>?> GetAllAsync(string name, CancellationToken cancellationToken = default);
}
