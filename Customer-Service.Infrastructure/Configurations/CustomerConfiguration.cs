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

        builder.Property(customer => customer.Name.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(customer => customer.Name.LastName)
            .HasColumnName("LastName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(customer => customer.Email)
            .HasColumnName("Email")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(customer => customer.PhoneNumber)
            .HasColumnName("Phone")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


        builder.HasOne(customer => customer.Address).WithOne();



        builder.ToTable("Customer");

        // Primary Key
        builder.HasKey(customer => customer.Id);

        // Properties for Name value object
        builder.Property(customer => customer.Name.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(customer => customer.Name.LastName)
            .HasColumnName("LastName")
            .HasColumnType("varchar(50)")
            .IsRequired();

        // Properties for Email value object
        builder.Property(customer => customer.Email.Address)
            .HasColumnName("Email")
            .HasColumnType("varchar(100)")
            .IsRequired();

        // Properties for PhoneNumber value object
        builder.Property(customer => customer.PhoneNumber.CountryCode)
            .HasColumnName("CountryCode")
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder.Property(customer => customer.PhoneNumber.Number)
            .HasColumnName("PhoneNumber")
            .HasColumnType("varchar(20)")
            .IsRequired();

        // Properties for Address value object
        builder.Property(customer => customer.Address.Street)
            .HasColumnName("Street")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(customer => customer.Address.City)
            .HasColumnName("City")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(customer => customer.Address.State)
            .HasColumnName("State")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(customer => customer.Address.ZipCode)
            .HasColumnName("ZipCode")
            .HasColumnType("varchar(20)")
            .IsRequired();

        // CreatedOn and UpdatedOn fields
        builder.Property(customer => customer.CreatedOn)
            .HasColumnName("CreatedOn")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(customer => customer.UpdatedOn)
            .HasColumnName("UpdatedOn")
            .HasColumnType("datetime")
            .IsRequired(false);
    }
}
