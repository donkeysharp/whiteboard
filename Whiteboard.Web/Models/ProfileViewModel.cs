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
        // Other properties from other data models (member, school)
        public string LastName { get; set; }
        public string Description { get; set; }
        // For password changing
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public ProfileViewModel() {
        }

        public ProfileViewModel(Profile profile) {
            this.Id = profile.Id;
            this.Name = profile.Name;
            this.Email = profile.Email;
            this.Country = profile.Country;
            this.PictureUrl = profile.PictureUrl;
            this.Role = profile.Role;
        }

        public ProfileViewModel(Profile profile, Member member) {
            this.Id = profile.Id;
            this.Name = profile.Name;
            this.Email = profile.Email;
            this.Country = profile.Country;
            this.PictureUrl = profile.PictureUrl;
            this.Role = profile.Role;
            // Information from member
            this.LastName = member.LastName;
        }

        public ProfileViewModel(Profile profile, School school) {
            this.Id = profile.Id;
            this.Name = profile.Name;
            this.Email = profile.Email;
            this.Country = profile.Country;
            this.PictureUrl = profile.PictureUrl;
            this.Role = profile.Role;
            // Information from school
            this.Description= school.Description;
        }
    }
}