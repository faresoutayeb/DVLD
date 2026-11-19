using DVLD.Classes;
using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Bussiness_Layer.clsLicense;

namespace DVLD_Presentation_Layer.Replacement_for_Damaged_Or_Lost_Licenses.Replacement_Screens
{
    public partial class frmReplaceLicense : Form
    {
        public frmReplaceLicense()
        {
            InitializeComponent();
        }
        //------------------------------------------ Function To call Ones Event Fired--------------------------------

        private void _WhenLicenseNotActive()
        {
            MessageBox.Show("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void _WhenLicenseNotReplaced()
        {
            MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _WhenLicenseReplaced(int NewRenewedLicenseID)
        {
            MessageBox.Show($"Licensed Replaced Successfully with ID = {_NewLicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //------------------------------------------ Controls Events --------------------------------
        private clsApplicationType.enApplicationType _GetApplicationTypeID()
        {
            //this will decide which application type to use accirding 
            // to user selection.

            if (rbDamagedLicense.Checked)

                return clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense;
            else
                return clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense;
        }

        private clsLicense.enIssueReasons _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rbDamagedLicense.Checked)

                return clsLicense.enIssueReasons.ReplacementForDamaged;
            else
                return clsLicense.enIssueReasons.ReplacementForLostOrStolen;
        }

        private void btnNewLicenseInfo_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseInfoScreen OpenLicenceInfoScreen = new frmLicenseInfoScreen(this._NewLicenseID);
            OpenLicenceInfoScreen.ShowDialog();

        }

        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLicenseHistory))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseHistoryScreen OpenLicenseHistoryScreen = new frmLicenseHistoryScreen(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DriverInfo.PersonInfo.PersonID);
            OpenLicenseHistoryScreen.ShowDialog();

        }

        private int _NewLicenseID = -1;

        private async void btnReplacementLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicense NewLicense = await ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ReplaceAsync(_GetIssueReason(), clsGlobalUserInfo.CurrentLogInUser.UserID);

            if (NewLicense == null)
            {
                _WhenLicenseNotReplaced();


                return;
            }
            lblReplacmentApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            lblReplacedLicenseID.Text = _NewLicenseID.ToString();
            _WhenLicenseReplaced(_NewLicenseID);

            btnReplacementLicense.Enabled = false;
            gbReplacementFor.Enabled = true;

            //ctrlOrdinaryLicenseFilter1.FilterEnabled = false;
            btnShowLicenseHistory.Enabled = true;


        }

        
        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblScreenTitle.Text = "Replacement for Lost License";
            this.Text = lblScreenTitle.Text;
            lblApplicationFees.Text = _LostLicenseFees.ToString();
        }

        private float _DamagedLicenseFees;
        private float _LostLicenseFees;

        private async void ReplacementForDamagedOrLostLicensesScreen_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUserName.Text = clsGlobalUserInfo.CurrentLogInUser.UserName;

            rbDamagedLicense.Checked = true;
            _DamagedLicenseFees = await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense);
            _LostLicenseFees = await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense);
            await ctrlTotalLocalLicenses1.LoadInfo();
            await ctrlTotalActiveLocalLicenses1.LoadInfo();
            await ctrlTotalInactiveLicenses1.LoadInfo();
            await ctrlTotalExpiredLicenses1.LoadInfo();
        }

        private async void ctrlOrdinaryLicenseFilter1_OnLicenseSelected(int LicenseID)
        {
            int SelectedLicenseID = LicenseID;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            btnShowLicenseHistory.Enabled = (SelectedLicenseID != -1);
            if (SelectedLicenseID == -1)
            {
                return;
            }

            await ctrlTotalLocalDriverLicenses1.LoadInfo(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ApplicationInfo.ApplicantPersonID);
            await ctrlAciveDriverLicenses1.LoadInfo(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ApplicationInfo.ApplicantPersonID);
            await ctrlExpiredDriverLicenses1.LoadInfo(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ApplicationInfo.ApplicantPersonID);
            await ctrlInactiveDriverLicenses1.LoadInfo(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ApplicationInfo.ApplicantPersonID);


            //dont allow a replacement if is Active .
            if (!ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.IsActive)
            {
                _WhenLicenseNotActive();
                btnReplacementLicense.Enabled = false;
                return;
            }
            gbReplacementFor.Enabled= true;
            btnReplacementLicense.Enabled = true;


        }



        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblScreenTitle.Text = "Replacement for Damaged License";
            this.Text = lblScreenTitle.Text;
            lblApplicationFees.Text = _DamagedLicenseFees.ToString();
        }

        private void ctrlOrdinaryLicenseFilter1_OnNoLicenseFounded()
        {
            MessageBox.Show("License not founded", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
