using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Main_Menue.Main_Menue_Controls
{
    public partial class ctrlWelcomeUser : UserControl
    {
        public ctrlWelcomeUser()
        {
            InitializeComponent();
        }

        public void LoadInfo(clsUser User)
        {
            if(User.UserPermissionsInfo.IsAdmin())
            {
                lblPrevileg.ForeColor = Color.Green;
                lblPrevileg.Text = "Admin User";

            }
            else
            {
                lblPrevileg.ForeColor = Color.Blue;

                lblPrevileg.Text = User.RoleInfo.RoleName;

            }
        }

    }
}
