using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.ProfileModule;
using whiteboard.BusinessLogic.SchoolModule;
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
    }
}
