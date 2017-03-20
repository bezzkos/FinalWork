namespace KnowSysTest.BLL.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities;

    public class TestLogic : ITestLogic
    {
        private ITestDAL dal;

        public TestLogic(ITestDAL dal)
        {
            if (dal == null)
            {
                throw new ArgumentNullException("dal", "DAL as parameter is null");
            }

            this.dal = dal;
        }

        public TestDTO GetTest(Guid id)
        {
            return this.dal.Get(id);
        }

        public IEnumerable<TestDTO> GetAllTests()
        {
            return this.dal.GetAll();
        }

        public IEnumerable<TestDTO> GetAllTestsByFk(Guid fk)
        {
            return this.dal.GetAllByFk(fk);
        }

        public IEnumerable<TestDTO> GetAllActiveTestsByFk(Guid fk)
        {
            return this.dal.GetAllByFk(fk).Where(test => test.IsActive);
        }

        public bool UpdateTest(TestDTO test)
        {
            return this.dal.Update(test);
        }

        public bool DeleteTest(Guid id)
        {
            return this.dal.Delete(id);
        }

        public bool CreateTest(TestDTO test)
        {
            return this.dal.Create(test);
        }

        public bool SaveTest()
        {
            return this.dal.Save();
        }
    }
}
