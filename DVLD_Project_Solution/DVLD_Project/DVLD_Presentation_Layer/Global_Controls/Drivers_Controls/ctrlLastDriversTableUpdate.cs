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
    public partial class ctrlLastDriversTableUpdate : UserControl
    {

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }
        private DateTime _LastUpdateDateTime;
        public DateTime LastUpdateDateTime
        { get => _LastUpdateDateTime; }

        public async Task LoadInfo()
        {

            _LastUpdateDateTime = await clsDriver.GetLastUpdateDateTimeAsync();


                lblLastUpdateDateTime.Text = _LastUpdateDateTime.ToString();


        }

        public ctrlLastDriversTableUpdate()
        {
            InitializeComponent();
        }

 
    }
}
