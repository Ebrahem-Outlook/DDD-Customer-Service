using Customer_Service.Domain.Core.BaseType;
using System.Net.Mail;

namespace Customer_Service.Domain.Customers.ValueObjects;

public sealed class Email : ValueObject
{
    private Email(string address) => Address = address;

    public string Address { get; }

    public static Email Create(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !IsValidEmail(address))
            throw new ArgumentException("Invalid email address.", nameof(address));


        return new Email(address);
    }

    private static bool IsValidEmail(string address)
    {
        try
        {
            var mailAddress = new MailAddress(address);
            return mailAddress.Address == address;
        }
        catch
        {
            return false;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }
}
