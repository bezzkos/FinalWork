using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowSysTest.Common
{
    using log4net;
    using log4net.Config;

    public class Log
    {
        static Log()
        {
            XmlConfigurator.Configure();
        }

        public static ILog For(object LoggedObject)
        {
            return For(LoggedObject != null ? LoggedObject.GetType() : null);
        }

        public static ILog For(Type ObjectType)
        {
            return LogManager.GetLogger(ObjectType != null ? ObjectType.Name : string.Empty);
        }
    }
}
