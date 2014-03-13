using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public string UserName { get; set; }

        public int CourseClassId { get; set; }
        [ForeignKey("CourseClassId")]
        public CourseClass CourseClass { get; set; }

    }
}
