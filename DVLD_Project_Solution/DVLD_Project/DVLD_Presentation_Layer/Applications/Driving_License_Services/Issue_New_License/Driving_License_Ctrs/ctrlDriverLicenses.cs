using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.License.LicenseScreens.international_License_Screen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.DrivingLicense.Driving_License_User_Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicenses;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
          
        public event Action  OnPersonIsNotDriver;
        protected virtual void PersonIsNotDriver()
        {
            OnPersonIsNotDriver?.Invoke();
        }

        private async Task _LoadLocalLicenseInfo()
        {

            _dtDriverLocalLicenses =await clsDriver.GetLicensesAsync(_DriverID);


            dgvLocalLicenses.DataSource = _dtDriverLocalLicenses;
            lblLocalLicensesRecords.Text = _dtDriverLocalLicenses.Rows.Count.ToString();

            if (dgvLocalLicenses.Rows.Count > 0)
            {
                dgvLocalLicenses.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicenses.Columns[0].Width = 110;

                dgvLocalLicenses.Columns[1].HeaderText = "App.ID";
                dgvLocalLicenses.Columns[1].Width = 110;

                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenses.Columns[2].Width = 270;

                dgvLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[3].Width = 170;

                dgvLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[4].Width = 170;

                dgvLocalLicenses.Columns[5].HeaderText = "Is Active";
                dgvLocalLicenses.Columns[5].Width = 110;

            }
        }

        private async Task _LoadInternationalLicenseInfo()
        {

            _dtDriverInternationalLicensesHistory = await clsDriver.GetInternationalLicensesAsync(_DriverID);


            dgvInternationalLicensesHistory.DataSource = _dtDriverInternationalLicensesHistory;
            lblInternationalLicensesRecords.Text = _dtDriverInternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 160;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 130;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 130;

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 180;

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 180;

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 120;

            }
        }

        public async Task LoadInfoByDriverID(int DriverID)
        {
            _Driver =await clsDriver.FindByDriverIDAsync(_DriverID);
            if (_Driver == null)
            {
              
                    PersonIsNotDriver();
                
                return;
            }
            _DriverID = DriverID;
           await _LoadLocalLicenseInfo();
           await _LoadInternationalLicenseInfo();

        }

        public async Task LoadInfoByPersonID(int PersonID)
        {

            _Driver = await clsDriver.FindByPersonIDAsync(PersonID);
            if (_Driver == null)
            {
             
                    PersonIsNotDriver();
                
                return;
            }
            _DriverID = _Driver.DriverID;
            await _LoadLocalLicenseInfo();
            await _LoadInternationalLicenseInfo();
        }




      

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            int InternationalLicenseID = (int)dgvInternationalLicensesHistory.CurrentRow.Cells[0].Value;
            frmInterLicenseInfo InternationalLicense = new frmInterLicenseInfo(InternationalLicenseID);
            InternationalLicense.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewInternationalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            int LicenseID = (int)dgvLocalLicenses.CurrentRow.Cells[0].Value;
            frmLicenseInfoScreen frm = new frmLicenseInfoScreen(LicenseID);
            frm.ShowDialog();
        }

        private void ctrlDataGridPagesMoving2_OnButtonClicked()
        {
            dgvInternationalLicensesHistory.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_dtDriverInternationalLicensesHistory.DefaultView);
        }

        private void ctrlDataGridPagesMoving1_OnButtonClicked()
        {
            dgvLocalLicenses.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_dtDriverLocalLicenses.DefaultView);
        }
    }
}
