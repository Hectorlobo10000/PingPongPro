using Autofac;
using PingPongPro.Domain;
using PingPongPro.Domain.CommandHandlers;
using PingPongPro.Domain.Commands;

namespace PinPongPro.Presentation.Infrastructure
{
    public class ConfigureCommands : IBootstrapperTask
    {
        readonly ContainerBuilder _containerBuilder;

        public ConfigureCommands(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public void Run()
        {
            _containerBuilder.RegisterType<TournamentCreator>().As<ICommandHandler<CreateTournament>>();

        }

        
    }
}