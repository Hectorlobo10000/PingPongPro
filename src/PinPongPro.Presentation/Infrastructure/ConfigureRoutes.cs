using System.Web.Http;
using System.Web.Routing;
using AttributeRouting.Web.Http.WebHost;
using AttributeRouting.Web.Mvc;
using PinPongPro.Presentation.Controllers;

namespace PinPongPro.Presentation.Infrastructure
{
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