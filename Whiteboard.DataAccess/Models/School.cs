using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class School {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
