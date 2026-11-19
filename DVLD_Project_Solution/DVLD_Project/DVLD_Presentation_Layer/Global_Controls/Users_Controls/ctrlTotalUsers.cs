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
    public partial class ctrlTotalUsers : UserControl
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



            int TotalActiveUsers =await clsUser.GetActiveUserCountAsync();
            int TotalUser =await  clsUser.GetAllUserCountAsync();
            float percentage;
            if (TotalUser==0)
            {
                percentage = 0;
            }
            else
            {
                                percentage =( TotalActiveUsers * 100) / TotalUser;

            }

            lblTotalCount.Text= TotalUser.ToString();

            progbActiveUserCount.Value= (byte)percentage;

            lblNewUsersThisWeek.Text = clsUser.GetUserCountSigUpInPeriodeAsync(DateTime.Now.AddDays(-7), DateTime.Now).ToString()+" New this week";
        }

        public ctrlTotalUsers()
        {
            InitializeComponent();
        }
    }
}
