using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class MemberService:IMemberService
    {
        private IMemberRepository da;
        private MemberService(IMemberRepository da)
        {
            this.da = da;
        }
        public static IMemberService GetInstance<T>() where T : IMemberRepository
        {
            IMemberRepository da = (IMemberRepository)Activator.CreateInstance<T>();
            return new MemberService(da);
        }
    }
}
