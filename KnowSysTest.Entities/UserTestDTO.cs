namespace KnowSysTest.Entities
{
    using System;

    public class UserTestDTO
    {
        public Guid UserFk { get; set; }

        public Guid TestFk { get; set; }

        public float Mark { get; set; }

        public bool IsPassed { get; set; }

        public DateTime AttemptDateTime { get; set; }
    }
}
