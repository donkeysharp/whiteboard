using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class CourseTeacher {
        public int Id { get; set; }
        
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Profile Teacher { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
