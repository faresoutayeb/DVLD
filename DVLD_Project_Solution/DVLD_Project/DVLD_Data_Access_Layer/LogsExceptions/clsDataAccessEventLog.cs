using System;
using System.Diagnostics;
using System.IO;

namespace DVLD_Data_Access_Layer
{

    public class clsDataAccessEventLog
    {
        private const string _ProjectSourceName = "DVLD-V2";
        private static readonly string _LogDirectory = Path.Combine(AppContext.BaseDirectory, "Logs");

        public static void InitializeLog()
        {
            if (!EventLog.SourceExists(_ProjectSourceName))
            {
                EventLog.CreateEventSource(_ProjectSourceName, "Application");
            }

            if (!Directory.Exists(_LogDirectory))
            {
                Directory.CreateDirectory(_LogDirectory);

            }
        }



        public delegate void LogHandler(clsLogEventArguments e);

        public static event LogHandler _OnLog;

        public static void FireLogExceptionEvent(Exception Exception, string ClassName )
        {
            _OnLog?.Invoke( new clsLogEventArguments(ClassName, Exception) );
        }

        public static void LogError(Exception CurrentException, string className)
        {
            FireLogExceptionEvent(CurrentException,className);
        }
    }
}