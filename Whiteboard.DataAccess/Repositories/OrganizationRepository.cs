using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories {
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository {
        public IEnumerable<Organization.Report> GetOrganizations(int userId) {
            string sql = string.Format(@"select o.*, oa.ProfileId as AdminId, p.name as AdminName
from organization o 
inner join organizationadmin oa on (oa.organizationId = o.id)
inner join profile p on (p.id = oa.profileId)
where p.id = {0}", userId);
            List<Organization.Report> result = context.Database.SqlQuery<Organization.Report>(sql).ToList();

            return result;
        }
    }
}
