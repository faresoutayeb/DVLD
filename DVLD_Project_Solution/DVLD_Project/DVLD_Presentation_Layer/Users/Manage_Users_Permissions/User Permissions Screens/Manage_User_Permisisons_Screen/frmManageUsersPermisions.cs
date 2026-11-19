using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Global_Controls.Users_Controls;
using DVLD_Presentation_Layer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_Screens
{
    public partial class frmManageUsersPermisions : Form
    {
        public frmManageUsersPermisions()
        {

            InitializeComponent();
        }

        private static DataTable _dtAllUsers;

        private enum enFilterBy
        {

            None = 0,
            UserId = 1,
            PersonId = 2,
            FullName = 3,
            UsersName = 4,
            IsActive = 5


        }
        enFilterBy _CurrentSelectedFilter = enFilterBy.None;

        private enum enFilterByActiveOrNot { All = 0, Active = 1, Inactive = 2 }
        enFilterByActiveOrNot _CurrentSelectedByActiveOrNot = enFilterByActiveOrNot.All;




        //--------------------------------------------------------------------------------

        private void _RefreshUsersTableFilter()
        {

            _dtAllUsers.DefaultView.RowFilter = "";
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtAllUsers.DefaultView.Count.ToString();
        }

        private void PerformFiltringDataWhenIsActiveFilterSelected()
        {

            switch (_CurrentSelectedByActiveOrNot)
            {
                case enFilterByActiveOrNot.Active:
                    _dtAllUsers.DefaultView.RowFilter = "[Is Active]  like 'A%' ";

                    break;
                case enFilterByActiveOrNot.Inactive:
                    _dtAllUsers.DefaultView.RowFilter = "[Is Active]  like 'I%' ";

                    break;
                default:
                    _dtAllUsers.DefaultView.RowFilter = "";

                    break;
            }

            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtAllUsers.DefaultView.Count.ToString();
        }

        private async Task _LoadUsersInfo()
        {
            _dtAllUsers =await clsUserPermissions.GetManageUsersPermissionsInfo();
            dgvUsersPermissions.DataSource = _dtAllUsers;

            _SetUserTableColumns();
            cbFilterBy.SelectedIndex = 0;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            await ctrlTotalActiveUsers1.LoadInfo();
           await ctrlTotalInactiveUsers1.LoadInfo();
           await ctrlTotalLockedUsers1.LoadInfo();
           await ctrlTotalOnlineUsers1.LoadInfo();
           await ctrlTotalRoles1.LoadInfo();
           await ctrlTotalUsers1.LoadInfo();
           await ctrlRolesUsersDistribution1.LoadInfo();
            ctrlWelcomeUser1.LoadInfo(clsGlobalUserInfo.CurrentLogInUser);
           await ctrlTodaySystemOverview1.LoadInfo();
        }

        private async Task HardRefresh()
        {
            await _LoadUsersInfo();
            
        }

        private void _SetUserTableColumns()
        {

            dgvUsersPermissions.Columns[0].HeaderText = "User ID";
            dgvUsersPermissions.Columns[0].Width = 100;
            dgvUsersPermissions.Columns[1].HeaderText = "Full Name";
            dgvUsersPermissions.Columns[1].Width = 230;
            dgvUsersPermissions.Columns[2].HeaderText = "User Name";
            dgvUsersPermissions.Columns[2].Width = 120;
            dgvUsersPermissions.Columns[3].HeaderText = "Role Name";
            dgvUsersPermissions.Columns[3].Width = 270;
            dgvUsersPermissions.Columns[4].HeaderText = "Is Active";
            dgvUsersPermissions.Columns[4].Width = 100;
            dgvUsersPermissions.Columns[5].HeaderText = "Last Login";
            dgvUsersPermissions.Columns[5].Width = 150;


        }


        private string _CurrentSelectedColumnName()
        {

            switch (_CurrentSelectedFilter)
            {

                case enFilterBy.UserId:
                    return "User ID";
                case enFilterBy.PersonId:
                    return "Person ID";
                case enFilterBy.FullName:
                    return "Full Name";
                case enFilterBy.UsersName:
                    return "User Name";
                default:
                    return "None";

            }
        }

        private void PerformDataFiltring()
        {
            string FilterColumn = _CurrentSelectedColumnName();
            //Map Selected Filter to real Column name 
            string textfilterValue = txtbFilterBy.Text.Trim();
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textfilterValue == "" || _CurrentSelectedFilter == enFilterBy.None)
            {
                _RefreshUsersTableFilter();
                return;
            }


            if (_CurrentSelectedFilter != enFilterBy.FullName && _CurrentSelectedFilter != enFilterBy.UsersName)
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textfilterValue);
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textfilterValue);


            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtAllUsers.DefaultView.Count.ToString();
        }




        //-------------------------------------------------------------------




        private void cbFilterByActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedByActiveOrNot = (enFilterByActiveOrNot)cbFilterByActive.SelectedIndex;
            PerformFiltringDataWhenIsActiveFilterSelected();
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {           
            PerformDataFiltring();

        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            _CurrentSelectedFilter = (enFilterBy)cbFilterBy.SelectedIndex;
            txtbFilterBy.Visible = (_CurrentSelectedFilter != enFilterBy.None && _CurrentSelectedFilter != enFilterBy.IsActive);
            cbFilterByActive.Visible = ( _CurrentSelectedFilter == enFilterBy.IsActive);

        }

        private async void ManageUsersPermisions_Load(object sender, EventArgs e)
        {
           await HardRefresh();
        }

        private void addEditPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.IsAdminLoged())
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }

            int UserID = (int)dgvUsersPermissions.CurrentRow.Cells[0].Value;
            frmAddEditUserPermissions UserEditPermission = new frmAddEditUserPermissions(UserID);
            UserEditPermission.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.IsAdminLoged())
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmAddEditUserPermissions UserEditPermission = new frmAddEditUserPermissions();
            UserEditPermission.ShowDialog();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }



        private void showPermisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsersPermissions.CurrentRow.Cells[0].Value;
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.IsAdminLoged())
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmFindUserPermisions UserEditPermission = new frmFindUserPermisions(UserID);
                UserEditPermission.ShowDialog();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            _RefreshUsersTableFilter();
        }

        private async void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            await _LoadUsersInfo();
        }

        private void ctrlDataGridPagesMoving1_OnButtonClicked()
        {
            dgvUsersPermissions.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_dtAllUsers.DefaultView);
            if (_CurrentSelectedFilter != enFilterBy.IsActive && _CurrentSelectedFilter != enFilterBy.None)
            {
                txtbFilterBy.Focus();
            }
        }
    }
}
