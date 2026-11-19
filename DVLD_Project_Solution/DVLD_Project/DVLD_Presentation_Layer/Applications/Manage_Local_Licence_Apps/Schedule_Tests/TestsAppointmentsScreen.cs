using DVLD_Bussiness_Layer;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Screens
{
    public partial class frmManageTestsAppointmentsScreen : Form
    {

        private DataTable _dtLicenseTestAppointments;
        private DataTable _TemporarlyDataTable;

        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        private clsLocalDrivingLicenseApplication _CurrentLocalLicenseApp;
        //-----------------------------  Constractor  --------------------------------------------

        public frmManageTestsAppointmentsScreen(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;

        }

        //----------------------------- Local Function To Execute when Firing Our local Events  --------------------------------------------


        private void _WhenAlreadyPassInCurrentTest()
        {
            MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void _WhenActiveAppointmentExist()
        {
            MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        //----------------------------- Controls events  --------------------------------------------

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        //pbTestTypeImage.Image = Resources.vision_test;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        // pbTestTypeImage.Image = Resources.written_test;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        // pbTestTypeImage.Image = Resources.street_test;
                        break;
                    }
            }
        }

        private async void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            _CurrentLocalLicenseApp = await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(_LocalDrivingLicenseApplicationID);
            if (_CurrentLocalLicenseApp != null)
            {
                await ctrlDrivingLicenseApplicationInfo2.LoadApplicationInfoByLocalDrivingAppID(_CurrentLocalLicenseApp.LocalDrivingLicenseApplicationID);

                await ctrlTotalAppointments1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestType, ctrlDrivingLicenseApplicationInfo2.CurrentLocalDrivingLicenseApplication.LicenseClassID);
                await ctrlLockedAppointments1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestType, ctrlDrivingLicenseApplicationInfo2.CurrentLocalDrivingLicenseApplication.LicenseClassID);
                await ctrlUnlockedAppointments1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestType, ctrlDrivingLicenseApplicationInfo2.CurrentLocalDrivingLicenseApplication.LicenseClassID);
                await ctrlLastUpdatedAppointments2.LoadInfo(_LocalDrivingLicenseApplicationID, _TestType, ctrlDrivingLicenseApplicationInfo2.CurrentLocalDrivingLicenseApplication.LicenseClassID);


            }

            _dtLicenseTestAppointments = await clsTestAppointment.GetTestAppointmentsInfoAsync(_LocalDrivingLicenseApplicationID, _TestType);


            dgvTestsApointmentsTable.DataSource = _dtLicenseTestAppointments;
            lblTotalAppointmentsCount.Text = dgvTestsApointmentsTable.Rows.Count.ToString();

            if (dgvTestsApointmentsTable.Rows.Count > 0)
            {
                dgvTestsApointmentsTable.Columns[0].HeaderText = "Appointment ID";
                dgvTestsApointmentsTable.Columns[0].Width = 100;

                dgvTestsApointmentsTable.Columns[1].HeaderText = "Appointment Date";
                dgvTestsApointmentsTable.Columns[1].Width = 120;

                dgvTestsApointmentsTable.Columns[2].HeaderText = "Paid Fees";
                dgvTestsApointmentsTable.Columns[2].Width = 100;

                dgvTestsApointmentsTable.Columns[3].HeaderText = "Is Locked";
                dgvTestsApointmentsTable.Columns[3].Width = 80;
            }

            ctrlDataGridPagesMoving1.btnFirst.PerformClick();



        }

        private async void btnAddNewAppointment_Click(object sender, EventArgs e)
        {

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(_LocalDrivingLicenseApplicationID);

           
            if (await localDrivingLicenseApplication.IsThereAnActiveScheduledTestAsync(_TestType))
            {
                _WhenActiveAppointmentExist();
                return;
            }
            //---
            clsTest LastTest = await localDrivingLicenseApplication.GetLastTestPerTestTypeAsync(_TestType);

            if (LastTest == null)
            {

                if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ScheduleTest))
                {

                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                _WhenAlreadyPassInCurrentTest();
                return;
            }

            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ScheduleTest))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmScheduleTest frm2 = new frmScheduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmListTestAppointments_Load(null, null);
            //---

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int TestAppointmentID = (int)dgvTestsApointmentsTable.CurrentRow.Cells[0].Value;

            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ScheduleTest))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.TakeTest))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            int TestAppointmentID = (int)dgvTestsApointmentsTable.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }


        private void ctrlDrivingLicenseApplicationInfo1_OnAppNotFound(int LocalAppID)
        {
            MessageBox.Show($"No applictaion Found with id = [{LocalAppID}]", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void ctrlDataGridPagesMoving2_OnButtonClicked()
        {
            dgvTestsApointmentsTable.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_dtLicenseTestAppointments.DefaultView);
        }

        private void cmsStreetTest_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            editTestToolStripMenuItem.Enabled =!(bool) dgvTestsApointmentsTable.CurrentRow.Cells[3].Value;
            takeTestToolStripMenuItem.Enabled = !(bool)dgvTestsApointmentsTable.CurrentRow.Cells[3].Value;

        }
    }
}
