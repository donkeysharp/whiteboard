using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.Web.Models {
    public class CourseClassViewModel {
        public int Id { get; set; }
        public string Description { get; set; }
        public long BeginTime { get; set; }
        public long EndTime { get; set; }
        public bool Broadcasting { get; set; }
        public bool Finished { get; set; }

        public CourseClassViewModel() {

        }

        public CourseClassViewModel(CourseClass cc) {
            Id = cc.Id;
            Description = cc.Description;
            BeginTime = cc.BeginTime;
            EndTime = cc.EndTime;
            Broadcasting = cc.Broadcasting;
            Finished = cc.Finished;
        }
    }
}