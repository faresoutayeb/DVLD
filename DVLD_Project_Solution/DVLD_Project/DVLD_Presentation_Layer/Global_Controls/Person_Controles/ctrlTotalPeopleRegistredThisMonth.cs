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
    public partial class ctrlTotalPeopleRegistredThisMonth : UserControl
    {
        public ctrlTotalPeopleRegistredThisMonth()
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
        private int _PeopleRegisteredThisMonth;
        public int PeopleRegisteredThisMonth { get => _PeopleRegisteredThisMonth; }

        public async Task LoadInfo()
        {
            Task<int> PeopleRegisteredThisMonthTask = clsPerson.GetPeopleRegisteredThisMonthCountAsync();
            Task<int> FemalesCountThisMonthTask = clsPerson.GetPeopleRegisteredCountBetweenAsync(clsPerson.enGender.Female,new DateTime(DateTime.Now.Year, DateTime.Now.Month,1) , DateTime.Today.AddDays(1));
            Task<int> MalesCountThisMonthTask = clsPerson.GetPeopleRegisteredCountBetweenAsync(clsPerson.enGender.Male, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Today.AddDays(1));
            Task<int> TotalPeopleTask = clsPerson.GetAllPeopleCountAsync();

            await Task.WhenAll(PeopleRegisteredThisMonthTask, FemalesCountThisMonthTask, MalesCountThisMonthTask, TotalPeopleTask);

            _PeopleRegisteredThisMonth = PeopleRegisteredThisMonthTask.Result;
            int FemalesCountThisMonth = FemalesCountThisMonthTask.Result;
            int MalesCountThisMonth = MalesCountThisMonthTask.Result;
            int TotalPeople = TotalPeopleTask.Result;

            int Percentage = TotalPeople > 0 ? (_PeopleRegisteredThisMonth * 100) / TotalPeople : 0;

            lblTotalCount.Text = _PeopleRegisteredThisMonth.ToString();
            lblFemalesCount.Text = FemalesCountThisMonth.ToString();
            lblMalesCount.Text = MalesCountThisMonth.ToString();

            lblPercentage.Text = Percentage + "% of over all";
            progbperentage.Value = Percentage;
        }

    }
}
