using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;

namespace Whiteboard.DataAccess.Repositories {
    public class CourseRepository : GenericRepository<Course>, ICourseRepository 
    {

        public IEnumerable<CourseReport> GetCoursesBySchoolId(int schoolId) {
            string sql = string.Format(@"select c.*, ifnull(t.Name,'No Teacher') as TeacherName
from course as c
left join courseteacher as ct on (ct.CourseId = c.Id)
left join profile as t on (t.id = ct.TeacherId)
where c.SchoolId = {0}", schoolId);

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            return result;
        }


        public CourseReport GetCourseReport(int id) {
            string sql = string.Format(@"select c.*, t.name as TeacherName, ifnull(t.Id,0) as TeacherId
from course as c
left join courseteacher as cs on (cs.CourseId = c.Id)
left join profile as t on (t.id = cs.TeacherId)
where c.id = {0}", id);

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            return result[0];
        }
    }
}
