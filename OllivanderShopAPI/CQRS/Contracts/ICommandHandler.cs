using Azure;
using ErrorOr;
using MediatR;

namespace OllivandersShopAPI.CQRS.Contracts
{
    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, ErrorOr<TResponse>>
        where TCommand : ICommand<TResponse>
    {

    }
}
