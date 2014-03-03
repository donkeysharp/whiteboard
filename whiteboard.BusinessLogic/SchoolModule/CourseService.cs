using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        private CourseService(ICourseRepository da)
            : base(da)
        {

        }
        public static ICourseService GetInstance<T>() where T : ICourseRepository
        {
            ICourseRepository da = (ICourseRepository)Activator.CreateInstance<T>();
            return new CourseService(da);
        }

        public IEnumerable<Course> Search(string data)
        {
            //add more search parameters ???
            return da.Filter(
                x => (x.Description.Contains(data) ||
                x.Title.Contains(data) ||
                x.Syllabus.Contains(data))
                );
        }

        public IEnumerable<Course> GetPublicCourses() {
            return da.Filter(x => x.IsPublic == true);
        }
    }
}
