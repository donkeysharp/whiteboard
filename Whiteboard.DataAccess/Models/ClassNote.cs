using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class ClassNote {
        public int Id { get; set; }
        public string Content { get; set; }

        public int CourseClassId { get; set; }
        [ForeignKey("CourseClassId")]
        public virtual CourseClass CourseClass { get; set; }
    }
}
