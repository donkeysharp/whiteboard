using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class WhiteboardService:GenericService<Whiteboard.DataAccess.Models.Whiteboard>,IWhiteboardService
    {
        private WhiteboardService(IWhiteboardRepository da):base(da)
        {

        }
        public static IWhiteboardService GetInstance<T>() where T : IWhiteboardRepository
        {
            IWhiteboardRepository da = (IWhiteboardRepository)Activator.CreateInstance<T>();
            return new WhiteboardService(da);
        }
    }
}
