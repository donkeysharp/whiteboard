using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using whiteboard.BusinessLogic.ProfileModule;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models;
using Whiteboard.Web.Models.DashboardModels;

namespace Whiteboard.Web.Controllers {
    [Authorize]
    public class DashboardController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            //if (IsInRole(Role.ROLE_SCHOOL)) {
            //    // Profile will always have a school role, so no problem when calling this method
            //    ViewBag.OurCourses = GetCoursesBySchool(CurrentProfile);
            //    ViewBag.OurTeachers = GetTeachersBySchool(CurrentProfile);
            //    ViewBag.OurStudents = GetStudentsBySchool(CurrentProfile);
            //} else if (IsInRole(Role.ROLE_TEACHER)) {
            //    ViewBag.MyCourses = GetCoursesByTeacher(CurrentProfile);
            //} else if (IsInRole(Role.ROLE_STUDENT)) {
            //    ViewBag.MyCourses = GetCoursesByStudent(CurrentProfile);
            //}
            return View();
        }

        [HttpGet]
        public ActionResult Public() {
            ViewBag.PublicCourses = GetPublicCourses();
            return View();
        }

        [HttpGet]
        public JsonResult PublicSearch(string keyword) {
            ICourseService service = CourseService.GetInstance<CourseRepository>();
            IEnumerable<CourseReport> res = service.SearchPublic(keyword);

            List<CourseViewModel> models = new List<CourseViewModel>();
            foreach (CourseReport course in res) {
                models.Add(new CourseViewModel(course, true));
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<CourseViewModel> GetPublicCourses() {
            ICourseService service = CourseService.GetInstance<CourseRepository>();
            IEnumerable<CourseReport> res = service.GetPublicCourses();

            List<CourseViewModel> models = new List<CourseViewModel>();
            foreach (CourseReport course in res) {
                models.Add(new CourseViewModel(course));
            }
            return models;
        }

        #region "Private methods for teacher and student dashboards"
        private IEnumerable<CourseViewModel> GetCoursesByStudent(Profile profile) {
            ICourseService service = CourseService.GetInstance<CourseRepository>();
            IEnumerable<CourseReport> res = service.GetCoursesByStudent(profile.Id);

            List<CourseViewModel> models = new List<CourseViewModel>();
            foreach (CourseReport course in res) {
                models.Add(new CourseViewModel(course));
            }
            return models;
        }

        private IEnumerable<CourseViewModel> GetCoursesByTeacher(Profile profile) {
            ICourseService service = CourseService.GetInstance<CourseRepository>();
            IEnumerable<CourseReport> res = service.GetCoursesByTeacherId(profile.Id);

            List<CourseViewModel> models = new List<CourseViewModel>();
            foreach (CourseReport course in res) {
                models.Add(new CourseViewModel(course));
            }
            return models;
        }
        #endregion

        #region "Private Methods for School Dashboard"
        private IEnumerable<ProfileViewModel> GetStudentsBySchool(Profile profile) {
            ISchoolStudentService service = SchoolStudentService.GetInstance<SchoolStudentRepository>();
            IEnumerable<Profile> res = service.GetStudentsBySchoolID(profile.Id);

            List<ProfileViewModel> models = new List<ProfileViewModel>();
            foreach (Profile p in res) {
                models.Add(new ProfileViewModel(p));
            }
            return models;
        }

        private IEnumerable<ProfileViewModel> GetTeachersBySchool(Profile profile) {
            ISchoolTeacherService service = SchoolTeacherService.GetInstance<SchoolTeacherRepository>();
            IEnumerable<Profile> res = service.GetTeachersBySchoolId(profile.Id, "");

            List<ProfileViewModel> models = new List<ProfileViewModel>();
            foreach (Profile p in res) {
                models.Add(new ProfileViewModel(p));
            }
            return models;
        }

        private IEnumerable<CourseViewModel> GetCoursesBySchool(Profile profile) {
            ICourseService courseService = CourseService.GetInstance<CourseRepository>();
            IEnumerable<CourseReport> res = courseService.GetCoursesBySchoolId(profile.Id);

            List<CourseViewModel> models = new List<CourseViewModel>();
            foreach (CourseReport course in  res) {
                models.Add(new CourseViewModel(course));
            }
            return models;
        }
        #endregion
    }
}
