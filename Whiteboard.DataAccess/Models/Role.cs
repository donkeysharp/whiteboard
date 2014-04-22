using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class Role {
        // In order to access its id values in order
        public enum Roles {
            School = 1,
            Teacher = 2,
            Student = 3
        }
        public const string ROLE_SCHOOL = "Profile.SchoolRole";
        public const string ROLE_TEACHER = "Profile.TeacherRole";
        public const string ROLE_STUDENT = "Profile.StudentRole";

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
