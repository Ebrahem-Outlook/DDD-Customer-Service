using Customer_Service.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer_Service.Infrastructure.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Email.Address).HasMaxLength(50).IsRequired();

        builder.Property(customer => customer.Email.Address).HasMaxLength(50).IsRequired();

        builder.Property(customer => customer.Email.Address).HasMaxLength(50).IsRequired();

        builder.Property(customer => customer.Email.Address).HasMaxLength(50).IsRequired();
    }
}
