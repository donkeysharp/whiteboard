using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class RequestCourseStudentService:GenericService<RequestCourseStudent>,IRequestCourseStudentService
    {
        private RequestCourseStudentService(IRequestCourseStudentRepository da):base(da)
        {

        }
        public static IRequestCourseStudentService GetInstance<T>() where T:IRequestCourseStudentRepository
        {
            IRequestCourseStudentRepository da = (IRequestCourseStudentRepository)Activator.CreateInstance<T>();
            return new RequestCourseStudentService(da);
        }
    }
}
