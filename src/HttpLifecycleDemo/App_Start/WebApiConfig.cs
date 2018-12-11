using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using HttpLifecycleDemo.Common;

namespace HttpLifecycleDemo
{
    public static class WebApiConfig
    {
        public static void Init(HttpConfiguration config)
        {
            RegisterWebApiRoute(config);
            RegisterWebApiFilters(config);

            config.EnsureInitialized();
        }

        private static void RegisterWebApiRoute(HttpConfiguration config)
        {
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void RegisterWebApiFilters(HttpConfiguration config)
        {
            var filters = config.Filters;
            filters.Add(new WebApiExceptionFilterAttribute());
            filters.Add(new WebApiTxActionFilter());
        }
    }
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            LogMessage(context.Exception.Message);
            //if (context.Exception is NotImplementedException)
            //{
            //    //context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            //}
        }


        private void LogMessage(string message)
        {
            UtilsLogger.LogMessage(typeof(WebApiExceptionFilterAttribute), "[" + this.GetHashCode() + "] " + ">>>>>>>>>>" + message);
        }

    }
    public class WebApiTxActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            LogMessage("OnActionExecuting!");
            base.OnActionExecuting(actionContext);
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            LogMessage("OnActionExecutingAsync!");
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            LogMessage("OnActionExecuted!");
            base.OnActionExecuted(actionExecutedContext);
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            LogMessage("OnActionExecutedAsync!");
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
            //todo
        }

        private void LogMessage(string message)
        {
            UtilsLogger.LogMessage(typeof(WebApiTxActionFilter), "[" + this.GetHashCode() + "] " + ">>>>>>>>>>" + message);
        }
    }
}
