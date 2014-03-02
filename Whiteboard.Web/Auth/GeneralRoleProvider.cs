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

            IRoleProfileService roleProfileService = RoleProfileService.GetInstance<RoleProfileRepository>();
            IEnumerable<RoleProfile> roleProfiles = roleProfileService.GetRolesByProfile(profile.Id);

            List<string> res = new List<string>();
            foreach (RoleProfile rp in roleProfiles) {
                res.Add(rp.Role.Name);
            }
            return res.ToArray();
        }

        public override string[] GetUsersInRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName) {
            IProfileService service = ProfileService.GetInstance<ProfileRepository>();
            IRoleService roleService = RoleService.GetInstance<RoleRepository>();

            Profile profile = service.Get(username);
            Role role = roleService.GetByName(roleName);
            if (profile == null || role == null) {
                return false;
            }

            IRoleProfileService roleProfileService = RoleProfileService.GetInstance<RoleProfileRepository>();
            return roleProfileService.IsUserInRole(profile.Id, role.Id);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName) {
            throw new NotImplementedException();
        }
    }
}