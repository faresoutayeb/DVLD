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
    public partial class ctrlMainMenueCounter : UserControl
    {
        private Control[] CurrentControls;
        public ctrlMainMenueCounter()
        {
            InitializeComponent();
            CurrentControls = new Control[24]
            {
               lblTotalPeopleCount,
               lblTotalActiveUsersCount,
               lblTotalActiveDriversCount,
               lblTotalActiveLicensesCount,
               lblTotalActiveInternationalLicensesCount,
               lblExpiredLicensesCount,
               lblExpiredLicensesSoonCount,
               lblTotalDetaiedLicensesCount,
               lblNewApplicationsCount,
               lblTotalCompletedAppCount,
               lblTotalTestsCount,
               guna2HtmlLabel1,
               guna2HtmlLabel9,
               guna2HtmlLabel3,
               guna2HtmlLabel5,
               guna2HtmlLabel7,
               guna2HtmlLabel16,
               guna2HtmlLabel8,
               guna2HtmlLabel14,
               guna2HtmlLabel12,
               guna2HtmlLabel13,
               guna2HtmlLabel2,
               guna2HtmlLabel11,
               guna2HtmlLabel15
            };


        }
                //guna2HtmlLabel4,


        private int _totalPeopleCount;
        public int TotalPeopleCount => _totalPeopleCount;

        private int _totalActiveUsersCount;
        public int TotalActiveUsersCount => _totalActiveUsersCount;

        private int _totalActiveDriversCount;
        public int TotalActiveDriversCount => _totalActiveDriversCount;

        private int _totalActiveInternationalLicensesCount;
        public int TotalActiveInternationalLicensesCount => _totalActiveInternationalLicensesCount;

        private int _totalCompletedAppCount;
        public int TotalCompletedAppCount => _totalCompletedAppCount;

        private int _totalDetainedLicensesCount;
        public int TotalDetainedLicensesCount => _totalDetainedLicensesCount;

        private int _totalTestsCount;
        public int TotalTestsCount => _totalTestsCount;

        private int _totalActiveLicensesCount;
        public int TotalActiveLicensesCount => _totalActiveLicensesCount;

        private int _expiredLicensesCount;
        public int ExpiredLicensesCount => _expiredLicensesCount;

        private int _newApplicationsCount;
        public int NewApplicationsCount => _newApplicationsCount;

        private int _expiredLicensesSoonCount;
        public int ExpiredLicensesSoonCount => _expiredLicensesSoonCount;



        public async Task LoadInfo()
        {
            int peopleTask = await clsPerson.GetAllPeopleCountAsync();
            int activeUsersTask =await clsUser.GetActiveUserCountAsync();
            int activeDriversTask = await clsDriver.GetAllDriversCountAsync();
            int internationalLicensesTask = await clsInternationalLicense.GetActiveInternationalLicensesCountAsync();
            int completedAppsTask = await clsApplication.GetApplicationsCountAsync( clsApplication.enApplicationStatus.completed);
            int detainedLicensesTask = await clsDetainedLicense.GetAllDetainedLicensesCountAsync();
            int testsTask = await clsTest.GetAllTestsCountAsync();
            int activeLicensesTask = await clsLicense.GetTotalActiveLocalLicensesCountAsync();
            int    expiredLicensesTask = await clsLicense.GetAllExpiredLicensesCountAsync();

            int newApplicationsTask =await
                clsApplication.GetApplicationsCountAsync(
                    clsApplication.enApplicationStatus.New);

           int expiredSoonTask =await
                clsLicense.GetExpiredLicensesCountToNextMonthAsync();



            _totalPeopleCount = peopleTask;
            _totalActiveUsersCount = activeUsersTask;
            _totalActiveDriversCount = activeDriversTask;
            _totalActiveInternationalLicensesCount = internationalLicensesTask;
            _totalCompletedAppCount = completedAppsTask;
            _totalDetainedLicensesCount = detainedLicensesTask;
            _totalTestsCount = testsTask;
            _totalActiveLicensesCount = activeLicensesTask;
            _expiredLicensesCount = expiredLicensesTask;
            _newApplicationsCount = newApplicationsTask  ;
            _expiredLicensesSoonCount = expiredSoonTask;

            lblTotalPeopleCount.Text = _totalPeopleCount.ToString();
            lblTotalActiveUsersCount.Text = _totalActiveUsersCount.ToString();
            lblTotalActiveDriversCount.Text = _totalActiveDriversCount.ToString();
            lblTotalActiveInternationalLicensesCount.Text = _totalActiveInternationalLicensesCount.ToString();
            lblTotalCompletedAppCount.Text = _totalCompletedAppCount.ToString();
            lblTotalDetaiedLicensesCount.Text = _totalDetainedLicensesCount.ToString();
            lblTotalTestsCount.Text = _totalTestsCount.ToString();
            lblTotalActiveLicensesCount.Text = _totalActiveLicensesCount.ToString();
            lblExpiredLicensesCount.Text = _expiredLicensesCount.ToString();
            lblNewApplicationsCount.Text = _newApplicationsCount.ToString();
            lblExpiredLicensesSoonCount.Text = _expiredLicensesSoonCount.ToString();


           //clsUtil.CenterilizeAllControlsDebugMode(CurrentControls);
            clsUtil.CenterilizeAllControls(CurrentControls);

        }


    }
}
