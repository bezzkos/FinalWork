using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.Helpers
{
    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DI.Providers;

    public static class Providers
    {
        public static IAnswerLogic AnswerBll = Provider.AnswerBll;
        public static IAvatarLogic AvatarBll = Provider.AvatarBll;
        public static ICategoryLogic CategoryBll = Provider.CategoryBll;
        public static IQuestionLogic QuestionBll = Provider.QuestionBll;
        public static ITestLogic TestBll = Provider.TestBll;
        public static IUserTestLogic UserTestBll = Provider.UserTestBll;

        public static IUserLogic UserBll = MembershipProvider.UserBll;
        public static IRoleLogic RoleBll = MembershipProvider.RoleBll;
        public static IUserInRoleLogic userInRoleBll = MembershipProvider.UserInRoleBll;
    }
}