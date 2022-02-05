using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using System.IO;
using System.Runtime.InteropServices;

namespace DbDataLibrary.Logger
{
    public enum LogTarget
    {
        File, Database, EventLog
    }

    public abstract class LogBase : ILogBase
    {
        protected readonly object lockObj = new object();

        public abstract void Log(string message, [Optional] bool isErrorLog);
    }

    public class FileLogger : LogBase
    {
        public string filePath = @"D:\IDGLog.txt";

        public override void Log(string message, [Optional] bool isErrorLog)
        {
            lock (lockObj)
            {
                using (var streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }

    public class EventLogger : LogBase
    {
        public override void Log(string message, [Optional] bool isErrorLog)
        {
            lock (lockObj)
            {
                //EventLog m_EventLog = new EventLog(“”);
                //m_EventLog.Source = "IDGEventLog";
                //m_EventLog.WriteEntry(message);
            }
        }
    }

    public class DBLogger : LogBase
    {
        public override void Log(string message, [Optional] bool isErrorLog)
        {
            lock (lockObj)
            {
                var newLog = new AppLogs()
                {
                    LogDesc = message,
                    //IdUser= UserInfo.GetInstance.UserDetails.IdEmployee
                };
                var efService = new DbService<AppLogs>();
                efService.AddRecord(newLog);
            }
        }
    }
}