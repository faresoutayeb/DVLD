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
    public partial class ctrlTotalLockedUsers : UserControl
    {
        public ctrlTotalLockedUsers()
        {
            InitializeComponent();
        }
        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        private int _TotalLockedUsers;
        public int TotalLockedUsers
        {
            get => _TotalLockedUsers;
        }
        
        public async Task LoadInfo()
        {
             _TotalLockedUsers = await clsUser.GetLockedUserCountAsync();
            lblTotalLockedUserCount.Text = _TotalLockedUsers.ToString();
            int TotalUser =await clsUser.GetAllUserCountAsync();

            float percentage = _TotalLockedUsers * 100 / TotalUser;
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

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }
    }
}
