using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using PinPongPro.Presentation.Controllers;

namespace PinPongPro.Presentation.Infrastructure
{
    public class ConfigureThisApp : IBootstrapperTask
    {
        readonly ContainerBuilder _containerBuilder;

        public ConfigureThisApp(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public void Run()
        {
            _containerBuilder.RegisterApiControllers((typeof(TournamentController).Assembly));
            _containerBuilder.RegisterControllers((typeof(HomeController).Assembly));
        }

    }
}