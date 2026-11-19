using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    internal class clsDataAccessLimiter
    {
        private static int GetMaxConcurrentOperations()
        {
            string value = ConfigurationManager.AppSettings["MaxConcurrentDatabaseOperations"];

            if (!int.TryParse(value, out int maxOperations) || maxOperations < 1)
            {
                throw new ConfigurationErrorsException(
                    "MaxConcurrentDatabaseOperations must be a positive integer.");
            }

            return maxOperations;
        }

        public static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(GetMaxConcurrentOperations());


    }
}
