using Microsoft.EntityFrameworkCore;

namespace Customer_Service.Application.Core.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}
