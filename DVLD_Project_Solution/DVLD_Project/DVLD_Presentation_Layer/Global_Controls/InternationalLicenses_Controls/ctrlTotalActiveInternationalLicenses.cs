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

namespace DVLD_Presentation_Layer.Global_Controls.InternationalLicenses_Controls
{
    public partial class ctrlTotalActiveInternationalLicenses : UserControl
    {
        public ctrlTotalActiveInternationalLicenses()
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

        private int _ActiveInternationalLicenseCount;
        public int ActiveInternationalLicenseCount { get => _ActiveInternationalLicenseCount; }

        public async Task LoadInfo()
        {
            _ActiveInternationalLicenseCount =
                await clsInternationalLicense.GetActiveInternationalLicensesCountAsync();

            int TotalInternationalLicensescount =
                await clsInternationalLicense.GetAllInternationalLicensesCountAsync();

            lblCount.Text = _ActiveInternationalLicenseCount.ToString();

            float Percentage;

            if (TotalInternationalLicensescount == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_ActiveInternationalLicenseCount * 100) / TotalInternationalLicensescount;
            }

            lblPercentage.Text = "(" + Percentage.ToString() + "%)";
            progbCount.Value = (int)Percentage;
        }
    }
}