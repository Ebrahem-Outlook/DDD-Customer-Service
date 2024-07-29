using Customer_Service.Domain.Core.BaseType;
using Customer_Service.Domain.Customers.Events;
using Customer_Service.Domain.Customers.ValueObjects;

namespace Customer_Service.Domain.Customers;

/// <summary>
/// 
/// </summary>
public sealed class Customer : AggregateRoot<CustomerId>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    private Customer(Name name, Email email, Address address, PhoneNumber phoneNumber) : base(CustomerId.Create())
    {
        Name = name;
        Email = email;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    /// <summary>
    /// 
    /// </summary>
    private Customer() { }

    /// <summary>
    /// 
    /// </summary>
    public Name Name { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public Email Email { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public Address Address { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public PhoneNumber PhoneNumber { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public static Customer Create(Name name, Email email, Address address, PhoneNumber phoneNumber)
    {
        Customer customer = new(name, email, address, phoneNumber);

        customer.Raise(new CustomerCreatedDomainEvent(customer));

        return customer;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="phone"></param>
    public void Update(Name name, Email email, Address address, PhoneNumber phone)
    {
        Name = name;
        Email = email;
        Address = address;
        PhoneNumber = phone;

        Raise(new CustomerUpdatedDomainEvent(this));
    }
}
