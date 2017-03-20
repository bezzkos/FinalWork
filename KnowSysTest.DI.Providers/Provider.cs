using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowSysTest.DI.Providers
{
    using System.Configuration;

    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.BLL.Logic;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.DAL.Db;

    public class Provider
    {
        public static IAnswerDAL AnswerDAL { get; private set; }

        public static IAvatarDAL AvatarDAL { get; private set; }

        public static ICategoryDAL CategoryDAL { get; private set; }

        public static IQuestionDAL QuestionDAL { get; private set; }

        public static ITestDAL TestDAL { get; private set; }

        public static IUserTestDAL UserTestDAL { get; private set; }

        public static IAnswerLogic AnswerBll { get; private set; }

        public static IAvatarLogic AvatarBll { get; private set; }

        public static ICategoryLogic CategoryBll { get; private set; }

        public static IQuestionLogic QuestionBll { get; private set; }

        public static ITestLogic TestBll { get; private set; }

        public static IUserTestLogic UserTestBll { get; private set; }

        static Provider()
        {
            var typeDAL = ConfigurationManager.AppSettings["typeDAL"];
            var typeBll = ConfigurationManager.AppSettings["typeBLL"];

            switch (typeDAL)
            {
                case "Files":
                    {
                    }
                    break;

                case "Fake":
                    {
                    }
                    break;

                case "DB":
                    {
                        AnswerDAL = new AnswerDbDAL();
                        AvatarDAL = new AvatarDbDAL();
                        CategoryDAL = new CategoryDbDAL();
                        QuestionDAL = new QuestionDbDAL();
                        TestDAL = new TestDbDAL();
                        UserTestDAL = new UserTestDbDAL();
                    }
                    break;
            }

            switch (typeBll)
            {
                case "Basic":
                    {
                        AnswerBll = new AnswerLogic(AnswerDAL);
                        //AvatarBll = new AvatarLogic(AvatarDAL);
                        CategoryBll = new CategoryLogic(CategoryDAL);
                        QuestionBll = new QuestionLogic(QuestionDAL);
                        TestBll = new TestLogic(TestDAL);
                        UserTestBll = new UserTestLogic(UserTestDAL);
                    }
                    break;

                case "Fake":
                    {
                    }
                    break;
            }
        }
    }
}
