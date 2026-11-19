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

namespace DVLD_Presentation_Layer.Global_Controls.Person_Controles
{
    public partial class ctrlTotalPersons : UserControl
    {
        public ctrlTotalPersons()
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

        private int _TotalPeopleCount;
        public int TotalPeopleCount { get => _TotalPeopleCount; }

        public async Task LoadInfo()
        {
            _TotalPeopleCount = await clsPerson.GetAllPeopleCountAsync();
            lblTotalCount.Text = _TotalPeopleCount.ToString();
        }


    }
}
