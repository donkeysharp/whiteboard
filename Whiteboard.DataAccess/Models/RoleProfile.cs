using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class RoleProfile {
        public int Id { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
    }
}
