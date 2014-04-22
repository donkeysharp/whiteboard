using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models {
    public class Plan {
        public const int FREE_PLAN = 1;
        public const int PREMIUM_PLAN = 2;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
