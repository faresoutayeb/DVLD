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
    public partial class ctrlTotalActiveDrivers : UserControl
    {
        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        public ctrlTotalActiveDrivers()
        {
            InitializeComponent();
        }

        private int _AllActiveDriversCount;
        public int AllActiveDriversCount { get => _AllActiveDriversCount; }

        public async Task LoadInfo()
        {
            int AllDriversCount = await clsDriver.GetAllDriversCountAsync();
            lblTotalCount.Text = AllDriversCount.ToString();

            _AllActiveDriversCount = await clsDriver.GetAllDriversCountAsync(true);


            float ActiveDriversPercentage;

            if (AllDriversCount == 0)
            {
                ActiveDriversPercentage = 0;
            }
            else
            {
                ActiveDriversPercentage = (_AllActiveDriversCount * 100) / AllDriversCount;
            }

            lblActiveDriverPercetage.Text = ActiveDriversPercentage + "% Active";
            prbrActiveDrivers.Value = (int)ActiveDriversPercentage;
        }
    }
}