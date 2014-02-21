using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Whiteboard.Web.Controllers {
    public class BaseController : Controller {

        #region "Protected Methods"
        protected List<SelectListItem> GetCountries() {
            var result = (from c in Whiteboard.Common.Geo.Regions.GetCountries()
                          select new SelectListItem() {
                              Text = c.Name, Value = c.Code
                          }).ToList();

            result.Insert(0, new SelectListItem() {
                Text = "--- Select your country ---",
                Value = ""
            });
            return result;
        }
        #endregion
    }
}