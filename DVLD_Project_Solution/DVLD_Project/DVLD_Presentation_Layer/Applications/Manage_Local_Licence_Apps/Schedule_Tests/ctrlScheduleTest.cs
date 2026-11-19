using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Controles
{
    public partial class ctrlScheduleTestInfo : UserControl
    {
        public ctrlScheduleTestInfo()
        {
            InitializeComponent();
        }


        //------------------------------ Event Definition-------------------------------------------------

        public event Action<int> OnLocalApplicationFounded;
        public virtual void LocalApplicationFounded(int LocalApplicationID)
        {
            OnLocalApplicationFounded?.Invoke(LocalApplicationID);
        }

        public event Action OnLocalApplicationNotFounded;
        public virtual void LocalApplicationNotFounded()
        {
            OnLocalApplicationNotFounded?.Invoke();
        }
        //------------------------------------------------------------------------------------------------
        public event Action<int> OnRetakeApplicationAdded;
        public virtual void RetakeApplicationAdded(int RetakeApplicationID)
        {
            OnRetakeApplicationAdded?.Invoke(RetakeApplicationID);
        }

        public event Action OnRetakeApplicationNotAdded;
        public virtual void RetakeApplicationNotAdded()
        {
            OnRetakeApplicationNotAdded?.Invoke();
        }
        //------------------------------------------------------------------------------------------------

        public event Action<int> OnAppointmentSave;
        public virtual void AppointmentSave(int NewTestAppointmentID)
        {
            OnAppointmentSave?.Invoke(NewTestAppointmentID);
        }

        public event Action OnAppointmentNotSave;
        public virtual void AppointmentNotSave()
        {
            OnAppointmentNotSave?.Invoke();
        }
        //------------------------------------------------------------------------------------------------

        public event Action <int>OnAppointmentFounded;
        public virtual void AppointmentFounded(int AppointmentID)
        {
            OnAppointmentFounded?.Invoke(AppointmentID);
        }

        public event Action OnAppointmentNotFounded;
        public virtual void AppointmentNotFounded()
        {
            OnAppointmentNotFounded?.Invoke();
        }
        //------------------------------------------------------------------------------------------------


        public enum enMode { AddNew = 0, Update = 1 };
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };

        private enMode _Mode = enMode.AddNew;
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestAppointmentID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsTestAppointment _TestAppointment;


        //public property is going to show in the designer ons you drag drop this control to a form
        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                _SetTestImage();
            }
        }

        private void _SetTestImage()
        {
            switch (_TestTypeID)
            {

                case clsTestType.enTestType.VisionTest:
                    {

                        lblTitle.Text = "Schedule Vision Test Appointments";
                        lblTestType.Text = "Vision Driving Test Appointment";
                        //pbTestTypeImage.Image = Resources.vision_test;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Schedule Written Test Appointments";

                        lblTestType.Text = "Written Driving Test Appointment";

                        //pbTestTypeImage.Image = Resources.written_test;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Schedule Street Test Appointments";

                        lblTestType.Text = "Street Driving Test Appointment";

                        //pbTestTypeImage.Image = Resources.street_test;
                        break;


                    }
            }

        }

        private async Task<enCreationMode> _GetCreationMode()
        {
            return (await _LocalDrivingLicenseApplication.DoesAttendTestTypeAsync(_TestTypeID) ? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule);

        }

        private async Task _InitilizeLocalVariables(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplication = await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(_LocalDrivingLicenseApplicationID);

        }

        public async Task LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            await _InitilizeLocalVariables(LocalDrivingLicenseApplicationID, AppointmentID);
            if (_LocalDrivingLicenseApplication == null)
            {
                btnSave.Enabled = false;
                LocalApplicationNotFounded();
               
                return;
            }

            _CreationMode = await _GetCreationMode();

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                float AppFees= await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.RetakeTest);
                lblRetakeAppFees.Text = AppFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonInfo.FullName;
            //this will show the trials for this test before  
            byte Trials= await _LocalDrivingLicenseApplication.TotalTrialsPerTestAsync(_TestTypeID);
            lblTrial.Text = Trials.ToString();
            lblRemainingTrials.Text=(3-Trials).ToString(); 
            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = (await clsTestType.FindTestTypeAsync(_TestTypeID))?.TestTypeFees.ToString() ?? "";
                DateTime? LastAppointment=await clsTestAppointment.LastAppointmentDateTimeAsync(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,TestTypeID, _LocalDrivingLicenseApplication.LicenseClassID);
                if(LastAppointment != null)
                {
                    dtpTestDate.MinDate = LastAppointment.Value;

                }
                else
                {
                    dtpTestDate.MinDate = DateTime.Now;

                }
                lblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();
            }

            else
            {

                if (!await _LoadTestAppointmentDataToUpdate())
                    return;
            }


            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();


            if (!await _HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (! await _HandlePrviousTestConstraint())
                return;



        }


        private async Task<bool> _LoadTestAppointmentDataToUpdate()
        {
            _TestAppointment = await clsTestAppointment.FindAsync(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                AppointmentNotFounded();
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;

            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";

                lblRetakeAppFees.Text = _TestAppointment.RetakeTestInfo.PaidFees.ToString();
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

            }
            return true;
        }

        private async Task<bool> _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew &&await clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTestAsync(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }

            lblUserMessage.Visible = false;

            return true;
        }

        private async Task<bool> _HandlePrviousTestConstraint()

        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        //in this case no required prvious test to pass.
                        lblUserMessage.Visible = false;

                        return true;
                    }


                case clsTestType.enTestType.WrittenTest:
                    {
                        //Written Test, you cannot sechdule it before person passes the vision test.
                        //we check if pass visiontest 1.
                        if (!await _LocalDrivingLicenseApplication.DoesPassTestTypeAsync(clsTestType.enTestType.VisionTest))
                        {
                            lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                            lblUserMessage.Visible = true;
                            btnSave.Enabled = false;
                            dtpTestDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lblUserMessage.Visible = false;
                            btnSave.Enabled = true;
                            dtpTestDate.Enabled = true;
                        }

                        return true;
                    }


                case clsTestType.enTestType.StreetTest:
                    {
                        //Street Test, you cannot sechdule it before person passes the written test.
                        //we check if pass Written 2.
                        if (!await _LocalDrivingLicenseApplication.DoesPassTestTypeAsync(clsTestType.enTestType.WrittenTest))
                        {
                            lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                            lblUserMessage.Visible = true;
                            btnSave.Enabled = false;
                            dtpTestDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lblUserMessage.Visible = false;
                            btnSave.Enabled = true;
                            dtpTestDate.Enabled = true;
                        }


                        return true;



                    }



            }
            return true;

        }

        private async Task<bool> _HandleSaveNewRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplication RetakeApplication = new clsApplication();

                RetakeApplication.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                RetakeApplication.ApplicationDate = DateTime.Now;
                RetakeApplication.ApplicationTypeID = (int)clsApplicationType.enApplicationType.RetakeTest;
                RetakeApplication.ApplicationStatus = clsApplication.enApplicationStatus.completed;
                RetakeApplication.LastStatusDate = DateTime.Now;
                RetakeApplication.PaidFees = await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.RetakeTest);
                RetakeApplication.CreatedByUserID = clsGlobalUserInfo.CurrentLogInUser.UserID;

                if (!await RetakeApplication.SaveAsync())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                 
                    RetakeApplicationNotAdded();
                    

                    return false;
                }
                _TestAppointment.RetakeTestApplicationID = RetakeApplication.ApplicationID;
                RetakeApplicationAdded(RetakeApplication.ApplicationID);
                


            }
            return true;
        }


        private async void btnSave_Click_1(object sender, EventArgs e)
        {

            if (!await _HandleSaveNewRetakeApplication())
                return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobalUserInfo.CurrentLogInUser.UserID;

            if ( await _TestAppointment.SaveAsync())
            {
                _Mode = enMode.Update;
     
                    AppointmentSave(_TestAppointment.TestAppointmentID);
               btnSave.Enabled = false;  

            }
            else
            {
          
                    AppointmentNotSave();
                
            }
        }
    }
}
