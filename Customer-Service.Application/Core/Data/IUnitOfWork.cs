using Microsoft.EntityFrameworkCore.Storage;

namespace Customer_Service.Application.Core.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
}
