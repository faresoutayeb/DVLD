using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using Microsoft.Win32;

namespace DVLD_Presentation_Layer
{
    static public class clsGlobalUserInfo
    {
        static public clsUser CurrentLogInUser
        {
            set { _CurrentUser = value; }
            get { return _CurrentUser; }

        }

        private static clsUser _CurrentUser;





    }
}