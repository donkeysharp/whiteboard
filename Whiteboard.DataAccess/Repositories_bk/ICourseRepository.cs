using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;

namespace Whiteboard.DataAccess.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        // search by date or get date when Course date updated
        IEnumerable<CourseReport> GetCoursesBySchoolId(int schoolId);
        CourseReport GetCourseReport(int id);

        IEnumerable<CourseReport> GetCoursesByTeacherId(int id);

        IEnumerable<CourseReport> GetCoursesByStudentId(int id);

        IEnumerable<CourseReport> GetPublicCourses();

        IEnumerable<CourseReport> SearchPublic(string keyword);

        bool IsTeacherOfCourse(int courseId, int teacherId);

        IEnumerable<Course.Report> GetAttendingCourses(int userId);

        IEnumerable<Course.Report> GetTeachingCourses(int userId);

        IEnumerable<Course.Report> GetCoursesByOrganization(int organizationId);
    }
}
