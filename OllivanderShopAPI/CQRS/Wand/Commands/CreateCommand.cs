using ErrorOr;
using MediatR;
using OllivandersShopAPI.Models;

namespace OllivandersShopAPI.CQRS.Wands.Commands
{
    public record CreateCommand(
        string Core, 
        string Wood,
        decimal LengthInInches) : IRequest<ErrorOr<Wand>>;
}
