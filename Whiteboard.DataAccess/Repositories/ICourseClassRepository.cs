using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public interface ICourseClassRepository:IRepository<CourseClass>
    {
        IEnumerable<CourseClass> GetClassesByCourseId(int courseId);
    }
}
