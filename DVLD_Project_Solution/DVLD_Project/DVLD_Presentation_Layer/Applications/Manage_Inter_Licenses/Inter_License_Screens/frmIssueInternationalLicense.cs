using DVLD.Classes;
using DVLD_Bussiness_Layer;
using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Bussiness_Layer.GlobalClasses;
using DVLD_Presentation_Layer.License.LicenseScreens.international_License_Screen;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;
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

namespace DVLD_Presentation_Layer.International_Driving_License.International_Driving_License_Screens
{
    public partial class frmIssueInternationalLicense : Form
    {
        private int _InternationalLicenseID = -1;

        public frmIssueInternationalLicense()
        {
            InitializeComponent();
            clsValidation.OnValidationError += _WhenObjectIsNotValid;
        }

        public void _WhenObjectIsNotValid(object sender, clsValidationErrorEventArgs e )
        {
            MessageBox.Show($"Property Name {e.PropertyName}  Error Message {e.ErrorMessage}");
        }

        private async void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));//add one year.
            lblFees.Text = (await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.NewInternationalLicense)).ToString();
            lblCurrentUserName.Text = clsGlobalUserInfo.CurrentLogInUser.UserName;
            await ctrlTotalActiveInternationalLicenses1.LoadInfo();
            await ctrlTotalInterLicensesIssuesThisMonth1.LoadInfo();
            await ctrlTotalInternationalLicenses1.LoadInfo();
            btnIssueInternationalLicense.Enabled = false;


        }

        private void _WhenFailedToIssueInternationalLicense()
        {
            MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _WhenInternationalLicenseIssued(int InternationalLicense)
        {
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void _WhenInvalidLocalLicenseClass()
        {
            MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void _WhenAlreadyInternationalLicenseExist(int ActiveInternaionalLicenseID)
        {
            MessageBox.Show($"Person already have an active international license with ID = {ActiveInternaionalLicenseID}", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private async Task<clsInternationalLicense> FillNewInternatinalObject(clsInternationalLicense InternationalLicense )
        {
            InternationalLicense.ApplicantPersonID = ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees =await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.NewInternationalLicense) ;
            InternationalLicense.CreatedByUserID = clsGlobalUserInfo.CurrentLogInUser.UserID;
            InternationalLicense.ApplicationTypeID = (byte)clsApplicationType.enApplicationType.NewInternationalLicense;

            InternationalLicense.DriverID = ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.CreatedByUserID = clsGlobalUserInfo.CurrentLogInUser.UserID;
            return InternationalLicense;
        }





        private void llShowDriverLicenseHistory_LinkClicked(object sender, EventArgs e)
        {
            frmLicenseHistoryScreen frm = new frmLicenseHistoryScreen(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {
            frmInterLicenseInfo frm = new frmInterLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void ctrlOrdinaryLicenseFilter1_OnControlsNotValidated()
        {
            MessageBox.Show("Invalid Input");
        }

        private void ctrlOrdinaryLicenseFilter1_OnNoLicenseFounded()
        {
            MessageBox.Show("License not founded","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private async void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense = await FillNewInternatinalObject(InternationalLicense);
            if(!clsValidation.IsValid(InternationalLicense))
            {
                return;
            }


            if (!await InternationalLicense.SaveInternationalLicenseAsync())
            {
                _WhenFailedToIssueInternationalLicense();
                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            _WhenInternationalLicenseIssued(InternationalLicense.InternationalLicenseID);

            btnIssueInternationalLicense.Enabled = false;
          //  ctrlOrdinaryLicenseFilter1.FilterEnabled = false;
            btnShowLicenseInfo.Enabled = true;
        }

        private async void ctrlOrdinaryLicenseFilter1_OnLicenseSelected(int LicenseID)
        {
            int SelectedLicenseID = LicenseID;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            btnShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            clsLicense CurrentSelectedLicense = await clsLicense.FindByAsync(LicenseID);
            await ctrlTotalLocalDriverLicenses1.LoadInfo(CurrentSelectedLicense.ApplicationInfo.ApplicantPersonID);
            await ctrlAciveDriverLicenses1.LoadInfo(CurrentSelectedLicense.ApplicationInfo.ApplicantPersonID);
            await ctrlInactiveDriverLicenses1.LoadInfo(CurrentSelectedLicense.ApplicationInfo.ApplicantPersonID);
            await ctrlExpiredDriverLicenses1.LoadInfo(CurrentSelectedLicense.ApplicationInfo.ApplicantPersonID);
            await ctrlTotalInternationalDriverLicenses1.LoadInfo(CurrentSelectedLicense.ApplicationInfo.ApplicantPersonID);
            //check the license class, person could not issue international license without having
            //normal license of class 3.

            if (ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                _WhenInvalidLocalLicenseClass();
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = await clsInternationalLicense.GetActiveInternationalLicenseIDByDriverIDAsync(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DriverID);
            if (ActiveInternaionalLicenseID != -1)
            {

                btnShowLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssueInternationalLicense.Enabled = false;
                _WhenAlreadyInternationalLicenseExist(ActiveInternaionalLicenseID);
                return;
            }

            btnIssueInternationalLicense.Enabled = true;
        }

        private void ctrlTotalActiveInternationalLicenses1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlOrdinaryLicenseFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
