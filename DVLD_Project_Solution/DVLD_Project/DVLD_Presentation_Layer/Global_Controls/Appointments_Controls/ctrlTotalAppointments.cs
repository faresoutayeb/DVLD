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

namespace DVLD_Presentation_Layer.Global_Controls
{
    public partial class ctrlTotalAppointments : UserControl
    {
        public ctrlTotalAppointments()
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
        private int _TotalAppointment;
        public int TotalAppointment
        {
            get => _TotalAppointment;
        }

        public async Task LoadInfo(int LocalDrivingLicenseApplicationAppID,clsTestType.enTestType TestType,int LicenseClassID)
        {
            _TotalAppointment = await clsTestAppointment.TotalAppointmentsCountAsync(LocalDrivingLicenseApplicationAppID, TestType, LicenseClassID);
            lblTotalCount.Text = _TotalAppointment.ToString();
            
        }


    }
}
