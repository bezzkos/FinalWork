using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.ViewModels
{
    using KnowSysTest.Entities;

    public class TestVM
    {
        public Guid Id { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Guid CategoryFk { get; set; }

        public TestVM(string title, string description, bool isActive, Guid categoryFk)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = description;
            this.IsActive = isActive;
            this.CategoryFk = categoryFk;
        }

        private TestVM()
        {
        }

        public static implicit operator TestDTO(TestVM model)
        {
            return new TestDTO()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive,
                CategoryFk = model.CategoryFk
            };
        }

        public static implicit operator TestVM(TestDTO model)
        {
            return new TestVM()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive,
                CategoryFk = model.CategoryFk
            };
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Title, this.Description, this.IsActive, this.CategoryFk);
        }
    }
}