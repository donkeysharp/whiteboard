using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public class SchoolTeacherRepository:GenericRepository<SchoolTeacher>,ISchoolTeacherRepository
    {
        public IEnumerable<Profile> GetTeachersBySchoolId(int schoolId, string query) {
            string sql = string.Format(@"select p.*
from profile as p
inner join schoolteacher as st on (st.TeacherId = p.id)
inner join profile as t on (t.id = st.TeacherId)
where st.SchoolId = {0} and (t.name like '%{1}%' or t.email like '%{2}%')", schoolId, query, query);
            return context.Profiles.SqlQuery(sql).ToList();
        }
    }
}
