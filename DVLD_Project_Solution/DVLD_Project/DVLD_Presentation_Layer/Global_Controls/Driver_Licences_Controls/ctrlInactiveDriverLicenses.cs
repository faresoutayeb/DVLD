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
    public partial class ctrlInactiveDriverLicenses : UserControl
    {
        public ctrlInactiveDriverLicenses()
        {
            InitializeComponent();
        }

        private int _InActiveDriverLicensesCount;
        public int InactiveDriverLicensesCount
        {
            get => _InActiveDriverLicensesCount;
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

            Task<int> GetInActiveDriverLicensesCountTask = clsLicense.GetLicensesCountAsync(PersonID, false);
            Task<int> TotalDriverLicensesCountTask = clsLicense.GetLicensesCountAsync(PersonID);
            await Task.WhenAll(GetInActiveDriverLicensesCountTask, TotalDriverLicensesCountTask);
            _InActiveDriverLicensesCount = GetInActiveDriverLicensesCountTask.Result;
            int TotalDriverLicensesCount = (TotalDriverLicensesCountTask.Result == 0) ? 1 : TotalDriverLicensesCountTask.Result;
            float percentage = (_InActiveDriverLicensesCount * 100) / TotalDriverLicensesCount;

            lblTotalCount.Text = TotalDriverLicensesCount.ToString();

            lblPercentage.Text = "(" + percentage.ToString() + "%) Inactive Of all licenses";
            progbCount.Value = (int)percentage;



        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
