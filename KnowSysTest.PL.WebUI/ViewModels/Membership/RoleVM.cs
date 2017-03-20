namespace KnowSysTest.PL.WebUI.ViewModels.Membership
{
    using System;

    using KnowSysTest.Entities.Membership;

    public class RoleVm
    {
        public Guid RoleId { get; private set; }

        public string RoleName { get; set; }

        public RoleVm(string roleName)
        {
            this.RoleId = Guid.NewGuid();
            this.RoleName = roleName;
        }

        private RoleVm()
        {
        }

        public static implicit operator RoleDTO(RoleVm model)
        {
            return new RoleDTO()
            {
                RoleId = model.RoleId,
                RoleName = model.RoleName
            };
        }

        public static implicit operator RoleVm(RoleDTO model)
        {
            return new RoleVm()
            {
                RoleId = model.RoleId,
                RoleName = model.RoleName
            };
        }

        public override string ToString()
        {
            return this.RoleName;
        }
    }
}