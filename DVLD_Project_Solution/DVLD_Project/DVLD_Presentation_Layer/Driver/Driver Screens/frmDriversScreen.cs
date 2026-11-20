using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Detained_License.Manage_Detain_Licenses_Screens;
using DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls;
using DVLD_Presentation_Layer.Global_Controls.Users_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Driver.Driver_Screens
{
    public partial class frmDriversScreen : Form
    {
        public frmDriversScreen()
        {


            InitializeComponent();
   
        }
        private DataTable _CurrentDriversInfoTable;
        private enum enFilterBy { None = 0, DriverID = 1, PersonID = 2, NationalNo = 3, FullName = 4 };
        private enFilterBy _CurrentSelectedFilter = enFilterBy.None;
        private enum enColumnIndex { DriverID = 0, PersonID = 1, NationalNo = 2, FullName = 3, Date = 4, ActiveLicenses = 5 };
        private enum enColumnWidth { DriverID = 120, PersonID = 120, NationalNo = 120, FullName = 350, Date = 200, ActiveLicenses = 180 };


        //------------------------------------ Controls Events --------------------------------



        private async Task _LoadDriversInfoToDataGrid()
        {

            _CurrentDriversInfoTable = await Task.Run(() => clsDriver.GetAllDrivers_ViewAsync());
            dgvDrivers.RowTemplate.Height = 35;
            dgvDrivers.DataSource = _CurrentDriversInfoTable;
            cbFilterBy.SelectedIndex = 0;
            lblTotalDrivers.Text=_CurrentDriversInfoTable.Rows.Count    .ToString ();

        }

        private void _RefreshDriverLicensesTable()
        {

            _CurrentDriversInfoTable.DefaultView.RowFilter = "";

            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblTotalDrivers.Text = _CurrentDriversInfoTable.DefaultView.Count.ToString();

        }


        private string GetCurrentColumnsName()
        {
            switch (_CurrentSelectedFilter)
            {

                case enFilterBy.DriverID:
                    return "Driver ID";
                case enFilterBy.PersonID:
                    return "Person ID";
                case enFilterBy.NationalNo:
                    return "National No";
                case enFilterBy.FullName:
                    return "Full Name";
                default:
                    return "None";
            }



        }
        private void _SetTableData()
        {
            string SelectedFilterColumnName = GetCurrentColumnsName();


            if (_CurrentSelectedFilter == enFilterBy.None || txtbFilterValue.Text.Trim() == "")
            {
                _RefreshDriverLicensesTable();
                return;
            }

            else

            {
                if (_CurrentSelectedFilter == enFilterBy.FullName || _CurrentSelectedFilter == enFilterBy.NationalNo)
                {
                    _CurrentDriversInfoTable.DefaultView.RowFilter = string.Format("[{0}] like '{1}'", SelectedFilterColumnName, txtbFilterValue.Text.Trim());
                }
                else
                {
                    _CurrentDriversInfoTable.DefaultView.RowFilter = string.Format("[{0}] = {1}", SelectedFilterColumnName, txtbFilterValue.Text.Trim());
                }
            }


            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblTotalDrivers.Text = _CurrentDriversInfoTable.DefaultView.Count.ToString();

        }

        private void _SetMaximaumColumnWidh()
        {
            dgvDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvDrivers.Columns[(byte)enColumnIndex.DriverID].Width = (int)enColumnWidth.DriverID;
            dgvDrivers.Columns[(byte)enColumnIndex.PersonID].Width = (int)enColumnWidth.PersonID;
            dgvDrivers.Columns[(byte)enColumnIndex.NationalNo].Width = (int)enColumnWidth.NationalNo;
            dgvDrivers.Columns[(byte)enColumnIndex.FullName].Width = (int)enColumnWidth.FullName;
            dgvDrivers.Columns[(byte)enColumnIndex.Date].Width = (int)enColumnWidth.Date;
            dgvDrivers.Columns[(byte)enColumnIndex.ActiveLicenses].Width = (int)enColumnWidth.ActiveLicenses;

        }
        private void txtbFilterValue_TextChanged(object sender, EventArgs e)
        {


            _SetTableData();
        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedFilter=(enFilterBy)cbFilterBy.SelectedIndex;
            txtbFilterValue.Visible = (_CurrentSelectedFilter != enFilterBy.None);
            _RefreshDriverLicensesTable();
        }

        private async void ManageDriversScreen_Load(object sender, EventArgs e)
        {

           await _LoadDriversInfoToDataGrid();

            _SetMaximaumColumnWidh();
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            await ctrlLastDriversTableUpdate1.LoadInfo();
            await ctrlTotalActiveDrivers1.LoadInfo();
            await ctrlTotalActiveInternationalLicenses1.LoadInfo();
            await ctrlTotalActiveLocalLicenses1.LoadInfo();
            await ctrlTotalRecentDrivers1.LoadInfo();
            await ctrlTotalLicenses1.LoadInfo();
            await ctrlTotalDrivers1.LoadInfo();
            await ctrlTotalActiveLicenses2.LoadInfo();

        }

        private void txtbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (_CurrentSelectedFilter == enFilterBy.DriverID || _CurrentSelectedFilter == enFilterBy.PersonID)
            {

                clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);

            }
        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
           await _LoadDriversInfoToDataGrid();
        }

        private void ctrlDataGridPagesMoving1_OnButtonClicked()
        {
            dgvDrivers.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(_CurrentDriversInfoTable.DefaultView);
            if ( _CurrentSelectedFilter != enFilterBy.None)
            {
                txtbFilterValue.Focus();
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            _RefreshDriverLicensesTable();
        }

        private void txtbFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if(_CurrentSelectedFilter==enFilterBy.PersonID || _CurrentSelectedFilter == enFilterBy.DriverID)
            {

                clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);
            }
        }

        private void ctrlTotalActiveLocalLicenses1_Load(object sender, EventArgs e)
        {

        }




        //----------------------------------------------------------------------------------------------------

    }
}
