namespace KnowSysTest.DAL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities.Membership;

    public interface IRoleDAL
    {
        RoleDTO Get(Guid id);

        RoleDTO GetByName(string roleName);

        IEnumerable<RoleDTO> GetAll();

        bool Update(RoleDTO role);

        bool Delete(Guid id);

        bool Create(RoleDTO role);

        bool RoleExists(string roleName);

        bool Save();
    }
}
