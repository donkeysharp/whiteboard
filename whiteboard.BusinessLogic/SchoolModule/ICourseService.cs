using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface ICourseService:IService<Course>
    {
        IEnumerable<Course> Search(string data);

        IEnumerable<CourseReport> GetPublicCourses();

        IEnumerable<CourseReport> GetCoursesBySchoolId(int schoolId);

        CourseReport GetCourseReport(int id);

        IEnumerable<CourseReport> GetCoursesByTeacherId(int id);

        IEnumerable<CourseReport> GetCoursesByStudent(int id);

        IEnumerable<CourseReport> SearchPublic(string keyword);

        bool IsTeacherOfCourse(int courseId, int teacherId);

        IEnumerable<Course.Report> GetAttendingCourses(int userId);

        IEnumerable<Course.Report> GetTeachingCourses(int userId);

        IEnumerable<Course.Report>  GetCoursesByOrganization(int organizationId);
    }
}
