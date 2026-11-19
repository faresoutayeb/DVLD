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

namespace DVLD_Presentation_Layer.Global_Controls.Drivers_Controls
{
    public partial class ctrlTotalActiveOrdinaryLicenses : UserControl
    {
        public ctrlTotalActiveOrdinaryLicenses()
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

        private int _TotalActiveOrdinaryLicenseCount;

        public int TotalActiveOrdinaryLicenseCount
        {
            get => _TotalActiveOrdinaryLicenseCount;
        }

        public async Task LoadInfo()
        {
            _TotalActiveOrdinaryLicenseCount = await clsLicense.GetTotalActiveOrdinaryLicensesCountAsync(
                clsLicenseClass.enLicenseClasses.Class3_OrdinaryDrivingLicense
            );
            lblTotalCount.Text = _TotalActiveOrdinaryLicenseCount.ToString();

            int TotalActiveLicensesCount = await clsLicense.GetTotalActiveLocalLicensesCountAsync();


            float Percentage;

            if (TotalActiveLicensesCount == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_TotalActiveOrdinaryLicenseCount * 100) / TotalActiveLicensesCount;
            }

            lblPercentage.Text = "(" + Percentage.ToString() + "%) of all licenses";

            progbCount.Value = (int)Percentage;
        }
    }
}