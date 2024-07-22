using Customer_Service.Domain.Core.BaseType;
using Customer_Service.Domain.Customers.ValueObjects;

namespace Customer_Service.Domain.Customers;

public sealed class Customer : AggregateRoot<CustomerId>
{
    public Customer(Name name, Email email, Address address, PhoneNumber phoneNumber)
    {
        CustomerId = CustomerId.Create();
        Name = name;
        Email = email;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    private Customer() { }

    public CustomerId CustomerId { get; } 
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    
}
