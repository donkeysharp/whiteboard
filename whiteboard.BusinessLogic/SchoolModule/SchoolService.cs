using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule {
    public class SchoolService : ISchoolService {
        private ISchoolRepository da;

        private SchoolService(ISchoolRepository da) {
            this.da = da;
        }

        public static ISchoolService GetInstance<T>() where T : ISchoolRepository {
            ISchoolRepository da = (ISchoolRepository)Activator.CreateInstance<T>();
            return new SchoolService(da);
        }
    }
}
