using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace WebStuff
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            var logger = new Logger.Logger();
            logger.Log("Register Areas");
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}