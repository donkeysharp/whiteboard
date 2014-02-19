using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class RequestSchoolMember {
        public const int REQUEST_STUDENT = 0;
        public const int REQUEST_TEACHER = 1;

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int SchoolId { get; set; }
        public int RequestType { get; set; }
    }
}
