using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface ICourseStudentService:IService<CourseStudent>
    {
        IEnumerable<Profile> GetStudentsByCourseId(int Id);
        IEnumerable<Course> GetCoursesByStudentId(int Id);

        IEnumerable<CourseStudent.Report> GetCourseStudentsByCourseId(int courseId);

        bool IsStudentInCourse(int courseId, int studentId);
    }
}
