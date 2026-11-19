using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_User__Controles
{
    public partial class ctrlLocalApplicationDetails : UserControl
    {


        public async Task LoadInfo(int LocalApplicationID)
        {

            clsLocalDrivingLicenseApplication LocalApp=await clsLocalDrivingLicenseApplication.FindByLocalAppIDAsync(LocalApplicationID);
            lblLocalAppId.Text = LocalApp.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationType.Text=LocalApp.ApplicationType.ApplicationTypeTitle;
            lblNationalNo.Text=LocalApp.PersonInfo.NationalNo;
            lblPersonName.Text=LocalApp.PersonInfo.Name;
            clsLocalDrivingLicenseApplication.enApplicationStatus AppStatus=  LocalApp.ApplicationStatus;
            if(AppStatus==clsApplication.enApplicationStatus.New)
            {
                btnAppStatus.Text = "New";
                btnAppStatus.FillColor = Color.DarkBlue;
                btnAppStatus.FillColor2 = Color.DarkTurquoise;
                
            }
            if (AppStatus == clsApplication.enApplicationStatus.completed)
            {
                btnAppStatus.Text = "completed";
                btnAppStatus.FillColor = Color.DarkSeaGreen;
                btnAppStatus.FillColor2 = Color.DarkGreen;

            }
            if (AppStatus == clsApplication.enApplicationStatus.Canceled)
            {
                btnAppStatus.Text = "Canceled";
                btnAppStatus.FillColor = Color.DarkRed;
                btnAppStatus.FillColor2 = Color.Purple;

            }

            lblAppDate.Text= LocalApp.ApplicationDate.ToShortDateString();

        }

        public ctrlLocalApplicationDetails()
        {
            InitializeComponent();
        }
    }
}
