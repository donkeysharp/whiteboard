using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.Web.Models {
    public class ProfileViewModel {
        public int Id { get; set; }
        [Required(ErrorMessage="Name is required.")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage="Country is required.")]
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
            this.PictureUrl = Path.Combine(Constants.UPLOADS_PATH, profile.PictureUrl);
        }
    }
}