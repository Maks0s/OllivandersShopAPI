using ErrorOr;
using MediatR;
using OllivandersShopAPI.CQRS.Contracts;
using OllivandersShopAPI.Models;
using System.Windows.Input;

namespace OllivandersShopAPI.CQRS.Wands.Commands
{
    public record CreateCommand(
        string Core, 
        string Wood,
        decimal LengthInInches) : ICommand<Wand>;
}
