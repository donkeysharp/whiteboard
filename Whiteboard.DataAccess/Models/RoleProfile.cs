using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models
{
    public class RoleProfile
    {
        public int Id { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        public int ProfileID { get; set; }
        [ForeignKey("ProfileID")]
        public Profile Profile { get; set; }
    }
}
