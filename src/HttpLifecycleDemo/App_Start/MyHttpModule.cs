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
            LogMessage("Init()");
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