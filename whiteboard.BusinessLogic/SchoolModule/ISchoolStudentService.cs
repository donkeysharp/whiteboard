using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface ISchoolStudentService:IService<SchoolStudent>
    {
        IEnumerable<Profile> GetStudentsBySchoolID(int SchoolID);

        IEnumerable<Profile> GetStudentsBySchoolIdNotInCourse(int schoolId, int courseId, string query);
    }
}
