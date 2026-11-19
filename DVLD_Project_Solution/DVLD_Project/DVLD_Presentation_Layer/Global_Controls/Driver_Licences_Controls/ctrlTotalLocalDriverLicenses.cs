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

namespace DVLD_Presentation_Layer.Global_Controls
{
    public partial class ctrlTotalLocalDriverLicenses : UserControl
    {
        public ctrlTotalLocalDriverLicenses()
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

        private int _ActiveDriverLicensesCount;
        public int ActiveDriverLicensesCount
        {
            get => _ActiveDriverLicensesCount;
        }

        public async Task LoadInfo(int PersonID)
        {

            int AllDriverLicensesCount = await clsLicense.GetLicensesCountAsync(PersonID);

            lblTotalCount.Text = AllDriverLicensesCount.ToString();
            _ActiveDriverLicensesCount = await clsLicense.GetLicensesCountAsync(PersonID, true);

            float Percentage;

            if (AllDriverLicensesCount == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_ActiveDriverLicensesCount * 100) / AllDriverLicensesCount;
            }

            lblPercentage.Text = "(" + Percentage.ToString() + "%) Active of all";

            progbCount.Value = (int)Percentage;
        }
    }
}