using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Global_Controls.Drivers_Controls;
using DVLD_Presentation_Layer.Global_Controls.Roles_Controls;
using DVLD_Presentation_Layer.Global_Controls.Users_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DVLD_Presentation_Layer.Users.User_Logs.User_logs_Screen
{
    public partial class frmUsersLogs : Form
    {
        public frmUsersLogs()
        {
            InitializeComponent();
        }

        private static DataTable _dtLoginsLogs;

        private enum enFilterBy
        {

            None = 0,
            LoginId = 1,
            UsersName = 2

        }
        enFilterBy _CurrentSelectedFilter = enFilterBy.None;


        private void _RefreshUsersTableFilter()
        {

            _dtLoginsLogs.DefaultView.RowFilter = "";
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtLoginsLogs.DefaultView.Count.ToString();
        }



        private void Performfiltring()
       {
            string FilterValueString = txtbFilterBy.Text.Trim();
            if(_CurrentSelectedFilter == enFilterBy.None || FilterValueString == "")
            {
                _RefreshUsersTableFilter();
                return;
            }
            switch (_CurrentSelectedFilter)
            {
                case enFilterBy.LoginId:
                    _dtLoginsLogs.DefaultView.RowFilter = string.Format($"[Login ID] = {FilterValueString}");

                    break;
                case enFilterBy.UsersName:
                    _dtLoginsLogs.DefaultView.RowFilter = string.Format($"[User Name] like  '{FilterValueString}%'");

                    break;
                default:
                    _RefreshUsersTableFilter();

                    break;
            }
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtLoginsLogs.DefaultView.Count.ToString();
        }

        private async Task _LoadUsersInfo()
        {           
            _dtLoginsLogs = await Task.Run(() => clsUserLog.GetLogsInfoAsync());

            dgvLoginsLogs.DataSource = _dtLoginsLogs.DefaultView;
            _SetUserTableColumns();

            cbFilterBy.SelectedIndex = 0;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();
            lblRecordsCount.Text = _dtLoginsLogs.DefaultView.Count.ToString();


        }



        private void _SetUserTableColumns()
        {

            dgvLoginsLogs.Columns[0].HeaderText = "Login ID";
            dgvLoginsLogs.Columns[0].Width = 50;

            dgvLoginsLogs.Columns[1].HeaderText = "User Name";
            dgvLoginsLogs.Columns[1].Width = 150;

            dgvLoginsLogs.Columns[2].HeaderText = "Login Date & Time";
            dgvLoginsLogs.Columns[2].Width = 200;

            dgvLoginsLogs.Columns[3].HeaderText = "Logout Date & Time";
            dgvLoginsLogs.Columns[3].Width = 200;

            dgvLoginsLogs.Columns[4].HeaderText = "Durration Session";
            dgvLoginsLogs.Columns[4].Width = 200;

        }





        private async void frmUsersLogs_Load(object sender, EventArgs e)
        {
            await _LoadUsersInfo();
            lblName.Text = clsGlobalUserInfo.CurrentLogInUser.PersonInfo.Name;
            lblUserName.Text=clsGlobalUserInfo.CurrentLogInUser.UserName;
            lblUserID.Text = clsGlobalUserInfo.CurrentLogInUser.UserID.ToString();
            await ctrlTotalActiveSessions1.LoadInfo();
            await ctrlTotalActiveUsers1.LoadInfo();
            await ctrlTotalInactiveUsers1.LoadInfo();
            await ctrlTotalLoginsLogs1.LoadInfo();
            ctrlTotalLogsInPeriod1.LoadInfo();
            await ctrlTotalOnlineUsers1.LoadInfo();
           await ctrlTotalTodayLogs1.LoadInfo();
            


        }
        private void ApplyDateFilter()
        {
            _dtLoginsLogs.DefaultView.RowFilter =  $"[Login Date & Time] >= #{dtpDateFrom.Value:MM/dd/yyyy}# AND " +
                $"[Logout Date & Time] <= #{dtpDateTo.Value:MM/dd/yyyy}#";
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtLoginsLogs.DefaultView.Count.ToString();

        }
        //private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        //{
        //    ApplyDateFilter();
        //}
        //private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        //{
        //    ApplyDateFilter();
        //}



        private void txtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            Performfiltring();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            _RefreshUsersTableFilter();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedFilter=(enFilterBy) cbFilterBy.SelectedIndex;
            txtbFilterBy.Visible = (_CurrentSelectedFilter != enFilterBy.None);
            if(_CurrentSelectedFilter ==enFilterBy.None)
            {
                _RefreshUsersTableFilter();
                return;
            }
        }

        private void ctrlDataGridPagesMoving1_OnButtonClicked()
        {
            dgvLoginsLogs.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_dtLoginsLogs.DefaultView);
            if ( _CurrentSelectedFilter != enFilterBy.None)
            {
                txtbFilterBy.Focus();
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            frmUsersLogs_Load(null, null);
        }


        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyDateFilter();

        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyDateFilter();

        }

        private void txtbFilterBy_TextChanged_1(object sender, EventArgs e)
        {
            Performfiltring();
        }
    }
}
