using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface IMessageService : IService<Message>
    {
        IEnumerable<Message> GetMessagesByClassId(int CourseClassId);
    }
}
