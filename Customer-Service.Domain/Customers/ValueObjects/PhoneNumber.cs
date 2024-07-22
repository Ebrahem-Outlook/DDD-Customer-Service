using Customer_Service.Domain.Core.BaseType;
using System.Text.RegularExpressions;

namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class PhoneNumber : ValueObject
{
    public string CountryCode { get; }
    public string Number { get; }

    public PhoneNumber(string countryCode, string number)
    {
        CountryCode = countryCode ?? throw new ArgumentNullException("Country code is required.", nameof(countryCode));
        Number = number ?? throw new ArgumentNullException("Invalid phone number.", nameof(number));
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
