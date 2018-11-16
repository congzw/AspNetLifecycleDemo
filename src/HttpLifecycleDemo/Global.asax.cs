using System;
using HttpLifecycleDemo.Common;

namespace HttpLifecycleDemo
{
    public class Global : System.Web.HttpApplication
    {
        public Global()
        {
            LogMessage("CTOR()");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            LogMessage("Application_Start");
            MainEntry.Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            LogMessage("Session_Start");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            LogMessage("Application_BeginRequest");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            LogMessage("Application_AuthenticateRequest");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            LogMessage("Application_Error");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            LogMessage("Session_End");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            LogMessage("Application_End");
        }

        private void LogMessage(string message)
        {
            UtilsLogger.LogMessage(typeof(Global), "[" + this.GetHashCode() + "] " +">>>>>>>>>>" + message);
        }
    }
}