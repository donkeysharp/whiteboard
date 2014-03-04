using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class SchoolCourseService : GenericService<SchoolCourse>, ISchoolCourseService
    {
        private SchoolCourseService(ISchoolCourseRepository da)
            : base(da)
        {

        }
        public static ISchoolCourseService GetInstance<T>() where T : ISchoolCourseRepository
        {
            ISchoolCourseRepository da = (ISchoolCourseRepository)Activator.CreateInstance<T>();
            return new SchoolCourseService(da);
        }

        public IEnumerable<Course> getCoursesBySchoolId(int SchoolId)
        {
            var data = da.Filter(x => x.SchoolId == SchoolId);
            return (from x in data select x.Course).ToList();
        }
    }
}
