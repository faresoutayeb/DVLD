using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Manage_Local_Driving_License_Applications_Screen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Applications_Controls
{
    public partial class ctrlRecentApplications : UserControl
    {
        public ctrlRecentApplications()
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
          dgvRecentApplications.DataSource =await clsApplication.GetRecentApplicationAsync();

            dgvRecentApplications.Columns[0].Width= 50;
            dgvRecentApplications.Columns[1].Width = 150;
            dgvRecentApplications.Columns[2].Width = 150;
            dgvRecentApplications.Columns[3].Width = 60;
            dgvRecentApplications.Columns[4].Width = 80;

        }
        private void ctrlRecentApplications_Load(object sender, EventArgs e)
        {

        }

        private async void guna2HtmlLabel2_Click_1(object sender, EventArgs e)
        {
            frmManageLocalLiApp ManageLocalApplicationsScreen = new frmManageLocalLiApp();
            ManageLocalApplicationsScreen.ShowDialog();
            await LoadInfo(); 
        }
    }
}
