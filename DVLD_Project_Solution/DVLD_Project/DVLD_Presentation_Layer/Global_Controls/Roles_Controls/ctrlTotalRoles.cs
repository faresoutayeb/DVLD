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

namespace DVLD_Presentation_Layer.Global_Controls.Roles_Controls
{
    public partial class ctrlTotalRoles : UserControl
    {

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }
        private int _TotalRolesCount;
        public int TotalRolesCount { get => _TotalRolesCount; }

        public async Task LoadInfo()
        {
            _TotalRolesCount = await clsRole.GetRolesCountAsync();
            lblTotalCount.Text = _TotalRolesCount.ToString();
        }
        public ctrlTotalRoles()
        {
            InitializeComponent();
        }
    }
}
