namespace KnowSysTest.BLL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities.Membership;

    public interface IUserLogic
    {
        UserDTO GetUser(Guid id);

        UserDTO GetUserByName(string userName);

        IEnumerable<UserDTO> GetAllUsers();

        bool CreateUser(UserDTO user);

        bool UpdateUser(UserDTO user);

        bool DeleteUser(Guid id);

        bool UserExists(string userName);

        bool SaveUser();
    }
}
