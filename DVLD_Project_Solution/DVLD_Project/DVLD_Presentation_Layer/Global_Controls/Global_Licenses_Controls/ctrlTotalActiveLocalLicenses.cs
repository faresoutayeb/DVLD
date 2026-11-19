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

namespace DVLD_Presentation_Layer.Global_Controls.Global_Licenses_Controls
{
    public partial class ctrlTotalActiveLocalLicenses : UserControl
    {
        public ctrlTotalActiveLocalLicenses()
        {
            InitializeComponent();
        }
        private int _TotalLicenseCount;

        public int TotalLicenseCount
        {
            get => _TotalLicenseCount;
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


            _TotalLicenseCount = await clsLicense.GetTotalLocalLicensesCountAsync();
            lblTotalCount.Text = _TotalLicenseCount.ToString();
            int TotalActiveLicenses = await clsLicense.GetTotalActiveLocalLicensesCountAsync();

            float Percentage;

            if (_TotalLicenseCount == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (TotalActiveLicenses * 100) / _TotalLicenseCount;
            }

            lblPercentage.Text = "(" + Percentage.ToString() + "%) active over all licenses";

            progbCount.Value = (int)Percentage;
        }


    }
}
