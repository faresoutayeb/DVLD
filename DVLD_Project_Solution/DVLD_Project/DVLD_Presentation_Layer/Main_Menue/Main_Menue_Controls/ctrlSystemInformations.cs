using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Main_Menue.Main_DVLD_Menue_Screens
{
    public partial class ctrlSystemInformations : UserControl
    {
        public ctrlSystemInformations()
        {
            InitializeComponent();
        }


        public async Task LoadInfo(clsUser User)
        {
            lblCurrentLogedUserName.Text = User.UserName;
            lblUserID.Text= User.UserID.ToString();
            lblDataBase.Text = "Connected";

           lblDataBase.ForeColor = (lblDataBase.Text == "Connected")?Color.Green:   Color.Red;

            
            lblCurrentVersion.Text = "V 0.0.2";
            if(User.IsAdmin())
            {

                lblUserType.Text = "Administrator";

            }
            else
            {
                lblUserType.Text = "Normal User";

            }
            lblLastLogin.Text= (await User.GetLastLogedInDateTimeAsync()).ToString();

        }

  
    }
}
