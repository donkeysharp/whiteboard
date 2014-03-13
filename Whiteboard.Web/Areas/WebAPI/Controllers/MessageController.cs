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
        // GET: /api/Foo/
        [HttpGet]
        public JsonResult GetMessages(int courseClassId) {
            IMessageService ms = MessageService.GetInstance<IMessageRepository>();
            var messages = ms.GetMessagesByClassId(courseClassId);
            var data = new List<TemporalMessage>();
            foreach (var item in messages)
            {
                data.Add(new TemporalMessage()
                {
                    user = item.UserName,
                    message = item.Message
                });
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public int Insert(int courseClassId, string username, string message)
        {
            IMessageService ms = MessageService.GetInstance<IMessageRepository>();
            Message item = new Message() { Message = message, UserName = username, CourseClassId = courseClassId };
            return ms.Insert(item).Id;
        }

    }
    public class TemporalMessage
    {
        public string user { get; set; }
        public string message { get; set; }
    }
}
