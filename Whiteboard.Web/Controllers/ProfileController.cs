using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.ProfileModule;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.Common;
using Whiteboard.Common.Cryptography;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models;

namespace Whiteboard.Web.Controllers {
    [Authorize]
    public class ProfileController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            Profile profile = service.Get(User.Identity.Name);

            ViewData["country"] = GetCountries(profile.Country);
            ViewData["Errors"] = TempData["Errors"] ?? new List<ModelError>();

            ProfileViewModel model = GetProfileViewModel(profile);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(ProfileViewModel profileVM) {
            IProfileService profileService = ProfileService.GetInstance<ProfileRepository>();
            if (!ModelState.IsValid) {
                TempData["ProfileModel"] = profileVM;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();

                return RedirectToAction("Index", "Profile");
            }
            Profile profile = GetProfile();
            //UpdateOrCreateMemberSchool(profile, profileVM);

            profile.Name = profileVM.Name;
            profile.Country = profile.Country;

            profileVM.CurrentPassword = profileVM.CurrentPassword ?? "";
            if (!string.IsNullOrEmpty(profileVM.CurrentPassword.Trim())) {
                string currentPasswordHash = HashSumUtil.GetHashSum(profileVM.CurrentPassword, HashSumType.SHA1);
                if (currentPasswordHash.Equals(profile.Password)) {
                    if (profileVM.NewPassword.Equals(profileVM.ConfirmPassword) && !string.IsNullOrEmpty(profileVM.NewPassword)) {
                        string newPasswordHash = HashSumUtil.GetHashSum(profileVM.NewPassword, HashSumType.SHA1);
                        profile.Password = newPasswordHash;
                    } else {
                        ModelState.AddModelError("PasswordError", "Passwords doesn\'t match.");
                        TempData["ProfileModel"] = profileVM;
                        TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();

                        RedirectToAction("Index", "Profile");
                    }
                } else {
                    ModelState.AddModelError("PasswordError", "Current Password Invalid");
                    TempData["ProfileModel"] = profileVM;
                    TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();

                    RedirectToAction("Index", "Profile");
                }
            }
            profileService.Update(profile);

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            Profile profile = service.Get(User.Identity.Name);

            if (file != null && file.ContentLength > 0) {
                string filename = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath(Constants.UPLOADS_PATH), filename);
                FileHelper.CreateFile(path, file.InputStream, true);

                profile.PictureUrl = filename;
                service.Update(profile);
            }
            return RedirectToAction("Index", "Profile");
        }

        [HttpGet]
        public ActionResult Details(int id) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            Profile profile = service.Get(id);
            if (profile == null || id == 0) {
                return RedirectToAction("Index", "Dashboard");
            }
            ProfileViewModel model = new ProfileViewModel(profile);

            return View(model);
        }

        #region "Private Methods"
        private ProfileViewModel GetProfileViewModel(Profile profile) {
            ProfileViewModel model = new ProfileViewModel(profile);
            return model;
        }
        #endregion
    }
}
