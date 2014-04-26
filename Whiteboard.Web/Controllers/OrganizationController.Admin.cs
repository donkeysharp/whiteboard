using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.OrganizationModule;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models.OrganizationModels;

namespace Whiteboard.Web.Controllers {
    public partial class OrganizationController {
        [HttpGet]
        public ActionResult Admin(int id = 0) {
            IOrganizationService service = OrganizationService.GetInstance<OrganizationRepository>();
            IOrganizationAdminService adminService = OrganizationAdminService.GetInstance<OrganizationAdminRepository>();
            bool isAdmin = adminService.IsAdmin(CurrentProfile.Id, id);

            if (id == 0 || !isAdmin) {
                return RedirectToAction("Index", "Organization");
            }
            Organization organization = service.Get(id);
            OrganizationViewModel model = new OrganizationViewModel(organization);

            return View(model);
        }
    }
}
