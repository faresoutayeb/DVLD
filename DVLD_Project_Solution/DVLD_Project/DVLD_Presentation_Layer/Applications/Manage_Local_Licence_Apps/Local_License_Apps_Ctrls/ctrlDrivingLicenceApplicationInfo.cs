using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.LocalDrivingLicence.Local_Driving_License_User_Controles
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicenseApplication _CurrentLocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID;
        private int _LicenseID;

        public clsLocalDrivingLicenseApplication CurrentLocalDrivingLicenseApplication
        {
            get {  return _CurrentLocalDrivingLicenseApplication;}
        }

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }


        public event Action <int>OnAppNotFound;
        protected void AppNotFound(int LocalDrivingLicenseAppID)
        {
            OnAppNotFound?.Invoke(LocalDrivingLicenseAppID);
        }
        public event Action<int> OnAppFound;
        protected void AppFound(int LocalDrivingLicenseAppID)
        {
            OnAppFound?.Invoke(LocalDrivingLicenseAppID);
        }

        public async Task LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _CurrentLocalDrivingLicenseApplication = await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(LocalDrivingLicenseApplicationID);
            if (_CurrentLocalDrivingLicenseApplication == null)
            {
                LoadDefaultInfo();

            
                    AppNotFound(LocalDrivingLicenseApplicationID);

                return;
            }
            
               await _FillLocalDrivingLicenseApplicationInfo();
             
                    AppFound(LocalDrivingLicenseApplicationID);
                

            

        }

        public async Task LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _CurrentLocalDrivingLicenseApplication = await clsLocalDrivingLicenseApplication.FindByApplicationIDAsync(ApplicationID);
            if (_CurrentLocalDrivingLicenseApplication == null)
            {
                LoadDefaultInfo();

                    AppNotFound(LocalDrivingLicenseApplicationID);
                
                //MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_CurrentLocalDrivingLicenseApplication != null)
            {
                await _FillLocalDrivingLicenseApplicationInfo();
          
                    AppFound(LocalDrivingLicenseApplicationID);
                

            }
        }

        private async Task _FillLocalDrivingLicenseApplicationInfo()
        {
            await ctrlApplicationBasicInfo1.LoadControlsInfo(_CurrentLocalDrivingLicenseApplication.ApplicationID);

            _LicenseID = await  _CurrentLocalDrivingLicenseApplication.GetActiveLicenseIDAsync();

            //incase there is license enable the show link.
            btnShowLicenseInfo.Enabled = (_LicenseID != -1);

            lblDrivingLicenseApplicationID.Text = _CurrentLocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedLicenceClass.Text = _CurrentLocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            byte PassedTests =await  _CurrentLocalDrivingLicenseApplication.GetPassedTestCountAsync();
            lblPassedTests.Text = PassedTests.ToString() + "/3";
            if(PassedTests==1)
            {
                pbVissionPassTest.Image = Resources.yes;
                pbPassWrittentTest.Image = null;
                pbStreetTest.Image = null;                


            }
            else if (PassedTests==2)
            {
                pbVissionPassTest.Image = Resources.yes;
                pbPassWrittentTest.Image = Resources.yes;
                pbStreetTest.Image = null;

            }
            else if (PassedTests == 3)
            {
                pbVissionPassTest.Image = Resources.yes;
                pbPassWrittentTest.Image = Resources.yes;
                pbStreetTest.Image = Resources.yes;

            }
            else
            {
                pbVissionPassTest.Image = null;
                pbPassWrittentTest.Image = null;
                pbVissionPassTest.Image = null;
            }
            byte PassedTestPercentage = (byte)((PassedTests * 100) / 3);
            ProgressBarForPassedTest.Value = PassedTestPercentage;
            lblPassedTestsPersentage.Text = PassedTestPercentage.ToString();

        }

        public void LoadDefaultInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ctrlApplicationBasicInfo1.LoadDefaultInfo();
            lblDrivingLicenseApplicationID.Text = "[????]";
            lblAppliedLicenceClass.Text = "[????]";
            lblPassedTests.Text = "NA/3";

        }




        private async void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {
            frmLicenseInfoScreen frm = new frmLicenseInfoScreen(await _CurrentLocalDrivingLicenseApplication.GetActiveLicenseIDAsync());
            frm.ShowDialog();
        }
    }
}
