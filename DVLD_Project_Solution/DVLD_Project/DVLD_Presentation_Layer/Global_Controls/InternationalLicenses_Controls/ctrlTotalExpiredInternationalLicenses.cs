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
    public partial class ctrlTotalExpiredInternationalLicenses : UserControl
    {
        public ctrlTotalExpiredInternationalLicenses()
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

        private int _ExpiredInternationalLicensesCount;

        public int ExpiredInternationalLicensesCount
        {
            get => _ExpiredInternationalLicensesCount;
        }

        public async Task LoadInfo()
        {
            _ExpiredInternationalLicensesCount =
                await clsInternationalLicense.GetExpiredInternationalLicensesCountAsync();

            lblCount.Text = _ExpiredInternationalLicensesCount.ToString();

            int TotalInternationalLicensesCount =
                await clsInternationalLicense.GetAllInternationalLicensesCountAsync();

            float Percentage;

            if (TotalInternationalLicensesCount == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_ExpiredInternationalLicensesCount * 100) / TotalInternationalLicensesCount;
            }

            lblPercentage.Text = "(" + Percentage.ToString() + "%) of total licenses";

            progbCount.Value = (int)Percentage;
        }
    }
}