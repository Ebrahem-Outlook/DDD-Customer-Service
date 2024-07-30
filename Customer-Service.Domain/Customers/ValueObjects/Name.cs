using Customer_Service.Domain.Core.BaseType;

namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class Name : ValueObject
{
    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    private Name() { }

    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;

    public static Name Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name is required.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name is required.", nameof(lastName));

        return new Name(firstName, lastName);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }

    public override string ToString() => $"{FirstName} {LastName}";
}
