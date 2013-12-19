using AcklenAvenue.Testing.Moq.ExpectedObjects;
using Machine.Specifications;
using Moq;
using PinPongPro.Presentation.Controllers;
using PinPongPro.Presentation.Models;
using PingPongPro.Domain;
using It = Machine.Specifications.It;

namespace PingPongPro.Presentation.Test
{
    public class when_creating_a_tournament
    {
        static TournamentController _controller;
        static IRepository _repository;
        static ICommandDispatcher _commandDispatcher;

        Establish context =
            () =>
                {
                    _repository = Mock.Of<IRepository>();
                    _commandDispatcher = Mock.Of<ICommandDispatcher>();
                    _controller = new TournamentController(_commandDispatcher, _repository);
                };

        Because of =
            () => _controller.CreateTournament(new TournamentModel());

        It should_dispatch_tournament =
            () => { Mock.Get(_commandDispatcher).Verify(c=>c.Dispatch(WithExpected.Object(`new CreateTournament()))); };
    }

    internal class CreateTournament:ICommand
    {
    }
}