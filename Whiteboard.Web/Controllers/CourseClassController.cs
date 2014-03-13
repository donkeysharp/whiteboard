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
        [HttpGet]
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
                bool isOwnerOfClass = courseService.IsTeacherOfCourse(courseClass.CourseId, CurrentProfile.Id);
                if (isOwnerOfClass) {
                    return View("TeacherWhiteboard");
                }
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = Role.ROLE_TEACHER)]
        public ActionResult Start(int courseId) {
            ICourseClassService service = CourseClassService.GetInstance<CourseClassRepository>();
            CourseClass courseClass = service.GetCommingSoonClassByCourseId(courseId);
            if (courseClass != null) {
                courseClass.Broadcasting = true;
                service.Update(courseClass);

                return Json(new { status = "ok", courseClassId = courseClass.Id });
            }
            return Json(new { status = "nok" });
        }

        [HttpPost]
        [Authorize(Roles = Role.ROLE_TEACHER)]
        public ActionResult Finish(int courseClassId) {
            ICourseClassService service = CourseClassService.GetInstance<CourseClassRepository>();
            CourseClass courseClass = service.Get(courseClassId);
            if (courseClass != null) {
                courseClass.Finished = true;
                service.Update(courseClass);
            }
            return Json(new { status = "ok" });
        }
    }
}
