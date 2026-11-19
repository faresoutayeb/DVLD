using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Local_Driving_License_Application_Screen;
using DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.New_Local_Driving_Licenses_Applications_Screen;
using DVLD_Presentation_Layer.DrivingLicense.Driving_License_Screens;
using DVLD_Presentation_Layer.DVLD_Applications.Applications_User_Controles;
using DVLD_Presentation_Layer.Global_Controls.License_History_Controls;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;
using DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Presentation_Layer.Person.PersonControles.ctrlFilterPersonInformation;

namespace DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Manage_Local_Driving_License_Applications_Screen
{
    public partial class frmManageLocalLiApp : Form
    {
        public frmManageLocalLiApp()
        {
            InitializeComponent();
            InitializeLocalEventFunctionToCall();
        }




        private async void frmListLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {
            _dtAllLocalDrivingLicenseApplications = await clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplicationsViewAsync();
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications.DefaultView;

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                SetColumnsStrature();

            }

            cbFilterBy.SelectedIndex = 0;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();


            await ctrlTotalLocalApplications1.LoadInfo();
            await ctrlTotalNewApplications2.LoadInfo();
            await ctrlTotalCanceledApps1.LoadInfo();
            await ctrlTotalCompeleteApps1.LoadInfo();

        }


        private  void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
 

            frmLocalLicenseAppInfo frm = new frmLocalLicenseAppInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //refresh
             frmListLocalDrivingLicesnseApplications_Load(null, null);

        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedFilter = (enFilterBy)cbFilterBy.SelectedIndex;

            txtFilterValue.Visible = (_CurrentSelectedFilter != enFilterBy.None);

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            RefreshTableFilter();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = FilterColumn_WhenFilterSelectedIndexChanged();
            string FilterstringValue = txtFilterValue.Text.Trim();
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (FilterstringValue == "" || _CurrentSelectedFilter == enFilterBy.None)
            {
                RefreshTableFilter();
                return;
            }


            if (_CurrentSelectedFilter == enFilterBy.LocalDVLsAppID)
                //in this case we deal with integer not string.
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterstringValue);
            else
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterstringValue);

            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtAllLocalDrivingLicenseApplications.DefaultView.Count.ToString();
        }

        private  void AddUpdateLocalApp_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase L.D.L.AppID id is selected.
            if (_CurrentSelectedFilter==enFilterBy.LocalDVLsAppID)
            {

                clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);
            }


        }


        private  void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ScheduleTest))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
             _ScheduleTest(clsTestType.enTestType.VisionTest);
        }

        private void  scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ScheduleTest))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            _ScheduleTest(clsTestType.enTestType.WrittenTest);
        }

        private  void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ScheduleTest))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }

        private  void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication AddUpdateLocalDrivingLicesnseApplication = new frmAddUpdateLocalDrivingLicesnseApplication();
            
            AddUpdateLocalDrivingLicesnseApplication.ShowDialog();
            //refresh
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private  void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.IssueNewDrivingLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmIssueNewDrivingLicenseScreen frm = new frmIssueNewDrivingLicenseScreen(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
            //refresh
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }


        private async void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
           await _SetApplicationsContextMenueStripEnabilityControls();

        }

        private async void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            int LicenseID = await (await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(LocalDrivingLicenseApplicationID)).GetActiveLicenseIDAsync();
            if (LicenseID != -1)
            {
                frmLicenseInfoScreen frm = new frmLicenseInfoScreen(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private async void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.CancellApplication))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (await LocalDrivingLicenseApplication.CanselAsync())
                {
                    
                        ApplicationStatusUpdated(LocalDrivingLicenseApplication.ApplicationStatus);
                    
                    //refresh the form again.
                    frmListLocalDrivingLicesnseApplications_Load(null, null);
                }
                else
                {

                 
                        ApplicationStatusNotUpdated();
                    
                }
            }
        }

        private async void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeleteApplication))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;


            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {

                if(await clsTestAppointment.IsTestAppointmentExistAsync(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,LocalDrivingLicenseApplication.LicenseClassID))
                {
                    _WhenLocalDrivingApplicationNotDeleted();
                    return;

                }
                if (await LocalDrivingLicenseApplication.DeleteLocalApplAsync())
                {
                  
                        LocalDrivingLicenseApplicationDeleted();

                        //refresh the form again.
                        frmListLocalDrivingLicesnseApplications_Load(null, null);
                }
                else
                {
                  
                        LocalDrivingLicenseApplicationNotDeleted();
                    
                }
            }
        }

        private async void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLicenseHistory))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(LocalDrivingLicenseApplicationID);

            frmLicenseHistoryScreen frm = new frmLicenseHistoryScreen(localDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();
        }

        private  void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            RefreshTableFilter();
        }

        private void ctrlDataGridPagesMoving1_OnButtonClicked()
        {
            dgvLocalDrivingLicenseApplications.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_dtAllLocalDrivingLicenseApplications.DefaultView);
            if(_CurrentSelectedFilter != enFilterBy.AppStatus && _CurrentSelectedFilter != enFilterBy.None)
            {
                 txtFilterValue.Focus();
            }
        
        }



        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private async void dgvLocalDrivingLicenseApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            string NationalNo = dgvLocalDrivingLicenseApplications.CurrentRow.Cells[2].Value.ToString();
            await ctrlPersonInfo_Small_1.LoadInfo(NationalNo);

            await ctrlLocalApplicationDetails1.LoadInfo(LocalDrivingLicenseApplicationID);
            byte PassedTests = Convert.ToByte( dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value);
            await ctrlUpcomingTests1.LoadInfo(LocalDrivingLicenseApplicationID, PassedTests);


        }


    }
}
