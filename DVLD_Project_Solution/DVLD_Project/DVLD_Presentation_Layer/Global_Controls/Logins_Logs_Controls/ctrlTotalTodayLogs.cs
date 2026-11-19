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

namespace DVLD_Presentation_Layer.Global_Controls.Logins_Logs_Controls
{
    public partial class ctrlTotalTodayLogs : UserControl
    {
        public ctrlTotalTodayLogs()
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
        private int _TodayUsersLogs;
        public int TodayUsersLogs
        {
            get => _TodayUsersLogs;
        }
        private int _TotalActiveUsers;
        public int TotalActiveUsers
        {
            get => _TotalActiveUsers;
        }
        public async Task LoadInfo()
        {
            _TodayUsersLogs =await clsUserLog.GetTotalLoginsTodayAsync();
            lblTotalCount.Text = _TodayUsersLogs.ToString();

            _TotalActiveUsers= await clsUser.GetActiveUserCountAsync();
            lblUnderTitle.Text= _TotalActiveUsers.ToString()+ " Active Users";




        }



    }
}
