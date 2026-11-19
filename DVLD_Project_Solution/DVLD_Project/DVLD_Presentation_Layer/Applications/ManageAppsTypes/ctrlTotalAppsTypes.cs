using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Manage_Applications_Types.Applications_Types_Controls.Total_Applications_Types
{
    public partial class ctrlTotalAppsTypes : UserControl
    {
        public ctrlTotalAppsTypes()
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
        private byte _TotalAppTypeCount;
        public byte TotalAppTypeCount 
        {

            get => _TotalAppTypeCount;
            
            private set
            {
                _TotalAppTypeCount = value;
            }
                
                
            
        }

        public async Task LoadInfo()
        {
            _TotalAppTypeCount = await clsApplicationType.GetApplicationsTypesCountAsync();
            
             lblCount.Text = _TotalAppTypeCount.ToString();
        }

    }
}
