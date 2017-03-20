using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.ViewModels
{
    using KnowSysTest.Entities;
    using KnowSysTest.Entities.Membership;
    using KnowSysTest.PL.WebUI.ViewModels.Membership;

    public class UserTestVM
    {
        public Guid UserFk { get; private set; }

        public Guid TestFk { get; private set; }

        public float Mark { get; set; }

        public bool IsPassed { get; set; }

        public DateTime AttemptDateTime { get; set; }

        public UserTestVM(Guid userFk, Guid testFk, float mark, bool isPassed, DateTime attemptDateTime)
        {
            this.UserFk = userFk;
            this.TestFk = testFk;
            this.Mark = mark;
            this.IsPassed = isPassed;
            this.AttemptDateTime = attemptDateTime;
        }

        private UserTestVM()
        {
        }

        public static implicit operator UserTestDTO(UserTestVM model)
        {
            return new UserTestDTO()
            {
                UserFk = model.UserFk,
                TestFk = model.TestFk,
                Mark = model.Mark,
                IsPassed = model.IsPassed,
                AttemptDateTime = model.AttemptDateTime
            };
        }

        public static implicit operator UserTestVM(UserTestDTO model)
        {
            return new UserTestVM()
            {
                UserFk = model.UserFk,
                TestFk = model.TestFk,
                Mark = model.Mark,
                IsPassed = model.IsPassed,
                AttemptDateTime = model.AttemptDateTime
            };
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Mark, this.IsPassed, this.AttemptDateTime);
        }
    }
}