using System;
using System.Web;
using HttpLifecycleDemo.Common;

namespace HttpLifecycleDemo
{
    public class MyHttpModule : IHttpModule
    {
        public MyHttpModule()
        {
            LogMessage("Ctor() => " + this.GetHashCode());
        }

        public void Init(HttpApplication context)
        {
            LogMessage("Init() HttpApplication =>" + context.GetHashCode());
            context.BeginRequest += (sender, e) =>
            {
                LogMessage("HttpContext.BeginRequest");
            };

            context.EndRequest += (sender, e) =>
            {
                LogMessage("HttpContext.EndRequest");
                ThrowAnotherEx();
            };

            context.Error += (sender, args) =>
            {
                LogMessage("HttpContext.Error");
            };
            LogMessage("Init() DONE!");


            //context.AcquireRequestState += new EventHandler(app_AcquireRequestState);
            //context.PostAcquireRequestState += new EventHandler(app_PostAcquireRequestState);
        }

        private void ThrowAnotherEx()
        {
            var myHttpContextHelper = MyHttpContextHelper.Instance;
            var value = myHttpContextHelper.GetCurrentUriParams("throw2");
            if (value == "true")
            {
                LogMessage("HttpContext.EndRequest ThrowAnotherEx");
                throw new ArgumentException("EndRequest ThrowAnotherEx");
            }
        }

        //// Define a custom AcquireRequestState event handler.
        //public void app_AcquireRequestState(object o, EventArgs ea)
        //{
        //    HttpApplication httpApp = (HttpApplication)o;
        //    HttpContext ctx = HttpContext.Current;
        //    ctx.Response.Write(" Executing AcquireRequestState ");
        //}

        //// Define a custom PostAcquireRequestState event handler.
        //public void app_PostAcquireRequestState(object o, EventArgs ea)
        //{
        //    HttpApplication httpApp = (HttpApplication)o;
        //    HttpContext ctx = HttpContext.Current;
        //    ctx.Response.Write(" Executing PostAcquireRequestState ");
        //}


        public void Dispose()
        {
            LogMessage("Dispose() ");
        }

        private void LogMessage(string message)
        {
            UtilsLogger.LogMessage(this.GetType(),   "[" + this.GetHashCode() + "] " + " >>>>>>>>>> " + message);
        }
    }
}