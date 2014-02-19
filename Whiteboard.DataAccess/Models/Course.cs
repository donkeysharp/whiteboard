using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class Course {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Schedule { get; set; }
        public bool OnAir { get; set; }
        public bool Public { get; set; }

        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual School School { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Member Teacher { get; set; }
    }
}
