using AcklenAvenue.Testing.Moq.ExpectedObjects;
using FizzWare.NBuilder;
using Machine.Specifications;
using Moq;
using PingPongPro.Domain.CommandHandlers;
using PingPongPro.Domain.Commands;
using PingPongPro.Domain.Entities;
using PingPongPro.Domain.Events;
using It = Machine.Specifications.It;

namespace PingPongPro.Domain.Test
{
    public class when_creating_a_new_tournament
    {
        static CreateTournament _command;
        static TournamentCreator _commandHandler;
        static IRepository _repository;
        static IEventDispatcher _eventDispatcher;
        static Tournament _tournament;
        static TournamentCreated _tournamentCreated;

        Establish context =
            () =>
                {
                    _command = Builder<CreateTournament>.CreateNew().Build();

                    _repository = Mock.Of<IRepository>();
                    _eventDispatcher = Mock.Of<IEventDispatcher>();
                    _commandHandler = new TournamentCreator(_repository, _eventDispatcher);

                    _tournament = new Tournament(_command.Id, _command.Name, _command.Address, _command.Date,
                                                 _command.Price);

                    _tournamentCreated = new TournamentCreated(_command.Id, _command.Name);
                };

        Because of =
            () => _commandHandler.Procces(_command);

        It should_creat_the_new_tournament_in_the_repository =
            () => Mock.Get(_repository).Verify(c => c.Create(WithExpected.Object(_tournament)));

        It should_raise_expected_event =
            () => Mock.Get(_eventDispatcher).Verify(c => c.Raise(WithExpected.Object(_tournamentCreated)));
    }
}