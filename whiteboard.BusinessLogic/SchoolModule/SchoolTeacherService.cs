using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class SchoolTeacherService:GenericService<SchoolTeacher>,ISchoolTeacherService
    {
        private SchoolTeacherService(ISchoolTeacherRepository da):base(da)
        {

        }
        public static ISchoolTeacherService GetInstance<T>() where T : ISchoolTeacherRepository
        {
            ISchoolTeacherRepository da = (ISchoolTeacherRepository)Activator.CreateInstance<T>();
            return new SchoolTeacherService(da);
        }
    }
}
