using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.ProfileModule {
    public class ProfileService : IProfileService {
        private IProfileRepository da;

        private ProfileService(IProfileRepository da) {
            this.da = da;
        }

        public static IProfileService GetInstance<T>() where T : IProfileRepository {
            IProfileRepository da = (IProfileRepository)Activator.CreateInstance<T>();
            return new ProfileService(da);
        }
    }
}
