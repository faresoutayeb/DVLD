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

namespace DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls
{
    public partial class ctrlTotalDetainedFees : UserControl
    {
        public ctrlTotalDetainedFees()
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

        private float _TotalCurrentlyDetainsLicensesFees;
        public float TotalCurrentlyDetainsLicensesFees { get => _TotalCurrentlyDetainsLicensesFees; }

        public async Task LoadInfo()
        {
            float AllDetainedLicensesOverAll = await clsDetainedLicense.GetAllDetainedLicensesFeesAsync();
            lblCount.Text = AllDetainedLicensesOverAll.ToString();

            _TotalCurrentlyDetainsLicensesFees = await clsDetainedLicense.TotalCurrentlyDetainedLicensesFeesAsync();


            float percentage;

            if (AllDetainedLicensesOverAll == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = (_TotalCurrentlyDetainsLicensesFees * 100) / AllDetainedLicensesOverAll;
            }

            lblPercentage.Text = "(" + percentage.ToString() + "%) Of all detained";
            progbCount.Value = (int)percentage;
        }
    }
}