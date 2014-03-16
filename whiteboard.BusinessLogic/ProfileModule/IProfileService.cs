using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.ProfileModule
{
    public interface IProfileService : IService<Profile>
    {
        Profile Get(string email);
        bool Validate(string email, string password);
        IEnumerable<Profile> Search(string data);

        IEnumerable<Profile> FilterStudents(int schoolId, string query);
    }
}
