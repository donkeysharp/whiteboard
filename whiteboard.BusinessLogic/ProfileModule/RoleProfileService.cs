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
    }
}
