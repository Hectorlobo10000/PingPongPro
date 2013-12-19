using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace PinPongPro.Presentation.Infrastructure
{
    public class Bootstrapper
    {
        readonly ContainerBuilder _containerBuilder;
        
        public Bootstrapper(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public IContainer Run()
        {
            new List<IBootstrapperTask>
                {
                    //boostrapper tasks here
                    new ConfigureRoutes(),
                    new DbConfiguration(_containerBuilder),
                    new ConfigureWebDependencies(_containerBuilder),
                    new ConfigureCommands(_containerBuilder),
                   
                }.ForEach(x => x.Run());
            return BuildContainer();
        }

        IContainer BuildContainer()
        {
            var container = _containerBuilder.Build();
            AfterContainerIsBuilt(container);
            return container;
        }

        void AfterContainerIsBuilt(ILifetimeScope container)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}