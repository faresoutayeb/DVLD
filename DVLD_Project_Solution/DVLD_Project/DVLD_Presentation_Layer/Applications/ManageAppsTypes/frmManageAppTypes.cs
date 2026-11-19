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
    public  partial class frmManageAppTypes : Form
    {
        public frmManageAppTypes()
        {

            InitializeComponent();
        }


        private void SetApplicationTypesGridViewColumnWidh()
        {
            dgvApplicationsTypes.Columns[0].HeaderText = "App ID";
            dgvApplicationsTypes.Columns[0].Width = 40;

            dgvApplicationsTypes.Columns[1].HeaderText = "Application Title";
            dgvApplicationsTypes.Columns[1].Width = 300;

            dgvApplicationsTypes.Columns[2].HeaderText = "App Fees";
            dgvApplicationsTypes.Columns[2].Width = 100;


        }

        private DataTable _dtApplicationTypesDataTable= new DataTable();
        private async Task _LoadApplicationTypesInfo()
        {
            _dtApplicationTypesDataTable= await clsApplicationType.GetAllApplicationTypesAsync();
            dgvApplicationsTypes.DataSource = _dtApplicationTypesDataTable;
            SetApplicationTypesGridViewColumnWidh();
            ctrlDataGridPagesMoving2.btnFirst.PerformClick();

        }



        private async void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
             await _LoadApplicationTypesInfo();

        }

        private void ctrlDataGridPagesMoving2_OnButtonClicked()
        {
            dgvApplicationsTypes.DataSource= ctrlDataGridPagesMoving2.GetUpdateTable(_dtApplicationTypesDataTable.DefaultView);
        }

        private async void editApplicationTypeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditApplicationTestType))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmEditApplicationType EditApplication = new frmEditApplicationType((int)dgvApplicationsTypes.CurrentRow.Cells[0].Value);
            EditApplication.ShowDialog();
            await _LoadApplicationTypesInfo();
        }


    }
}
