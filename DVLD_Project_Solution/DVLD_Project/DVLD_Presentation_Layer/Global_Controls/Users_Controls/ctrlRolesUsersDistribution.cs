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
using System.Web.Hosting;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls.Users_Controls
{
    public partial class ctrlRolesUsersDistribution : UserControl
    {
        public ctrlRolesUsersDistribution()
        {
            InitializeComponent();
        }
        private void SetProgressBarColors(Guna2ProgressBar CurrentProgBar)
        {

            if(CurrentProgBar.Value<10)
           {
                CurrentProgBar.ProgressColor2 = Color.SkyBlue;

            }

            if (CurrentProgBar.Value >= 10 && CurrentProgBar.Value <= 30)
            {
                CurrentProgBar.ProgressColor2 = Color.Violet;


            }
            if (CurrentProgBar.Value > 30 && CurrentProgBar.Value <= 50)
            {
                CurrentProgBar.ProgressColor2 = Color.Orange;


            }
            if (CurrentProgBar.Value > 50 && CurrentProgBar.Value<=60)
            {
                CurrentProgBar.ProgressColor2 = Color.Blue;


            }

            if(CurrentProgBar.Value>60)
            {
                CurrentProgBar.ProgressColor2= Color.Green;
            }

        }

        public async Task LoadInfo()
        {
            int TotalUsers=await clsUser.GetAllUserCountAsync();

            int TotalRoles= await clsRole.GetRolesCountAsync();
           lblTotalRolsCount.Text= TotalRoles.ToString();


            DataTable dt = new DataTable(); 
            dt=await  clsRole.GetRolesUsersCountAsync   ();


            int SystemAdministrater = Convert.ToInt32(dt.Rows[0][1]);
            int UserManager = Convert.ToInt32(dt.Rows[1][1]);
            int     PeopleManager =  Convert.ToInt32(dt.Rows[2][1]);
            int     ApplicationManager =  Convert.ToInt32(dt.Rows[3][1]);
            int     LocalLicenseOfficer =  Convert.ToInt32(dt.Rows[4][1]);
            int     InternationalLicenseOfficer =  Convert.ToInt32(dt.Rows[5][1]);
            int     TestManager =  Convert.ToInt32(dt.Rows[6][1]);
            int     ApplicationAndTestOfficer =  Convert.ToInt32(dt.Rows[7][1]);
            int     DetentionOfficer =  Convert.ToInt32(dt.Rows[8][1]);
            int     ApplicationTypeManager =  Convert.ToInt32(dt.Rows[9][1]);
            int     TestTypeManager =  Convert.ToInt32(dt.Rows[10][1]);
            int     ApplicationTypesAndTestTypesManager =  Convert.ToInt32(dt.Rows[11][1]);
            int Receptionist =  Convert.ToInt32(dt.Rows[12][1]);
            int     LicenseServiceOfficer =  Convert.ToInt32(dt.Rows[13][1]);
            int     TestExaminer =  Convert.ToInt32(dt.Rows[14][1]);
            int     TestAppointmentOfficer =  Convert.ToInt32(dt.Rows[15][1]);
            int     LicenseViewer =  Convert.ToInt32(dt.Rows[16][1]);
            int     ApplicationViewer =  Convert.ToInt32(dt.Rows[17][1]);


            lblSystemAdministraterCount.Text=SystemAdministrater.ToString()+"/"  + TotalUsers;
            lblUserManagerCount.Text = UserManager.ToString() + "/" + TotalUsers;
            lblPeopleManagerCount.Text = PeopleManager.ToString() + "/" + TotalUsers;
            lblApplicationManagerCount.Text = ApplicationManager.ToString() + "/" + TotalUsers;
            lblLocalLicenseOfficerCount.Text = LocalLicenseOfficer.ToString() + "/" + TotalUsers;
            lblInternationalLicenseOfficerCount.Text = InternationalLicenseOfficer.ToString() + "/" + TotalUsers;
            lblTestManagerExaminerCount.Text = TestManager.ToString() + "/" + TotalUsers;
            lblApplicationTestOfficerCount.Text = ApplicationAndTestOfficer.ToString() + "/" + TotalUsers;
            lblDetentionOfficerCount.Text = DetentionOfficer.ToString() + "/" + TotalUsers;
            lblApplicationTypeManagerCount.Text = ApplicationTypeManager.ToString() + "/" + TotalUsers;
            lblTestTypesManagerCount.Text = TestTypeManager.ToString() + "/" + TotalUsers;
            lblApplicationTypesAndTestTypesManager.Text = ApplicationTypesAndTestTypesManager.ToString() + "/" + TotalUsers;

            lblReceptionistCount.Text = Receptionist.ToString() + "/" + TotalUsers;
            lblLicenseServiceOfficerCount.Text = LicenseServiceOfficer.ToString() + "/" + TotalUsers;
            lblTestExaminerCount.Text = TestExaminer.ToString() + "/" + TotalUsers;
            lblTestAppointmentOfficerCount.Text = TestAppointmentOfficer.ToString() + "/" + TotalUsers;
            lblLicenseViewerCount.Text = LicenseViewer.ToString() + "/" + TotalUsers;
            lblApplicationViewerCount.Text = ApplicationViewer.ToString() + "/" + TotalUsers;



            progbSystemAdministrater.Value = (SystemAdministrater * 100) / TotalUsers;
            progbUserManager.Value = (UserManager * 100) / TotalUsers;
            progbPeopleManager.Value = (PeopleManager * 100) / TotalUsers;
            progbApplicationManager.Value = (ApplicationManager * 100) / TotalUsers;
            progbLocalLicenseOfficer.Value = (LocalLicenseOfficer * 100) / TotalUsers;
            progbInternationalLicenseOfficer.Value = (InternationalLicenseOfficer * 100) / TotalUsers;
            progbTestManager.Value = (TestManager * 100) / TotalUsers;
            progbApplicationAndTestOfficer.Value = (ApplicationAndTestOfficer * 100) / TotalUsers;
            progbDetentionOfficer.Value = (DetentionOfficer * 100) / TotalUsers;
            progbApplicationTypeManager.Value = (ApplicationAndTestOfficer * 100) / TotalUsers;
            progbTestTypeManager.Value = (TestTypeManager * 100) / TotalUsers;
            progbApplicationTypesAndTestTypesManager.Value = (ApplicationTypesAndTestTypesManager * 100) / TotalUsers;
            progbReceptionist.Value = (Receptionist * 100) / TotalUsers;
            progbLicenseServiceOfficer.Value = (LicenseServiceOfficer * 100) / TotalUsers;
            progbTestExaminer.Value = (TestExaminer * 100) / TotalUsers;
            progbTestAppointmentOfficer.Value = (TestAppointmentOfficer * 100) / TotalUsers;
            progbLicenseViewer.Value = (LicenseViewer * 100) / TotalUsers;
            progbApplicationViewer.Value = (ApplicationViewer * 100) / TotalUsers;


            SetProgressBarColors(progbSystemAdministrater);
            SetProgressBarColors(progbUserManager);
            SetProgressBarColors(progbPeopleManager);
            SetProgressBarColors(progbApplicationManager);
            SetProgressBarColors(progbLocalLicenseOfficer);
            SetProgressBarColors(progbInternationalLicenseOfficer);
            SetProgressBarColors(progbTestManager);
            SetProgressBarColors(progbApplicationAndTestOfficer);
            SetProgressBarColors(progbDetentionOfficer);
            SetProgressBarColors(progbApplicationTypeManager);
            SetProgressBarColors(progbTestTypeManager);
            SetProgressBarColors(progbApplicationTypesAndTestTypesManager);
            SetProgressBarColors(progbReceptionist);
            SetProgressBarColors(progbLicenseServiceOfficer);
            SetProgressBarColors(progbTestExaminer);
            SetProgressBarColors(progbTestAppointmentOfficer);
            SetProgressBarColors(progbLicenseViewer);
            SetProgressBarColors(progbApplicationViewer);
        }



    }
}
