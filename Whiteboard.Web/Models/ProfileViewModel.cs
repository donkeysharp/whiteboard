using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.Web.Models {
    public class ProfileViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string PictureUrl { get; set; }
        public string Role { get; set; }

        public ProfileViewModel(Profile profile) {
            this.Id = profile.Id;
            this.Name = profile.Name;
            this.Email = profile.Email;
            this.Country = profile.Country;
            this.PictureUrl = profile.PictureUrl;
            this.Role = profile.Role;
        }
    }
}