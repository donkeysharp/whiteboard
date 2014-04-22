using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Reports {
    public class CourseReport {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AboutCourse { get; set; }
        public string Syllabus { get; set; }
        public string Lectures { get; set; }
        public string Schedule { get; set; }
        public string PictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool IsPublic { get; set; }
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }
    }
}
