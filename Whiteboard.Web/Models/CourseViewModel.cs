using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;

namespace Whiteboard.Web.Models {
    public class CourseViewModel {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string AboutCourse { get; set; }
        [AllowHtml]
        public string Syllabus { get; set; }
        [AllowHtml]
        public string Lectures { get; set; }
        public string Schedule { get; set; }
        public string PictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool IsPublic { get; set; }
        public string Teacher { get; set; }
        [Required(ErrorMessage="Teacher must be filled")]
        public int TeacherId { get; set; }

        public CourseViewModel() {
            Title = string.Empty;
            Description = string.Empty;
            AboutCourse = string.Empty;
            Syllabus = string.Empty;
            Lectures = string.Empty;
            Schedule = string.Empty;
            VideoUrl = string.Empty;
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

        public CourseViewModel(CourseReport course) {
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
            this.Teacher = course.TeacherName;
            this.TeacherId = course.TeacherId;
        }

        public IEnumerable<CourseClassViewModel> CourseClasses { get; set; }
    }
}