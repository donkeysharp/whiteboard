using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.Web.Models {
    public class RegisterViewModel {
        [Required(ErrorMessage="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage="Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="Passwords doesn\'t match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        public Profile Profile {
            get {
                return new Profile() {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                    Country = Country
                };
            }
        }
    }
}