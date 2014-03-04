using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.ProfileModule;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models.DashboardModels;

namespace Whiteboard.Web.Controllers {
    [Authorize]
    [RouteMap(Title = "Dashboard", Description = "Dashboard Information", Route = "Dashboard, Foo")]
    public class DashboardController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public JsonResult MyCourses() {
            ICourseStudentService courseService = CourseStudentService.GetInstance<CourseStudentRepository>();
            var courses = courseService.GetCoursesByStudentId(CurrentProfile.Id);
            var res = new List<CourseItemViewModel>();
            foreach (var c in courses) {
                res.Add(new CourseItemViewModel() { 
                    Title = c.Title,
                    PictureUrl = c.PictureUrl,
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
                    Title = course.Title,
                    Description = course.Description,
                    PictureUrl = course.PictureUrl
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
                    PictureUrl = item.PictureUrl,
                    Description = item.Description,
                    Title = item.Title,
                    NumberStudents = nroStundents
                });
            }
            //res.Add(new CourseItemViewModel() { 
            //    Title = "title 1",
            //    PictureUrl = "",
            //    Description = "primer curso",
            //    NumberStudents = 23
            //});
            //res.Add(new CourseItemViewModel()
            //{
            //    Title = "title 2",
            //    PictureUrl = "",
            //    Description = "segundo curso",
            //    NumberStudents = 3
            //});
            //res.Add(new CourseItemViewModel()
            //{
            //    Title = "title 1",
            //    PictureUrl = "",
            //    Description = "primer curso",
            //    NumberStudents = 5
            //});
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
                        Description = item.Description,
                        PictureUrl = item.PictureUrl,
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
            var schoolStudents = ssService.getStudentsBySchoolID(CurrentProfile.Id);
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
