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

namespace DVLD_Presentation_Layer.Global_Controls.Appointments_User_Controls
{
    public partial class ctrlTotalLockedAppointments : UserControl
    {
        public ctrlTotalLockedAppointments()
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

        private int _TotalLockedAppointments;
        public int TotalLockedAppointments
        {
            get => _TotalLockedAppointments;
        }

        public async Task LoadInfo(int LocalDrivingLicenseApplicationAppID, clsTestType.enTestType TestType, int LicenseClassID)
        {
            _TotalLockedAppointments = await clsTestAppointment.TotalLockedAppointmentsCountAsync(LocalDrivingLicenseApplicationAppID, TestType, LicenseClassID);

            lblTotalCount.Text = _TotalLockedAppointments.ToString();

            int TotalAppointments = await clsTestAppointment.TotalAppointmentsCountAsync(LocalDrivingLicenseApplicationAppID, TestType, LicenseClassID);

            float percentage;

            if (TotalAppointments == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = (_TotalLockedAppointments * 100) / TotalAppointments;
            }

            lblPercentage.Text = "(" + percentage.ToString() + "%)";
            progbCount.Value = (int)percentage;
        }
    }
}