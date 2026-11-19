using DVLD.Classes;
using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Bussiness_Layer.clsTestType;

namespace DVLD_Presentation_Layer.ScheduleTests.Schedule_Tests_Controles
{
    public partial class ctrlScheduledTest : UserControl
    {
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsTestAppointment _TestAppointment;
        private clsTestType.enTestType _TestTypeID;
        private int _TestID = -1;
        private int _TestAppointmentID = -1;

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }
        public int TestID
        {
            get
            {
                return _TestID;
            }
        }
        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                _SetpbTestTypeImageAndGbTestType();
            }
        }


        public event Action<int> OnAppointmentFound;
        protected virtual void AppointmentFound(int TestAppointmentID)
        {
            OnAppointmentFound?.Invoke(TestAppointmentID);

        }
        public event Action<int> OnTestFound;
        protected virtual void TestFound(int TestID)
        {
            OnTestFound?.Invoke(TestID);

        }

        public event Action<int> OnNoAppointmentFound;
        protected virtual void NoAppointmentFound(int TestAppointmentID)
        {
            OnNoAppointmentFound?.Invoke(TestAppointmentID);

        }

        public event Action<int> OnNoLocalDrivingLicenseAppFound;
        protected virtual void NoLocalDrivingLicenseAppFound(int LocalDrivingLicenseAppID)
        {
            OnNoLocalDrivingLicenseAppFound?.Invoke(LocalDrivingLicenseAppID);

        }


        private void _SetpbTestTypeImageAndGbTestType()
        {
            switch (_TestTypeID)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Scheduled Vision Test";
                        pbTestTypeImage.Image = Resources.eye;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Scheduled Written Test";
                        pbTestTypeImage.Image = Resources.exam;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Scheduled Street Test";
                        pbTestTypeImage.Image = Resources.steering_wheel;
                        break;


                    }
            }

        }


        public async Task LoadInfo(int TestAppointmentID)
        {

            _TestAppointmentID = TestAppointmentID;
            _TestAppointment = await clsTestAppointment.FindAsync(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointment == null)
            {
                _TestAppointmentID = -1;
             
                    NoAppointmentFound(_TestAppointment.TestAppointmentID);
                
                return;
            }
            
                AppointmentFound(_TestAppointment.TestAppointmentID);
            

            _LocalDrivingLicenseApplication = await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(_TestAppointment.LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
  

                    NoLocalDrivingLicenseAppFound(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
                

                return;
            }

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonInfo.FullName;

            //this will show the trials for this test before 
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTestAsync(_TestTypeID).ToString();

            lblAppointmentDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lblFees.Text = _TestAppointment.PaidFees.ToString();

            _TestID = (await clsTest.FindByTestAppointmentIDAsync(_TestAppointmentID))?.TestID ?? -1;
            lblTestID.Text = (_TestID == -1) ? "Not Taken Yet" : _TestID.ToString();
            if(_TestID!=-1)
            {
             
                    TestFound(_TestID);
                
            }

        }

   
    }
}
