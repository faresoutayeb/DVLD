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

namespace DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls
{
    public partial class ctrlAciveDriverLicenses : UserControl
    {
        public ctrlAciveDriverLicenses()
        {
            InitializeComponent();
        }

        private int _ActiveDriverLicensesCount;
        public int ActiveDriverLicensesCount
        {
            get => _ActiveDriverLicensesCount;
        }

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        public async Task LoadInfo(int PersonID)
        {
            _ActiveDriverLicensesCount = await clsLicense.GetLicensesCountAsync(PersonID, true);

            int TotalDriverLicensesCount = await clsLicense.GetLicensesCountAsync(PersonID);

            lblTotalCount.Text = TotalDriverLicensesCount.ToString();

            float percentage;

            if (TotalDriverLicensesCount == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = (_ActiveDriverLicensesCount * 100f) / TotalDriverLicensesCount;
            }

            lblPercentage.Text = $"({percentage}%) Active Of all licenses";
            progbCount.Value = (int)percentage;
        }
    }
}