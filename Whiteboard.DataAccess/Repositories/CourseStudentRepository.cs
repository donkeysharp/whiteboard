using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public class CourseStudentRepository:GenericRepository<CourseStudent>,ICourseStudentRepository
    {

        public IEnumerable<CourseStudent.Report> GetCourseStudentsByCourseId(int courseId) {
            string sql = @"select cs.*, s.Name as StudentName
from coursestudent cs
inner join profile s on (s.id = cs.StudentId)
where cs.CourseId = {0}
";
            sql = string.Format(sql, courseId);
            return context.Database.SqlQuery<CourseStudent.Report>(sql).ToList();
        }
    }
}
