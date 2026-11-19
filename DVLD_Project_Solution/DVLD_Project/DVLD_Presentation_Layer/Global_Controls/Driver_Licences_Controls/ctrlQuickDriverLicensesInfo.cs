using DVLD.Classes;
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

namespace DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls
{
    public partial class ctrlQuickDriverLicensesInfo : UserControl
    {
        public ctrlQuickDriverLicensesInfo()
        {
            InitializeComponent();
            controls = new Control[16]
            {
                  guna2HtmlLabel2,
                    guna2HtmlLabel3,
                    guna2HtmlLabel4,
                    guna2HtmlLabel5,
                    lblFirstLicenseIssuedDate,
                    lblLastLicenseIssuedDate,
                    lblExpiryDate,
                    lblDaysUntilExpiry,
                    guna2PictureBox1,
                    guna2PictureBox2,
                    guna2PictureBox3,
                    guna2PictureBox4,
                    guna2HtmlLabel8,
                    guna2HtmlLabel7,
                    guna2HtmlLabel6,
                    guna2HtmlLabel9,
            };

        }

        Control[] controls;

        private clsLicense _LastLicense;
        public clsLicense LastLicense
        {
            get => _LastLicense;
        }
        [Category("Appearance")]
        [Description("Gets or sets the Group Box fill color of the control.")]
        public Color CustomColor
        {
            get => this.guna2GroupBox1.FillColor;
            set => this.guna2GroupBox1.FillColor = value;
        }
        public async Task LoadInfo(int PersonID)
        {
            lblFirstLicenseIssuedDate.Text = clsFormat.DateToShort(await clsLicense.GetFirstLicenseIssuedDateAsync(PersonID)).ToString();

             _LastLicense = await clsLicense.GetLastLicenseInfoByPersonIDAsync(PersonID);
            if(_LastLicense != null)
            {
                lblLastLicenseIssuedDate.Text= clsFormat.DateToShort(_LastLicense.IssueDate).ToString();
                lblExpiryDate.Text = clsFormat.DateToShort(_LastLicense.ExpirationDate);
                int DayUntilEprired = (DateTime.Now - _LastLicense.ExpirationDate).Days;
                lblDaysUntilExpiry.Text =  (DayUntilEprired <0)? (DayUntilEprired * (-1)).ToString(): DayUntilEprired.ToString();


                clsUtil.CenterilizeAllControls(controls);

            }



        }

    }
}
