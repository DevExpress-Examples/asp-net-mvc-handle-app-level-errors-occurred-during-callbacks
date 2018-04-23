using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DevExpress.Web.ASPxClasses;

namespace MvcGridView_example {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ASPxWebControl.CallbackError += new EventHandler(Application_Error);
        }

        void Application_Error(object sender, EventArgs e) {
            HttpServerUtility server = HttpContext.Current.Server;
            Exception exception = server.GetLastError();
            
            AddToLog(exception.Message, exception.StackTrace);
        }

        void AddToLog(string message, string stackTrace) {
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

            Application["Log"] += sb.ToString();

            sb.AppendLine();
        }
    }
}