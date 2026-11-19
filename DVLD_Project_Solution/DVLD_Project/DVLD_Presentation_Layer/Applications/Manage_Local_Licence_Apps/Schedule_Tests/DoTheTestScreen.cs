using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Screens
{
    public partial class frmTakeTest : Form
    {
        public frmTakeTest()
        {

            InitializeComponent();
        }

        private int _AppointmentID;
        private clsTestType.enTestType _TestType;
        private int _TestID = -1;

        private clsTest _Test;

        public frmTakeTest(int AppointmentID, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            this._AppointmentID = AppointmentID;
            _TestType = TestType;
            
        }

        public delegate void OnDoTheTestScreenClosedEventHandler();
        public event OnDoTheTestScreenClosedEventHandler OnDoTheTestScreenClosed;




        private void _WhenTestNotAdded()
        {
            MessageBox.Show("Test Not Added","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void _WhenTestAdded(int NewAddedTestId)
        {
            MessageBox.Show($"Test Added and locked Successfully With Id = {NewAddedTestId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _WhenTestAppointmentLocked(int TestAppointmentID)
        {

            MessageBox.Show($"Test Appointment With Id = {TestAppointmentID} was Locked Successfully ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void _WhenTestAppointmentNotLocked(int TestAppointmentID)
        {

            MessageBox.Show($"Test Appointment With Id = {TestAppointmentID} was not Locked ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _WhenTestAppointmentNotFound(int TestAppointmentID)
        {
            _AppointmentID=TestAppointmentID;
            MessageBox.Show($"No Test Appointment With Id = {TestAppointmentID} was founded  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        
        }


        private void _FillTestObjectFromControls()
        {
            _Test=new clsTest();

            _Test.TestResult = rbPass.Checked;


                _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobalUserInfo.CurrentLogInUser.UserID;
            _Test.TestAppointmentID = _AppointmentID;
        }

    

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
            OnDoTheTestScreenClosed?.Invoke();
        }

        private void ctrlScheduledTest1_OnAppointmentFound(int FoundedAppointmentID)
        {
            _AppointmentID = FoundedAppointmentID;
        }

        private async void ctrlScheduledTest1_OnTestFound(int FoundedTestID)
        {
            _TestID = FoundedTestID;
            if (this._TestID != -1)
            {
                _Test =await clsTest.FindByTestIDAsync(_TestID);

            }
            else 
            {
                    _Test = new clsTest();

            }



        }

        private async void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestType;
            await ctrlScheduledTest1.LoadInfo(_AppointmentID);

            if (this._AppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            if (_Test != null)
            {
                rbPass.Checked = (_Test.TestResult);
                txtNotes.Text = _Test.Notes;
                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _FillTestObjectFromControls();

            if (await this._Test.SaveAsync())
            {
                clsTestAppointment TestAppointment =await clsTestAppointment.FindAsync(_AppointmentID);
                if(TestAppointment != null)
                {
                    if(await TestAppointment.LockedAppointmentAsync())
                    {
                        _WhenTestAdded(this._Test.TestID);
                        btnSave.Enabled = false;

                    }
                }



            }
            else
            {
                _WhenTestNotAdded();
            }
        }
    }
}
