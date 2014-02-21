using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class MemberService:GenericService<Member>, IMemberService
    {
        private IProfileRepository daProfile;
        private MemberService(IMemberRepository da,IProfileRepository daProfile):base(da)
        {
            this.daProfile = daProfile;
        }
        private MemberService(IMemberRepository da):base(da)
        {

        }
        public static IMemberService GetInstance<T>() where T : IMemberRepository
        {
            IMemberRepository da = (IMemberRepository)Activator.CreateInstance<T>();
            return new MemberService(da);
        }
        public static IMemberService GetInstance<T,W>() where T: IMemberRepository where W:IProfileRepository
        {
            IMemberRepository da = (IMemberRepository)Activator.CreateInstance<T>();
            IProfileRepository daProfile = (IProfileRepository)Activator.CreateInstance<W>();
            return new MemberService(da,daProfile);
        }
        public IEnumerable<Member> GetSortedBy(MemberTypes type)
        {
            switch (type)
            {
                case MemberTypes.ID:
                    return da.Filter(null, x => x.OrderBy(y => y.Id));
                case MemberTypes.Name:
                    return da.Filter(null, x => x.OrderBy(y => y.Profile.Name));
                case MemberTypes.LastName:
                    return da.Filter(null, x => x.OrderBy(y => y.LastName));
                case MemberTypes.Email:
                    return da.Filter(null, x => x.OrderBy(y => y.Profile.Email));
                case MemberTypes.Country:
                    return da.Filter(null, x => x.OrderBy(y => y.Profile.Country));
                case MemberTypes.Role:
                    return da.Filter(null, x => x.OrderBy(y => y.Profile.Role));
                default:
                    break;
            }
            return new List<Member>();
        }

        public IEnumerable<Member> Search(string data)
        {
            return da.Filter((x) => (x.Profile.Name.Contains(data) || x.Profile.Email.Contains(data)),
                (x) => x.OrderBy((y) => y.Id));
        }
    }
    public enum MemberTypes
    {
        ID, Name, LastName, Email, Country, Role
    }
}
