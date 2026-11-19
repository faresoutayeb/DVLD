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
    public partial class ctrlExpiredDriverLicenses : UserControl
    {
        public ctrlExpiredDriverLicenses()
        {
            InitializeComponent();
        }

        private int _ExpiredLicensesCount;
        public int ExpiredLicensesCount
        {
            get => _ExpiredLicensesCount;
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
            _ExpiredLicensesCount = await clsLicense.GetExpiredLicensesCountAsync(PersonID);
            lblTotalCount.Text = _ExpiredLicensesCount.ToString();

            int TotalDriverLicensesCount = await clsLicense.GetLicensesCountAsync(PersonID);


            float percentage;

            if (TotalDriverLicensesCount == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = (_ExpiredLicensesCount * 100) / TotalDriverLicensesCount;
            }

            lblPercentage.Text = "(" + percentage.ToString() + "%) Expired Of all licenses";
            progbCount.Value = (int)percentage;
        }
    }
}