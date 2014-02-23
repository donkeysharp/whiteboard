using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class RequestSchoolMemberService:GenericService<RequestSchoolMember>,IRequestSchoolMemberService
    {
        private RequestSchoolMemberService(IRequestSchoolMemberRepository da):base(da)
        {

        }
        public static IRequestSchoolMemberService GetInstance<T>() where T: IRequestSchoolMemberRepository
        {
            IRequestSchoolMemberRepository da =(IRequestSchoolMemberRepository)Activator.CreateInstance<T>();
            return new RequestSchoolMemberService(da);
        }
    }
}
