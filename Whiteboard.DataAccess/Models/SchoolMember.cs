using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class SchoolMember {
        public int Id { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }
    }
}
