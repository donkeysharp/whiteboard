using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models;

namespace Whiteboard.Web.Controllers {
    [Authorize()]
    public class CourseController : BaseController {
        [HttpGet]
        public ActionResult Index(int id = 0) {
            ICourseService courseService = CourseService.GetInstance<CourseRepository>();
            Course course = courseService.Get(id);
            if (id == 0 || course == null) {
                // If no id specified, redirect to profile's dashboard
                return RedirectToHash("Dashboard", "Index", "dashboard");
            }
            CourseViewModel model = new CourseViewModel(course);
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles=Role.ROLE_SCHOOL)]
        public ActionResult List() {
            ICourseService service = CourseService.GetInstance<CourseRepository>();
            List<CourseReport> courses = service.GetCoursesBySchoolId(CurrentProfile.Id) as List<CourseReport>;
            ViewBag.Courses = courses;
            return View();
        }
        [HttpGet]
        [Authorize(Roles=Role.ROLE_SCHOOL + "," + Role.ROLE_TEACHER)]
        public ActionResult Edit(int id = 0) {
            ICourseService courseService = CourseService.GetInstance<CourseRepository>();
            CourseReport course = courseService.GetCourseReport(id);
            CourseViewModel model = TempData["CourseModel"] as CourseViewModel ?? new CourseViewModel();
            if (course != null) {
                model = new CourseViewModel(course);
            }
            ViewData["Errors"] = TempData["Errors"] ?? new List<ModelError>();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles=Role.ROLE_SCHOOL + "," + Role.ROLE_TEACHER)]
        [ValidateInput(false)]
        public ActionResult Edit(CourseViewModel model, HttpPostedFileBase file) {
            if (!ModelState.IsValid || model.TeacherId < 1) {
                TempData["CourseModel"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
            }
            ICourseService courseService = CourseService.GetInstance<CourseRepository>();
            ICourseTeacherService courseTeacherService = CourseTeacherService.GetInstance<CourseTeacherRepository>();
            Course course = model.Id == 0 ? new Course() : courseService.Get(model.Id);
            course.Title = model.Title;
            course.Description = model.Description;
            course.AboutCourse = model.AboutCourse;
            course.Syllabus = model.Syllabus;
            course.Lectures = model.Lectures;
            course.IsPublic = model.IsPublic;

            if (file != null && file.ContentLength > 0) {
                string filename = Guid.NewGuid().ToString() + "." + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath(Constants.UPLOADS_PATH), filename);
                FileHelper.CreateFile(path, file.InputStream, true);

                course.PictureUrl = filename;
            }

            if (model.Id == 0) {
                course = courseService.Insert(course);
            } else {
                courseService.Update(course);
            }

            CourseTeacher courseTeacher = new CourseTeacher();
            courseTeacher.CourseId = course.Id;
            courseTeacher.TeacherId = model.TeacherId;
            courseTeacherService.Insert(courseTeacher);

            return RedirectToAction("Edit", "Course", new { id = course.Id });
        }
        [HttpGet]
        public ActionResult Teachers(string query) {
            ISchoolTeacherService schoolTeacherService = SchoolTeacherService.GetInstance<SchoolTeacherRepository>();
            IEnumerable<Profile> teachers = schoolTeacherService.GetTeachersBySchoolId(CurrentProfile.Id, query);
            List<object> res = new List<object>();
            foreach (Profile profile in teachers) {
                res.Add(new {
                    data = profile.Id,
                    value = profile.Name
                });
            }
            var obj = new {
                suggestions = res
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}
