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
    public partial class ctrlTotalActiveSessions : UserControl
    {
        public ctrlTotalActiveSessions()
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
        private int _TotalActiveSessions;
        public int TotalActiveSessions
        {
            get => _TotalActiveSessions;
        }
        private int _TotalUsersLogs;
        public int TotalUsersLogs
        {
            get => _TotalUsersLogs;
        }
        public async Task LoadInfo()
        {
            _TotalActiveSessions = await clsUserLog.GetActiveSessionsCountAsync();
            lblTotalCount.Text= _TotalActiveSessions.ToString();

            _TotalUsersLogs= await clsUser.GetActiveUserCountAsync();
            lblUnderTitle.Text= _TotalUsersLogs.ToString()+" Active Users";


        }


    }
}
