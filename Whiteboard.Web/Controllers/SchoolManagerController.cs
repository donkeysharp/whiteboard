using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whiteboard.DataAccess.Models;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models;

namespace Whiteboard.Web.Controllers {
    [Authorize(Roles=Role.ROLE_SCHOOL)]
    public class SchoolManagerController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();

            IEnumerable<Profile> students = service.GetStudentsBySchoolId(CurrentProfile.Id);
            List<ProfileViewModel> studentModels = new List<ProfileViewModel>();
            foreach (Profile profile in students) {
                studentModels.Add(new ProfileViewModel(profile));
            }
            ViewBag.Students = studentModels;

            IEnumerable<Profile> teachers = service.GetTeachersBySchoolId(CurrentProfile.Id);
            List<ProfileViewModel> teacherModels = new List<ProfileViewModel>();
            foreach (Profile profile in teachers) {
                teacherModels.Add(new ProfileViewModel(profile));
            }
            ViewBag.Teachers = teacherModels;
            return View();
        }

        [HttpGet]
        public JsonResult Students(string query) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            IEnumerable<Profile> students = service.FilterStudents(CurrentProfile.Id, query);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
