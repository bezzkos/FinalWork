namespace KnowSysTest.Entities
{
    using System;
    using System.Web.Mvc;

    public class QuestionDTO
    {
        public Guid Id { get; set; }

        [AllowHtml]
        public string Question { get; set; }

        public bool IsActive { get; set; }

        public bool IsRequired { get; set; }

        public bool IsMultiple { get; set; }

        public Guid TestFk { get; set; }
    }
}
