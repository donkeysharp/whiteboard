using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public class SchoolStudentRepository:GenericRepository<SchoolStudent>,ISchoolStudentRepository
    {
        public IEnumerable<Profile> GetStudentsBySchoolId(int schoolId) {
            string sql = string.Format(@"select p.*
from profile as p
inner join schoolstudent as ss on( ss.StudentId = p.id)
where ss.SchoolId = {0}", schoolId);
            return context.Profiles.SqlQuery(sql).ToList();
        }

        public IEnumerable<Profile> GetStudentsBySchoolIdNotInCourse(int schoolId, int courseId, string query) {
            string sql = @"select s.*
from profile s
inner join schoolstudent ss on (ss.StudentId = s.Id)
where (s.name like '%{2}%' or s.email like '%{2}%' ) and ss.SchoolId = {0} and s.Id not in (
select StudentId
from coursestudent cs
where cs.CourseId = {1}
);";
            sql = string.Format(sql, schoolId, courseId, query);
            //var mycontext = ((IObjectContextAdapter)context);
            //mycontext.ObjectContext.Refresh((.
            return context.Profiles.SqlQuery(sql).ToList();
        }
    }
}
