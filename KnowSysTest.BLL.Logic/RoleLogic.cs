namespace KnowSysTest.BLL.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Security.Permissions;

    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities.Membership;

    public class RoleLogic : IRoleLogic
    {
        private IRoleDAL DAL;

        public RoleLogic(IRoleDAL DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL", "DAL as parameter is null");
            }

            this.DAL = DAL;
        }

        public RoleDTO GetRole(Guid id)
        {
            return this.DAL.Get(id);
        }

        public RoleDTO GetRoleByName(string roleName)
        {
            return this.DAL.GetByName(roleName);
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            return this.DAL.GetAll();
        }

        public bool CreateRole(RoleDTO role)
        {
            return this.DAL.Create(role);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public bool UpdateRole(RoleDTO role)
        {
            return this.DAL.Update(role);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public bool DeleteRole(Guid id)
        {
            return this.DAL.Delete(id);
        }

        public bool SaveRole()
        {
            return this.DAL.Save();
        }
    }
}
