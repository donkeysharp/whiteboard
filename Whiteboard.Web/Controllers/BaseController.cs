using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using whiteboard.BusinessLogic.ProfileModule;
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
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext) {

            if (Request.IsAuthenticated) {
                Profile profile = CurrentProfile;
                ViewBag.ProfileData = profile;
            }
            base.OnActionExecuted(filterContext);
        }

        private string[] userRoles = null;
        protected bool IsInRole(string roleName) {
            if (userRoles == null) {
                userRoles = Roles.GetRolesForUser(User.Identity.Name);
            }
            return userRoles.Where(x => x.Equals(roleName)).Count() > 0;
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