using Microsoft.EntityFrameworkCore;

namespace Customer_Service.Infrastructure.Database;

public sealed class AppDbContext : DbContext, IDbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected 
}
