using Customer_Service.Domain.Core.BaseType;

namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class CustomerId : ValueObject
{
    private CustomerId(string value) => Value = value;

    public string Value { get; }

    public static CustomerId Create()
    {

        return new CustomerId(Guid.NewGuid().ToString());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => $"{Value}";
}
