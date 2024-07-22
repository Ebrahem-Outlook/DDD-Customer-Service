using Customer_Service.Domain.Core.BaseType.Result;
using MediatR;

namespace Customer_Service.Application.Core.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
    where TResponse : Result
{

}
