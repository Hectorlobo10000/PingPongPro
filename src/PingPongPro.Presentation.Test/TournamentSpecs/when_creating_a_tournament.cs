using System;
using AcklenAvenue.Testing.Moq.ExpectedObjects;
using Machine.Specifications;
using Moq;
using PinPongPro.Presentation.Controllers;
using PinPongPro.Presentation.Models;
using PingPongPro.Domain;
using PingPongPro.Domain.Commands;
using It = Machine.Specifications.It;

namespace PingPongPro.Presentation.Test.TournamentSpecs
{
    public class when_creating_a_tournament
    {
        static TournamentController _controller;
        static IRepository _repository;
        static ICommandDispatcher _commandDispatcher;
        static CreateTournament _createTournament;
        static TournamentModel _tournamentModel;

        Establish context =
            () =>
                {
                    _repository = Mock.Of<IRepository>();
                    _commandDispatcher = Mock.Of<ICommandDispatcher>();
                    _controller = new TournamentController(_commandDispatcher, _repository);

                    var guid = Guid.NewGuid();
                    SystemGuid.New = () => guid;
                    _tournamentModel = new TournamentModel();
                    _createTournament = new CreateTournament(guid, _tournamentModel.Name, _tournamentModel.Address,
                                                             _tournamentModel.Date, _tournamentModel.Price);
                };

        Because of =
            () => _controller.CreateTournament(_tournamentModel);

        It should_dispatch_tournament =
            () => Mock.Get(_commandDispatcher).Verify(c => c.Dispatch(WithExpected.Object(_createTournament)));
    }
}