using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models;

namespace Whiteboard.Web.Controllers {
    [Authorize]
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
    }
}
