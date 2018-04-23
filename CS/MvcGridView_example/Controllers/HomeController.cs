using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DevExpress.Web.Mvc;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;

namespace MvcGridView_example.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Error() {
            ViewData["Log"] = HttpContext.Application["Log"];

            return View(@"Error");
        }

        public ActionResult CallbackPanelPartial() {
            Exception innerException = new Exception("No Report");
            throw new Exception("This exception is thrown to demonstrate an <b>ASPxWebControl.CallbackError</b> event handler.", innerException);
        }
    }
}
