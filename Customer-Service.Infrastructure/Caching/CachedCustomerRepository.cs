using Customer_Service.Domain.Customers;
using Customer_Service.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Customer_Service.Infrastructure.Caching;

internal sealed class CachedCustomerRepository(CustomerRepository decorated, IDistributedCache cache) : ICustomerRepository
{
    public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        await decorated.AddAsync(customer, cancellationToken);
        string key = $"Key-{customer.Id}";
        await cache.RemoveAsync(key, cancellationToken);
    }

    public async Task Update(Customer customer, CancellationToken cancellationToken = default)
    {
        await decorated.Update(customer, cancellationToken);
        string key = $"Key-{customer.Id}";
        await cache.RemoveAsync(key, cancellationToken);
    }

    public async Task Delete(Customer customer, CancellationToken cancellationToken = default)
    {
        await decorated.Delete(customer);
        string key = $"Key-{customer.Id}";
        await cache.RemoveAsync(key, cancellationToken);
    }

    public async Task<List<Customer>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await decorated.GetAllAsync(cancellationToken);
    }

    public async Task<Customer?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await decorated.GetByIdAsync(id, cancellationToken);
    }

    public async Task<List<Customer>?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await decorated.GetByNameAsync(name, cancellationToken);
    }
}
