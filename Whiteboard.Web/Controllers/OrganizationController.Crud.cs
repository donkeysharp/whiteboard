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
    public partial class OrganizationController : BaseController {
        [HttpGet]
        public ActionResult Index(int id = 0) {
            if (id == 0) {
                return View();
            } else {
                IOrganizationService service = OrganizationService.GetInstance<OrganizationRepository>();
                Organization organization = service.Get(id);
                if (organization != null) {
                    // Check whether or not user is organization's admin
                    IOrganizationAdminService adminService = OrganizationAdminService.GetInstance<OrganizationAdminRepository>();
                    ViewBag.IsOrganizationAdmin = adminService.IsAdmin(CurrentProfile.Id, organization.Id);

                    ICourseService courseService = CourseService.GetInstance<CourseRepository>();
                    ViewBag.OrganizationCourses = courseService.GetCoursesByOrganization(organization.Id);

                    OrganizationViewModel model = new OrganizationViewModel(organization);
                    return View("Detail", model);
                } else {
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult Edit(int id = 0) {
            IOrganizationService service = OrganizationService.GetInstance<OrganizationRepository>();
            IOrganizationAdminService adminService = OrganizationAdminService.GetInstance<OrganizationAdminRepository>();
            bool isAdmin = adminService.IsAdmin(CurrentProfile.Id, id);

            if (!isAdmin) {
                return RedirectToAction("Index", "Organization", new { id = id });
            }

            Organization organization = service.Get(id);
            OrganizationViewModel model;
            if (organization != null) {
                model = new OrganizationViewModel(organization);
            } else {
                model = TempData["OrganizationViewModel"] as OrganizationViewModel ?? new OrganizationViewModel();
            }
            ViewData["Errors"] = TempData["Errors"] ?? new List<ModelError>();

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(OrganizationViewModel model, HttpPostedFileBase file) {
            IOrganizationService service = OrganizationService.GetInstance<OrganizationRepository>();
            Organization organization;
            TempData["OrganizationModel"] = model;


            if (!ModelState.IsValid) {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                if (model.Id > 0) {
                    return RedirectToAction("Edit", "Organization", new { id = model.Id });
                } else {
                    return RedirectToAction("Edit", "Organization");
                }
            }
            organization = service.Get(model.Name);
            if (organization != null && model.Id != organization.Id) {
                ModelState.AddModelError("ModelExists", "Organization already exists");
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                if (model.Id > 0) {
                    return RedirectToAction("Edit", "Organization", new { id = model.Id });
                } else {
                    return RedirectToAction("Edit", "Organization");
                }
            }

            organization = service.Get(model.Id);

            if (model.Id > 0) {
                organization.Id = model.Id;
                organization.Name = model.Name;
                organization.WebSite = model.WebSite;
                organization.Email = model.Email;
                organization.Description = model.Description;
                if (file != null) {
                    organization.PictureUrl = UploadFile(file, "course.png");
                }

                service.Update(organization);
            } else {
                organization = model.ToModel();
                organization.PictureUrl = UploadFile(file, "course.png");

                organization = service.Insert(organization);
                AddOrganizationAdmin(organization.Id);
            }
            ViewBag.Organization = organization;

            return RedirectToAction("Edit", "Organization", new { id = organization.Id });
        }

        #region "Private Methods"
        private void AddOrganizationAdmin(int organizationId) {
            IOrganizationAdminService service = OrganizationAdminService.GetInstance<OrganizationAdminRepository>();
            OrganizationAdmin oaObj = new OrganizationAdmin();
            oaObj.OrganizationId = organizationId;
            oaObj.ProfileId = CurrentProfile.Id;

            service.Insert(oaObj);
        }
        #endregion
    }
}
