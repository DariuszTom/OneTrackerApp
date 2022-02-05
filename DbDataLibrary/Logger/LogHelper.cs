namespace DbDataLibrary.Logger
{
    public static class LogHelper
    {
        private static ILogBase logger = null;

        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;

                case LogTarget.Database:
                    logger = new DBLogger();
                    logger.Log(message);
                    break;

                case LogTarget.EventLog:
                    logger = new EventLogger();
                    logger.Log(message);
                    break;

                default:
                    return;
            }
        }
    }
}