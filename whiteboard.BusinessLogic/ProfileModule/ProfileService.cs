using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Common.Cryptography;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.ProfileModule {
    public class ProfileService : IProfileService {
        private IProfileRepository da;

        private ProfileService(IProfileRepository da) {
            this.da = da;
        }

        public static IProfileService GetInstance<T>() where T : IProfileRepository {
            IProfileRepository da = (IProfileRepository)Activator.CreateInstance<T>();
            return new ProfileService(da);
        }

        public Profile Get(string email) {
            return da.GetByEmail(email);
        }

        public Profile Get(int id) {
            return da.Get(id);
        }

        public Profile Insert(Profile item) {
            // Replaces current password with a hashed password
            item.Password = HashSumUtil.GetHashSum(item.Password, HashSumType.SHA1);

            return da.Insert(item);
        }

        public bool Validate(string email, string password) {
            Profile profile = da.GetByEmail(email);
            if (profile == null) {
                return false;
            }
            string inputHash = HashSumUtil.GetHashSum(password, HashSumType.SHA1);

            // Compare hashed password with current profile's hashed password
            return inputHash.Equals(profile.Password);
        }

        public int Update(Profile item) {
            return da.Update(item);
        }
    }
}
