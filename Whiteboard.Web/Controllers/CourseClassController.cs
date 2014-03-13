using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace Whiteboard.Web.Controllers {
    [Authorize]
    public class CourseClassController : BaseController {
        public ActionResult Index(int id) {
            ICourseClassService service = CourseClassService.GetInstance<CourseClassRepository>();
            CourseClass courseClass = service.Get(id);
            if (courseClass == null || id == 0) {
                return RedirectToHash("Dashboard", "Index", "dashboard");
            }
            if (IsInRole(Role.ROLE_STUDENT)) {
                if (courseClass.Broadcasting) {
                    ICourseStudentService courseStudentService = CourseStudentService.GetInstance<CourseStudentRepository>();
                    if (courseStudentService.IsStudentInCourse(courseClass.CourseId, CurrentProfile.Id)) {
                        return View("StudentWhiteboard");
                    }
                }
            } else if (IsInRole(Role.ROLE_TEACHER)) {
                ICourseService courseService = CourseService.GetInstance<CourseRepository>();
                bool res = courseService.IsTeacherOfCourse(courseClass.CourseId, CurrentProfile.Id);
                if (res) {
                    return View("TeacherWhiteboard");
                }
            }
            return View();
        }
    }
}
