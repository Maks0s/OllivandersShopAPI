using ErrorOr;
using OllivandersShopAPI.CQRS.Contracts;

namespace OllivandersShopAPI.CQRS.Wands.Commands.Delete
{
    public record DeleteCommand(int Id) : ICommand<Deleted>;
}
