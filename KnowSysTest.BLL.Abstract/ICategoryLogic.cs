namespace KnowSysTest.BLL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface ICategoryLogic
    {
        CategoryDTO GetCategory(Guid id);

        IEnumerable<CategoryDTO> GetAllCategories();

        bool UpdateCategory(CategoryDTO category);

        bool DeleteCategory(Guid id);

        bool CreateCategory(CategoryDTO category);

        bool SaveCategory();
    }
}
