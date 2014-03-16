using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;

namespace Whiteboard.DataAccess.Repositories {
    public interface IProfileRepository : IRepository<Profile> {
        Profile GetByEmail(string username);

        IEnumerable<Profile> FilterStudents(int schoolId, string query);
        IEnumerable<Profile> GetStudentsBySchoolId(int schoolId);
        IEnumerable<Profile> GetTeachersBySchoolId(int schoolId);
        IEnumerable<Profile> FilterTeachers(int schoolId, string query);
    }
}
