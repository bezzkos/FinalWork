using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.Helpers
{
    using System.Web.Services;

    using KnowSysTest.PL.WebUI.Helpers.Utilities;

    public static class JQueryValidationHelper
    {
        [WebMethod]
        public static bool UsernameCheck(string userName)
        {
            return Providers.UserBll.UserExists(userName);
        }

        [WebMethod]
        public static bool PasswordCheck(string password, string login, string salt, string realPassword)
        {
            return EncryptPassword.VerifyPassword(password, login, salt, realPassword);
        }
    }
}