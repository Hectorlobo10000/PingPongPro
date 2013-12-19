using System.Web.Http;
using PinPongPro.Presentation.Models;
using PingPongPro.Domain;

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

        public void CreateTournament(TournamentModel tournamentModel)
        {
            
        }
    }
}