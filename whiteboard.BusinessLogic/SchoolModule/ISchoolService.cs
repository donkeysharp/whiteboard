using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface ISchoolService : IService<School>
    {
        IEnumerable<School> GetSortedBy(SchoolTypes type);
        IEnumerable<School> Search(string data);        
        //bool Validate(int name);
    }
}
