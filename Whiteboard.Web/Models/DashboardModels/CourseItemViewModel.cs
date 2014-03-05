using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Web.Models.DashboardModels {
    public class CourseItemViewModel {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "pictureUrl")]
        public string PictureUrl { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        public int NumberStudents { get; set; }
    }
}