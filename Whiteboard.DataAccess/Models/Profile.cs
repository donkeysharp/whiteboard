using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class Profile {
        public const string ROLE_ADMIN = "Profile.AdminRole";
        public const string ROLE_COMMON = "Profile.CommonRole";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public string PictureUrl { get; set; }
        public string Role { get; set; }
        public long SignUpDate { get; set; }

        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }

        public class ProfileReport : Profile {
        }
    }
}
