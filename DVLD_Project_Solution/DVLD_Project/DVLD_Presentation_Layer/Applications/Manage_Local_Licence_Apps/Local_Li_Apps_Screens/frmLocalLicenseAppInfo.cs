using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Local_Driving_License_Application_Screen
{
    public partial class frmLocalLicenseAppInfo : Form
    {
        public frmLocalLicenseAppInfo()
        {
            InitializeComponent();
        }

        private int _LocalDrivingLicenseApplicationID;

        public frmLocalLicenseAppInfo(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseAppID;
        }

        private async void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
           await ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }

        private void ctrlDrivingLicenseApplicationInfo1_OnAppNotFound(int LocalDrivingLicenseApplicationID)
        {
            MessageBox.Show("No Application with Local Driving License Application ID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


    }
}
