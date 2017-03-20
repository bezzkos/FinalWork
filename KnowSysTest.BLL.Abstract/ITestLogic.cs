namespace KnowSysTest.BLL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface ITestLogic
    {
        TestDTO GetTest(Guid id);

        IEnumerable<TestDTO> GetAllTests();

        IEnumerable<TestDTO> GetAllTestsByFk(Guid fk);

        IEnumerable<TestDTO> GetAllActiveTestsByFk(Guid fk);

        bool UpdateTest(TestDTO test);

        bool DeleteTest(Guid id);

        bool CreateTest(TestDTO test);

        bool SaveTest();
    }
}
