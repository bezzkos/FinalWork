namespace KnowSysTest.DAL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities.Membership;

    public interface IUserDAL
    {
        UserDTO Get(Guid id);

        UserDTO GetByName(string userName);

        IEnumerable<UserDTO> GetAll();

        bool Update(UserDTO user);

        bool Delete(Guid id);

        bool Create(UserDTO user);

        bool UserExists(string userName);

        bool Save();
    }
}
