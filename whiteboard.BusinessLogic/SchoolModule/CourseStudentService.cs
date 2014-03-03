using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class CourseStudentService : GenericService<CourseStudent>, ICourseStudentService
    {
        private CourseStudentService(ICourseStudentRepository da)
            : base(da)
        {

        }
        public static ICourseStudentService GetInstance<T>() where T : ICourseStudentRepository
        {
            ICourseStudentRepository da = (ICourseStudentRepository)Activator.CreateInstance<T>();
            return new CourseStudentService(da);
        }

        public IEnumerable<Profile> GetStudentsByCourseId(int CourseId)
        {
            var query = da.Filter(x => x.CourseId == CourseId);
            return (from x in query select x.Student).ToList();
        }

        public IEnumerable<Course> GetCoursesByStudentId(int StudentId)
        {
            var query = da.Filter(x => x.StudentId == StudentId);
            return (from x in query select x.Course).ToList();
        }
    }
}
