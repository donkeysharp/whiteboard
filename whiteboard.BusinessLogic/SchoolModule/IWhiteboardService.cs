using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface IWhiteboardService:IService<Whiteboard.DataAccess.Models.WhiteboardNote>
    {
        IEnumerable<Whiteboard.DataAccess.Models.WhiteboardNote> GetWhiteboardNotesByClassId(int p);
    }
}
