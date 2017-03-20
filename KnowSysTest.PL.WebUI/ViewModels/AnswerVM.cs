using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.ViewModels
{
    using System.Web.Mvc;

    using KnowSysTest.Entities;

    public class AnswerVM
    {
        public Guid Id { get; private set; }

        [AllowHtml]
        public string Answer { get; set; }

        public bool IsCorrect { get; set; }

        public Guid QuestionFk { get; set; }

        public AnswerVM(string answer, bool isCorrect, Guid questionFk)
        {
            this.Id = Guid.NewGuid();
            this.Answer = answer;
            this.IsCorrect = isCorrect;
            this.QuestionFk = questionFk;
        }

        private AnswerVM()
        {
        }

        public static implicit operator AnswerDTO(AnswerVM model)
        {
            return new AnswerDTO()
            {
                Id = model.Id,
                Answer = model.Answer,
                IsCorrect = model.IsCorrect,
                QuestionFk = model.QuestionFk
            };
        }

        public static implicit operator AnswerVM(AnswerDTO model)
        {
            return new AnswerVM()
            {
                Id = model.Id,
                Answer = model.Answer,
                IsCorrect = model.IsCorrect,
                QuestionFk = model.QuestionFk
            };
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Answer, this.IsCorrect, this.QuestionFk);
        }
    }
}