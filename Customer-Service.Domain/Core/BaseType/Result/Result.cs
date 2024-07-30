using System.Data.SqlTypes;

namespace Customer_Service.Domain.Core.BaseType.Result;

public class Result
{
    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new Result(true, Error.None);

    public static Result Failure(Error error) => new Result(false, error);
}
