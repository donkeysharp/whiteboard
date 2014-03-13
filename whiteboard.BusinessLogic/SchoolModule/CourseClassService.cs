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
        private ICourseClassRepository Da {
            get {
                return da as ICourseClassRepository;
            }
        }

        private CourseClassService(ICourseClassRepository da):base(da)
        {

        }

        public static ICourseClassService GetInstance<T>() where T : ICourseClassRepository
        {
            ICourseClassRepository da = (ICourseClassRepository)Activator.CreateInstance<T>();
            return new CourseClassService(da);
        }

        public IEnumerable<CourseClass> GetClassesByCourseId(int CourseId)
        {
            return Da.GetClassesByCourseId(CourseId);
        }


        public CourseClass GetCommingSoonClassByCourseId(int courseId) {
            return Da.GetCommingSoonClassByCourseId(courseId);
        }
    }
}
