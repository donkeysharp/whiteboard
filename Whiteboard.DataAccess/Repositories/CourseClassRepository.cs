using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public class CourseClassRepository:GenericRepository<CourseClass>,ICourseClassRepository
    {
        public IEnumerable<CourseClass> GetClassesByCourseId(int courseId) {
            string sql = @"select * from courseclass where courseId = {0}";
            sql = string.Format(sql, courseId);
            return context.Database.SqlQuery<CourseClass>(sql).ToList();
        }

        public CourseClass GetCommingSoonClassByCourseId(int courseId) {
            string sql = @"select * 
from courseclass cs
where cs.CourseId = {0} and not cs.Finished
order by BeginTime limit 1";
            sql = string.Format(sql, courseId);

            var res = context.Database.SqlQuery<CourseClass>(sql).ToList();
            if (res.Count > 0) {
                return res[0];
            }
            return null;
        }
    }
}
