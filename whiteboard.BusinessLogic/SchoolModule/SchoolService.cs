using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class SchoolService :GenericService<School>, ISchoolService
    {

        private SchoolService(ISchoolRepository da):base(da)
        {
        }

        public static ISchoolService GetInstance<T>() where T : ISchoolRepository
        {
            ISchoolRepository da = (ISchoolRepository)Activator.CreateInstance<T>();
            return new SchoolService(da);
        }
        public IEnumerable<School> GetSortedBy(SchoolTypes type)
        {
            switch (type)
            {
                case SchoolTypes.Id:
                    return da.Filter(null, (x) => x.OrderBy((y) => y.Id));
                case SchoolTypes.Name:
                    return da.Filter(null, (x) => x.OrderBy((y) => y.Profile.Name));
                case SchoolTypes.Email:
                    return da.Filter(null, (x) => x.OrderBy((y) => y.Profile.Email));
                case SchoolTypes.Country:
                    return da.Filter(null, (x) => x.OrderBy((y) => y.Profile.Country));
                case SchoolTypes.Role:
                    return da.Filter(null, (x) => x.OrderBy((y) => y.Profile.Role));
                default:
                    break;

            }
            return new List<School>();
        }


        public IEnumerable<School> Search(string data)
        {
            return da.Filter((x) => (x.Profile.Name.Contains(data) || x.Profile.Email.Contains(data)),
                (x) => x.OrderBy((y) => y.Id));
        }
    }
    public enum SchoolTypes
    {
        Id, Name, Email, Country, Role
    }
}
