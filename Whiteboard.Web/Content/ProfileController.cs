using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace Whiteboard.Web.Content {
    [Authorize]
    public class ProfileController : Controller {
        // GET: /Profile/
        public ActionResult Index() {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            Profile profile = service.Get(User.Identity.Name);
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            Profile profile = service.Get(User.Identity.Name);
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            if (file != null && file.ContentLength > 0) {
                string filename = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath(Constants.UPLOADS_PATH), filename);
                FileHelper.CreateFile(path, file.InputStream, true);

                profile.PictureUrl = filename;
                service.Update(profile);
            }
            return RedirectToAction("Index", "Profile");
        }
    }
}
