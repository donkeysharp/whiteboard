using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace Whiteboard.Web.Controllers {
    public class BaseController : Controller {
        private Profile currentProfile = null;

        protected Profile CurrentProfile {
            get {
                if (currentProfile == null) {
                    IProfileService service = ProfileService.GetInstance<ProfileRepository>();
                    currentProfile = service.Get(User.Identity.Name);
                }
                return currentProfile;
            }
        }

        protected ActionResult RedirectToHash(string controllerName, string action, string hash) {
            return Redirect(Url.RouteUrl(new { controller = controllerName, action = action }) + "#" + hash);
        }

        protected string UploadFile(HttpPostedFileBase file, string defaultName) {
            string filename;
            if (file != null && file.ContentLength > 0) {
                filename = Guid.NewGuid().ToString() + "." + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath(Constants.UPLOADS_PATH), filename);
                FileHelper.CreateFile(path, file.InputStream, true);
            } else {
                filename = defaultName;
            }
            return filename;
        }
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext) {

            if (Request.IsAuthenticated) {
                Profile profile = CurrentProfile;
                ViewBag.ProfileData = profile;
            }
            base.OnActionExecuted(filterContext);
        }

        protected bool IsInRole(string roleName) {
            return CurrentProfile.Role.Equals(roleName);
        }
        #region "Protected Methods"
        protected List<SelectListItem> GetCountries(string selectedCountry = null) {
            var result = (from c in Whiteboard.Common.Geo.Regions.GetCountries()
                          select new SelectListItem() {
                              Text = c.Name, Value = c.Code, Selected = c.Code.Equals(selectedCountry)
                          }).ToList();

            result.Insert(0, new SelectListItem() {
                Text = "--- Select your country ---",
                Value = ""
            });
            return result;
        }

        protected Profile GetProfile() {
            if (Request.IsAuthenticated) {
                IProfileService service = ProfileService.GetInstance<ProfileRepository>();
                return service.Get(User.Identity.Name);
            }
            return null;
        }
        #endregion
    }
}