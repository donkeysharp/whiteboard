using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class RequestSchoolMember {
        public const string REQUEST_STUDENT = "Request.Student";
        public const string REQUEST_TEACHER = "Request.Teacher";

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int SchoolId { get; set; }
        public string RequestType { get; set; }
    }
}
