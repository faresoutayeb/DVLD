using DVLD_Bussiness_Layer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Person_Controles
{
    public partial class ctrlTotalPeopleRegistredThisYear : UserControl
    {
        public ctrlTotalPeopleRegistredThisYear()
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

        private int _PeopleRegisteredThisYear;
        public int PeopleRegisteredThisYear { get => _PeopleRegisteredThisYear; }

        private int _FemalesRegisteredThisYear;
        public int FemalesRegisteredThisYear { get => _FemalesRegisteredThisYear; }

        private int _MalesRegisteredThisYear;
        public int MalesRegisteredThisYear { get => _MalesRegisteredThisYear; }

        public async Task LoadInfo()
        {
            _PeopleRegisteredThisYear =
                await clsPerson.GetPeopleRegisteredThisYearCountAsync();

            lblTotalCount.Text = _PeopleRegisteredThisYear.ToString();

            _FemalesRegisteredThisYear =
                await clsPerson.GetPeopleRegisteredCountBetweenAsync(
                    clsPerson.enGender.Female,
                    new DateTime(DateTime.Now.Year, 1, 1),
                    DateTime.Today.AddDays(1));

            lblFemalesCount.Text = _FemalesRegisteredThisYear.ToString();

            _MalesRegisteredThisYear =
                await clsPerson.GetPeopleRegisteredCountBetweenAsync(
                    clsPerson.enGender.Male,
                    new DateTime(DateTime.Now.Year, 1, 1),
                    DateTime.Today.AddDays(1));

            lblMalesCount.Text = _MalesRegisteredThisYear.ToString();

            int TotalPeople = await clsPerson.GetAllPeopleCountAsync();

            int Percentage = TotalPeople > 0
                ? (_PeopleRegisteredThisYear * 100) / TotalPeople
                : 0;

            lblPercentage.Text = Percentage + "% of over all";
            progbperentage.Value = Percentage;
        }
    }
}