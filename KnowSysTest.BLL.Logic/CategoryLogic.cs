namespace KnowSysTest.BLL.Logic
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities;

    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryDAL dal;

        public CategoryLogic(ICategoryDAL dal)
        {
            if (dal == null)
            {
                throw new ArgumentNullException("dal", "DAL as parameter is null");
            }

            this.dal = dal;
        }

        public CategoryDTO GetCategory(Guid id)
        {
            return this.dal.Get(id);
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            return this.dal.GetAll();
        }

        public bool UpdateCategory(CategoryDTO category)
        {
            return this.dal.Update(category);
        }

        public bool DeleteCategory(Guid id)
        {
            return this.dal.Delete(id);
        }

        public bool CreateCategory(CategoryDTO category)
        {
            return this.dal.Create(category);
        }

        public bool SaveCategory()
        {
            return this.dal.Save();
        }
    }
}
