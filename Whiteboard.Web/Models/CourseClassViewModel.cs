using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Web.Models {
    public class CourseClassViewModel {
        public int Id { get; set; }
        public string Description { get; set; }
        public long BeginTime { get; set; }
        public long EndTime { get; set; }
        public bool Broadcasting { get; set; }
        public bool Finished { get; set; }
    }
}