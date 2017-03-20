namespace KnowSysTest.BLL.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities;

    public class UserTestLogic : IUserTestLogic
    {
        private IUserTestDAL dal;

        public UserTestLogic(IUserTestDAL dal)
        {
            if (dal == null)
            {
                throw new ArgumentNullException("dal", "DAL as parameter is null");
            }

            this.dal = dal;
        }

        public UserTestDTO GetUserTest(Guid userId, Guid testId, int attemptsCount)
        {
            return this.dal.Get(userId, testId, attemptsCount);
        }

        public IEnumerable<UserTestDTO> GetAllUserTests()
        {
            return this.dal.GetAll();
        }

        public IEnumerable<UserTestDTO> GetAllTestsForUser(Guid fk)
        {
            return this.dal.GetAll().Where(userTest => userTest.UserFk == fk).ToList();
        }

        public bool UpdateUserTest(UserTestDTO usertest)
        {
            return this.dal.Update(usertest);
        }

        public bool DeleteUserTest(Guid userId, Guid testId, int attemptsCount)
        {
            return this.dal.Delete(userId, testId, attemptsCount);
        }

        public bool CreateUserTest(UserTestDTO usertest)
        {
            return this.dal.Create(usertest);
        }

        public bool Save()
        {
            return this.dal.Save();
        }
    }
}
