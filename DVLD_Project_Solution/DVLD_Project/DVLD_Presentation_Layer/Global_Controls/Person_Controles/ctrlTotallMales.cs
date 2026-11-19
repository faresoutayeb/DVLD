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
    public partial class ctrlTotallMales : UserControl
    {
        public ctrlTotallMales()
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

        private int _TotalMales;
        public int TotalMales { get => _TotalMales; }

        public async Task LoadInfo()
        {
            int TotalPeople = await clsPerson.GetAllPeopleCountAsync();

            _TotalMales =
                await clsPerson.GetPeopleCountByGenderAsync(clsPerson.enGender.Male);

            lblTotalCount.Text = _TotalMales.ToString();

            float Percentage;

            if (TotalPeople == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (_TotalMales * 100) / TotalPeople;
            }

            lblPercentage.Text = Percentage + "% of males over all";
            progbperentage.Value = (int)Percentage;
        }
    }
}