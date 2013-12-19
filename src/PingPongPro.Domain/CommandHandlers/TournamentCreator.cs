using PingPongPro.Domain.Commands;
using PingPongPro.Domain.Entities;
using PingPongPro.Domain.Events;

namespace PingPongPro.Domain.CommandHandlers
{
    public class TournamentCreator : ICommandHandler<CreateTournament>
    {
        readonly IEventDispatcher _eventDispatcher;
        readonly IRepository _repository;

        public TournamentCreator(IRepository repository, IEventDispatcher eventDispatcher)
        {
            _repository = repository;
            _eventDispatcher = eventDispatcher;
        }

        public void Procces(CreateTournament command)
        {
            var newTournament = new Tournament(command.Id, command.Name, command.Address, command.Date, command.Price);

            _repository.Create(newTournament);

            _eventDispatcher.Raise(new TournamentCreated(newTournament.Id, newTournament.Name));
        }
    }
}