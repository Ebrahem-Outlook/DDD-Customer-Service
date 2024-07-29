using Customer_Service.Domain.Core.BaseType.Result;
using MediatR;

namespace Customer_Service.Application.Core.Messaging;

public interface IQuery : IRequest
{

}

public interface IQuery<TResponse> : IRequest<TResponse>
    where TResponse : Result
{

}
