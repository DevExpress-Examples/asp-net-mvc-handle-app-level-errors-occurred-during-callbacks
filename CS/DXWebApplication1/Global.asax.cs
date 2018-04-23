using System;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using DevExpress.Web;

namespace DXWebApplication1 {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication: System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();

            ASPxWebControl.CallbackError += Application_Error;
        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception exception = HttpContext.Current.Server.GetLastError();
            if (exception is HttpUnhandledException)
                exception = exception.InnerException;
            AddToLog(exception.Message, exception.StackTrace);
        }

        public static void AddToLog(string message, string stackTrace) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToLocalTime().ToString());
            sb.AppendLine(message);
            sb.AppendLine();
            sb.AppendLine("Source File: " + HttpContext.Current.Request.RawUrl);
            sb.AppendLine();
            sb.AppendLine("Stack Trace: ");
            sb.AppendLine(stackTrace);
            for (int i = 0; i < 150; i++)
                sb.Append("-");
            sb.AppendLine();
            HttpContext.Current.Application["Log"] += sb.ToString();
            sb.AppendLine();
        }
    }
}