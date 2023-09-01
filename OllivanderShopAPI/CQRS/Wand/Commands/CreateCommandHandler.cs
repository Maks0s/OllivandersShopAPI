using ErrorOr;
using MediatR;
using OllivandersShopAPI.Data.DataAccess.Repositories.Abstractions;
using OllivandersShopAPI.Mapper.Abstractions;
using OllivandersShopAPI.Models.DTO;
using OllivandersShopAPI.Models;

namespace OllivandersShopAPI.CQRS.Wands.Commands
{
    public class CreateCommandHandler
        : IRequestHandler<CreateCommand, ErrorOr<Wand>>
    {
        private readonly IWandRepository _wandRepository;

        public CreateCommandHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }


        public async Task<ErrorOr<Wand>> Handle(CreateCommand command, CancellationToken cancellationToken)
        {
            var postResult = await _wandRepository.AddWandAsync(new PostWandDto()
            {
                Core = command.Core,
                Wood = command.Wood,
                LengthInInches = command.LengthInInches
            });

            return postResult;
        }
    }
}
