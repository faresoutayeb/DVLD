using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls
{
    public partial class ctrlDetainReasons_Top5_ : UserControl
    {
        public ctrlDetainReasons_Top5_()
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
                lblReasonText1.Visible = false;
                lblDetainReasonCount1.Visible = false;
                lblDetainPercentage1.Visible = false;
                progbReason1.Visible = false;
                return;
            }

            if (RowNumber == 2)
            {
                lblReasonText2.Visible = false;
                lblDetainReasonCount2.Visible = false;
                lblDetainPercentage2.Visible = false;
                progbReason2.Visible = false;
                return;
            }

            if (RowNumber == 3)
            {
                lblReasonText3.Visible = false;
                lblDetainReasonCount3.Visible = false;
                lblDetainPercentage3.Visible = false;
                progbReason3.Visible = false;
                return;
            }

            if (RowNumber == 4)
            {
                lblReasonText4.Visible = false;
                lblDetainReasonCount4.Visible = false;
                lblDetainPercentage4.Visible = false;
                progbReason4.Visible = false;
                return;
            }

            if (RowNumber == 5)
            {
                lblReasonText5.Visible = false;
                lblDetainReasonCount5.Visible = false;
                lblDetainPercentage5.Visible = false;
                progbReason5.Visible = false;
                return;
            }
        }

        private void SetControlsVisibility()
        {
            byte TotalRows = (byte)dtRecentActivities.Rows.Count;

            if (TotalRows < 5)
            {
                for (byte i = (byte)(TotalRows + 1); i <= 5; i++)
                {
                    DesableControlsInRow(i);
                }
            }
        }

        public void SetControlsData(int TotalDetainedLicenses)
        {
            int TotalTows = dtRecentActivities.Rows.Count;
            float Percentage;
            int DetainedReasonCount;

            if (TotalTows >= 1)
            {
                lblReasonText1.Text = dtRecentActivities.Rows[0][0].ToString();
                DetainedReasonCount = Convert.ToInt32(dtRecentActivities.Rows[0][1]);
                lblDetainReasonCount1.Text = DetainedReasonCount.ToString();

                if (TotalDetainedLicenses == 0)
                    Percentage = 0;
                else
                    Percentage = (DetainedReasonCount * 100) / TotalDetainedLicenses;

                lblDetainPercentage1.Text = "(" + Percentage.ToString() + "%)";
                progbReason1.Value = (int)Percentage;
            }

            if (TotalTows >= 2)
            {
                lblReasonText2.Text = dtRecentActivities.Rows[1][0].ToString();
                DetainedReasonCount = Convert.ToInt32(dtRecentActivities.Rows[1][1]);
                lblDetainReasonCount2.Text = DetainedReasonCount.ToString();

                if (TotalDetainedLicenses == 0)
                    Percentage = 0;
                else
                    Percentage = (DetainedReasonCount * 100) / TotalDetainedLicenses;

                lblDetainPercentage2.Text = "(" + Percentage.ToString() + "%)";
                progbReason2.Value = (int)Percentage;
            }

            if (TotalTows >= 3)
            {
                lblReasonText3.Text = dtRecentActivities.Rows[2][0].ToString();
                DetainedReasonCount = Convert.ToInt32(dtRecentActivities.Rows[2][1]);
                lblDetainReasonCount3.Text = DetainedReasonCount.ToString();

                if (TotalDetainedLicenses == 0)
                    Percentage = 0;
                else
                    Percentage = (DetainedReasonCount * 100) / TotalDetainedLicenses;

                lblDetainPercentage3.Text = "(" + Percentage.ToString() + "%)";
                progbReason3.Value = (int)Percentage;
            }

            if (TotalTows >= 4)
            {
                lblReasonText4.Text = dtRecentActivities.Rows[3][0].ToString();
                DetainedReasonCount = Convert.ToInt32(dtRecentActivities.Rows[3][1]);
                lblDetainReasonCount4.Text = DetainedReasonCount.ToString();

                if (TotalDetainedLicenses == 0)
                    Percentage = 0;
                else
                    Percentage = (DetainedReasonCount * 100) / TotalDetainedLicenses;

                lblDetainPercentage4.Text = "(" + Percentage.ToString() + "%)";
                progbReason4.Value = (int)Percentage;
            }

            if (TotalTows >= 5)
            {
                lblReasonText5.Text = dtRecentActivities.Rows[4][0].ToString();
                DetainedReasonCount = Convert.ToInt32(dtRecentActivities.Rows[4][1]);
                lblDetainReasonCount5.Text = DetainedReasonCount.ToString();

                if (TotalDetainedLicenses == 0)
                    Percentage = 0;
                else
                    Percentage = (DetainedReasonCount * 100) / TotalDetainedLicenses;

                lblDetainPercentage5.Text = "(" + Percentage.ToString() + "%)";
                progbReason5.Value = (int)Percentage;
            }
        }

        public async Task LoadInfo()
        {
            dtRecentActivities = await clsDetainedLicense.GetTopDetainReasonsAsync();

            int TotalDetainedLicenses = await clsDetainedLicense.GetAllDetainedLicensesCountAsync();

            SetControlsVisibility();
            SetControlsData(TotalDetainedLicenses);
        }
    }
}