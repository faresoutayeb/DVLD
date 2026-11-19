using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Person_Controles
{
    public partial class ctrlRecentlyAddedPeople : UserControl
    {
        public ctrlRecentlyAddedPeople()
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

        private int _TotalCount;
        public int TotalCount => _TotalCount;

        private int _FemalesCount;
        public int FemalesCount => _FemalesCount;

        private int _MalesCount;
        public int MalesCount => _MalesCount;

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _TotalCount = await clsPerson.GetPeopleRegisteredCountBetweenAsync(
                dtpDateFrom.Value, dtpDateTo.Value);

            lblTotalCount.Text = _TotalCount.ToString();

            _FemalesCount = await clsPerson.GetPeopleRegisteredCountBetweenAsync(
                clsPerson.enGender.Female, dtpDateFrom.Value, dtpDateTo.Value);

            lblFemalesCount.Text = _FemalesCount.ToString();

            _MalesCount = await clsPerson.GetPeopleRegisteredCountBetweenAsync(
                clsPerson.enGender.Male, dtpDateFrom.Value, dtpDateTo.Value);

            lblMalesCount.Text = _MalesCount.ToString();
        }

        public void LoadInfo()
        {
            dtpDateFrom.Value = new DateTime(
                DateTime.Now.Year - 1,
                DateTime.Now.Month,
                DateTime.Now.Day);

            dtpDateTo.Value = DateTime.Now;

            btnSearch_Click(null, null);
        }

        private void ctrlRecentlyAddedPeople_Load(object sender, EventArgs e)
        {
            lblFemalesCount.Text = "";
            lblMalesCount.Text = "";
            lblTotalCount.Text = "";
        }
    }
}
