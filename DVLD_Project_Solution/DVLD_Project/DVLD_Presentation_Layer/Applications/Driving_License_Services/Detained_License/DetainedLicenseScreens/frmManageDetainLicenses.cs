using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Detained_License.Detained_License_Screens;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;
using DVLD_Presentation_Layer.Release_License.Realease_License_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Detained_License.Manage_Detain_Licenses_Screens
{
    public partial class frmManageDetainLicenses : Form
    {

        private DataTable _dtDetainedLicenses;

        enum enfilterBy { None, DetainID, IsReleased, NationalNo, FullName, ReleaseApplicationID}
        enfilterBy _CurrentFilterValue = enfilterBy.None;

        enum enReleaseFilter { All, Yes, No }
        enReleaseFilter _CurrentReleaseFilter = enReleaseFilter.All;
        public frmManageDetainLicenses()
        {
            InitializeComponent();

        }



        private void SetDataGridStracture()
        {

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                      dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 40;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 40;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 80;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 60;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 60;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 80;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 50;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 100;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                dgvDetainedLicenses.Columns[8].Width = 80;
            }

        }

        private async void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;


            _dtDetainedLicenses = await Task.Run(() => clsDetainedLicense.GetAllDetainedLicensesViewAsync());
            SetDataGridStracture();


            dgvDetainedLicenses.DataSource = _dtDetainedLicenses.DefaultView;
            lblTotalCount.Text = dgvDetainedLicenses.Rows.Count.ToString();



            await ctrlTotalCurrentlyDetainedLicenses1.LoadInfo();
            await  ctrlNewDetentionsThisMonth1.LoadInfo();
            await ctrlNewDetentionsLast30Days1.LoadInfo();
            await ctrlTotalDetainedLicenses1.LoadInfo();
            await ctrlTotalReleasedLicenses1.LoadInfo();
            await ctrlTotalDetainedFees1.LoadInfo();
            await ctrlDetainReasons_Top5_1.LoadInfo();
            await       ctrlFinesOverview1.LoadInfo();
           await ctrlRecentDetainActivities1.LoadInfo();

            ctrlDataGridPagesMoving1.btnFirst.PerformClick();



        }

        private string _ColumnNameDependOnFilter()
        {



            //Map Selected Filter to real Column name 
            switch (_CurrentFilterValue)
            {
                case enfilterBy.DetainID:
                    return "Detain ID";
                case enfilterBy.IsReleased:
                    return "Is Released";
                case enfilterBy.NationalNo:
                    return "National No";
                case enfilterBy.FullName:
                    return "Full Name";
                case enfilterBy.ReleaseApplicationID:
                    return "Release Application ID";
                default:
                    return "None";
            }
        }

        private void _RefreshTableFilter()
        {

            _dtDetainedLicenses.DefaultView.RowFilter = "";
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblTotalCount.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
        }



        private string _FilterValue()
        {
            switch (_CurrentReleaseFilter)
            {

                case enReleaseFilter.Yes:
                    return "1";
                case enReleaseFilter.No:
                    return "0";
                default:
                    return "All";
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
                        _CurrentReleaseFilter = (enReleaseFilter)cbIsReleaseFilter.SelectedIndex;
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (_CurrentFilterValue==enfilterBy.DetainID || _CurrentFilterValue == enfilterBy.ReleaseApplicationID)
            {
                clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);
            }
        }






        private  void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DetainLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            //refresh
             frmListDetainedLicenses_Load(null, null);

        }

        private  void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ReleaseLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmReleaseLicenseScreen ReleaseLicenseScreen = new frmReleaseLicenseScreen();
            ReleaseLicenseScreen.ShowDialog();
            //refresh
             frmListDetainedLicenses_Load(null, null);

        }


        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {

            guna2ContextMenuStrip1.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }


        private  void guna2GradientButton1_Click(object sender, EventArgs e)
        {
             frmListDetainedLicenses_Load(null, null);
        }


        private void ctrlDataGridPagesMoving2_OnButtonClicked()
        {
            dgvDetainedLicenses.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_dtDetainedLicenses.DefaultView);
            
            if(_CurrentFilterValue != enfilterBy.None || _CurrentFilterValue != enfilterBy.IsReleased)
            {
                  txtFilterValue.Focus();

            }

        }

        private async void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvDetainedLicenses.CurrentRow.Cells[6].Value;
            int PersonID =await clsPerson.GetPersonIDAsync(NationalNo);
            frmPersonInformationScreen frm = new frmPersonInformationScreen(PersonID);
            frm.ShowDialog();
            //refresh
        }

        private void showLicenseDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            frmLicenseInfoScreen frm = new frmLicenseInfoScreen(LicenseID);
            frm.ShowDialog();
        }

        private async void showPersonLicenseHistoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvDetainedLicenses.CurrentRow.Cells[6].Value;
            int PersonID = await clsPerson.GetPersonIDAsync(NationalNo);
            frmLicenseHistoryScreen frm = new frmLicenseHistoryScreen(PersonID);
            frm.ShowDialog();
        }

        private  void releaseDetainedLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ReleaseLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            frmReleaseLicenseScreen frm = new frmReleaseLicenseScreen(LicenseID);
            frm.ShowDialog();
            //refresh
             frmListDetainedLicenses_Load(null, null);
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            frmListDetainedLicenses_Load(null, null);

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            _RefreshTableFilter();
        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _CurrentFilterValue=(enfilterBy)cbFilterBy.SelectedIndex;
            txtFilterValue.Visible = (_CurrentFilterValue !=enfilterBy.None && _CurrentFilterValue != enfilterBy.IsReleased);

            cbIsReleaseFilter.Visible = (_CurrentFilterValue == enfilterBy.IsReleased);

            if (_CurrentFilterValue == enfilterBy.None)
            {
                     _RefreshTableFilter();
                txtFilterValue.Visible = false;
                cbIsReleaseFilter.Visible = false;


            }


            
        }

        private void txtFilterValue_TextChanged_1(object sender, EventArgs e)
        {
            string FilterColumn = _ColumnNameDependOnFilter();

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || _CurrentFilterValue == enfilterBy.None)
            {
                _RefreshTableFilter();
                return;
            }
            if (_CurrentFilterValue == enfilterBy.DetainID || _CurrentFilterValue == enfilterBy.ReleaseApplicationID)
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());


            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblTotalCount.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
        }

        private void cbIsReleaseFilter_SelectedIndexChanged(object sender, EventArgs e)

        {
            _CurrentReleaseFilter = (enReleaseFilter)cbIsReleaseFilter.SelectedIndex;
            string FilterColumn = "Is Released";
            string FilterValue = _FilterValue();

            if (_CurrentReleaseFilter == enReleaseFilter.All)
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblTotalCount.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
        }
    }
}
