using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class Organization {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string PictureUrl { get; set; }

        public class Report : Organization {
            public int AdminId { get; set; }
            public string AdminName { get; set; }
        }
    }
}
