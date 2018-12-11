using System.Web.Mvc;
using System.Web.Routing;
using HttpLifecycleDemo.Common;

namespace HttpLifecycleDemo
{
    public class MvcConfig
    {
        public static void Init()
        {
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MvcTxActionFilter());
            filters.Add(new HandleErrorAttribute());
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var defaultNamespace = typeof(MvcConfig).Namespace + ".Controllers";
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Empty", action = "Index" },
                namespaces: new[] { defaultNamespace }
                );
        }
    }

    public class MvcTxActionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogMessage("OnActionExecuting");
            //start tx
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogMessage("OnResultExecuted");
            base.OnResultExecuted(filterContext);
            //flush tx
        }

        public void OnException(ExceptionContext filterContext)
        {
            LogMessage("OnException");
            //filterContext.ExceptionHandled = true;
            //filterContext.Result = new ContentResult(){Content = "blah"};
            //rollback
        }
        private void LogMessage(string message)
        {
            UtilsLogger.LogMessage(this.GetType(), "[" + this.GetHashCode() + "] " + ">>>>>>>>>>" + message);
        }
    }
}
