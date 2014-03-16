using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whiteboard.DataAccess.Models;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.DataAccess.Repositories;

namespace Whiteboard.Web.Controllers {
    [Authorize(Roles=Role.ROLE_SCHOOL)]
    public class SchoolManagerController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public JsonResult Students(string query) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            IEnumerable<Profile> students = service.FilterStudents(CurrentProfile.Id, query);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
