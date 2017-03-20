namespace KnowSysTest.BLL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface IUserTestLogic
    {
        UserTestDTO GetUserTest(Guid userId, Guid testId, int attemptsCount);

        IEnumerable<UserTestDTO> GetAllUserTests();

        IEnumerable<UserTestDTO> GetAllTestsForUser(Guid fk);

        bool UpdateUserTest(UserTestDTO usertest);

        bool DeleteUserTest(Guid userId, Guid testId, int attemptsCount);

        bool CreateUserTest(UserTestDTO usertest);

        bool Save();
    }
}
