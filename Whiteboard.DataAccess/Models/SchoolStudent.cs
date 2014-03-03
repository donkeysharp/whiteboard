using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class SchoolStudent {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual Profile School { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Profile Student { get; set; }
    }
}
