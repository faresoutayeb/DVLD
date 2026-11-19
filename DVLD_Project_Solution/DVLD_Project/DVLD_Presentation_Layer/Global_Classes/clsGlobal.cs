using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.GlobalForms.Access_Denied_Screen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    static public  class clsGlobal
    {

        static public void AllowNumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar !='\b')
            {
                e.Handled = true;
            }
        }

        static public void ShowAccessDeniedScreen()
        {

            frmAccessDeniedScreen OpenAccessDeniedScreen = new frmAccessDeniedScreen();
            OpenAccessDeniedScreen.ShowDialog();
        }




    }
}
