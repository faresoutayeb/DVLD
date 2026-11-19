using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls
{
    public partial class ctrlRecentDetainActivities : UserControl
    {
        public ctrlRecentDetainActivities()
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

        DataTable dtRecentActivities = new DataTable();

        private void DesableControlsInRow(byte RowNumber)
        {
            if (RowNumber == 1)
            {
                pbLicenseState1.Visible = false;
                lblLIcenseId1.Visible = false;
                lblDetainReleaseReason1.Visible = false;
                lblDate1.Visible = false;
            }

            if (RowNumber == 2)
            {
                pbLicenseState2.Visible = false;
                lblLIcenseId2.Visible = false;
                lblDetainReleaseReason2.Visible = false;
                lblDate2.Visible = false;
            }

            if (RowNumber == 3)
            {
                pbLicenseState3.Visible = false;
                lblLIcenseId3.Visible = false;
                lblDetainReleaseReason3.Visible = false;
                lblDate3.Visible = false;
            }

            if (RowNumber == 4)
            {
                pbLicenseState4.Visible = false;
                lblLIcenseId4.Visible = false;
                lblDetainReleaseReason4.Visible = false;
                lblDate4.Visible = false;
            }

            if (RowNumber == 5)
            {
                pbLicenseState5.Visible = false;
                lblLIcenseId5.Visible = false;
                lblDetainReleaseReason5.Visible = false;
                lblDate5.Visible = false;
            }
        }

        private void SetControlsVisibility()
        {
            byte TotalRows = (byte)dtRecentActivities.Rows.Count;

            if (TotalRows <= 5)
            {
                for (byte i = (byte)(TotalRows + 1); i <= 5; i++)
                {
                    DesableControlsInRow(i);
                }
            }
        }

        private bool IsTheSameDay(DateTime Date1, DateTime Date2)
        {
            if (Date1.Year != Date2.Year)
            {
                return false;
            }

            if (Date1.Month != Date2.Month)
            {
                return false;
            }

            if (Date1.Day != Date2.Day)
            {
                return false;
            }

            return true;
        }

        private bool IsTheSameDayTime(DateTime Date1, DateTime Date2)
        {
            if (Date1.Year != Date2.Year)
            {
                return false;
            }

            if (Date1.Month != Date2.Month)
            {
                return false;
            }

            if (Date1.Day != Date2.Day)
            {
                return false;
            }

            if (Date1.Hour != Date2.Hour)
            {
                return false;
            }

            if (Date1.Minute != Date2.Minute)
            {
                return false;
            }

            if (Date1.Second != Date2.Second)
            {
                return false;
            }

            return true;
        }

        private bool IsYesterday(DateTime Date1)
        {
            if (Date1.Year != DateTime.Now.Year)
            {
                return false;
            }

            if (Date1.Month != DateTime.Now.Month)
            {
                return false;
            }

            if (Date1.Day - 1 == DateTime.Now.Day)
            {
                return true;
            }

            return false;
        }

        private void SetDateTimeControl(Guna2HtmlLabel Control, int Row)
        {
            DateTime LastActionDateTime = Convert.ToDateTime(dtRecentActivities.Rows[Row][5]);

            bool IsToday = IsTheSameDay(DateTime.Now, LastActionDateTime);

            if (IsToday)
            {
                Control.Text = "Today " + LastActionDateTime.Hour + ":" + LastActionDateTime.Minute.ToString();
            }

            bool IsYesterdayDate = IsYesterday(LastActionDateTime);

            if (IsYesterdayDate)
            {
                Control.Text = "Yesterday " + LastActionDateTime.Hour + ":" + LastActionDateTime.Minute.ToString();
            }

            if (!IsToday && !IsYesterdayDate)
            {
                Control.Text = LastActionDateTime.ToString();
            }
        }

        public void SetControlsData()
        {
            int TotalTows = dtRecentActivities.Rows.Count;

            Image LockPicture = Resources.smart_lock;
            Image UnLockPicture = Resources.unlock;

            if (TotalTows >= 1)
            {
                if (Convert.ToBoolean(dtRecentActivities.Rows[0][1]) == true)
                {
                    pbLicenseState1.Image = UnLockPicture;
                    lblLIcenseId1.Text = $"License " + dtRecentActivities.Rows[0][0].ToString() + " Released";
                    lblDetainReleaseReason1.Text = " Released After Payment";
                    SetDateTimeControl(lblDate1, 0);
                }
                else
                {
                    pbLicenseState1.Image = LockPicture;
                    lblLIcenseId1.Text = $"License " + dtRecentActivities.Rows[0][0].ToString() + " Detained";
                    lblDetainReleaseReason1.Text = dtRecentActivities.Rows[0][2].ToString();
                    SetDateTimeControl(lblDate1, 0);
                }

                if (!IsTheSameDayTime(Convert.ToDateTime(dtRecentActivities.Rows[0][5]), Convert.ToDateTime(dtRecentActivities.Rows[0][3])))
                {
                    lblLIcenseId1.Text = $"License " + dtRecentActivities.Rows[0][0].ToString() + " Update Detaining";
                }
            }

            if (TotalTows >= 2)
            {
                if (Convert.ToBoolean(dtRecentActivities.Rows[1][1]) == true)
                {
                    pbLicenseState2.Image = UnLockPicture;
                    lblLIcenseId2.Text = $"License " + dtRecentActivities.Rows[1][0].ToString() + " Released";
                    lblDetainReleaseReason2.Text = " Released After Payment";
                    SetDateTimeControl(lblDate2, 1);
                }
                else
                {
                    pbLicenseState2.Image = LockPicture;
                    lblLIcenseId2.Text = $"License " + dtRecentActivities.Rows[1][0].ToString() + " Detained";
                    lblDetainReleaseReason2.Text = dtRecentActivities.Rows[1][2].ToString();
                    SetDateTimeControl(lblDate2, 1);
                }

                if (!IsTheSameDayTime(Convert.ToDateTime(dtRecentActivities.Rows[1][5]), Convert.ToDateTime(dtRecentActivities.Rows[1][3])))
                {
                    lblLIcenseId2.Text = $"License " + dtRecentActivities.Rows[1][0].ToString() + " Update Detaining";
                }
            }

            if (TotalTows >= 3)
            {
                if (Convert.ToBoolean(dtRecentActivities.Rows[2][1]) == true)
                {
                    pbLicenseState3.Image = UnLockPicture;
                    lblLIcenseId3.Text = $"License " + dtRecentActivities.Rows[2][0].ToString() + " Released";
                    lblDetainReleaseReason3.Text = " Released After Payment";
                    SetDateTimeControl(lblDate3, 2);
                }
                else
                {
                    pbLicenseState3.Image = LockPicture;
                    lblLIcenseId3.Text = $"License " + dtRecentActivities.Rows[2][0].ToString() + " Detained";
                    lblDetainReleaseReason3.Text = dtRecentActivities.Rows[2][2].ToString();
                    SetDateTimeControl(lblDate3, 2);
                }

                if (!IsTheSameDayTime(Convert.ToDateTime(dtRecentActivities.Rows[2][5]), Convert.ToDateTime(dtRecentActivities.Rows[2][3])))
                {
                    lblLIcenseId3.Text = $"License " + dtRecentActivities.Rows[2][0].ToString() + " Update Detaining";
                }
            }

            if (TotalTows >= 4)
            {
                if (Convert.ToBoolean(dtRecentActivities.Rows[3][1]) == true)
                {
                    pbLicenseState4.Image = UnLockPicture;
                    lblLIcenseId4.Text = $"License " + dtRecentActivities.Rows[3][0].ToString() + " Released";
                    lblDetainReleaseReason4.Text = " Released After Payment";
                    SetDateTimeControl(lblDate4, 3);
                }
                else
                {
                    pbLicenseState4.Image = LockPicture;
                    lblLIcenseId4.Text = $"License " + dtRecentActivities.Rows[3][0] + " Detained";
                    lblDetainReleaseReason4.Text = dtRecentActivities.Rows[3][2].ToString();
                    SetDateTimeControl(lblDate4, 3);
                }

                if (!IsTheSameDayTime(Convert.ToDateTime(dtRecentActivities.Rows[3][5]), Convert.ToDateTime(dtRecentActivities.Rows[3][3])))
                {
                    lblLIcenseId4.Text = $"License " + dtRecentActivities.Rows[3][0].ToString() + " Update Detaining";
                }
            }

            if (TotalTows >= 5)
            {
                if (Convert.ToBoolean(dtRecentActivities.Rows[4][1]) == true)
                {
                    pbLicenseState5.Image = UnLockPicture;
                    lblLIcenseId5.Text = $"License " + dtRecentActivities.Rows[4][0].ToString() + " Released";
                    lblDetainReleaseReason5.Text = " Released After Payment";
                    SetDateTimeControl(lblDate5, 4);
                }
                else
                {
                    pbLicenseState5.Image = LockPicture;
                    lblLIcenseId5.Text = $"License " + dtRecentActivities.Rows[4][0] + " Detained";
                    lblDetainReleaseReason5.Text = dtRecentActivities.Rows[4][2].ToString();
                    SetDateTimeControl(lblDate5, 4);
                }

                if (!IsTheSameDayTime(Convert.ToDateTime(dtRecentActivities.Rows[4][5]), Convert.ToDateTime(dtRecentActivities.Rows[4][3])))
                {
                    lblLIcenseId5.Text = $"License " + dtRecentActivities.Rows[4][0].ToString() + " Update Detaining";
                }
            }
        }

        public async Task LoadInfo()
        {
            dtRecentActivities = await clsDetainedLicense.GetRecenttActivityAsync();

            SetControlsVisibility();
            SetControlsData();
        }
    }
}