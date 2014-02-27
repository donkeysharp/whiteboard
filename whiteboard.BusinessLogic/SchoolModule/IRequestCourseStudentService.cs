using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface IRequestCourseStudentService:IService<RequestCourseStudent>
    {
        IEnumerable<RequestCourseStudent> GetByCourseId(int id);
        IEnumerable<RequestCourseStudent> GetByTeacherId(int id);
    }
}
