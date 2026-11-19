using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsLogEventArguments : EventArgs
    {
        public Exception Exception { get; private set; }
        public string ClassName { get; private set; }

        public clsLogEventArguments(string className, Exception currentException)
        {
            ClassName = className;
            Exception = currentException;
        }
    }
}
