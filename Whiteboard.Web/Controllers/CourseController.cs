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
        [Authorize(Roles = Role.ROLE_SCHOOL)]
        public ActionResult List() {
            ICourseService service = CourseService.GetInstance<CourseRepository>();
            List<CourseReport> courses = service.GetCoursesBySchoolId(CurrentProfile.Id) as List<CourseReport>;
            ViewBag.Courses = courses;
            return View();
        }

        [HttpGet]
        [Authorize(Roles = Role.ROLE_SCHOOL + "," + Role.ROLE_TEACHER)]
        public ActionResult Edit(int id = 0) {
            ICourseService courseService = CourseService.GetInstance<CourseRepository>();
            CourseReport course = courseService.GetCourseReport(id);
            CourseViewModel model = TempData["CourseModel"] as CourseViewModel ?? new CourseViewModel();
            if (course != null) {
                model = new CourseViewModel(course);
                ICourseClassService courseClassService = CourseClassService.GetInstance<CourseClassRepository>();
                IEnumerable<CourseClass> courseClasses = courseClassService.GetClassesByCourseId(course.Id);
                List<CourseClassViewModel> courseClassModels = new List<CourseClassViewModel>();
                foreach (CourseClass cc in courseClasses) {
                    courseClassModels.Add(new CourseClassViewModel() {
                        Id = cc.Id,
                        Description = cc.Description,
                        BeginTime = cc.BeginTime,
                        EndTime = cc.EndTime,
                        Finished = cc.Finished,
                        Broadcasting = cc.Broadcasting
                    });
                }
                model.CourseClasses = courseClassModels;
            }
            ViewData["Errors"] = TempData["Errors"] ?? new List<ModelError>();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Role.ROLE_SCHOOL + "," + Role.ROLE_TEACHER)]
        [ValidateInput(false)]
        public ActionResult Edit(CourseViewModel model, HttpPostedFileBase file) {
            if (!ModelState.IsValid || model.TeacherId == 0) {
                TempData["CourseModel"] = model;
                if (model.TeacherId == 0) {
                    ModelState.AddModelError("NoTeacher", "You must specify a teacher.");
                }
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                if (model.Id > 0) {
                    return RedirectToAction("Edit", "Course", new { id = model.Id });
                } else {
                    return RedirectToAction("Edit", "Course");
                }
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
            if (course.SchoolId == 0) {
                course.SchoolId = CurrentProfile.Id;
            }

            string filename;
            if (file != null && file.ContentLength > 0) {
                filename = Guid.NewGuid().ToString() + "." + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath(Constants.UPLOADS_PATH), filename);
                FileHelper.CreateFile(path, file.InputStream, true);


            } else {
                filename = "class_default.jpg";
            }

            course.PictureUrl = filename;

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
        [HttpPost]
        public ActionResult AddClass(int courseId, string description, long beginTime, long endTime) {
            ICourseClassService courseClassService = CourseClassService.GetInstance<CourseClassRepository>();
            CourseClass courseClass = new CourseClass();
            courseClass.CourseId = courseId;
            courseClass.Description = description;
            courseClass.Finished = false;
            courseClass.Broadcasting = false;
            courseClass.BeginTime = beginTime;
            courseClass.EndTime = endTime;

            courseClass = courseClassService.Insert(courseClass);

            return Json(new { status = "ok", id = courseClass.Id, begin = beginTime, end = endTime, description = description });
        }
        [HttpPost]
        public ActionResult DeleteClass(int classId) {
            ICourseClassService courseClassService = CourseClassService.GetInstance<CourseClassRepository>();
            CourseClass courseClass = courseClassService.Get(classId);
            if (courseClass != null) {
                courseClassService.Delete(courseClass);   
            }
            return Json(new { status = "ok" });
        }
    }
}
