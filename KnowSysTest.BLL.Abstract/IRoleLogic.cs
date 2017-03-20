namespace KnowSysTest.BLL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities.Membership;

    public interface IRoleLogic
    {
        RoleDTO GetRole(Guid id);

        RoleDTO GetRoleByName(string roleName);

        IEnumerable<RoleDTO> GetAllRoles();

        bool CreateRole(RoleDTO role);

        bool UpdateRole(RoleDTO role);

        bool DeleteRole(Guid id);

        bool SaveRole();
    }
}
