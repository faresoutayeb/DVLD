using DVLD.Classes;
using DVLD_Bussiness_Layer;
using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Bussiness_Layer.GlobalClasses;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;
using DVLD_Presentation_Layer.Renew_Driving_License.Renew_Driving_License_Screens;
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

namespace DVLD_Presentation_Layer.Detained_License.Detained_License_Screens
{
    public partial  class frmDetainLicense : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
            clsLicense.OnObjectNotValid += WhenCurrentDetainObjectNotValid;

        }

        DataTable dtDetainReasons = new DataTable();
        private async Task FillDetainReasonComboBox()
        {
            dtDetainReasons = await clsDetainReason.GetAllDetainReasonsAsync();

            for (int i = 0; i < dtDetainReasons.Rows.Count; i++)
            {

                cbDetainReasons.Items.Add(dtDetainReasons.Rows[i][1]);
            }
        }
        //------------------------------- Function To call ones event fired ----------------------------------

        private void _WhenLicenseDetained(int LicenseID, int DetainID)
        {
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _WhenLicenseNotDetained()
        {
            MessageBox.Show("License Not Detained", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _WhenLicenseNotValid()
        {
            MessageBox.Show("License Not Valid ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void _WhenLicenseAlreadyDetained()
        {
            MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        //------------------------------------------ Initialize Local Events with function to call ones fired-------------------------------

        private void WhenCurrentDetainObjectNotValid(object sender, clsValidationErrorEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "FineFees":
                    errorProvider1.SetError(txtFineFees, $"Property  {e.PropertyName} {e.ErrorMessage}");
                    break;
                default:
                    errorProvider1.SetError(txtFineFees,null);
                    break;
            }


        }
        private async void btnDetain_Click(object sender, EventArgs e)
        {



            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //ToDo: make sure the license is not detained already.
            if (await clsDetainedLicense.IsLicenseDetainedAsync(_SelectedLicenseID))
            {
                _WhenLicenseAlreadyDetained();
                btnDetainLicense.Enabled = false;
                btnShowLicenseHistory.Enabled = false;
                btnShowLicenseInfo.Enabled = true;
                return;
            }

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some required filed Not filled properly ! put the mouse on the red icon to see the error", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }



            clsDetainReason CurrentReason=await clsDetainReason.FindAsync(cbDetainReasons.SelectedIndex);
            if(clsUtil.IsObjectFull(CurrentReason))
            {
                _DetainID = await ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DetainAsync(Convert.ToSingle(txtFineFees.Text), clsGlobalUserInfo.CurrentLogInUser.UserID, CurrentReason.DetainReasonID);
                if (_DetainID == -1)
                {
                    _WhenLicenseNotDetained();

                    return;
                }

            }
            lblDetainID.Text = _DetainID.ToString();
            btnDetainLicense.Enabled = false;
            //ctrlOrdinaryLicenseFilter1.FilterEnabled = false;
            btnShowLicenseInfo.Enabled = true;
           await LoadControlsInfos();
            _WhenLicenseDetained(_SelectedLicenseID, _DetainID);

        }




        private  void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            btnShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            txtFineFees.Focus();
            btnDetainLicense.Enabled = true;
            btnShowLicenseHistory.Enabled = true;
            btnShowLicenseInfo.Enabled=true;        
        }


        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {

            if (!clsValidation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            }
            ;
        }



        private void llShowLicenseHistory_LinkClicked(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLicenseHistory))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseHistoryScreen frm = new frmLicenseHistoryScreen(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseInfoScreen frm = new frmLicenseInfoScreen(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void ctrlOrdinaryLicenseFilter1_OnControlsNotValidated()
        {
            _WhenLicenseNotValid();
        }

        private async Task LoadControlsInfos()
        {
            await ctrlDetainReasons_Top5_1.LoadInfo();
            await  ctrlTotalCurrentlyDetainedLicenses1.LoadInfo();
            await ctrlTotalDetainedFees1.LoadInfo();
            await ctrlTotalDetainedLicenses1.LoadInfo();
            await ctrlTotalReleasedLicenses1.LoadInfo();
        }
        private async void frmDetainLicenseScreen_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobalUserInfo.CurrentLogInUser.UserName;
            await LoadControlsInfos();
            await FillDetainReasonComboBox();
        }

        private void ctrlOrdinaryLicenseFilter1_OnNoLicenseFounded()
        {
            MessageBox.Show("License not founded", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
