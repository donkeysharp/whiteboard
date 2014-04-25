using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.OrganizationModule;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;
using Whiteboard.Web.Models.OrganizationModels;

namespace Whiteboard.Web.Controllers {
    public class OrganizationController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            ViewData["Errors"] = TempData["Errors"] ?? new List<ModelError>();
            return View();
        }

        [HttpGet]
        public ActionResult Edit() {
            ViewData["Errors"] = TempData["Errors"] ?? new List<ModelError>();
            return View(new OrganizationViewModel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(OrganizationViewModel model) {
            IOrganizationService service = OrganizationService.GetInstance<OrganizationRepository>();
            Organization orgTemp = service.Get(model.Name);

            if (orgTemp != null) {
                // TODO: Already exists an organization with that name
            }

            Organization organization = model.ToModel();
            if (organization.Id > 0) {
                service.Update(organization);
            } else {
                organization = service.Insert(organization);
            }
            ViewBag.Organization = organization;

            return View();
        }
    }
}
