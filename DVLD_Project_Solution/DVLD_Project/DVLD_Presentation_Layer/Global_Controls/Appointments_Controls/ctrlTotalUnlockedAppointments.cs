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
    public partial class ctrlTotalUnlockedAppointments : UserControl
    {
        public ctrlTotalUnlockedAppointments()
        {
            InitializeComponent();
        }

        private int _TotalAppointments;
        public int TotalAppointments
        {
            get => _TotalAppointments;
        }

        public async Task LoadInfo(int LocalDrivingLicenseApplicationAppID, clsTestType.enTestType TestType, int LicenseClassID)
        {
            int UnlockedAppointmentsCount = await clsTestAppointment.GetUnLockedAppointmentsCountAsync(LocalDrivingLicenseApplicationAppID, TestType, LicenseClassID);

            lblTotalCount.Text = UnlockedAppointmentsCount.ToString();

            _TotalAppointments = await clsTestAppointment.TotalAppointmentsCountAsync(LocalDrivingLicenseApplicationAppID, TestType, LicenseClassID);

            float Percentage;

            if (_TotalAppointments == 0)
            {
                Percentage = 0;
            }
            else
            {
                Percentage = (UnlockedAppointmentsCount * 100) / _TotalAppointments;
            }

            lblPercentage.Text = Percentage.ToString();
            progbCount.Value = (int)Percentage;
        }
    }
}