using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whiteboard.Web.Models {
    public class RegisterViewModel {
        [Required(ErrorMessage="Name is required.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
    }
}