using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class SchoolMemberService:GenericService<SchoolMember>,ISchoolMemberService
    {
        private SchoolMemberService(ISchoolMemberRepository da):base(da)
        {

        }
        public static ISchoolMemberService GetInstance<T>() where T : ISchoolMemberRepository
        {
            ISchoolMemberRepository da = (ISchoolMemberRepository)Activator.CreateInstance<T>();
            return new SchoolMemberService(da);
        }
    }
}
