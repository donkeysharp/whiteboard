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
    }
}
