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
    [RouteMap(Title = "Profile", Description = "Profile Information", Route = "Profile, Edit")]
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

        #region "Private Methods"
        //private void UpdateOrCreateMemberSchool(Profile profile, ProfileViewModel profileVM) {
        //    if (profile.Role.Equals(Whiteboard.DataAccess.Models.Profile.ROLE_STUDENT) || profile.Role.Equals(Whiteboard.DataAccess.Models.Profile.ROLE_TEACHER)) {
        //        IMemberService memberService = MemberService.GetInstance<MemberRepository>();
        //        Member member = memberService.GetByProfile(profile.Id);
        //        if (member == null) {
        //            member = new Member();
        //            member.ProfileId = profile.Id;
        //            member.LastName = profileVM.LastName;

        //            memberService.Insert(member);
        //        } else {
        //            member.LastName = profileVM.LastName;

        //            memberService.Update(member);
        //        }
        //    } else if (profile.Role.Equals(Whiteboard.DataAccess.Models.Profile.ROLE_SCHOOL)) {
        //        ISchoolService schoolService = SchoolService.GetInstance<SchoolRepository>();
        //        School school = schoolService.GetByProfile(profile.Id);
        //        if (school == null) {
        //            school = new School();
        //            school.ProfileId = profile.Id;
        //            school.Description = profileVM.Description;

        //            schoolService.Insert(school);
        //        } else {
        //            school.Description = profileVM.Description;

        //            schoolService.Update(school);
        //        }
        //    }
        //}

        private ProfileViewModel GetProfileViewModel(Profile profile) {
            ProfileViewModel model = new ProfileViewModel(profile);
            return model;
        }
        #endregion
    }
}
