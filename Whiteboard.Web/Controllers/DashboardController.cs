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
using Whiteboard.Web.Models.DashboardModels;

namespace Whiteboard.Web.Controllers {
    [Authorize]
    public class DashboardController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            if (IsInRole(Role.ROLE_SCHOOL)) {
                // Profile will always have a school role, so no problem when calling this method
                ViewBag.OurCourses = GetCoursesBySchool(CurrentProfile);
                ViewBag.OurTeachers = GetTeachersBySchool(CurrentProfile);
                ViewBag.OurStudents = GetStudentsBySchool(CurrentProfile);
            } else if (IsInRole(Role.ROLE_TEACHER)) {
                ViewBag.MyCourses = null;
            } else if (IsInRole(Role.ROLE_STUDENT)) {
                ViewBag.MyCourses = null;
            }
            return View();
        }

        private IEnumerable<Profile> GetStudentsBySchool(Profile profile) {
            ISchoolStudentService service = SchoolStudentService.GetInstance<SchoolStudentRepository>();
            return service.GetStudentsBySchoolID(profile.Id);
        }

        private IEnumerable<Profile> GetTeachersBySchool(Profile profile) {
            ISchoolTeacherService service = SchoolTeacherService.GetInstance<SchoolTeacherRepository>();
            return service.GetTeachersBySchoolId(profile.Id, "");
        }

        private IEnumerable<CourseReport> GetCoursesBySchool(Profile profile) {
            ICourseService courseService = CourseService.GetInstance<CourseRepository>();
            return courseService.GetCoursesBySchoolId(profile.Id);
        }

        [HttpGet]
        public JsonResult MyCourses() {
            ICourseStudentService courseService = CourseStudentService.GetInstance<CourseStudentRepository>();
            var courses = courseService.GetCoursesByStudentId(CurrentProfile.Id);
            var res = new List<CourseItemViewModel>();
            foreach (var c in courses) {
                res.Add(new CourseItemViewModel() { 
                    Id = c.Id,
                    Title = c.Title,
                    PictureUrl = Path.Combine(Constants.UPLOADS_PATH_RELATIVE, c.PictureUrl),
                    Description = c.Description
                });
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListCourses() {
            ICourseService courseService = CourseService.GetInstance<CourseRepository>();
            IEnumerable<Course> courses = courseService.GetPublicCourses();
            List<CourseItemViewModel> res = new List<CourseItemViewModel>();
            foreach (Course course in courses) {
                res.Add(new CourseItemViewModel() {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description,
                    PictureUrl = Path.Combine(Constants.UPLOADS_PATH_RELATIVE, course.PictureUrl),
                });
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCoursesInformation()
        {
            ICourseTeacherService courseService = CourseTeacherService.GetInstance<CourseTeacherRepository>();
            ICourseStudentService studentService = CourseStudentService.GetInstance<CourseStudentRepository>();
            var teacherCourses = courseService.GetCoursesByTeacherID(CurrentProfile.Id);
            List<CourseItemViewModel> res = new List<CourseItemViewModel>();
            foreach (var item in teacherCourses)
            {
                int nroStundents = studentService.GetStudentsByCourseId(item.Id).Count();
                res.Add(new CourseItemViewModel()
                {
                    Id = item.Id,
                    PictureUrl = Path.Combine(Constants.UPLOADS_PATH_RELATIVE, item.PictureUrl),
                    Description = item.Description,
                    Title = item.Title,
                    NumberStudents = nroStundents
                });
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Return school courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles=Role.ROLE_SCHOOL)]
        public JsonResult Courses()
        {
            ISchoolCourseService scService = SchoolCourseService.GetInstance<SchoolCourseRepository>();
            var courses = scService.getCoursesBySchoolId(CurrentProfile.Id);
            var res = new List<CourseItemViewModel>();
            foreach (var item in courses)
            {
                res.Add(new CourseItemViewModel()
                    {
                        Id = item.Id,
                        Description = item.Description,
                        PictureUrl = Path.Combine(Constants.UPLOADS_PATH_RELATIVE, item.PictureUrl),
                        Title = item.Title
                    });
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Return school teachers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Teachers()
        {
            ISchoolTeacherService stService = SchoolTeacherService.GetInstance<SchoolTeacherRepository>();
            var schoolTeachers = stService.GetStudentsBySchoolId(CurrentProfile.Id);
            List<TeacherItemViewModel> res = new List<TeacherItemViewModel>();
            foreach (var item in schoolTeachers)
            {
                res.Add(new TeacherItemViewModel()
                {
                    Name=item.Name,
                    PictureUrl=item.PictureUrl
                });
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Return school students
        /// </summary>
        [HttpGet]
        public JsonResult Students()
        {
            ISchoolStudentService ssService = SchoolStudentService.GetInstance<SchoolStudentRepository>();
            var schoolStudents = ssService.GetStudentsBySchoolID(CurrentProfile.Id);
            var res = new List<StudentItemViewModel>();
            foreach (var item in schoolStudents)
            {
                res.Add(new StudentItemViewModel()
                {
                    PictureUrl = item.PictureUrl,
                    Name = item.Name
                });
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
