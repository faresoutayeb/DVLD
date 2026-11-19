using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Manage_International_Driving_Licenses.View_All_International_Licenses_Expired_Screen
{
    public partial class frmExpiredSoonInterLicenses : Form
    {
        public frmExpiredSoonInterLicenses()
        {
            InitializeComponent();
        }
        DataTable dt_ExpiringLicensesSoon;
        private async void frmExpiredSoonInternationalLicenses_Load(object sender, EventArgs e)
        {
            dt_ExpiringLicensesSoon=await  clsInternationalLicense.GetSoonExpirationLicensesRecordsAsync(false);
            dgvInternationalLicensesExpiringSoon.DataSource = dt_ExpiringLicensesSoon;
            dgvInternationalLicensesExpiringSoon.Columns[0].Width= 100;
            dgvInternationalLicensesExpiringSoon.Columns[1].Width = 250;
            dgvInternationalLicensesExpiringSoon.Columns[2].Width = 200;
            dgvInternationalLicensesExpiringSoon.Columns[3].Width = 200;
            dgvInternationalLicensesExpiringSoon.Columns[4].Width = 100;

            dgvInternationalLicensesExpiringSoon.Columns[0].HeaderText = "Inter.L.ID";
            dgvInternationalLicensesExpiringSoon.Columns[1].HeaderText = "Full Name";
            dgvInternationalLicensesExpiringSoon.Columns[2].HeaderText = "Country";
            dgvInternationalLicensesExpiringSoon.Columns[3].HeaderText = "Class";
            dgvInternationalLicensesExpiringSoon.Columns[4].HeaderText = "Remaining Days";

            ctrlDataGridPagesMoving1.btnFirst.PerformClick();



        }

        private void ctrlDataGridPagesMoving1_OnButtonClicked()
        {
            dgvInternationalLicensesExpiringSoon.DataSource = ctrlDataGridPagesMoving1.GetUpdateTable(dt_ExpiringLicensesSoon.DefaultView);
        }
    }
}
