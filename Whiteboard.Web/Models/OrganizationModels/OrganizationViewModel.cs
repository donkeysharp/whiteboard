using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.Web.Models.OrganizationModels {
    public class OrganizationViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public OrganizationViewModel() {
        }

        public OrganizationViewModel(Organization org) {
            this.Id = org.Id;
            this.Name = org.Name;
            this.WebSite = org.WebSite;
            this.Email = org.Email;
            this.Description = org.Description;
            this.PictureUrl = org.PictureUrl;
        }

        internal Organization ToModel() {
            return new Organization() { 
                Id = Id,
                Name = Name,
                WebSite = WebSite,
                Email = Email,
                Description = Description,
                PictureUrl = PictureUrl
            };
        }
    }
}