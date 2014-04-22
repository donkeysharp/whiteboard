using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface ISchoolTeacherService:IService<SchoolTeacher>
    {
        IEnumerable<Profile> GetStudentsBySchoolId(int SchoolID);
        IEnumerable<Profile> GetTeachersBySchoolId(int schoolId, string query);
    }
}
