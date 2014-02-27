using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models
{
    public class Role
    {
        public const string ROLE_SCHOOL = "Profile.SchoolRole";
        public const string ROLE_TEACHER = "Profile.TeacherRole";
        public const string ROLE_STUDENT = "Profile.StudentRole";

        public int Id { get; set; }
        public string Value { get; set; }
    }
}
