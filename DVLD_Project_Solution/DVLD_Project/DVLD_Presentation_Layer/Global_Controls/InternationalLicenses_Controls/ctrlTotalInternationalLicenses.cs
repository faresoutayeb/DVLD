using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.InternationalLicenses_Controls
{
    public partial class ctrlTotalInternationalLicenses : UserControl
    {
        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        public ctrlTotalInternationalLicenses()
        {
            InitializeComponent();
        }

        private int _ActiveInternationalLicenseCount;
        public int ActiveInternationalLicenseCount { get => _ActiveInternationalLicenseCount; }

        public async Task LoadInfo()
        {
            int TotalInternationalLicensescount =
                await clsInternationalLicense.GetAllInternationalLicensesCountAsync();

            lblCount.Text = TotalInternationalLicensescount.ToString();

            _ActiveInternationalLicenseCount =
                await clsInternationalLicense.GetActiveInternationalLicensesCountAsync();

            float Percentage;

            if (TotalInternationalLicensescount == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_ActiveInternationalLicenseCount * 100) / TotalInternationalLicensescount;
            }

            lblPercentage.Text = "(" + Percentage.ToString() + "%) Active Licenses";
            progbCount.Value = (int)Percentage;
        }
    }
}