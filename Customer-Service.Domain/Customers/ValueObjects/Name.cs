using Customer_Service.Domain.Core.BaseType;

namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class Name : ValueObject
{
    private Name(string value) => Value = value;

    public string Value { get; }

    public static Name Create(string value)
    {
        return new Name(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
