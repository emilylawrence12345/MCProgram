using NLog;

namespace HeathCareMemberCoreProj
{
    public class NLogger
    {
        private static readonly Logger logger;
        static NLogger()
        {
            logger = LogManager.GetCurrentClassLogger();
        }
        public static void loginfo(string message)
        { 
            if (DataBaseSettings.LogInfoFlag)
                logger.Info(message);
        }
        public static void Error(string message)
        {            
                logger.Info(message);
        }

        public static void Trace(string message)
        {
            if (DataBaseSettings.LogTraceFlag)
                logger.Info(message);
        }
        public static void Warning(string message)
        {
            if (DataBaseSettings.LogWarnFlag)
                logger.Info(message);
        }
        public static void Fatal(string message)
        {            
                logger.Info(message);
        }
        public static void Debug(string message)
        {
            if (DataBaseSettings.LogDebugFlag)
                logger.Info(message);
        }

    }
}
