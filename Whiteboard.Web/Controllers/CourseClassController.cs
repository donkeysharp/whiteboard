using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace Whiteboard.Web.Controllers {
    [Authorize]
    public class CourseClassController : BaseController {
        CourseClass courseClass = null;
        [HttpGet]
        public ActionResult Index(int id) {
            ICourseClassService service = CourseClassService.GetInstance<CourseClassRepository>();
            courseClass = service.Get(id);
            if (courseClass == null || id == 0) {
                return RedirectToHash("Dashboard", "Index", "dashboard");
            }
            ViewBag.CourseClassId = courseClass.Id;
            ViewBag.ClassUserName = CurrentProfile.Name;

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
                if (isOwnerOfClass && courseClass.Broadcasting) {
                    return View("TeacherWhiteboard");
                }
            }
            IWhiteboardService whiteboardService = WhiteboardService.GetInstance<WhiteboardRepository>();
            IEnumerable<WhiteboardNote> notes = whiteboardService.GetWhiteboardNotesByClassId(courseClass.Id);
            ViewBag.WhiteboardNotes = notes;

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
                courseClass.Broadcasting = false;
                courseClass.Finished = true;
                service.Update(courseClass);
            }
            return Json(new { status = "ok" });
        }

        [HttpPost]
        public ActionResult UploadImage(string data, int courseClassId) {
            byte[] byteArray = System.Convert.FromBase64String(data);
            string filename = Guid.NewGuid().ToString() + ".png";

            using(MemoryStream ms = new MemoryStream(byteArray)) {
                string path = Path.Combine(Server.MapPath(Constants.UPLOADS_PATH), filename);

                FileHelper.CreateFile(path, ms, true);
            }

            IWhiteboardService service = WhiteboardService.GetInstance<WhiteboardRepository>();

            WhiteboardNote whiteboardNote = new WhiteboardNote();
            whiteboardNote.CourseClassId = courseClassId;
            whiteboardNote.PictureUrl = filename;

            service.Insert(whiteboardNote);

            return Json(new { status = "ok" });
        }
    }
}
