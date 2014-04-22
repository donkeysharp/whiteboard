using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.ProfileModule
{
    public class RoleProfileService:GenericService<RoleProfile>,IRoleProfileService
    {
        private RoleProfileService(IRoleProfileRepository da):base(da)
        {

        }       
        public static IRoleProfileService GetInstance<T>() where T  : IRoleProfileRepository
        {
            IRoleProfileRepository da = (IRoleProfileRepository)Activator.CreateInstance<T>();
            return new RoleProfileService(da);
        }

        public IEnumerable<RoleProfile> GetRolesByProfile(int profileId) {
            return da.Filter(x => x.ProfileId == profileId);
        }

        public bool IsUserInRole(int profileId, int roleId) {
            List<RoleProfile> roleProfiles = da.Filter(x => x.RoleId == roleId && x.ProfileId == profileId).ToList();
            return roleProfiles.Count > 0;
        }
    }
}
