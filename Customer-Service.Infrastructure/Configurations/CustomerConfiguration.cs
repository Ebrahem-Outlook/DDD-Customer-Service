using Customer_Service.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer_Service.Infrastructure.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();

        builder.Property(customer => customer.Email).HasColumnType("varchar").HasMaxLength(50).IsRequired();

        builder.Property(customer => customer.Address).HasColumnType("varchar").HasMaxLength(50).IsRequired();

        builder.Property(customer => customer.PhoneNumber).HasColumnType("varchar").HasMaxLength(50).IsRequired();
    }
}
