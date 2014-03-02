using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class Whiteboard {
        public int Id { get; set; }
        public string PictureUrl { get; set; }

        public int CourseClassId { get; set; }
        [ForeignKey("CourseClassId")]
        public virtual CourseClass CourseClass { get; set; }
    }
}
