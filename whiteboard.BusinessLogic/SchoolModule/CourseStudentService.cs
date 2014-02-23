using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class CourseStudentService:GenericService<CourseStudent>,ICourseStudentService
    {
        private CourseStudentService(ICourseStudentRepository da):base(da)
        {

        }
        public ICourseStudentService GetInstance<T>() where T:ICourseStudentRepository
        {
            ICourseStudentRepository da = (ICourseStudentRepository)Activator.CreateInstance<T>();
            return new CourseStudentService(da);
        }
    }
}
