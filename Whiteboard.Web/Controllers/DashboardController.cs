using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using whiteboard.BusinessLogic.OrganizationModule;
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
            if (IsInRole(Whiteboard.DataAccess.Models.Profile.ROLE_COMMON)) {
                int userId = CurrentProfile.Id;
                ViewBag.Attending= GetAttendingCourses(userId);
                ViewBag.Teaching = GetTeachingCourses(userId);
                ViewBag.Organizations = GetOrganizations(userId);
            }
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

        #region "Private Methods for Dashboard"
        private List<Course.Report> GetAttendingCourses(int userId) {
            ICourseService service = CourseService.GetInstance<CourseRepository>();
            
            IEnumerable<Course.Report> res = service.GetAttendingCourses(userId);
            return res as List<Course.Report>;
        }
        private List<Course.Report> GetTeachingCourses(int userId) {
            ICourseService service = CourseService.GetInstance<CourseRepository>();

            IEnumerable<Course.Report> res = service.GetTeachingCourses(userId);
            List<CourseViewModel> models = new List<CourseViewModel>();
            return res as List<Course.Report>;
        }
        private List<Organization.Report> GetOrganizations(int userId) {
            IOrganizationService service = OrganizationService.GetInstance<OrganizationRepository>();

            IEnumerable<Organization.Report> res = service.GetOrganizations(userId);
            return res as List<Organization.Report>;
        }
        #endregion
    }
}
