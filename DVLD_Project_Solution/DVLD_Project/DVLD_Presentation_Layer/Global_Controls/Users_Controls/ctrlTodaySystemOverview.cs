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
    public partial class ctrlTodaySystemOverview : UserControl
    {

        private int _TotalLoginsTodayCount;
        public int TotalLoginsTodayCount { get => _TotalLoginsTodayCount; }

        private int _PasswordChangesTodayCount;
        public int PasswordChangesTodayCount { get => _PasswordChangesTodayCount; }

        private int _AccountsLockedTodayCount;
        public int AccountsLockedTodayCount { get => _AccountsLockedTodayCount; }

        public async Task LoadInfo()
        {
            Task<int> TotalLoginsTodayTask = clsUserLog.GetTotalLoginsTodayAsync();
            Task<int> PasswordChangesTodayTask = clsPasswordHistory.GetTodayPasswordChangesCountAsync();
            Task<int> AccountsLockedTodayTask = clsUser.GetLockedUserCountAsync();

            await Task.WhenAll(TotalLoginsTodayTask, PasswordChangesTodayTask, AccountsLockedTodayTask);

            _TotalLoginsTodayCount = TotalLoginsTodayTask.Result;
            _PasswordChangesTodayCount = PasswordChangesTodayTask.Result;
            _AccountsLockedTodayCount = AccountsLockedTodayTask.Result;

            lblTotalLoginsTodayCount.Text = _TotalLoginsTodayCount.ToString();
            lblPasswordChangesTodayCount.Text = _PasswordChangesTodayCount.ToString();
            lblAccountsLockedTodayCount.Text = _AccountsLockedTodayCount.ToString();
        }
        public ctrlTodaySystemOverview()
        {
            InitializeComponent();
        }
    }
}
