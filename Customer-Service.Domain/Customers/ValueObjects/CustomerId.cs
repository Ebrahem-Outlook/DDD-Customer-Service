namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class CustomerId : 
{
    private CustomerId(string value) => Value = value;

    public string Value { get; }

    public static CustomerId Create()
    {
        return new CustomerId(Guid.NewGuid().ToString());
    }
}
