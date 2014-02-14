using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whiteboard.DataAccess;

namespace Whiteboard.Web.Areas.WebAPI.Controllers {
    public class FooController : Controller {
        // GET: /api/Foo/
        public string Index() {
            var a = Whiteboard.DataAccess.DataBaseContext.Context;
            return "Foo";
        }
    }
}
