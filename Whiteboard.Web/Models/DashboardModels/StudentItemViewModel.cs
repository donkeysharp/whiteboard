using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Web.Models.DashboardModels
{
    public class StudentItemViewModel
    {
        [JsonProperty("pictureUrl")]
        public string PictureUrl { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}