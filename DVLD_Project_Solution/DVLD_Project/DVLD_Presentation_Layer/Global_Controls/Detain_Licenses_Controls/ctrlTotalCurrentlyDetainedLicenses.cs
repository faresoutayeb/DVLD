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
    public partial class ctrlTotalCurrentlyDetainedLicenses : UserControl
    {
        public ctrlTotalCurrentlyDetainedLicenses()
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

        private int _TotalDetainedLicenses;
        public int TotalDetainedLicenses { get => _TotalDetainedLicenses; }

        public async Task LoadInfo()
        {

            _TotalDetainedLicenses = await clsDetainedLicense.GetCurrentlyDetainedLicensesCountAsync();

            lblCount.Text = _TotalDetainedLicenses.ToString();
            int TotalDetainsLicensesEverAllSystem = await clsDetainedLicense.GetAllDetainedLicensesCountAsync();

            float percentage;

            if (TotalDetainsLicensesEverAllSystem == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = (_TotalDetainedLicenses * 100) / TotalDetainsLicensesEverAllSystem;
            }

            lblPercentage.Text = "(" + percentage.ToString() + "%) Of Currently Detained";
            progbCount.Value = (int)percentage;
        }
    }
}