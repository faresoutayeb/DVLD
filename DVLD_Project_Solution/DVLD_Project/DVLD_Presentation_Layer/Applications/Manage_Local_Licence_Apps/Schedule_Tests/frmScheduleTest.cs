using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Manage_Local_Driving_License_Applications_Screen;
using DVLD_Presentation_Layer.LocalDrivingLicence;
using DVLD_Presentation_Layer.Properties;
using DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Controles;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

//using static DVLD_Presentation_Layer.Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Manage_Local_Driving_License_Applications_Screen.ManageLocalDrivingLicensesApplicationsScreen;
using static DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Screens.frmManageTestsAppointmentsScreen;

namespace DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Screens
{
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest()
        {

            InitializeComponent();
        }

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;


        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int AppointmentID = -1)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
            InitializeComponent();
        }

        //------------------------------ Event Function To Fire-----------------------------------


        private void _WhenTestAppointmentFounded(int TestAppointmentID)
        {
            MessageBox.Show($"New TestAppointment Added Successsfuly With ID = {TestAppointmentID}");
        }

        private void _WhenTestAppointmentNotFounded()
        {
            MessageBox.Show($"New TestAppointment not founded ");
        }
        private void _WhenTestAppointmentSave(int NewTestAppointmentID)
        {
            MessageBox.Show($"New TestAppointment Added Successsfuly With ID = {NewTestAppointmentID}");
        }

        private void _WhenTestAppointmentNotSave()
        {
            MessageBox.Show($"New TestAppointment Added Successsfuly");
        }
        private void _WhenRetakeApplicationAdded(int NewRetakeApplicationID)
        {
            MessageBox.Show($"New Retake application  added Successsfuly With ID = {NewRetakeApplicationID}");
        }

        private void _WhenRetakeApplicationNotAdded()
        {
            MessageBox.Show($"New Retake application Not added  ");
        }


        private void _WhenLocalDrivingLicenseApplicationFounded(int LocalDrivingAppID)
        {
            MessageBox.Show($"Local Driving License Application Founded with id = {LocalDrivingAppID}",
                        "Great", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void _WhenLocalDrivingLicenseApplicationNotFounded()
        {
            MessageBox.Show($"Error: No Local Driving License Application Not Founded ",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }






        private async void AddEditTestAppointmentScreen_Load(object sender, EventArgs e)
        {
            ctrlScheduleTestInfo1 .TestTypeID= _TestTypeID;
            await ctrlScheduleTestInfo1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }

        private void ctrlScheduleTestInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
