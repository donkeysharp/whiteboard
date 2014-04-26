using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.OrganizationModule {
    public class OrganizationAdminService : GenericService<OrganizationAdmin>, IOrganizationAdminService {
        private IOrganizationAdminRepository Da {
            get {
                return (IOrganizationAdminRepository )da;
            }
        }
        private OrganizationAdminService(IOrganizationAdminRepository da)
            : base(da) {
        }

        public static IOrganizationAdminService GetInstance<T>() where T : IOrganizationAdminRepository {
            IOrganizationAdminRepository da = (IOrganizationAdminRepository)Activator.CreateInstance<T>();
            return new OrganizationAdminService(da);
        }

        public bool IsAdmin(int profileId, int organizationId) {
            List<OrganizationAdmin> result = da.Filter(x => x.ProfileId == profileId && x.OrganizationId == organizationId).ToList();
            return result.Count > 0;
        }
    }
}
