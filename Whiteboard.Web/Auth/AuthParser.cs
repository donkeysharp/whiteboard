using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.Web.Auth {
    public class AuthParser {
        public static GeneralMembershipUser ProfileToUser(Profile profile) {
            GeneralMembershipUser user = new GeneralMembershipUser(profile.Email);
            user.Email = profile.Email;
            user.Name = profile.Name;

            return user;
        }
    }
}