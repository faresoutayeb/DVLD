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

namespace DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls
{
    public partial class ctrlTotalInternationalDriverLicenses : UserControl
    {
        public ctrlTotalInternationalDriverLicenses()
        {
            InitializeComponent();
        }

        private int _InternationalDriverLicensesCount;
        private int _ActiveInternationalDriverLicensesCount;
        public int InternationalDriverLicensesCount { get => _InternationalDriverLicensesCount; }
        public int ActiveInternationalDriverLicensesCount { get => _ActiveInternationalDriverLicensesCount; }

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        public async Task LoadInfo(int PersonID)
        {

            _ActiveInternationalDriverLicensesCount = await clsInternationalLicense.GetActiveInternationalDriverLicensesCountAsync(PersonID);

            lblTotalCount.Text = _ActiveInternationalDriverLicensesCount.ToString();
            _InternationalDriverLicensesCount = await clsInternationalLicense.GetInternationalDriverLicensesCountAsync(PersonID);

            float percentage;

            if (_InternationalDriverLicensesCount == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = (_ActiveInternationalDriverLicensesCount * 100) / _InternationalDriverLicensesCount;
            }

            lblPercentage.Text = "(" + percentage.ToString() + "%) Active of all";
            progbCount.Value = (int)percentage;
        }
    }
}