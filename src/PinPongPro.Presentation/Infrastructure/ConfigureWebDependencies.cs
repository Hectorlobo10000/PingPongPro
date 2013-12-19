using Autofac;
using PingPongPro.Data;
using PingPongPro.Domain;

namespace PinPongPro.Presentation.Infrastructure
{
    public class ConfigureWebDependencies : IBootstrapperTask
    {
        readonly ContainerBuilder _containerBuilder;

        public ConfigureWebDependencies(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public void Run()
        {
            _containerBuilder.RegisterType<Repository>().As<IRepository>();
            _containerBuilder.RegisterType<AutoFacCommandDispatcher>().As<ICommandDispatcher>();
            _containerBuilder.RegisterType<AutoFacEventDisptacher>().As<IEventDispatcher>();
        }

        
    }
}