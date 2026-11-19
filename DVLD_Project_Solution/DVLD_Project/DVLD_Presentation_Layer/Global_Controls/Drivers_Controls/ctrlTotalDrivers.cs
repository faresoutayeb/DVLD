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

namespace DVLD_Presentation_Layer.Global_Controls.Drivers_Controls
{
    public partial class ctrlTotalDrivers : UserControl
    {
        public ctrlTotalDrivers()
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
        private int _TotalGrivers;
        public int TotalGrivers
        {
            get => _TotalGrivers;
        }

        public async Task LoadInfo()
        {
            _TotalGrivers =await clsDriver.GetAllDriversCountAsync();
            lblTotalCount.Text = _TotalGrivers.ToString();
        }


    }
}
