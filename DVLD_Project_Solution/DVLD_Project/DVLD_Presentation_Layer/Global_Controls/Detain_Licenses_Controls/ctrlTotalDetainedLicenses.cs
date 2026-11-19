using DVLD_Bussiness_Layer;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls
{
    public partial class ctrlTotalDetainedLicenses : UserControl
    {
        public ctrlTotalDetainedLicenses()
        {
            InitializeComponent();
        }

        private int _CurrentlyDetainedLicenses;
        public int CurrentlyDetainedLicenses { get => _CurrentlyDetainedLicenses; }

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        public async Task LoadInfo()
        {

            _CurrentlyDetainedLicenses = await clsDetainedLicense.GetCurrentlyDetainedLicensesCountAsync();
            lblCount.Text = _CurrentlyDetainedLicenses.ToString();


         
        }
    }
}