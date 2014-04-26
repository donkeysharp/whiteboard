using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models;

namespace Whiteboard.Web.Controllers {
    public class AuthController : BaseController {
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
                Profile profile = service.Get(user.Email);
                base.CurrentProfile = profile;

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
            // Verifies if the emails is not being used
            Whiteboard.DataAccess.Models.Profile profile = service.Get(model.Email);
            if (profile != null) {
                ModelState.AddModelError("ModelExists", "Email already exists.");
                TempData["RegisterModel"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();

                return RedirectToAction("Register", "Auth");
            }
            IRoleProfileService roleProfileService = RoleProfileService.GetInstance<RoleProfileRepository>();
            // Sets the default image for profile
            var profileInsert = model.Profile;
            profileInsert.PictureUrl = "user.png";
            profile = service.Insert(profileInsert);

            // Creates a default role for the new profile
            RoleProfile roleProfile = new RoleProfile();
            roleProfile.ProfileId = profile.Id;
            roleProfile.RoleId = (int)Role.Roles.School;
            roleProfileService.Insert(roleProfile);

            return RedirectToAction("Login", "Auth");
        }
    }
}
