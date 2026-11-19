using DVLD_Bussiness_Layer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.InternationalLicenses_Controls
{
    public partial class ctrlInternationalLicensesIssuanceStatistic : UserControl
    {
        private Control[] CurrentControls;

        public ctrlInternationalLicensesIssuanceStatistic()
        {
            InitializeComponent();
            CurrentControls = new Control[18]
                {
                               guna2HtmlLabel2,
                               guna2HtmlLabel3,
                               guna2HtmlLabel6,
                               guna2PictureBox1,
                               guna2PictureBox2,
                               guna2PictureBox3,
                               lblTotalCountLastMonth,
                               lblTotalCountLastSeason,
                               lblTotalCountLastYear,
                               guna2HtmlLabel1,
                               guna2HtmlLabel4,
                               guna2HtmlLabel7,
                               lblLastMonthProgressPercentage,
                               lblLastSeasonProgressPercentage,
                               lblLastYearProgressPercentage,
                               guna2HtmlLabel9,
                               guna2HtmlLabel10,
                               guna2HtmlLabel11


                };

        }

        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }

        enum enMonths
        {
            January = 1, February, March, April, May, June,
            July, August, September, October, November, December
        }

        enum enSessons { Winter, Spring, Summer, Autumn }

        enum enCurrentMonthInSesson { First, Second, Third }

        private enMonths PreviousMonth()
        {
            return DateTime.Now.Month == 1
                ? enMonths.December
                : (enMonths)(DateTime.Now.Month - 1);
        }

        private enMonths BeforPreviousMonth()
        {
            return (enMonths)(((DateTime.Now.Month - 3 + 12) % 12) + 1);
        }

        private enSessons CurrentSeasson()
        {
            int Month = DateTime.Now.Month;

            if (Month == 12 || Month <= 2)
                return enSessons.Winter;

            if (Month <= 5)
                return enSessons.Spring;

            if (Month <= 8)
                return enSessons.Summer;

            return enSessons.Autumn;
        }

        private enCurrentMonthInSesson CurrentMonthInThisSesson()
        {
            int Month = DateTime.Now.Month;

            if (Month == 12 || Month <= 2)
                return Month == 12 ? enCurrentMonthInSesson.First
                    : Month == 1 ? enCurrentMonthInSesson.Second
                    : enCurrentMonthInSesson.Third;

            if (Month <= 5)
                return Month == 3 ? enCurrentMonthInSesson.First
                    : Month == 4 ? enCurrentMonthInSesson.Second
                    : enCurrentMonthInSesson.Third;

            if (Month <= 8)
                return Month == 6 ? enCurrentMonthInSesson.First
                    : Month == 7 ? enCurrentMonthInSesson.Second
                    : enCurrentMonthInSesson.Third;

            return Month == 9 ? enCurrentMonthInSesson.First
                : Month == 10 ? enCurrentMonthInSesson.Second
                : enCurrentMonthInSesson.Third;
        }

        private int CurrentSeassonsDays()
        {
            int Days = DateTime.Now.Day;
            var CurrentMonth = CurrentMonthInThisSesson();

            if (CurrentMonth == enCurrentMonthInSesson.Second)
                Days += DateTime.DaysInMonth(DateTime.Now.Year, (byte)PreviousMonth());

            if (CurrentMonth == enCurrentMonthInSesson.Third)
            {
                Days += DateTime.DaysInMonth(DateTime.Now.Year, (byte)PreviousMonth());
                Days += DateTime.DaysInMonth(DateTime.Now.Year, (byte)BeforPreviousMonth());
            }

            return Days;
        }

        private enSessons PreviusSessons()
        {
            enSessons CurrentSeason = CurrentSeasson();

            if (CurrentSeason == enSessons.Winter)
                return enSessons.Autumn;

            if (CurrentSeason == enSessons.Autumn)
                return enSessons.Summer;

            if (CurrentSeason == enSessons.Summer)
                return enSessons.Spring;

            return enSessons.Winter;
        }

        private int PreviusSessonDays()
        {
            enSessons PreviousSeason = PreviusSessons();

            if (PreviousSeason == enSessons.Winter)
                return DateTime.IsLeapYear(DateTime.Now.Year) ? 91 : 90;

            if (PreviousSeason == enSessons.Spring)
                return 92;

            if (PreviousSeason == enSessons.Summer)
                return 92;

            return 91;
        }
        public async Task LoadInfo()
        {

            int TotalDaysInThisYear =
                DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;

            int TotalDaysInLastYear =
                DateTime.IsLeapYear(DateTime.Now.Year - 1) ? 366 : 365;

            int CurrentSeasonDays = CurrentSeassonsDays();

            int ThisMonthIssuedLicensesCount =
                await clsInternationalLicense.GetInterLicensesCountIssuedLastDaysBetweenAsync(
                    -DateTime.Now.Day, 0);

            lblTotalCountLastMonth.Text = ThisMonthIssuedLicensesCount.ToString();

            int ThisSeasonIssuedLicensesCount =
                await clsInternationalLicense.GetInterLicensesCountIssuedLastDaysBetweenAsync(
                    -CurrentSeasonDays, 0);

            lblTotalCountLastSeason.Text = ThisSeasonIssuedLicensesCount.ToString();

            int ThisYearIssuedLicensesCount =
                await clsInternationalLicense.GetInterLicensesCountIssuedLastDaysBetweenAsync(
                    -TotalDaysInThisYear, 0);

            lblTotalCountLastYear.Text = ThisYearIssuedLicensesCount.ToString();

            int PreviousMonthIssuedLicensesCount =
                await clsInternationalLicense.GetInterLicensesCountIssuedLastDaysBetweenAsync(
                    -DateTime.DaysInMonth(
                        DateTime.Now.Year, (byte)PreviousMonth()),
                    -DateTime.Now.Day);

            int PreviousSeasonIssuedLicensesCount =
                await clsInternationalLicense.GetInterLicensesCountIssuedLastDaysBetweenAsync(
                   -( PreviusSessonDays() + CurrentSeasonDays),
                    CurrentSeasonDays);

            int PreviousYearIssuedLicensesCount =
                await clsInternationalLicense.GetInterLicensesCountIssuedLastDaysBetweenAsync(
                    -TotalDaysInLastYear, 0);

            float LastMonthProgressPercentage = 0;
            float LastSeasonProgressPercentage = 0;
            float LastYearProgressPercentage = 0;

            int MonthTotal = ThisMonthIssuedLicensesCount + PreviousMonthIssuedLicensesCount;
            int SeasonTotal = ThisSeasonIssuedLicensesCount + PreviousSeasonIssuedLicensesCount;
            int YearTotal = ThisYearIssuedLicensesCount + PreviousYearIssuedLicensesCount;

            if (MonthTotal != 0)
            {
                LastMonthProgressPercentage =
                    (float)(ThisMonthIssuedLicensesCount - PreviousMonthIssuedLicensesCount)
                    * 100 / MonthTotal;
            }

            if (SeasonTotal != 0)
            {
                LastSeasonProgressPercentage =
                    (float)(ThisSeasonIssuedLicensesCount - PreviousSeasonIssuedLicensesCount)
                    * 100 / SeasonTotal;
            }

            if (YearTotal != 0)
            {
                LastYearProgressPercentage =
                    (float)(ThisYearIssuedLicensesCount - PreviousYearIssuedLicensesCount)
                    * 100 / YearTotal;
            }

            lblLastMonthProgressPercentage.ForeColor =
                LastMonthProgressPercentage < 0 ? Color.Red : Color.Green;

            lblLastSeasonProgressPercentage.ForeColor =
                LastSeasonProgressPercentage < 0 ? Color.Red : Color.Green;

            lblLastYearProgressPercentage.ForeColor =
                LastYearProgressPercentage < 0 ? Color.Red : Color.Green;

            lblLastMonthProgressPercentage.Text =
                LastMonthProgressPercentage.ToString("0.##") + "%";

            lblLastSeasonProgressPercentage.Text =
                LastSeasonProgressPercentage.ToString("0.##") + "%";

            lblLastYearProgressPercentage.Text =
                LastYearProgressPercentage.ToString("0.##") + "%";
            clsUtil.CenterilizeAllControls(CurrentControls);

        }
    }
}