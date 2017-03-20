using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.ViewModels
{
    using System.Web.Mvc;

    using KnowSysTest.Entities;

    public class QuestionVM
    {
        public Guid Id { get; private set; }

        [AllowHtml]
        public string Question { get; set; }

        public bool IsActive { get; set; }

        public bool IsRequired { get; set; }

        public bool IsMultiple { get; set; }

        public Guid TestFk { get; set; }

        public QuestionVM(string question, bool isActive, bool isRequired, bool isMultiple, Guid testFk)
        {
            this.Id = Guid.NewGuid();
            this.Question = question;
            this.IsActive = isActive;
            this.IsRequired = isRequired;
            this.IsMultiple = isMultiple;
            this.TestFk = testFk;
        }

        private QuestionVM()
        {
        }

        public static implicit operator QuestionDTO(QuestionVM model)
        {
            return new QuestionDTO()
            {
                Id = model.Id,
                Question = model.Question,
                IsActive = model.IsActive,
                IsRequired = model.IsRequired,
                IsMultiple = model.IsMultiple,
                TestFk = model.TestFk
            };
        }

        public static implicit operator QuestionVM(QuestionDTO model)
        {
            return new QuestionVM()
            {
                Id = model.Id,
                Question = model.Question,
                IsActive = model.IsActive,
                IsRequired = model.IsRequired,
                IsMultiple = model.IsMultiple,
                TestFk = model.TestFk
            };
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", this.Question, this.IsActive, this.IsRequired, this.IsMultiple, this.TestFk);
        }
    }
}