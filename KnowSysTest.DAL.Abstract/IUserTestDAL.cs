namespace KnowSysTest.DAL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;
    using KnowSysTest.Entities.Membership;

    public interface IUserTestDAL
    {
        UserTestDTO Get(Guid userId, Guid testId, int attemptsCount);

        IEnumerable<UserTestDTO> GetAll();

        bool Update(UserTestDTO usertest);

        bool Delete(Guid userId, Guid testId, int attemptsCount);

        bool Create(UserTestDTO usertest);

        bool Save();
    }
}
