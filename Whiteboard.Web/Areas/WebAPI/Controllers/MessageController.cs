using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whiteboard.BusinessLogic.SchoolModule;
using Whiteboard.DataAccess;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace Whiteboard.Web.Areas.WebAPI.Controllers {
    public class MessageController : Controller {
        [HttpGet]
        public JsonResult GetMessages(int courseClassId) {
            IMessageService ms = MessageService.GetInstance<MessageRepository>();
            var messages = ms.GetMessagesByClassId(courseClassId);
            var data = new List<TemporalMessage>();
            foreach (var item in messages)
            {
                data.Add(new TemporalMessage()
                {
                    user = item.UserName,
                    message = item.Content
                });
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Insert(int courseClassId, string username, string message)
        {
            IMessageService ms = MessageService.GetInstance<MessageRepository>();
            Message item = new Message() { Content = message, UserName = username, CourseClassId = courseClassId };
            if (ms.Insert(item) != null)
                return Json(new { status = "ok" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { status = "error" }, JsonRequestBehavior.AllowGet);
        }

    }
    public class TemporalMessage
    {
        public string user { get; set; }
        public string message { get; set; }
    }
}
