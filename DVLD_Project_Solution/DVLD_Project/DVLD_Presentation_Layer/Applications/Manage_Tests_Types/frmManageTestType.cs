using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Global_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class frmManageTestType : Form
    {
        public frmManageTestType()
        {

            InitializeComponent();
        }

        private DataTable _dtTestTypes;

        private void SetTestTypesGridViewColumnsStructure()
        {
            if(dgvTestTypes.Rows.Count>0)
            {
                dgvTestTypes.Columns[0].HeaderText = "Test ID";

                dgvTestTypes.Columns[0].Width = 60;
                dgvTestTypes.Columns[1].HeaderText = "Test Title";

                dgvTestTypes.Columns[1].Width = 100;
                dgvTestTypes.Columns[2].HeaderText = "Test Description";

                dgvTestTypes.Columns[2].Width = 200;
                dgvTestTypes.Columns[3].HeaderText = "Test Fees";

                dgvTestTypes.Columns[3].Width = 60;
            }



        }

        private async Task _RefreshTestsTypesInfoDataGrid()
        {
            _dtTestTypes = await clsTestType.GetAllTestTypesAsync();
            dgvTestTypes.DataSource = _dtTestTypes;
            SetTestTypesGridViewColumnsStructure();
            ctrlDataGridPagesMoving2.btnFirst.PerformClick();

        }

        private async void editApplicationTypeInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditApplicationTestType))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }

            UpdateTestTypesScreen updateTestTypes= new UpdateTestTypesScreen((clsTestType.enTestType)(int)dgvTestTypes.CurrentRow.Cells[0].Value);
            updateTestTypes.ShowDialog();
            await _RefreshTestsTypesInfoDataGrid();

        }

        private async void ManageTestType_Load(object sender, EventArgs e)
        {
           await _RefreshTestsTypesInfoDataGrid();

        }

        private void ctrlDataGridPagesMoving2_OnButtonClicked()
        {
            dgvTestTypes.DataSource = ctrlDataGridPagesMoving2.GetUpdateTable(_dtTestTypes.DefaultView);
        }
    }
}
