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
    public partial class ctrlTotalInterLicensesIssuesThisMonth : UserControl
    {
        public ctrlTotalInterLicensesIssuesThisMonth()
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
        private int _InterLicensesCountIssuedLastDays;

        public int InterLicensesCountIssuedLastDays
        {
            get => _InterLicensesCountIssuedLastDays;
        }

        public async Task LoadInfo()
        {
            Task<int> TotalInternationalLicensesCountTask =
                clsInternationalLicense.GetAllInternationalLicensesCountAsync();

            Task<int> InterLicensesCountIssuedLastDaysTask =
                clsInternationalLicense.GetInterLicensesCountIssuedLastDaysBetweenAsync(30, 0);

            await Task.WhenAll(
                InterLicensesCountIssuedLastDaysTask,
                TotalInternationalLicensesCountTask
            );

            _InterLicensesCountIssuedLastDays =
                InterLicensesCountIssuedLastDaysTask.Result;
                ;

            int TotalInternationalLicenses =
                TotalInternationalLicensesCountTask.Result;

            int Percentage = TotalInternationalLicenses > 0
                ? (_InterLicensesCountIssuedLastDays * 100) / TotalInternationalLicenses
                : 0;

            lblCount.Text = _InterLicensesCountIssuedLastDays.ToString();

            lblPercentage.Text = "(" + Percentage.ToString() + "%)";

            progbCount.Value = Percentage;
        }


    }
}
