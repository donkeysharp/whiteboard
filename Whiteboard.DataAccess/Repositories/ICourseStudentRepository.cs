using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public interface ICourseStudentRepository : IRepository<CourseStudent>
    {

        IEnumerable<CourseStudent.Report> GetCourseStudentsByCourseId(int courseId);
    }
}
