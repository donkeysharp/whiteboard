using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whiteboard.DataAccess;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.Web.Areas.WebAPI.Controllers {
    public class FooController : Controller {
        // GET: /api/Foo/
        public JsonResult Index() {
            Message message=new Message()
            {
                Id=12312312,
                CourseId=1,
                SenderId=2
            };
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }
}
