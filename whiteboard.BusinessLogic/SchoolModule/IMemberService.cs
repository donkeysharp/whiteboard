using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface IMemberService : IService<Member>
    {
        IEnumerable<Member> GetSortedBy(MemberTypes type);
        IEnumerable<Member> Search(string data);
        Member GetByProfile(int profileId);
    }
}
