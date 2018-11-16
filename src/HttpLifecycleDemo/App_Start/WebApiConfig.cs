using System.Web.Http;

namespace HttpLifecycleDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        
        public static void RegisterGlobalFilters(HttpConfiguration config)
        {
            //事务控制WebApi
        }
    }
}
