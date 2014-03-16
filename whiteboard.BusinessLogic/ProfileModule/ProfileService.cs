using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Common.Cryptography;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.ProfileModule {
    public class ProfileService :GenericService<Profile>, IProfileService {
        private IProfileRepository daProfile;


        private ProfileService(IProfileRepository da):base(da) {
            this.daProfile = da;
        }
            
        public static IProfileService GetInstance<T>() where T : IProfileRepository {
            IProfileRepository da = (IProfileRepository)Activator.CreateInstance<T>();
            return new ProfileService(da);
        }

        public Profile Get(string email) {
            return daProfile.GetByEmail(email);
        }

        public override Profile Insert(Profile item)
        {
            // Replaces current password with a hashed password
            item.Password = HashSumUtil.GetHashSum(item.Password, HashSumType.SHA1);
            return daProfile.Insert(item);
        }

        public bool Validate(string email, string password) {
            Profile profile = daProfile.GetByEmail(email);
            if (profile == null) {
                return false;
            }
            string inputHash = HashSumUtil.GetHashSum(password, HashSumType.SHA1);

            // Compare hashed password with current profile's hashed password
            return inputHash.Equals(profile.Password);
        }

        public IEnumerable<Profile> Search(string data)
        {
            return daProfile.Filter((x) => (x.Name.Contains(data) || x.Email.Contains(data)),
                (x) => x.OrderBy((y) => y.Id));
        }

        public IEnumerable<Profile> FilterStudents(int schoolId, string query) {
            return daProfile.FilterStudents(schoolId, query);
        }
    }
}
