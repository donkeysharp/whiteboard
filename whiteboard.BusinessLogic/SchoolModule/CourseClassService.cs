using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class CourseClassService:GenericService<CourseClass>,ICourseClassService
    {
        private CourseClassService(ICourseClassRepository da):base(da)
        {

        }

        public static ICourseClassService GetInstance<T>() where T : ICourseClassRepository
        {
            ICourseClassRepository da = (ICourseClassRepository)Activator.CreateInstance<T>();
            return new CourseClassService(da);
        }

        IEnumerable<Course> ICourseClassService.GetClassesByCourseId(int CourseId)
        {
            var query = da.Filter(x => x.CourseId == CourseId);
            return (from x in query select x.Course).ToList();
        }
    }
}
