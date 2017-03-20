namespace KnowSysTest.DAL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface ITestDAL
    {
        TestDTO Get(Guid id);

        IEnumerable<TestDTO> GetAll();

        IEnumerable<TestDTO> GetAllByFk(Guid fk);

        bool Update(TestDTO test);

        bool Delete(Guid id);

        bool Create(TestDTO test);

        bool Save();
    }
}
