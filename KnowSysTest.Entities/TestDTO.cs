namespace KnowSysTest.Entities
{
    using System;

    public class TestDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
        
        public Guid CategoryFk { get; set; }
    }
}
