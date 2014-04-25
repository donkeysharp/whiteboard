using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.OrganizationModule {
    public interface IOrganizationService : IService<Organization> {
        IEnumerable<Organization.Report> GetOrganizations(int userId);

        Organization Get(string name);
    }
}
