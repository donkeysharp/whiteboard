using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.ProfileModule
{
    public interface IRoleProfileService:IService<RoleProfile>
    {
        IEnumerable<RoleProfile> GetRolesByProfile(int profileId);

        bool IsUserInRole(int p1, int p2);
    }
}
