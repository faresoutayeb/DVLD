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
    public partial class ctrlTotalExpiredSoonLast30Days : UserControl
    {
        public ctrlTotalExpiredSoonLast30Days()
        {
            InitializeComponent();
        }

        private int _TotalExpiringSoonInternationalLicensesCount;

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        public int TotalExpiringSoonInternationalLicensesCount
        {
            get => _TotalExpiringSoonInternationalLicensesCount;
        }

        public async Task LoadInfo()
        {
            _TotalExpiringSoonInternationalLicensesCount =
                await clsInternationalLicense.GetInterLicensesCountExpiringLastDaysBetweenAsync(30, 0);

            lblCount.Text = _TotalExpiringSoonInternationalLicensesCount.ToString();

            int TotalInternationalLicenses =
                await clsInternationalLicense.GetAllInternationalLicensesCountAsync();

            float Percentage;

            if (TotalInternationalLicenses == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_TotalExpiringSoonInternationalLicensesCount * 100) / TotalInternationalLicenses;
            }

            lblPercentage.Text = "(" + Percentage.ToString() + "%)";

            progbCount.Value = (int)Percentage;
        }
    }
}