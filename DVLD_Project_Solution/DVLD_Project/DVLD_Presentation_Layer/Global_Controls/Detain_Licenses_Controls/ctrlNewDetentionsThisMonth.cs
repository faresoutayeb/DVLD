using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls
{
    public partial class ctrlNewDetentionsThisMonth : UserControl
    {
        public ctrlNewDetentionsThisMonth()
        {
            InitializeComponent();
        }

        private int _CurrentlyDetainsLicenses;
        private int _DetainedLicensesCountThisMonth;
        public int DetainedLicensesCountThisMonth { get => _DetainedLicensesCountThisMonth; }
        public int CurrentlyDetainsLicenses { get => _CurrentlyDetainsLicenses; }

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        public async Task LoadInfo()
        {

            _DetainedLicensesCountThisMonth = await clsDetainedLicense.GetDetainedLicensesCountThisMonthAsync();

            lblCount.Text = _DetainedLicensesCountThisMonth.ToString();
            _CurrentlyDetainsLicenses = await clsDetainedLicense.GetCurrentlyDetainedLicensesCountAsync();

            float percentage;

            if (_CurrentlyDetainsLicenses == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = (_DetainedLicensesCountThisMonth * 100) / _CurrentlyDetainsLicenses;
            }

            lblPercentage.Text = "(" + percentage.ToString() + "%) Of Currently Detained";
            progbCount.Value = (int)percentage;
        }
    }
}