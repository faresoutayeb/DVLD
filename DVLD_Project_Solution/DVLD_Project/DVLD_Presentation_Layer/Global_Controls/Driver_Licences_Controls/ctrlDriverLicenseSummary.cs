using DVLD_Bussiness_Layer;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls
{
    public partial class ctrlDriverLicenseSummary : UserControl
    {
        Control[] controls;

        public ctrlDriverLicenseSummary()
        {
            InitializeComponent();

            controls = new Control[17]
            {
                lblActiveLicensesCount,
                lblExpiredLicensesCount,
                lblRevokedLicensesCount,
                lblInternationalLicensesCount,
                lblTotalLicensesCount,
                lblActiveLicensesPercentage,
                lblExpiredLicensesPercentage,
                lblRevokedLicensesPercentage,
                lblInternationalLicensesPercentage,
                guna2HtmlLabel2,
                guna2HtmlLabel3,
                guna2HtmlLabel5,
                guna2HtmlLabel4,
                guna2PictureBox2,
                guna2PictureBox4,
                guna2PictureBox5,
                guna2PictureBox3
            };
        }

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        private int _TotalLicensesCountTask;
        public int TotalLicensesCount => _TotalLicensesCountTask;

        private int _ActiveLicensesCountTask;
        public int ActiveLicensesCount => _ActiveLicensesCountTask;

        private int _ExpiredLicensesCountTask { get; set; }
        public int ExpiredLicensesCount => _ExpiredLicensesCountTask;

        private int _RevokedLicensesCountTask { get; set; }
        public int RevokedLicensesCount => _RevokedLicensesCountTask;

        private int _InternationalLicensesCountTask { get; set; }
        public int InternationalLicensesCount => _InternationalLicensesCountTask;

        public async Task LoadInfo(int PersonID)
        {
            _TotalLicensesCountTask = await clsLicense.GetAllLocalLicensesCountAsync();

            _ActiveLicensesCountTask = await clsLicense.GetLicensesCountAsync(PersonID, true);

            _ExpiredLicensesCountTask = await clsLicense.GetExpiredLicensesCountAsync(PersonID);

            _RevokedLicensesCountTask = await clsLicense.GetLicensesCountAsync(PersonID, false);

            _InternationalLicensesCountTask = await clsInternationalLicense.GetInternationalDriverLicensesCountAsync(PersonID);

            lblActiveLicensesCount.Text = _ActiveLicensesCountTask.ToString();
            lblExpiredLicensesCount.Text = _ExpiredLicensesCountTask.ToString();
            lblRevokedLicensesCount.Text = _RevokedLicensesCountTask.ToString();
            lblInternationalLicensesCount.Text = _InternationalLicensesCountTask.ToString();
            lblTotalLicensesCount.Text = _TotalLicensesCountTask.ToString();

            float ActivePercentage;
            float ExpiredPercentage;
            float RevokedPercentage;
            float InternationalPercentage;

            if (_TotalLicensesCountTask == 0)
            {
                ActivePercentage = 0;
                ExpiredPercentage = 0;
                RevokedPercentage = 0;
                InternationalPercentage = 0;
            }
            else
            {
                ActivePercentage = (_ActiveLicensesCountTask * 100f) / _TotalLicensesCountTask;
                ExpiredPercentage = (_ExpiredLicensesCountTask * 100f) / _TotalLicensesCountTask;
                RevokedPercentage = (_RevokedLicensesCountTask * 100f) / _TotalLicensesCountTask;
                InternationalPercentage = (_InternationalLicensesCountTask * 100f) / _TotalLicensesCountTask;
            }

            lblActiveLicensesPercentage.Text = ActivePercentage.ToString() + "%";
            lblExpiredLicensesPercentage.Text = ExpiredPercentage.ToString() + "%";
            lblRevokedLicensesPercentage.Text = RevokedPercentage.ToString() + "%";
            lblInternationalLicensesPercentage.Text = InternationalPercentage.ToString() + "%";

            clsUtil.CenterilizeAllControls(this.controls);
        }
    }
}