namespace KnowSysTest.BLL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities.Membership;

    public interface IUserInRoleLogic
    {
        UserInRoleDTO GetUserInRole(Guid userId, Guid roleId);

        IEnumerable<UserInRoleDTO> GetAllUsersInRole();

        bool CreateUserInRole(UserInRoleDTO userInRole);

        bool UpdateUserInRole(UserInRoleDTO userInRole);

        bool DeleteUserInRole(Guid userId, Guid roleId);

        bool SaveUserInRole();
    }
}
