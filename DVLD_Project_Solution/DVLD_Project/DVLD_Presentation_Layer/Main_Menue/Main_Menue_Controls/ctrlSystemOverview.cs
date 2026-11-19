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

namespace DVLD_Presentation_Layer.Main_Menue.Main_Menue_Controls
{
    public partial class ctrlSystemOverview : UserControl
    {
        public ctrlSystemOverview()
        {
            InitializeComponent();
        }


        private int _peopleCount;
        private int _ActiveLicensesCount;
        private int _driversCount;
        private int _applicationsCount;
        private int _detainedCount;
        private int _appointmentsCount;

        // Public get-only properties
        public int PeopleCount => _peopleCount;
        public int ActiveLicensesCount => _ActiveLicensesCount;
        public int DriversCount => _driversCount;
        public int ApplicationsCount => _applicationsCount;
        public int DetainedCount => _detainedCount;
        public int ActiveAppointmentsCount => _appointmentsCount;

        public async Task LoadInfo()
        {
            // Start all tasks
            int peopleTask =await clsPerson.GetAllPeopleCountAsync();
            int  ActiveLicensesTask =await clsLicense.GetTotalActiveLocalLicensesCountAsync();
            int driversTask =await clsDriver.GetAllDriversCountAsync(true);
            int applicationsTask =await clsApplication.GetApplicationsCountAsync();
            int detainedTask =await clsDetainedLicense.GetCurrentlyDetainedLicensesCountAsync();
            int appointmentsTask =await clsTestAppointment.GetAllUnLockedAppointmentsCountAsync();

            // Wait for all tasks to complete


            // Fill private fields
            _peopleCount = peopleTask;
            _ActiveLicensesCount = ActiveLicensesTask;
            _driversCount = driversTask;
            _applicationsCount = applicationsTask;
            _detainedCount = detainedTask;
            _appointmentsCount = appointmentsTask;

            // Fill labels using public properties
            lblPeopleCount.Text = _peopleCount.ToString();
            lblActiveLicensesCount.Text = _ActiveLicensesCount.ToString();
            lblDriversCount.Text = _driversCount.ToString();
            lblApplicationsCount.Text = _applicationsCount.ToString();
            lblDetainedCount.Text = _detainedCount.ToString();
            lblActiveAppointments.Text = _appointmentsCount.ToString();
        }

    }
}
