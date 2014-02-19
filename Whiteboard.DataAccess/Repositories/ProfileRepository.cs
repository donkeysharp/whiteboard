using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories {
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository {
        public Profile GetByEmail(string email) {
            List<Profile> result = (from p in this.context.Profiles
                                    where p.Email.Equals(email)
                                    select p).ToList();

            if (result.Count > 0) {
                return result[0];
            }
            return null;
        }
    }
}
