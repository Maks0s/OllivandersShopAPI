using ErrorOr;
using OllivandersShopAPI.CQRS.Contracts;
using OllivandersShopAPI.Data.DataAccess.Repositories.Abstractions;

namespace OllivandersShopAPI.CQRS.Wands.Commands.Delete
{
    public class DeleteCommandHandler : ICommandHandler<DeleteCommand, Deleted>
    {
        private readonly IWandRepository _wandRepository;

        public DeleteCommandHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(DeleteCommand command, CancellationToken cancellationToken)
        {
            return await _wandRepository.DeleteWandAsync(command.Id);
        }
    }
}
