using Customer_Service.Domain.Core.BaseType;

namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class Address : ValueObject
{
    private Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    private Address() { }

    public string Street { get; } = default!;
    public string City { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;

    public static Address Create(string street, string city, string state, string zipCode)
    {

        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street is required.", nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City is required.", nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentException("State is required.", nameof(state));
        if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentException("ZipCode is required.", nameof(zipCode));

        return new Address(street, city, state, zipCode);   
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return ZipCode;
    }

    public override string ToString() => $"{Street}, {City}, {State}, {ZipCode}";
}
