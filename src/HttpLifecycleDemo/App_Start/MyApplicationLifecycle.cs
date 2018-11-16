using HttpLifecycleDemo;
using HttpLifecycleDemo.Common;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(MyApplicationLifecycle), "PreApplicationStart")]
[assembly: ApplicationShutdownMethod(typeof(MyApplicationLifecycle), "ApplicationShutdown")]

namespace HttpLifecycleDemo
{
    public static class MyApplicationLifecycle
    {
        public static void PreApplicationStart()
        {
            LogMessage("=> PreApplicationStart()");
            DynamicModuleUtility.RegisterModule(typeof(MyHttpModule));
            LogMessage("=> DynamicModuleUtility.RegisterModule() DONE!");
        }

        public static void ApplicationShutdown()
        {
            LogMessage("=> ApplicationShutdown()");
        }

        private static void LogMessage(string message)
        {
            UtilsLogger.LogMessage(typeof(MyApplicationLifecycle), ">>>>>>>>>>" + message);
        }
    }
}