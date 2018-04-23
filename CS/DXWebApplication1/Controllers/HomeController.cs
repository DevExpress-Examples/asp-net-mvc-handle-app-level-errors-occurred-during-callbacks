using System;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers {
    public class HomeController: Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Error() {
            if (HttpContext.Application["Log"] != null)
                ViewData["Log"] = HttpContext.Application["Log"].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult Error(object model) {
            HttpContext.Application["Log"] = "";
            return View();
        }
        public ActionResult CallbackPanelPartial(bool? ThrowExceptionOnCallback) {
            //throw new Exception("This Exception is thrown in the controller action");
            if (ThrowExceptionOnCallback.HasValue)
                ViewData["ThrowExceptionOnCallback"] = ThrowExceptionOnCallback.Value;
            return PartialView();
        }
    }
}