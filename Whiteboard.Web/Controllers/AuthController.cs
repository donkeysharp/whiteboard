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

        [HttpGet]
        public ActionResult Login() {
            if (Request.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Errors = TempData["Errors"];
            ViewBag.Email = TempData["Email"];
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel user) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            if (Membership.ValidateUser(user.Email, user.Password)) {
                FormsAuthentication.SetAuthCookie(user.Email, true);
                return RedirectToAction("Index", "Home");
            }
            TempData["Errors"] = "Invalid email or password, please verify they are correct.";
            TempData["Email"] = user.Email; 
            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut() {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register() {
            if (Request.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }
            var result = GetCountries();
            ViewData["country"] = result;
            ViewData["Errors"] = TempData["Errors"] ?? new List<ModelError>();
            ViewData["RegisterModel"] = TempData["RegisterModel"] ?? new RegisterViewModel();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model) {
            if (!ModelState.IsValid) {
                TempData["RegisterModel"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                
                return RedirectToAction("Register", "Auth");
            }
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            Whiteboard.DataAccess.Models.Profile profile = service.Get(model.Email);
            if (profile != null) {
                ModelState.AddModelError("ModelExists", "Email already exists.");
                TempData["RegisterModel"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();

                return RedirectToAction("Register", "Auth");
            }
            service.Insert(model.Profile);

            return RedirectToAction("Login", "Auth");
        }

        #region "Private Methods"

        private static List<SelectListItem> GetCountries() {
            var result = (from c in Whiteboard.Common.Geo.Regions.GetCountries()
                          select new SelectListItem() {
                              Text = c.Name, Value = c.Code
                          }).ToList();

            result.Insert(0, new SelectListItem() {
                Text = "--- Select your country ---",
                Value = ""
            });
            return result;
        }
        #endregion
    }
}
