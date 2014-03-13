using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class MessageService : GenericService<Message>, IMessageService
    {
        private MessageService(IMessageRepository da):base(da)
        {

        }

        public static IMessageService GetInstance<T>() where T : IMessageRepository
        {
            IMessageRepository da = (IMessageRepository)Activator.CreateInstance<T>();
            return new MessageService(da);
        }

        public IEnumerable<Message> GetMessagesByClassId(int CourseClassId)
        {
            return da.Filter(x => x.CourseClassId == CourseClassId);
        }
    }
}
