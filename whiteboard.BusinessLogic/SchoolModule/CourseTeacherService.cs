using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class CourseTeacherService:GenericService<CourseTeacher>,ICourseTeacherService
    {
        private CourseTeacherService(ICourseTeacherRepository da):base(da)
        {

        }
        public static ICourseTeacherService GetInstance<T>() where T : ICourseTeacherRepository
        {
            ICourseTeacherRepository da = (ICourseTeacherRepository)Activator.CreateInstance<T>();
            return new CourseTeacherService(da);
        }
    }
}
