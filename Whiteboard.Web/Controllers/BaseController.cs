using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace Whiteboard.Web.Controllers {
    public class RouteMapAttribute : Attribute {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public string[] RouteList { get; set; }

        public RouteMapAttribute() {
            Title = "Blank Page";
            Description = "For Customization";
            Route = "Dashboard, BlankPage";
            RouteList = new string[] { "Dashboard" };
        }
    }

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

                //Type t = this.GetType();
                //object[] attributes = t.GetCustomAttributes(true);

                //ViewBag.RouteMap = new RouteMapAttribute();
                //foreach (var o in attributes) {
                //    Trace.TraceInformation(o.GetType().Name);
                //    if (o is RouteMapAttribute) {
                //        var attrib = o as RouteMapAttribute;
                //        attrib.RouteList = attrib.Route.Split(new char[] { ',', ' ' });
                //        ViewBag.RouteMap = attrib;
                //    }
                //}
            }
            base.OnActionExecuted(filterContext);
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