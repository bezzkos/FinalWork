namespace KnowSysTest.DAL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities.Membership;

    public interface IUserInRoleDAL
    {
        UserInRoleDTO Get(Guid userId, Guid roleId);

        IEnumerable<UserInRoleDTO> GetAll();

        bool Update(UserInRoleDTO userInRole);

        bool Delete(Guid userId, Guid roleId);

        bool Create(UserInRoleDTO userInRole);

        bool Save();
    }
}
