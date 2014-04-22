using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models
{
    public class ProfileBk
    {
        public const string ROLE_SCHOOL = "Profile.SchoolRole";
        public const string ROLE_TEACHER = "Profile.TeacherRole";
        public const string ROLE_STUDENT = "Profile.StudentRole";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public string PictureUrl { get; set; }
    }
}
