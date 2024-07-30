namespace Customer_Service.Domain.Core.BaseType.Result;

public class Result<TValue> : Result
{
    protected Result(bool isSuccess, Error error) : base(isSuccess, error)
    {
    }
}
