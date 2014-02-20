using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models;

namespace Whiteboard.Web.Controllers {
    public class AuthController : Controller {
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public string Login(LoginViewModel user) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            string message = "nada";
            if (Membership.ValidateUser(user.Email, user.Password)) {
                message = "ahora si";
                FormsAuthentication.SetAuthCookie(user.Email, true);
            }
            return message;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut() {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
