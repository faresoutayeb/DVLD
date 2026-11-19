using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Application.Application_Screens;
using DVLD_Presentation_Layer.DrivingLicense.Driving_License_Screens;
using DVLD_Presentation_Layer.LocalDrivingLicence;
using DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Manage_Local_Driving_License_Applications_Screen
{
    public partial class frmManageLocalLiApp
    {

        //------------------ Local Function Definition --------------------------
        private string FilterColumn_WhenFilterSelectedIndexChanged()
        {
            //Map Selected Filter to real Column name 

            switch (_CurrentSelectedFilter)
            {
                case enFilterBy.LocalDVLsAppID:
                    return "LocalDrivingLicenseApplicationID";
                case enFilterBy.NationalNo:
                    return "NationalNo";
                case enFilterBy.FullName:
                    return "FullName";
                case enFilterBy.AppStatus:
                    return "Status";
                default:
                    return "None";
            }
        }

        private void RefreshTableFilter()
        {
            _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtAllLocalDrivingLicenseApplications.DefaultView.Count.ToString();
        }

        private  void _ScheduleTest(clsTestType.enTestType TestType)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmManageTestsAppointmentsScreen frm = new frmManageTestsAppointmentsScreen(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();
            //refresh
            frmListLocalDrivingLicesnseApplications_Load(null, null);

        }

        private async Task _SetApplicationsContextMenueStripEnabilityControls()
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            bool LicenseExists =await LocalDrivingLicenseApplication.IsLicenseIssuedAsync();

            //Enabled only if person passed all tests and Does not have license. 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            EditApplication_ToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            ScheduleTestsMenue.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            CancelApplicaitonToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            DeleteApplicationToolStripMenuItem.Enabled =(LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);



            //Enable Disable Schedule menue and it's sub menue
            bool IsPassedVisionTest =await LocalDrivingLicenseApplication.DoesPassTestTypeAsync(clsTestType.enTestType.VisionTest); ;
            bool IsPassedWrittenTest = await LocalDrivingLicenseApplication.DoesPassTestTypeAsync(clsTestType.enTestType.WrittenTest);
            bool IsPassedStreetTest = await LocalDrivingLicenseApplication.DoesPassTestTypeAsync(clsTestType.enTestType.StreetTest);

            ScheduleTestsMenue.Enabled =
                (!IsPassedVisionTest || !IsPassedWrittenTest || !IsPassedStreetTest) &&
                (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (ScheduleTestsMenue.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                scheduleVisionTestToolStripMenuItem.Enabled = !IsPassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                scheduleWrittenTestToolStripMenuItem.Enabled = IsPassedVisionTest && !IsPassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                scheduleStreetTestToolStripMenuItem.Enabled = IsPassedVisionTest && IsPassedWrittenTest && !IsPassedStreetTest;

            }



        }


        private void SetColumnsStrature()
        {

            dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
            dgvLocalDrivingLicenseApplications.Columns[0].Width = 80;

            dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
            dgvLocalDrivingLicenseApplications.Columns[1].Width = 250;

            dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
            dgvLocalDrivingLicenseApplications.Columns[2].Width = 80;

            dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
            dgvLocalDrivingLicenseApplications.Columns[3].Width = 200;

            dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
            dgvLocalDrivingLicenseApplications.Columns[4].Width = 120;

            dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
            dgvLocalDrivingLicenseApplications.Columns[5].Width = 100;


        }




    }
}
