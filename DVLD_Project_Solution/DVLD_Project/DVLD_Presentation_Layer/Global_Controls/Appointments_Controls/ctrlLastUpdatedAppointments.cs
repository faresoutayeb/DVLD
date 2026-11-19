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
    public partial class ctrlLastUpdatedAppointments : UserControl
    {
        public ctrlLastUpdatedAppointments()
        {
            InitializeComponent();
        }

        private DateTime _LastAppointmentDateTime;
        public DateTime LastAppointmentDateTime
        {
            get=> _LastAppointmentDateTime;
        }
        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        public async Task LoadInfo(int LocalDrivingLicenseApplicationAppID, clsTestType.enTestType TestType, int LicenseClassID)
        {
            DateTime? lastAppintment = await clsTestAppointment.LastAppointmentDateTimeAsync(LocalDrivingLicenseApplicationAppID, TestType, LicenseClassID);
            if(lastAppintment == null)
            {
                lblDate.Text = "00/00/0000";

                lblTime.Text = "00:00:00";
                return;
            }
            _LastAppointmentDateTime =lastAppintment.Value;


            lblDate.Text = (_LastAppointmentDateTime.Day+"-"+ _LastAppointmentDateTime.Month + "-" + _LastAppointmentDateTime.Year).ToString();
            lblTime.Text=(_LastAppointmentDateTime.Hour+":"+ _LastAppointmentDateTime.Minute+ ":"+_LastAppointmentDateTime.Second).ToString();
        }



    }
}
