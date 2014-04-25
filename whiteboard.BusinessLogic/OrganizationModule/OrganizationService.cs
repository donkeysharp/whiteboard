using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.OrganizationModule {
    public class OrganizationService : GenericService<Organization>, IOrganizationService {
        private IOrganizationRepository Da {
            get {
                return (IOrganizationRepository)da;
            }
        }
        private OrganizationService(IOrganizationRepository da)
            : base(da) {
        }

        public static IOrganizationService GetInstance<T>() where T : IOrganizationRepository {
            IOrganizationRepository da = (IOrganizationRepository)Activator.CreateInstance<T>();
            return new OrganizationService(da);
        }

        public IEnumerable<Organization.Report> GetOrganizations(int userId) {
            return Da.GetOrganizations(userId);
        }

        public Organization Get(string name) {
            List<Organization> res = da.Filter(x => x.Name.Equals(name)).ToList();
            if (res.Count > 0) {
                return res[0];
            }
            return null;
        }
    }
}
