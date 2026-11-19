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

namespace DVLD_Presentation_Layer.Global_Controls.Users_Controls
{
    public partial class ctrlTotalOnlineUsers : UserControl
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
            int TotalOnlineUsers =await clsUser.GetOnlineUsersCountAsync();
            lblTotalCount.Text = TotalOnlineUsers.ToString();
            int TotalActiveUser =await clsUser.GetActiveUserCountAsync();

            float percentage = TotalOnlineUsers * 100 / TotalActiveUser;
            if (percentage > 70)
            {
                lblPercetage.Text = "High (" + percentage.ToString() + "%)";

            }
            if (percentage < 30)
            {
                lblPercetage.Text = "Low (" + percentage.ToString() + "%)";

            }
            if (percentage >= 30 && percentage <= 70)
            {
                lblPercetage.Text = "In Medium (" + percentage.ToString() + "%)";

            }

            progbCount.Value = (byte)percentage;


        }


        public ctrlTotalOnlineUsers()
        {
            InitializeComponent();
        }
    }
}
