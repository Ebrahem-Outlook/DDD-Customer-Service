using Customer_Service.Application.Core.Data;
using Customer_Service.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Customer_Service.Infrastructure.Repositories;

internal sealed class CustomerRepository(IDbContext dbContext) : ICustomerRepository
{
    public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<Customer>().AddAsync(customer, cancellationToken);
    }

    public async Task Update(Customer customer, CancellationToken cancellationToken = default)
    {
        dbContext.Set<Customer>().Update(customer);

        await Task.CompletedTask;
    }

    public async Task Delete(Customer customer, CancellationToken cancellationToken = default)
    {
        dbContext.Set<Customer>().Remove(customer);

        await Task.CompletedTask;
    }

    public async Task<List<Customer>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Customer>().ToListAsync(cancellationToken);
    }

    public async Task<List<Customer>?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Customer>().Where(c => c.Name.FirstName == name).ToListAsync(cancellationToken);   
    }

    public async Task<Customer?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Customer>().FirstOrDefaultAsync(c => c.Id.Value == id, cancellationToken);
    }
}
