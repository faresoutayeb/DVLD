using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Users;
using DVLD_Presentation_Layer.Users.UserScreens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Users.User_Screens
{
    public partial class frmManageUsersScreen : Form
    {
        private static DataTable _dtAllUsers;

        public frmManageUsersScreen()
        {
            InitializeComponent();
        }
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





        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            PerformDataFiltring();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedFilter = (enFilterBy)cbFilterBy.SelectedIndex;
            SetControlsVisibilityWhenSelectingFilterByChanged();

        }

        private async void frmListUsers_Load(object sender, EventArgs e)
        {
           await _LoadUsersInfoToDataGrid();
            _SetUserTableColumns();
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            await ctrlUserDetails1.LoadInfo(clsGlobalUserInfo.CurrentLogInUser.UserID);
            await ctrlTotalActiveUsers1.LoadInfo();
            await ctrlTotalInactiveUsers1.LoadInfo();
            await ctrlTotalActiveUsers1.LoadInfo();
            await ctrlTotalLockedUsers1.LoadInfo();
            await ctrlTotalRoles1.LoadInfo();
            await ctrlTotalOnlineUsers1.LoadInfo();
           await ctrlRolesUsersDistribution1.LoadInfo();
         await   ctrlTotalUsers1.LoadInfo();

        }



        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedByActiveOrNot = (enFilterByActiveOrNot)cbFilterByActive.SelectedIndex;
            PerformFiltringDataWhenIsActiveFilterSelected();


        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditUser))
            {
                clsGlobal.ShowAccessDeniedScreen();
                return;
            }
            frmAddEditUser Frm1 = new frmAddEditUser();
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditUser))
            {
                clsGlobal.ShowAccessDeniedScreen();
                return;
            }
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmAddEditUser Frm1 = new frmAddEditUser(UserID);
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditUser))
            {
                clsGlobal.ShowAccessDeniedScreen();
                return;
            }

            frmAddEditUser Frm1 = new frmAddEditUser();
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);

        }

        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmShowUserInfoScreen Frm1 = new frmShowUserInfoScreen((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmShowUserInfoScreen Frm1 = new frmShowUserInfoScreen((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();

        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditUserPassword))
            {
                clsGlobal.ShowAccessDeniedScreen();
                return;
            }
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmChangePassword Frm1 = new frmChangePassword(UserID);
            Frm1.ShowDialog();

        }




        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (_CurrentSelectedFilter == enFilterBy.PersonId || _CurrentSelectedFilter == enFilterBy.UserId)
            {
                clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);

            }
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeleteUser))
            {
                clsGlobal.ShowAccessDeniedScreen();
                return;
            }
            frmDeleteUserScreen DeleteUser = new frmDeleteUserScreen((int)dgvUsers.CurrentRow.Cells[0].Value);
            DeleteUser.ShowDialog();
            frmListUsers_Load(null, null);

        }

        private void ctrlDataGridPagesMoving1_OnButtonClicked()
        {
            dgvUsers.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_dtAllUsers.DefaultView);
            if (_CurrentSelectedFilter != enFilterBy.IsActive && _CurrentSelectedFilter != enFilterBy.None)
            {
                txtbFilterBy.Focus();
            }
        }
    }
}
