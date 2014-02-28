using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace Whiteboard.Web.Auth {
    public class GeneralRoleProvider : RoleProvider {
        private string applicationName = "WebApplication";

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override string ApplicationName {
            get {
                return applicationName;
            }
            set {
                this.applicationName = value;
            }
        }

        public override void CreateRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles() {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            Profile profile = service.Get(username);
            if (profile == null) {
                return new string[0];
            }
            return new string[] { profile.Role };
        }

        public override string[] GetUsersInRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            Profile profile = service.Get(username);
            if (profile == null) {
                return false;
            }
            return profile.Role.Equals(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName) {
            throw new NotImplementedException();
        }
    }
}