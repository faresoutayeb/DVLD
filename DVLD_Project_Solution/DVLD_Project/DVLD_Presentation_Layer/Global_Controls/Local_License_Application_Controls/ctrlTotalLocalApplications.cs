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

namespace DVLD_Presentation_Layer.Global_Controls.Local_License_Application_Controls
{
    public partial class ctrlTotalLocalApplications : UserControl
    {
        public ctrlTotalLocalApplications()
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
        private int _TotalApplicationsCount;

        public int TotalApplicationsCount
        {
            get => _TotalApplicationsCount;
        }

        public async Task LoadInfo()
        {
            _TotalApplicationsCount = await clsLocalDrivingLicenseApplication.GetApplicationsCountAsync();
            lblCount.Text = _TotalApplicationsCount.ToString();
        }

    }
}
