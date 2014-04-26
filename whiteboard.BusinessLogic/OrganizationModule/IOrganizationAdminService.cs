using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.OrganizationModule {
    public interface IOrganizationAdminService : IService<OrganizationAdmin> {
        bool IsAdmin(int profileId, int organizationId);
    }
}
