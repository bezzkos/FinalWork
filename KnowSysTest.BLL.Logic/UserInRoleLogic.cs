namespace KnowSysTest.BLL.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Security.Permissions;

    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities.Membership;

    public class UserInRoleLogic : IUserInRoleLogic
    {
        private IUserInRoleDAL dal;

        public UserInRoleLogic(IUserInRoleDAL dal)
        {
            if (dal == null)
            {
                throw new ArgumentNullException("dal", "DAL as parameter is null");
            }

            this.dal = dal;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public UserInRoleDTO GetUserInRole(Guid userId, Guid roleId)
        {
            return this.dal.Get(userId, roleId);
        }

        public IEnumerable<UserInRoleDTO> GetAllUsersInRole()
        {
            return this.dal.GetAll();
        }

        public bool CreateUserInRole(UserInRoleDTO user)
        {
            return this.dal.Create(user);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public bool UpdateUserInRole(UserInRoleDTO user)
        {
            return this.dal.Update(user);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public bool DeleteUserInRole(Guid userId, Guid roleId)
        {
            return this.dal.Delete(userId, roleId);
        }

        public bool SaveUserInRole()
        {
            return this.dal.Save();
        }
    }
}
