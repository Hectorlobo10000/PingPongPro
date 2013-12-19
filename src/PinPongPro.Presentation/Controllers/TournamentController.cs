using System;
using System.Web.Http;
using AttributeRouting.Web.Http;
using PinPongPro.Presentation.Models;
using PingPongPro.Domain;
using PingPongPro.Domain.Commands;

namespace PinPongPro.Presentation.Controllers
{
    public class TournamentController:ApiController
    {
        readonly ICommandDispatcher _commandDispatcher;
        readonly IRepository _repository;

        public TournamentController(ICommandDispatcher commandDispatcher, IRepository repository)
        {
            _commandDispatcher = commandDispatcher;
            _repository = repository;
        }

        [POST("tournament")]
        public void CreateTournament(TournamentModel tournamentModel)
        {
            var id = SystemGuid.New();

            var command = new CreateTournament(id, tournamentModel.Name, tournamentModel.Address, tournamentModel.Date,
                                               tournamentModel.Price);

            _commandDispatcher.Dispatch(command);

        }
    }
}