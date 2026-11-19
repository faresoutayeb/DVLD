using DVLD_Bussiness_Layer;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.License_History_Controls
{
    public partial class ctrlLicenseHistorySumary : UserControl
    {
        public ctrlLicenseHistorySumary()
        {
            InitializeComponent();
        }

        private int _totalLocalLicenses;
        public int TotalLocalLicenses => _totalLocalLicenses;

        private int _totalLocalRenewelLicenses;
        public int TotalLocalRenewelLicenses => _totalLocalRenewelLicenses;

        private int _totalLocalLostLicenses;
        public int TotalLocalLostLicenses => _totalLocalLostLicenses;

        private int _totalLocalDamagedLicenses;
        public int TotalLocalDamagedLicenses => _totalLocalDamagedLicenses;

        public void LoadDefaultControlsValue()
        {
            _totalLocalLicenses = 0;
            _totalLocalRenewelLicenses = 0;
            _totalLocalLostLicenses = 0;
            _totalLocalDamagedLicenses = 0;

            lblTotalLocalLicenses.Text = "0";
            lblTotalLocalRenewelLicenses.Text = "0";
            lblTotalLocalLostLicenses.Text = "0";
            lblTotalLocalDamagedLicenses.Text = "0";
        }

        public async Task LoadInfo(int PersonID)
        {
            if (PersonID <= 0)
            {
                LoadDefaultControlsValue();
                return;
            }

            _totalLocalLicenses =
                await clsLicense.GetLicensesCountAsync(PersonID, true);

            lblTotalLocalLicenses.Text = _totalLocalLicenses.ToString();

            _totalLocalRenewelLicenses =
                await clsLicense.GetLicensesCountAsync(
                    PersonID, true,
                    clsLicense.enIssueReasons.Renew);

            lblTotalLocalRenewelLicenses.Text = _totalLocalRenewelLicenses.ToString();

            _totalLocalLostLicenses =
                await clsLicense.GetLicensesCountAsync(
                    PersonID, true,
                    clsLicense.enIssueReasons.ReplacementForLostOrStolen);

            lblTotalLocalLostLicenses.Text = _totalLocalLostLicenses.ToString();

            _totalLocalDamagedLicenses =
                await clsLicense.GetLicensesCountAsync(
                    PersonID, true,
                    clsLicense.enIssueReasons.ReplacementForDamaged);

            lblTotalLocalDamagedLicenses.Text = _totalLocalDamagedLicenses.ToString();
        }

        private void ctrlLicenseHistorySumary_Load(object sender, System.EventArgs e)
        {
            LoadDefaultControlsValue();
        }
    }
}
