using DVLD.Classes;
using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Release_License.Realease_License_Screens
{
    public partial class frmReleaseLicenseScreen : Form
    {
        private int _SelectedLicenseID = -1;

        public frmReleaseLicenseScreen()
        {
            InitializeComponent();
            _Mode = enMode.AddNeW;
        }

        enum  enMode { Update,AddNeW}
        enMode _Mode;
        public frmReleaseLicenseScreen(int LicenseID)
        {
            InitializeComponent();
            _Mode = enMode.Update;

            _SelectedLicenseID = LicenseID;

        }

        private void _WhenLicenseIsNotRelease()
        {
            MessageBox.Show("Selected License i is not released, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _WhenFailedToReleaseLicense()
        {
            MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void _WhenLicenseReleased()
        {
            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private async void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            btnShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            float ApplicationFess = await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense);
            lblApplicationFees.Text = ApplicationFess.ToString();

            clsDetainedLicense DetainInfo =await clsDetainedLicense.FindByLicenseIDAsync(_SelectedLicenseID); 
            if(clsUtil.IsObjectFull(DetainInfo))
            {
                lblDetainID.Text = DetainInfo.DetainID.ToString();
                lblLicenseID.Text = DetainInfo.LicenseID.ToString();
                lblCreatedByUser.Text = DetainInfo.UserInfo.UserName;
                lblDetainDate.Text = clsFormat.DateToShort(DetainInfo.DetainDate);
                lblFineFees.Text = DetainInfo.FineFees.ToString();
                lblTotalFees.Text = (ApplicationFess + Convert.ToSingle(lblFineFees.Text)).ToString();

                btnReleaseLicense.Enabled = true;
                btnShowLicenseHistory.Enabled = true;
                btnNewLicenseInfo.Enabled = true;

            }

        }




        private void llShowLicenseHistory_LinkClicked(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLicenseHistory))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseHistoryScreen frm =new frmLicenseHistoryScreen(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnNewLicenseInfo_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseInfoScreen frm = new frmLicenseInfoScreen(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private async void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsDetainedLicense CurrentDetainedLicense =await clsDetainedLicense.FindByLicenseIDAsync(_SelectedLicenseID);
            if (CurrentDetainedLicense == null)
            {

                MessageBox.Show( "License is not detained","", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (!await CurrentDetainedLicense.IsLicenseDetainedAsync())
            {
                MessageBox.Show("You cannot release this license","License is not detained",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                return;
            }
            clsLicense.clsReleaseInfo releaseInfo = new clsLicense.clsReleaseInfo();
            releaseInfo = await ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ReleaseDetainedLicenseAsync(clsGlobalUserInfo.CurrentLogInUser.UserID); ;

            lblApplicationID.Text = releaseInfo.ReleaseApplicationID.ToString();

            if (!releaseInfo.IsRelease)
            {
                _WhenFailedToReleaseLicense();
                return;
            }


            btnReleaseLicense.Enabled = false;
            btnShowLicenseHistory.Enabled = true;
            btnNewLicenseInfo.Enabled = true;
            await _LoadControlsInfo();
            _WhenLicenseReleased();


        }

        private async void frmReleaseLicenseScreen_Load(object sender, EventArgs e)
        {
            if(_Mode==enMode.Update)
            {


                ctrlOrdinaryLicenseFilter1.LoadLicenseInfo(_SelectedLicenseID);
                ctrlOrdinaryLicenseFilter1.FilterEnabled = false;
            }
            else
            {
                _SelectedLicenseID = -1;
            }

          await  _LoadControlsInfo();

        }


        private async Task _LoadControlsInfo()
        {
            ctrlWelcomeUser1.LoadInfo(clsGlobalUserInfo.CurrentLogInUser);

            await ctrlTotalActiveLicenses1.LoadInfo();
            await ctrlTotalCurrentlyDetainedLicenses1.LoadInfo();
            await ctrlTotalDetainedFees1.LoadInfo();
            await ctrlTotalDetainedLicenses1.LoadInfo();
            await ctrlTotalReleasedLicenses1.LoadInfo();

            await ctrlTotalCurrentlyDetainedLicenses1.LoadInfo();
            await ctrlNewDetentionsThisMonth1.LoadInfo();
            await ctrlNewDetentionsLast30Days1.LoadInfo();

            await ctrlDetainReasons_Top5_1.LoadInfo();

        }
        private void ctrlOrdinaryLicenseFilter1_OnNoLicenseFounded()
        {
            MessageBox.Show("License not founded", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
