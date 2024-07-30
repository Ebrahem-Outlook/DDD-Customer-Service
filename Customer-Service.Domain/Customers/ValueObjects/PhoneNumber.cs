using Customer_Service.Domain.Core.BaseType;
using System.Text.RegularExpressions;

namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class PhoneNumber : ValueObject
{
    public PhoneNumber(string countryCode, string number)
    {
        CountryCode = countryCode;
        Number = number;
    }

    private PhoneNumber() { }

    public string CountryCode { get; } = default!;
    public string Number { get; } = default!;

    public static PhoneNumber Create(string countryCode, string number)
    {
        return new PhoneNumber(countryCode, number);
    }

    public bool IsValidPhoneNumber(string number)
    {
        var regex = new Regex(@"^\+?[1-9]\d{1,14}$"); // Simplified phone number validation
        return regex.IsMatch(number);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        yield return Number;
    }

    public override string ToString() => $"{CountryCode} {Number}";
}
