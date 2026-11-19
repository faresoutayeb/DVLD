using DVLD_Bussiness_Layer;
using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_User__Controles;
using DVLD_Presentation_Layer.DVLD_Applications.Applications_User_Controles;
using DVLD_Presentation_Layer.Global_Controls;
using DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls;
using DVLD_Presentation_Layer.Global_Controls.Global_Licenses_Controls;
using DVLD_Presentation_Layer.LocalDrivingLicence.Local_Driving_License_User_Controles;
using DVLD_Presentation_Layer.Person.PersonControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.DrivingLicense.Driving_License_Screens
{
    public partial class frmIssueNewDrivingLicenseScreen : Form
    {


        public frmIssueNewDrivingLicenseScreen(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            clsLocalDrivingLicenseApplication.OnLicenseObjectNotValid += _WhenLicenseObjectNotValid;
        }

        private void _WhenLicenseObjectNotValid(object  sender, clsValidationErrorEventArgs e)
        {
            MessageBox.Show($"property name {e.PropertyName}  error message {e.ErrorMessage}", "license object is not valid");
        }

        //--------------------- Variable Definition -------------------------------
        private int _LocalDrivingLicenseApplicationID;

        private clsLocalDrivingLicenseApplication _CurrentLocalApplication; 

        //--------------------- Function To call Once Firing Event -------------------------------

        private void _WhenPersonIsAlreadyHasActiveLicenseInThisClass(int LicenseID)
        {
            MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _WhenNewDrivingLicenseCreated(int NewLicenseID)
        {
            MessageBox.Show($"New Driving License Created with ID = {NewLicenseID}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _WhenLocalDrivingLicenseNotFounded(int LocalDrivingLicenseAppID)
        {
            MessageBox.Show("No Applicaiton with ID=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _WhenNewDrivingLicenseNotCreated()
        {
            MessageBox.Show($"New Driving License Not Created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _WhenPersonIsNotCompleteAllTheTests()
        {
            MessageBox.Show($"Person Is Not Complete All The Tests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //--------------------- Our Local Function -------------------------------

        //--------------------- Controls Event To Fire -------------------------------

        private async void btnIssueLicense_Click_1(object sender, EventArgs e)
        {

            int LicenseID =await  _CurrentLocalApplication.IssueLicenseForTheFirtTimeAsync(txtbNotes.Text.Trim(), clsGlobalUserInfo.CurrentLogInUser.UserID);

            if (LicenseID != -1)
            {
                _WhenNewDrivingLicenseCreated(LicenseID);
                btnIssueLicense.Enabled = false;
                this.Close();
            }
            else
            {
                _WhenNewDrivingLicenseNotCreated();
            }
        }

        public void _WhenlicenseObjectNotValid(object obj)
        {
            MessageBox.Show($"Object {obj.ToString()} not valid");
        }

        private async void frmIssueNewDrivingLicenseScreen_Load(object sender, EventArgs e)
        {
            txtbNotes.Focus();
            _CurrentLocalApplication = await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(_LocalDrivingLicenseApplicationID);

            if (_CurrentLocalApplication == null)
            {

                _WhenLocalDrivingLicenseNotFounded(_LocalDrivingLicenseApplicationID);
                this.Close();
            }


            if (!await _CurrentLocalApplication.PassedAllTestsAsync())
            {

                _WhenPersonIsNotCompleteAllTheTests();
                this.Close();
                return;
            }

            int LicenseID = await _CurrentLocalApplication.GetActiveLicenseIDAsync();
            if (LicenseID != -1)
            {
                _WhenPersonIsAlreadyHasActiveLicenseInThisClass(LicenseID);
                this.Close();
                return;

            }

          await  ctrlPersonInfo_Small_1.LoadInfo(_CurrentLocalApplication.ApplicantPersonID);
            await ctrlLocalApplicationDetails1.LoadInfo(_CurrentLocalApplication.LocalDrivingLicenseApplicationID);
           await  ctrlUpcomingTests1.LoadInfo(_CurrentLocalApplication.LocalDrivingLicenseApplicationID,await clsLocalDrivingLicenseApplication.GetPassedTestsCountAsync(_CurrentLocalApplication.LocalDrivingLicenseApplicationID));
           await ctrlRecentDetainActivities1.LoadInfo();

           await ctrlTotalLocalLicenses2.LoadInfo();
          await  ctrlTotalLocalDriverLicenses1.LoadInfo(_CurrentLocalApplication.ApplicantPersonID);

          await  ctrlAciveDriverLicenses1.LoadInfo(_CurrentLocalApplication.ApplicantPersonID);
            await ctrlInactiveDriverLicenses1.LoadInfo(_CurrentLocalApplication.ApplicantPersonID);
           await ctrlTotalActiveLocalLicenses1.LoadInfo();
             await ctrlTotalExpiredLicenses1.LoadInfo();

            await ctrlTotalInactiveLicenses1.LoadInfo();
            await ctrlExpiredDriverLicenses1.LoadInfo(_CurrentLocalApplication.ApplicantPersonID);
        }
    }
}
