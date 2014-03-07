using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.Web.Models {
    public class CourseViewModel {
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

        public CourseViewModel() {

        }

        public CourseViewModel(Course course) {
            this.Id = course.Id;
            this.Title = course.Title;
            this.Description = course.Description;
            this.Syllabus = course.Syllabus;
            this.AboutCourse = course.AboutCourse;
            this.Lectures = course.Lectures;
            this.Schedule = course.Schedule;
            this.PictureUrl = Path.Combine(Constants.UPLOADS_PATH, course.PictureUrl);
            this.VideoUrl = course.VideoUrl;
            this.IsPublic = course.IsPublic;
        }
    }
}