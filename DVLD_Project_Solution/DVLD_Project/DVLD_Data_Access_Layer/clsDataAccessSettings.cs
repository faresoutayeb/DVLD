using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DVLD_Data_Access_Layer
{
    static public class clsDataAccessSettings
    {



        private static string _ConnectionString = "";
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_ConnectionString))
                {
                    _ConnectionString =
                        System.Configuration.ConfigurationManager
                        .ConnectionStrings["DVLDConnection"]
                        .ConnectionString;
                }

                return _ConnectionString;
            }
        }




    }
}

