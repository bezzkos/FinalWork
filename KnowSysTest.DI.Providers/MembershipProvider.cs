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

    public static class MembershipProvider
    {
        public static IUserDAL UserDAL { get; private set; }

        public static IRoleDAL RoleDAL { get; private set; }

        public static IUserInRoleDAL UserInRoleDAL { get; private set; }

        public static IUserLogic UserBll { get; private set; }

        public static IRoleLogic RoleBll { get; private set; }

        public static IUserInRoleLogic UserInRoleBll { get; private set; }

        static MembershipProvider()
        {
            var typeDal = ConfigurationManager.AppSettings["typeDAL"];
            var typeBll = ConfigurationManager.AppSettings["typeBLL"];

            switch (typeDal)
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
                        UserDAL = new UserDbDAL();
                        RoleDAL = new RoleDbDAL();
                        UserInRoleDAL = new UserInRoleDbDAL();
                    }
                    break;
            }

            switch (typeBll)
            {
                case "Basic":
                    {
                        UserBll = new UserLogic(UserDAL);
                        RoleBll = new RoleLogic(RoleDAL);
                        UserInRoleBll = new UserInRoleLogic(UserInRoleDAL);
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
