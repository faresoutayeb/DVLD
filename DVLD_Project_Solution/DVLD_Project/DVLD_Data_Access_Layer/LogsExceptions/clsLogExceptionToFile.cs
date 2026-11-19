using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DVLD_Data_Access_Layer
{
    public  class clsLogExceptionToFile
    {
        private static readonly object _Lock = new object();

        private static readonly string _LogDirectory = Path.Combine(AppContext.BaseDirectory, "Logs");

        private static readonly string _LogFilePath = Path.Combine(_LogDirectory, "DVLD-Errors.log");

        public clsLogExceptionToFile() 
        {
            clsDataAccessEventLog._OnLog += LogError;

        }

        public static void LogError(clsLogEventArguments e)
        {
            string message =
                $"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}{Environment.NewLine}" +
                $"Class: {e.ClassName}{Environment.NewLine}" +
                $"Error Message: {e.Exception.Message}{Environment.NewLine}" +
                $"Exception Details: {e.Exception}{Environment.NewLine}" +
                $"{new string('-', 60)}{Environment.NewLine}";

            // Save to the log file
            lock (_Lock)
            {
                File.AppendAllText(_LogFilePath, message);
            }

        }



    }
}
