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
    public partial class ctrlNewDetentionsLast30Days : UserControl
    {
        public ctrlNewDetentionsLast30Days()
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

        private int _TotalCurrentlyDetainsLicenses;
        public int TotalCurrentlyDetainsLicenses
        {
            get => _TotalCurrentlyDetainsLicenses;
        }

        private int _DetainedLicensesCountlast30days;
        public int DetainedLicensesCountlast30days
        {
            get => _DetainedLicensesCountlast30days;
        }

        public async Task LoadInfo()
        {

            _DetainedLicensesCountlast30days = await clsDetainedLicense.DetainedLicensesCountLast30DaysAsync();

            lblCount.Text = _DetainedLicensesCountlast30days.ToString();
            _TotalCurrentlyDetainsLicenses = await clsDetainedLicense.GetCurrentlyDetainedLicensesCountAsync();

            float percentage;

            if (_TotalCurrentlyDetainsLicenses == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = (_DetainedLicensesCountlast30days * 100) / _TotalCurrentlyDetainsLicenses;
            }

            lblPercentage.Text = "(" + percentage.ToString() + "%) Of Currently Detained";
            progbCount.Value = (int)percentage;
        }
    }
}