using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whiteboard.Web.Models;

namespace Whiteboard.Web.Controllers {
    public class HomeController : BaseController {
        public ActionResult Index() {
            if (Request.IsAuthenticated) {
                return RedirectToAction("Index", "Dashboard");
            }
            // Necessary because there is a RegisterWidget on Index view
            var result = GetCountries();
            ViewData["country"] = result;
            ViewData["Errors"] = TempData["Errors"] ?? new List<ModelError>();
            ViewData["RegisterModel"] = TempData["RegisterModel"] ?? new RegisterViewModel();

            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
