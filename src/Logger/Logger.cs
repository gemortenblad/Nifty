using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Logger
{
    public class Logger
    {

        public Logger(bool configure = false)
        {
            if (configure)
            {
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            }
        }

        public void Log(string logmsg)
        {
            
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Debug(logmsg);
        }

    }
}