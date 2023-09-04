using ErrorOr;
using MediatR;
using OllivandersShopAPI.CQRS.Contracts;
using OllivandersShopAPI.Models;
using System.Windows.Input;

namespace OllivandersShopAPI.CQRS.Wands.Commands.Create
{
    public record CreateCommand(
        string Core,
        string Wood,
        decimal LengthInInches) : ICommand<Wand>;
}
