using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.Helpers
{
    using System.Web.Security;
    public class KnowSysTestRoleProvider : RoleProvider
    {
        public override string[] GetAllRoles()
        {
            return Providers.RoleBll.GetAllRoles().Select(role => role.RoleName).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            var roles = new List<string>();
            var user = Providers.UserBll.GetUserByName(username);

            foreach (var userInRole in Providers.userInRoleBll.GetAllUsersInRole().Where(userInRole => userInRole.UserFk == user.UserId))
            {
                var role = Providers.RoleBll.GetRole(userInRole.RoleFk);
                roles.Add(role.RoleName);
            }

            return roles.ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = Providers.UserBll.GetUserByName(username);
            var role = Providers.RoleBll.GetRoleByName(roleName);
            return Providers.userInRoleBll.GetUserInRole(user.UserId, role.RoleId) != null;
        }

        #region NotUsed

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        #endregion NotUsed
    }
}