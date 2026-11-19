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
    public partial class ctrlTotalRecentDrivers : UserControl
    {
        public ctrlTotalRecentDrivers()
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
        private int _RecentlyDriversCount;
        public int RecentlyDriversCount
        {
            get => _RecentlyDriversCount;
        }

        public async Task LoadInfo()
        {
            _RecentlyDriversCount = await clsDriver.GetRecentlyDriversCountAsync();
            lblTotalCount.Text= _RecentlyDriversCount.ToString();
        }


    }
}
