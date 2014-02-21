using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> Search(string parameter);
        // search by date or get date when Course date updated
       
    }
}
