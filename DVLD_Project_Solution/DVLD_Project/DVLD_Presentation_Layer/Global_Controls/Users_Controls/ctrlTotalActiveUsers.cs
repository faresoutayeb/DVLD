using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Users_Controls
{
    public partial class ctrlTotalActiveUsers : UserControl
    {
        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }
        public async Task LoadInfo()
        {
            int TotalActiveUsers = await clsUser.GetActiveUserCountAsync();
            lblTotalActiveUsersCount.Text = TotalActiveUsers.ToString();
            int TotalUser=await clsUser.GetAllUserCountAsync();
            float percentage;
            if (TotalUser == 0)
                percentage = 0;
            else
            {
               percentage = (TotalActiveUsers * 100) / TotalUser;

            }
            if(percentage>70)
            {
                lblActiveDriverPercetage.Text = "High (" + percentage.ToString() + "%)";

            }
            if (percentage<30)
            {
                lblActiveDriverPercetage.Text = "Low (" + percentage.ToString() + "%)";

            }
            if(percentage>=30 && percentage <=70)
            {
                lblActiveDriverPercetage.Text = "In Medium (" + percentage.ToString() + "%)";

            }

            progbActiveUserCount.Value = (byte)percentage;


        }

        public ctrlTotalActiveUsers()
        {
            InitializeComponent();
        }
    }
}
