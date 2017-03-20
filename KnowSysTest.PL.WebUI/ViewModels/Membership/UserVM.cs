namespace KnowSysTest.PL.WebUI.ViewModels.Membership
{
    using System;

    using KnowSysTest.Entities.Membership;

    public class UserVm
    {
        public Guid UserId { get; private set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public UserVm(string userName, string password, string salt)
        {
            this.UserId = Guid.NewGuid();
            this.UserName = userName;
            this.Password = password;
            this.Salt = salt;
        }

        private UserVm()
        {
        }

        public static implicit operator UserDTO(UserVm model)
        {
            return new UserDTO()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Password = model.Password,
                Salt = model.Salt
            };
        }

        public static implicit operator UserVm(UserDTO model)
        {
            return new UserVm()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Password = model.Password,
                Salt = model.Salt
            };
        }

        public override string ToString()
        {
            return this.UserName;
        }
    }
}
