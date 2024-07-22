
namespace Customer_Service.Domain.Core.BaseType;

public sealed class Error : ValueObject
{
    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }

    public string Message { get; }

    public static Error None => new Error(string.Empty, string.Empty);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Message;
    }
}
