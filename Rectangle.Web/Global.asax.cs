using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using RectangleProblem.DI;

namespace RectangleProblem
{
    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            container = WebBootstrapper.Init();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}
