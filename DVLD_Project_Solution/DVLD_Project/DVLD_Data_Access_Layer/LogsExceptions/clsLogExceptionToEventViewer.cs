using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsLogExceptionToEventViewer
    {

        public clsLogExceptionToEventViewer()
        {
            clsDataAccessEventLog._OnLog  +=LogError ;

        }
        private const string _ProjectSourceName = "DVLD-V2";

        public static void LogError( clsLogEventArguments e)
        {
            string message =
                $"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}{Environment.NewLine}" +
                $"Class: {e.ClassName}{Environment.NewLine}" +
                $"Error Message: {e.Exception.Message}{Environment.NewLine}" +
                $"Exception Details: {e.Exception}{Environment.NewLine}" +
                $"{new string('-', 60)}{Environment.NewLine}";

            // Save to Windows Event Viewer
            EventLog.WriteEntry(_ProjectSourceName, message, EventLogEntryType.Error);

        }




    }
}
