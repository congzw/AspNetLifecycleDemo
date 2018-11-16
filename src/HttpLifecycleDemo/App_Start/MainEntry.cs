using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace HttpLifecycleDemo
{
    public class MainEntry
    {
        public static void Init()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(WebApiConfig.RegisterGlobalFilters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
