using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace whiteboard.BusinessLogic.ProfileModule {
    public interface IProfileService {
        Profile Get(string email);
        Profile Get(int id);
        Profile Insert(Profile item);
        int Update(Profile item);
        bool Validate(string email, string password);
    }
}
