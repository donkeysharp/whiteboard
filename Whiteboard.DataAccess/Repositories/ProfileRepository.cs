using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;

namespace Whiteboard.DataAccess.Repositories {
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository {
        public Profile GetByEmail(string email) {
            string sql = string.Format("select * from profile where email='{0}'", email);
            List<Profile> result = context.Profiles.SqlQuery(sql).ToList();

            if (result.Count > 0) {
                return result[0];
            }
            return null;
        }

        public IEnumerable<Profile> FilterStudents(int schoolId, string query) {
            string sql = @"select t1.*
from (
select *
from profile as p
where id not in (
	select StudentId
	from schoolstudent ss
	where ss.SchoolId = {0}
)
) as t1
inner join roleprofile rp on (rp.ProfileId = t1.Id)
where rp.RoleId = 3";
            sql = string.Format(sql, schoolId);

            return context.Profiles.SqlQuery(sql);
        }
    }
}
