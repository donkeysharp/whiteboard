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
    }
}
