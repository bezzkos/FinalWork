namespace KnowSysTest.DAL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface ICategoryDAL
    {
        CategoryDTO Get(Guid id);

        IEnumerable<CategoryDTO> GetAll();

        bool Update(CategoryDTO category);

        bool Delete(Guid id);

        bool Create(CategoryDTO category);

        bool Save();
    }
}
