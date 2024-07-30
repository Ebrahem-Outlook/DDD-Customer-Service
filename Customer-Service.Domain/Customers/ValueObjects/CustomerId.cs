using Customer_Service.Domain.Core.BaseType;

namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class CustomerId : ValueObject
{
    private CustomerId(string value) => Value = value;

    private CustomerId() { }

    public string Value { get; } = default!;

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
