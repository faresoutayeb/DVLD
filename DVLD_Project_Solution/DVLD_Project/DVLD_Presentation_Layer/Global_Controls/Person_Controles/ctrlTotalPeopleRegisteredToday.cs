using DVLD_Bussiness_Layer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Person_Controles
{
    public partial class ctrlTotalPeopleRegisteredToday : UserControl
    {
        public ctrlTotalPeopleRegisteredToday()
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

        private int _PeopleRegisteredToday;
        public int PeopleRegisteredToday { get => _PeopleRegisteredToday; }

        public async Task LoadInfo()
        {
            _PeopleRegisteredToday =
                await clsPerson.GetPeopleRegisteredTodayCountAsync();

            lblTotalCount.Text = _PeopleRegisteredToday.ToString();

            int FemalesCountToday =
                await clsPerson.GetPeopleRegisteredCountBetweenAsync(
                    clsPerson.enGender.Female,
                    DateTime.Today,
                    DateTime.Today.AddDays(1));

            lblFemalesCount.Text = FemalesCountToday.ToString();

            int MalesCountToday =
                await clsPerson.GetPeopleRegisteredCountBetweenAsync(
                    clsPerson.enGender.Male,
                    DateTime.Today,
                    DateTime.Today.AddDays(1));

            lblMalesCount.Text = MalesCountToday.ToString();

            int TotalPeople =
                await clsPerson.GetAllPeopleCountAsync();

            int Percentage = TotalPeople > 0
                ? (_PeopleRegisteredToday * 100) / TotalPeople
                : 0;

            lblPercentage.Text = Percentage + "% of over all";
            progbperentage.Value = Percentage;
        }
    }
}