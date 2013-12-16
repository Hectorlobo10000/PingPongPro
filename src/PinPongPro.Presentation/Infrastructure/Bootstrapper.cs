using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AttributeRouting.Web.Http.WebHost;
using AttributeRouting.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using PinPongPro.Presentation.Controllers;

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

    public class ConfigureRoutes   : IBootstrapperTask
    {
        
        #region IBootstrapperTask Members

        public void Run()
        {
            var httpRouteCollection = GlobalConfiguration.Configuration.Routes;
            httpRouteCollection.Clear();

            var routeCollection = RouteTable.Routes;
            routeCollection.Clear();

            RegisterWebApi(httpRouteCollection);
            RegisterMvc(routeCollection);
        }

        #endregion

        void RegisterMvc(RouteCollection routes)
        {
            routes.MapAttributeRoutes(c => c.AddRoutesFromAssemblyOf<HomeController>());
        }

        void RegisterWebApi(HttpRouteCollection routes)
        {
            routes.MapHttpAttributeRoutes(c => c.AddRoutesFromAssembly(typeof(TournamentController).Assembly));
        }
    }
}