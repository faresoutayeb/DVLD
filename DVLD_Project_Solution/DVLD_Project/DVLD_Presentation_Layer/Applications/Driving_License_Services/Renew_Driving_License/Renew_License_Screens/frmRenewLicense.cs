using DVLD.Classes;
using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Global_Controls;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;
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
using System.Xml.Serialization;

namespace DVLD_Presentation_Layer.Renew_Driving_License.Renew_Driving_License_Screens
{
    public partial class frmRenewDrivingLicenseScreen : Form
    {
        public frmRenewDrivingLicenseScreen()
        {
            InitializeComponent();

        }

        private int _NewLicenseID;
      
      

        //------------------------------------------ Controls Events Fired -------------------------------

        private async void ctrlOrdinaryLicenseFilter1_OnLicenseSelected(int LicenseID)
        {
            int SelectedLicenseID = LicenseID;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            btnShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }
            clsApplicationType apptype =await clsApplicationType.FindApplicationTypeAsync(clsApplicationType.enApplicationType.RenewDrivingLicense);
            
            int DefaultValidityLength = ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            float LicenseClassFees = ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees;
            lblApplicationFees.Text = LicenseClassFees.ToString();

            lblTotalFees.Text = (LicenseClassFees +apptype.ApplicationFees ).ToString();
            txtbNotes.Text = ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.Notes;

           await ctrlTotalLocalDriverLicenses1.LoadInfo(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ApplicationInfo.ApplicantPersonID);
              await ctrlAciveDriverLicenses1.LoadInfo(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ApplicationInfo.ApplicantPersonID);
          await  ctrlExpiredDriverLicenses1.LoadInfo(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ApplicationInfo.ApplicantPersonID);
          await  ctrlInactiveDriverLicenses1.LoadInfo(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ApplicationInfo.ApplicantPersonID);
            
            
            //check the license is not Expired.
            if (!ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.IsExpired)
            {
                _WhenLicenseNotExpired();                  
                btnRenewLicense.Enabled = false;
                return;
            }

            //check the license is not Expired.
            if (!ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.IsActive)
            {
                _WhenLicenseNotActive();
                btnRenewLicense.Enabled = false;
                return;
            }
            btnRenewLicense.Enabled = true;



        }
         
        private async void RenewDrivingLicenseScreen_Load(object sender, EventArgs e)
        {
            ctrlOrdinaryLicenseFilter1.txtLicenseIDFocus();

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblExpirationDate.Text = "???";
            float applicationFees = await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.RenewDrivingLicense);
            lblApplicationFees.Text = applicationFees.ToString();
            lblCreatedByUserID.Text = clsGlobalUserInfo.CurrentLogInUser.UserName;

           await ctrlTotalLocalLicenses1.LoadInfo();
           await ctrlTotalActiveLocalLicenses1.LoadInfo();
          await  ctrlTotalInactiveLicenses1.LoadInfo();
           await ctrlTotalExpiredLicenses1.LoadInfo();
        }


        private void frmRenewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlOrdinaryLicenseFilter1.txtLicenseIDFocus();

        }



        private void ShowLicenseInfoScreen_ButtonClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseInfoScreen frm = new frmLicenseInfoScreen(_NewLicenseID);
            frm.ShowDialog();
        }



        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLicenseHistory))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseHistoryScreen frm = new frmLicenseHistoryScreen(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnLicenseInfo_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseInfoScreen frm = new frmLicenseInfoScreen(_NewLicenseID);
            frm.ShowDialog();
        }

        private async void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicense NewLicense = await ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.RenewLicenseAsync(txtbNotes.Text.Trim(), clsGlobalUserInfo.CurrentLogInUser.UserID);

            if (NewLicense == null)
            {
                _WhenLicenseNotRenewed();
                return;
            }
            _NewLicenseID = NewLicense.LicenseID;

            lblRenewApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            btnRenewLicense.Enabled = false;
            //ctrlOrdinaryLicenseFilter1.FilterEnabled = false;
            btnLicenseInfo.Enabled = true;
            btnShowLicenseHistory.Enabled = true;

            _WhenLicenseRenewed(NewLicense.LicenseID);


        }

        private void ctrlOrdinaryLicenseFilter1_OnNoLicenseFounded()
        {
            MessageBox.Show("License not founded", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
