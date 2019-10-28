using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface ILogger
    {
        void LogMessage(Exception e, LoggingLevels loggingLevel);

        void LogMessage(string message, LoggingLevels loggingLevel);
    }
}
