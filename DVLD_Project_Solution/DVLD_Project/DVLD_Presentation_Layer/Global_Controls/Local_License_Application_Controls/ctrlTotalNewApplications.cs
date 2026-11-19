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
    public partial class ctrlTotalNewApplications : UserControl
    {
        public ctrlTotalNewApplications()
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

        private int _NewApplicationCount;
        public int NewApplicationCount { get => _NewApplicationCount; }

        public async Task LoadInfo()
        {
     
            _NewApplicationCount =
                await clsLocalDrivingLicenseApplication.GetApplicationsCountAsync(
                    clsApplication.enApplicationStatus.New);

            lblCount.Text = _NewApplicationCount.ToString();
       int TotalApplicationsCount =
                await clsLocalDrivingLicenseApplication.GetApplicationsCountAsync();

            float Percentage;

            if (TotalApplicationsCount == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_NewApplicationCount * 100) / TotalApplicationsCount;
            }

            lblPercentage.Text = Percentage + "% of all Applications";
        }
    }
}