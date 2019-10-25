using System;

namespace Logger
{
    public class CustomLogger: ILogger
    {
        public CustomLogger(Action<string> WriteLog)
        {
            this.WriteLog = WriteLog; 
        }

        private Action<string> WriteLog;

        public void LogMessage(Exception e)
        {
            string details = GetExceptionDetails(e);
            WriteLog(details);
        }

        public void LogMessage(string message)
        {
            WriteLog(message);
        }

        private string GetExceptionDetails(Exception e)
        {
            string message = $"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("h:mm:ss")}: {e.Source} -> {e.Message}";
            return message;
        }
    }
}
