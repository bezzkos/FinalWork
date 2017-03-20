namespace KnowSysTest.Entities
{
    using System;
    using System.Web.Mvc;

    public class AnswerDTO
    {
        public Guid Id { get; set; }

        [AllowHtml]
        public string Answer { get; set; }

        public bool IsCorrect { get; set; }

        public Guid QuestionFk { get; set; }
    }
}
