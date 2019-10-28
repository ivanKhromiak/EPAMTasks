using System;

namespace Logger
{
    public class CustomLogger: ILogger
    {
        public static LoggingLevels MinLevel { get; set; }

        public ILogBase LogBase { get; private set; }

        public CustomLogger(ILogBase logBase, LoggingLevels minLevel)
        {
            LogBase = logBase;
            MinLevel = minLevel;
        }

        public void ChangeLogBase(ILogBase logBase)
        {
            LogBase = logBase;
        }

        public void LogMessage(Exception e, LoggingLevels logginglevel)
        {
            if (logginglevel >= MinLevel)
            {
                string details = GetExceptionDetails(e);
                LogBase.WriteLog(details);
            }
        }

        public void LogMessage(string message, LoggingLevels logginglevel)
        {
            if (logginglevel >= MinLevel)
            {
                LogBase.WriteLog(message);
            }
        }

        private string GetExceptionDetails(Exception e)
        {
            string message = $"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("h:mm:ss")}: {e.Source} -> {e.Message}";
            return message;
        }
    }
}
