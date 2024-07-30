using Customer_Service.Domain.Core.BaseType.Result;
using MediatR;

namespace Customer_Service.Application.Core.Messaging;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{

}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : Result<TResponse>
{

}
