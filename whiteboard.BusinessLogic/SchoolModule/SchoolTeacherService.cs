using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class SchoolTeacherService : GenericService<SchoolTeacher>, ISchoolTeacherService
    {
        private ISchoolTeacherRepository Da {
            get {
                return da as ISchoolTeacherRepository;
            }
        }

        private SchoolTeacherService(ISchoolTeacherRepository da)
            : base(da)
        {

        }
        public static ISchoolTeacherService GetInstance<T>() where T : ISchoolTeacherRepository
        {
            ISchoolTeacherRepository da = (ISchoolTeacherRepository)Activator.CreateInstance<T>();
            return new SchoolTeacherService(da);
        }

        public IEnumerable<Profile> GetStudentsBySchoolId(int SchoolID)
        {
            var data = da.Filter(x => x.SchoolId == SchoolID);
            return (from y in data.ToList() select y.Teacher).ToList();
        }


        public IEnumerable<Profile> GetTeachersBySchoolId(int schoolId, string query) {
            return Da.GetTeachersBySchoolId(schoolId, query);
        }
    }
}
