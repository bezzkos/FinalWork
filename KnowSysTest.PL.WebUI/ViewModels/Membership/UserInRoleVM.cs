namespace KnowSysTest.PL.WebUI.ViewModels.Membership
{
    using System;

    using KnowSysTest.Entities.Membership;

    public class UserInRoleVm
    {
        public Guid UserFk { get; private set; }

        public Guid RoleFk { get; private set; }

        public UserInRoleVm(Guid userFk, Guid roleFk)
        {
            this.UserFk = userFk;
            this.RoleFk = roleFk;
        }

        private UserInRoleVm()
        {
        }

        public static implicit operator UserInRoleDTO(UserInRoleVm model)
        {
            return new UserInRoleDTO()
            {
                UserFk = model.UserFk,
                RoleFk = model.RoleFk
            };
        }

        public static implicit operator UserInRoleVm(UserInRoleDTO model)
        {
            return new UserInRoleVm()
            {
                UserFk = model.UserFk,
                RoleFk = model.RoleFk
            };
        }
    }
}