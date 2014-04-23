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
        public string Description { get; set; }
        public string AboutCourse { get; set; }
        public string Syllabus { get; set; }
        public string Lectures { get; set; }
        public string Language { get; set; }
        public string Schedule { get; set; }
        public string PictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool IsPublic { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual Profile Owner { get; set; }

        public int? OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }

        public class Report : Course {
            public string TeacherName { get; set; }
        }
    }
}
