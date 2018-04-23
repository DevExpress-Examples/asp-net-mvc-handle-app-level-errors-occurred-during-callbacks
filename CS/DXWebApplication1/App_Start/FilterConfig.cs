using DXWebApplication1.Controllers;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1 {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttributeEx());
        }

        public class HandleErrorAttributeEx : HandleErrorAttribute {
            public HandleErrorAttributeEx() : base() { }
            public override void OnException(ExceptionContext filterContext) {
                base.OnException(filterContext);
                filterContext.ExceptionHandled = false;
            }
        }
    }
}