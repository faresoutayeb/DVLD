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
using static System.Math;

namespace DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls
{
    public partial class ctrlFinesOverview : UserControl
    {
        public ctrlFinesOverview()
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

        private float _Totalfines;
        public float Totalfines
        {
            get => _Totalfines;
        }

        private float _CollectedFees;
        public float CollectedFees
        {
            get => _CollectedFees;
        }

        public async Task LoadInfo()
        {
            _Totalfines = await clsDetainedLicense.TotalCurrentlyDetainedLicensesFeesAsync();
            lblTotalFines.Text = _Totalfines.ToString();

            _CollectedFees = await clsDetainedLicense.CollectedFeesAsync();

            lblCollectedFees.Text = _CollectedFees.ToString();
            lblUnpaidFees.Text = (_Totalfines - _CollectedFees).ToString();

            float CollectionRate;

            if (_Totalfines == 0)
            {
                CollectionRate = 0;
            }
            else
            {
                CollectionRate = (_CollectedFees * 100) / _Totalfines;
            }

            lblCollectionRate.Text = Round(CollectionRate, 2) + "%";
            progbCollectionRate.Value = (int)CollectionRate;
        }
    }
}