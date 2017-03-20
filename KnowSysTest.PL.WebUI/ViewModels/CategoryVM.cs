using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.ViewModels
{
    using KnowSysTest.Entities;

    public class CategoryVM
    {
        public Guid Id { get; private set; }

        public string Title { get; set; }

        public CategoryVM(string title)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
        }

        private CategoryVM()
        {
        }

        public static implicit operator CategoryDTO(CategoryVM model)
        {
            return new CategoryDTO()
            {
                Id = model.Id,
                Title = model.Title
            };
        }

        public static implicit operator CategoryVM(CategoryDTO model)
        {
            return new CategoryVM()
            {
                Id = model.Id,
                Title = model.Title
            };
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Title);
        }
    }
}