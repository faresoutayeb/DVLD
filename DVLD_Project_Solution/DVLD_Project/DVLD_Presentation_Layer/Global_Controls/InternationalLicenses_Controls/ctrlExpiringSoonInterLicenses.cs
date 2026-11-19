using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Applications.Manage_International_Driving_Licenses.View_All_International_Licenses_Expired_Screen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.InternationalLicenses_Controls
{
    public partial class ctrlExpiringSoonInterLicenses : UserControl
    {
        public ctrlExpiringSoonInterLicenses()
        {
            InitializeComponent();
        }
        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }
        public async Task LoadInfo()
        {
            dgvInternationalLicensesExpiringSoon.DataSource = await clsInternationalLicense.GetSoonExpirationLicensesRecordsAsync(true);
            if(dgvInternationalLicensesExpiringSoon.Rows.Count>0)
            {
                dgvInternationalLicensesExpiringSoon.Columns[0].Width = 100;
                dgvInternationalLicensesExpiringSoon.Columns[1].Width = 150;
                dgvInternationalLicensesExpiringSoon.Columns[2].Width = 100;
                dgvInternationalLicensesExpiringSoon.Columns[3].Width = 100;
                dgvInternationalLicensesExpiringSoon.Columns[4].Width = 40;

                dgvInternationalLicensesExpiringSoon.Columns[0].HeaderText = "I.L.ID";
                dgvInternationalLicensesExpiringSoon.Columns[1].HeaderText = "Full Name";
                dgvInternationalLicensesExpiringSoon.Columns[2].HeaderText = "Country";
                dgvInternationalLicensesExpiringSoon.Columns[3].HeaderText = "Class";
                dgvInternationalLicensesExpiringSoon.Columns[4].HeaderText = "Remain Days";

            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            frmExpiredSoonInterLicenses ExpiredLicensesScreen = new frmExpiredSoonInterLicenses();
            ExpiredLicensesScreen.ShowDialog();
        }
    }
}
