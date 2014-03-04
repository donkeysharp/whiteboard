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
        public JsonResult GetCoursesInformation() {
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
    }
}
