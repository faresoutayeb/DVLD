using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer
{
    public  static   class clsEventLog
    {
        public static void Initialize()
        {
            clsDataAccessEventLog.InitializeLog();
        }

        public static void LogError(Exception ex, string source)
        {
            clsDataAccessEventLog.LogError(ex, source);
        }
    }
}
