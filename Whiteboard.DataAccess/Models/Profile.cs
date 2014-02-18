using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class Profile {
        public const int ROLE_SCHOOL = 0;
        public const int ROLE_TEACHER = 1;
        public const int ROLE_STUDENT = 2;

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public int Role { get; set; }
    }
}
