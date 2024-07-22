using Customer_Service.Domain.Core.BaseType;
using Customer_Service.Domain.Customers.Events;
using Customer_Service.Domain.Customers.ValueObjects;

namespace Customer_Service.Domain.Customers;

public sealed class Customer : AggregateRoot<CustomerId>
{
    private Customer(Name name, Email email, Address address, PhoneNumber phoneNumber) : base(CustomerId.Create())
    {
        Name = name;
        Email = email;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    private Customer() { }

    public Name Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public PhoneNumber PhoneNumber { get; private set; } = default!;

    public static Customer Create(Name name, Email email, Address address, PhoneNumber phoneNumber)
    {
        Customer customer = new(name, email, address, phoneNumber);

        customer.Raise(new CustomerCreatedDomainEvent(customer));

        return customer;
    }

    public void Update(Name name, Email email, Address address, PhoneNumber phone)
    {
        Name = name;
        Email = email;
        Address = address;
        PhoneNumber = phone;

        Raise(new CustomerUpdatedDomainEvent(this));
    }
}
