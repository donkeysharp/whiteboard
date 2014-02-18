using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class StudentSchool {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SchoolId { get; set; }
    }
}
