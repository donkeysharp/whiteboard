using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface ICourseService : IService<Course>
    {
        IEnumerable<Course> GetSortedBy(CourseTypes type);
        IEnumerable<Course> Search(string data);
        IEnumerable<Course> GetBySchoolId(int id);
        IEnumerable<Course> GetByTeacherId(int id);
    }
}
