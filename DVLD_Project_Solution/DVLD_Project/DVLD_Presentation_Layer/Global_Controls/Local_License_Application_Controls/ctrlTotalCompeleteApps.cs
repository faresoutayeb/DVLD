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
    public partial class ctrlTotalCompeleteApps : UserControl
    {
        public ctrlTotalCompeleteApps()
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

        private int _CompletedApplicationCount;
        public int CompletedApplicationCount
        {
            get => _CompletedApplicationCount;
        }

        public async Task LoadInfo()
        {
     
            _CompletedApplicationCount =
                await clsLocalDrivingLicenseApplication.GetApplicationsCountAsync(
                    clsApplication.enApplicationStatus.completed);

            lblCount.Text = _CompletedApplicationCount.ToString();
       int TotalApplicationsCount =
                await clsLocalDrivingLicenseApplication.GetApplicationsCountAsync();

            float Percentage;

            if (TotalApplicationsCount == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_CompletedApplicationCount * 100) / TotalApplicationsCount;
            }

            lblPercentage.Text = Percentage + "% of all Applications";
        }
    }
}
