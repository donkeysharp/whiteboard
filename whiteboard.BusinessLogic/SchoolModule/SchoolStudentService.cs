using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class SchoolStudentService:GenericService<SchoolStudent>,ISchoolStudentService
    {
        private SchoolStudentService(ISchoolStudentRepository da):base(da)
        {

        }
        public static ISchoolStudentService GetInstance<T>() where T: ISchoolStudentRepository
        {
            ISchoolStudentRepository da = (ISchoolStudentRepository)Activator.CreateInstance<T>();
            return new SchoolStudentService(da);
        }

        public IEnumerable<Profile> getStudentsBySchoolID(int SchoolID)
        {
            var data = da.Filter(x => x.SchoolId == SchoolID);
            return (from x in data select x.Student).ToList();
        }
    }
}
