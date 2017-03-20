namespace KnowSysTest.Entities.Membership
{
    using System;

    public class UserInRoleDTO
    {
        public Guid UserFk { get; set; }

        public Guid RoleFk { get; set; }
    }
}
