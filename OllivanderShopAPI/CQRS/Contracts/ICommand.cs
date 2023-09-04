using ErrorOr;
using MediatR;

namespace OllivandersShopAPI.CQRS.Contracts
{
    public interface ICommand<TResponse>
        : IRequest<ErrorOr<TResponse>>
    {

    }
}
