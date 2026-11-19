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
    public partial class ctrlInterLicensesExpirationAlert : UserControl
    {
        public ctrlInterLicensesExpirationAlert()
        {
            InitializeComponent();
        }

        [Category("Appearance")]
        [Description("Gets or sets the background color of the control.")]
        public Color CustomColor
        {
            get => this.BackColor;
            set => this.BackColor = value;
        }

        private int _AlreadyExpiredLicensesCount;
        public int AlreadyExpiredLicensesCount
        {
            get => _AlreadyExpiredLicensesCount;
        }

        private int _ExpiringInLast30DaysCount;
        public int ExpiringInLast30DaysCount
        {
            get => _ExpiringInLast30DaysCount;
        }

        private int _ExpiringInLast31To61DaysCount;
        public int ExpiringInLast31To61DaysCount
        {
            get => _ExpiringInLast31To61DaysCount;
        }

        private int _ExpiringInLast61To90DaysCount;
        public int ExpiringInLast61To90DaysCount
        {
            get => _ExpiringInLast61To90DaysCount;
        }

        private int _ExpiringInMoreThan90DaysCount;
        public int ExpiringInMoreThan90DaysCount
        {
            get => _ExpiringInMoreThan90DaysCount;
        }

        public async Task LoadInfo()
        {
            _AlreadyExpiredLicensesCount =
                await clsInternationalLicense.GetExpiredInternationalLicensesCountAsync();

            lblAlreadyExpiredLicensesCount.Text = _AlreadyExpiredLicensesCount.ToString();

            _ExpiringInLast30DaysCount =
                await clsInternationalLicense.GetInterLicensesCountExpiringLastDaysBetweenAsync(0, 30);

            lblExpiringInLast30DaysCount.Text = _ExpiringInLast30DaysCount.ToString();

            _ExpiringInLast31To61DaysCount =
                await clsInternationalLicense.GetInterLicensesCountExpiringLastDaysBetweenAsync(31, 60);

            lblExpiringInLast31To61DaysCount.Text = _ExpiringInLast31To61DaysCount.ToString();

            _ExpiringInLast61To90DaysCount = await clsInternationalLicense.GetInterLicensesCountExpiringLastDaysBetweenAsync(61, 90);

            lblExpiringInLast61To90DaysCount.Text = _ExpiringInLast61To90DaysCount.ToString();

            _ExpiringInMoreThan90DaysCount =
                await clsInternationalLicense.GetInterLicensesCountExpiringLastDaysBetweenAsync(91, 0);

            lblExpiringInLastMore91DaysCount.Text = _ExpiringInMoreThan90DaysCount.ToString();
        }
    }
}