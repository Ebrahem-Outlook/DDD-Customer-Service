using Customer_Service.Application.Core.Data;
using Customer_Service.Application.Core.Emails;
using Customer_Service.Domain.Customers;
using Customer_Service.Infrastructure.Caching;
using Customer_Service.Infrastructure.Database;
using Customer_Service.Infrastructure.Emails;
using Customer_Service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer_Service.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            string? connection = configuration.GetConnectionString("Postgres");

            options.UseNpgsql(connection);
        });

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());


        // Customer Repository and Cached service...
        services.AddDistributedMemoryCache();

        services.AddScoped<CustomerRepository>();

        services.AddScoped<ICustomerRepository>(serviceProvider =>
        {
            var decorated = serviceProvider.GetRequiredService<CustomerRepository>();

            var cache = serviceProvider.GetRequiredService<IDistributedCache>();

            return new CachedCustomerRepository(decorated, cache);
        });


        // Email Service...
        services.AddScoped<IEmailService, EmailService>();



        return services;
    }
}
