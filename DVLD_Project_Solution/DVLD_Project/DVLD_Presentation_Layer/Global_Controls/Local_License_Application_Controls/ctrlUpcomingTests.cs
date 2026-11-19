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

namespace DVLD_Presentation_Layer.Global_Controls.Local_License_Application_Controls
{
    public partial class ctrlUpcomingTests : UserControl
    {
        public ctrlUpcomingTests()
        {
            InitializeComponent();
        }

        public void LoadDefaultControlsValue()
        {
            string DefaultControlsString = "";
            lblStreetTest.Text = DefaultControlsString;
            lblWritenTest.Text = DefaultControlsString;
            lblVisionTest.Text = DefaultControlsString;

        }

        private byte _PassedTestCount;
        public byte PassedTestCount { get => _PassedTestCount; }
        private int _LocalLicenseAppId;
        public int LocalLicenseAppId { get => _LocalLicenseAppId; }

        public async Task LoadInfo(int LocalLicenseAppId,int PassedTestsCount)
        {
            _LocalLicenseAppId= LocalLicenseAppId;
            _PassedTestCount = (byte)PassedTestsCount;
            if (PassedTestsCount == 3)
            {

                    lblVisionTest.Text = "Pass";
                    lblStreetTest.Text = "Pass";
                    lblWritenTest.Text = "Pass";

            }

            if (PassedTestsCount == 2)
            {

                lblVisionTest.Text = "Pass";
                lblWritenTest.Text = "Pass";
                clsTestAppointment LastTestAppointment = await clsTestAppointment.GetLastTestAppointmentAsync(LocalLicenseAppId, clsTestType.enTestType.StreetTest);
                if(LastTestAppointment != null)
                {
                  
                    if(LastTestAppointment.IsLocked)
                    
                        lblStreetTest.Text = "Fail";
                    else
                        lblStreetTest.Text = "Scheduled";
                }
                else
                    lblStreetTest.Text = "No Scheduled";

            }

            if (PassedTestsCount == 1)
            {

                lblVisionTest.Text = "Pass";
                lblStreetTest.Text = "Not Scheduled";
                clsTestAppointment LastTestAppointment =await clsTestAppointment.GetLastTestAppointmentAsync(LocalLicenseAppId, clsTestType.enTestType.WrittenTest);
                if (LastTestAppointment != null)
                {

                    if (LastTestAppointment.IsLocked)

                        lblWritenTest.Text = "Fail";
                    
                    else
                        lblWritenTest.Text = "Scheduled";
                }
                else
                    lblWritenTest.Text = "No Scheduled";



            }




        }

        private void ctrlUpcomingTests_Load(object sender, EventArgs e)
        {
            LoadDefaultControlsValue();
        }

  
    }
}
