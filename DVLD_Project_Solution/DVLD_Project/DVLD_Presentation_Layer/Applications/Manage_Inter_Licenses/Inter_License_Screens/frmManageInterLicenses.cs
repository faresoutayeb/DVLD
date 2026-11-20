using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Global_Controls;
using DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls;
using DVLD_Presentation_Layer.License.LicenseScreens;
using DVLD_Presentation_Layer.License.LicenseScreens.international_License_Screen;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;
using System;
using System.Data;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.International_Driving_License.International_Driving_License_Screens
{
    public partial class frmManageInterLicenses : Form
    {
        private DataTable _dtInternationalLicenseApplications;

        enum enFilter { None, InternationalLicenseID, LocalLicenseID, DriverID, IsActive }
        enFilter _CurrentSelectedFilter = enFilter.None;

        enum enActive { All, Active, Inactive }
        enActive _CurrentSelectedActiveFilter;
        int CurrentPage = 1;
        short ItemsPerPage = 10;

        public frmManageInterLicenses()
        {
            InitializeComponent();
        }

        private async Task LoadFormListInternationalLicesnseApplications()
        {
            _dtInternationalLicenseApplications = await Task.Run(() => clsInternationalLicense.GetAllInternationalLicensesAsync());            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications.DefaultView;
            lblInternationalLicensesRecords.Text = _dtInternationalLicenseApplications.DefaultView.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 100;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 100;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 100;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 100;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 100;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 100;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 100;

            }

            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            await ctrlTotalActiveInternationalLicenses1.LoadInfo();
            await ctrlTotalExpiredLicenses1.LoadInfo();
            await ctrlTotalInternationalLicenses2.LoadInfo();

           await ctrlTotalLocalLicenses1.LoadInfo();
            await ctrlTotalActiveLocalLicenses1.LoadInfo();
           await ctrlTotalInactiveLicenses1.LoadInfo();

            await ctrlExpiringSoonInterLicenses1.LoadInfo();
            await ctrlInternationalLicensesIssuanceStatistic1.LoadInfo();
           await ctrlInterLicensesExpirationAlert1.LoadInfo();


        }

        private async void btnNewApplication_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.IssueInternationalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }

            frmIssueInternationalLicense InternationalLicenseScreen = new frmIssueInternationalLicense();
            InternationalLicenseScreen.ShowDialog();
            //refresh
           await LoadFormListInternationalLicesnseApplications();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewInternationalLicense))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }

            int InternationalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
            frmInterLicenseInfo frm = new frmInterLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private async void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            Task<clsDriver> DriverInfo =  clsDriver.FindByDriverIDAsync(DriverID);
            await Task.WhenAll(DriverInfo);
            frmPersonInformationScreen frm = new frmPersonInformationScreen(DriverInfo.Result.PersonID);
            frm.ShowDialog();

        }

        private async void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLicenseHistory))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }

            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            Task<clsDriver> DriverInfo = clsDriver.FindByDriverIDAsync(DriverID);
            await Task.WhenAll(DriverInfo); frmLicenseHistoryScreen frm = new frmLicenseHistoryScreen(DriverInfo.Result.PersonID);
            frm.ShowDialog();

        }




        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedFilter = (enFilter)cbFilterBy.SelectedIndex;
            txtFilterValue.Visible = (_CurrentSelectedFilter != enFilter.None && _CurrentSelectedFilter != enFilter.IsActive);
            cbIsActive.Visible = (_CurrentSelectedFilter != enFilter.None && _CurrentSelectedFilter == enFilter.IsActive);
            if(_CurrentSelectedFilter ==enFilter.None)
            {
                _RefreshTableFilter();
                return;
            }

        }

        private string _FilterValueByIsActive()
        {

            switch (_CurrentSelectedActiveFilter)
            {

                case enActive.Active:
                    return "1";

                case enActive.Inactive:
                    return "0";
                default:
                    return "1";
            }

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedActiveFilter =(enActive)cbIsActive.SelectedIndex;
            string FilterColumn = "IsActive";
            string FilterValue = _FilterValueByIsActive();


            if (_CurrentSelectedActiveFilter == enActive.All)
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
            }
            else
            {
                //in this case we deal with numbers not string.
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
                //the same as  this below
                //_dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format($"[{FilterColumn}] = {FilterValue}");

            }
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblInternationalLicensesRecords.Text = _dtInternationalLicenseApplications.DefaultView.Count.ToString();
        }


        private string GetColumnNameDependOnSelectedFilter()
        {


            switch (_CurrentSelectedFilter)
            {

                case enFilter.InternationalLicenseID:
                    return "InternationalLicenseID";
                case enFilter.LocalLicenseID:
                    return "IssuedUsingLocalLicenseID";
                case enFilter.DriverID:
                    return "DriverID";
                case enFilter.IsActive:
                    return "IsActive";
                default:
                    return "None";
            }


        }

        private void _RefreshTableFilter()
        {
            _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblInternationalLicensesRecords.Text = _dtInternationalLicenseApplications.DefaultView.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {


            string FilterColumn = GetColumnNameDependOnSelectedFilter();
            string filtervalue = txtFilterValue.Text.Trim();
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (filtervalue == "" || _CurrentSelectedFilter == enFilter.None)
            {
                _RefreshTableFilter();

                return;
            }
            _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, filtervalue);

            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblInternationalLicensesRecords.Text = _dtInternationalLicenseApplications.DefaultView.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow numbers only becasue all fiters are numbers.
            clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);
        }

 


        private void ctrlDataGridPagesMoving1_OnButtonClicked()
        {


            dgvInternationalLicenses.DataSource= ctrlDataGridPagesMoving1.GetUpdateTable(_dtInternationalLicenseApplications.DefaultView);
            if(_CurrentSelectedFilter != enFilter.None && _CurrentSelectedFilter != enFilter.IsActive)
            {
                        txtFilterValue.Focus();

            }
        }

        private async void guna2GradientButton3_Click(object sender, EventArgs e)
        {
           await LoadFormListInternationalLicesnseApplications();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            _RefreshTableFilter();
        }

        private async void frmManageInternationalLicensesScreen_Load(object sender, EventArgs e)
        {
            await LoadFormListInternationalLicesnseApplications();

        }

        private async void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense NewInternationalLicense =  new frmIssueInternationalLicense();
            NewInternationalLicense.ShowDialog();
           await LoadFormListInternationalLicesnseApplications();
        }
    }
}
