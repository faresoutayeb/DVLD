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

namespace DVLD_Presentation_Layer.Global_Controls.Logins_Logs_Controls
{
    public partial class ctrlTotalLogsInPeriod : UserControl
    {
        public ctrlTotalLogsInPeriod()
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
        private int _TotalLogsBetween;
        public int TotalLogsBetween
        {
            get => _TotalLogsBetween;
        }


        public void LoadInfo()
        {
            dtpDateFrom.Value = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            dtpDateTo.Value = DateTime.Now;
            btnSearch_Click(null, null);
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _TotalLogsBetween = await clsUserLog.GetLogsCountByPeriodAsync(dtpDateFrom.Value, dtpDateTo.Value);
            lblTotalCount.Text = _TotalLogsBetween.ToString();
        }
    }
}
