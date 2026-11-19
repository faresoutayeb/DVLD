using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Person.PersonControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.LicenseHistory.License_History_Screens
{
    public partial class frmLicenseHistoryScreen : Form
    {
        enum enMode { Read,Update}
        enMode _Mode= enMode.Read;

        private int _PersonID=-1;

        public frmLicenseHistoryScreen()
        {
            InitializeComponent();
             _Mode = enMode.Read;



        }

        public frmLicenseHistoryScreen(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;

            _PersonID = PersonID;


        }

        private  void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {

            if(_Mode ==enMode.Read)
            {
                ctrlFilterPersonInformation1.EnableFilter = true;
                ctrlFilterPersonInformation1.EnableAddNewButton = true;
                ctrlFilterPersonInformation1.Enabled = true;
                ctrlFilterPersonInformation1.FocusOnFilterTextBox();
            }

            else
            {
                ctrlFilterPersonInformation1.EnableFilter = true;

                ctrlFilterPersonInformation1.cbPersonFilter.SelectedIndex = 0;
                ctrlFilterPersonInformation1.txtbFilter.Text= _PersonID.ToString();
                ctrlFilterPersonInformation1.btnSearch.PerformClick();
                ctrlFilterPersonInformation1.EnableFilter = false;



            }
     




            





        }


        private async void ctrlFilterPersonInformation1_OnPersonSelectedByPersonID(int obj)
        {
            _PersonID = obj;
        
                await ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);

                await ctrlAciveDriverLicenses1.LoadInfo(_PersonID);
                await ctrlExpiredDriverLicenses1.LoadInfo(_PersonID);
                await ctrlInactiveDriverLicenses1.LoadInfo(_PersonID);
                await ctrlTotalInternationalDriverLicenses1.LoadInfo(_PersonID);
                await ctrlTotalLocalDriverLicenses1.LoadInfo(_PersonID);

                await ctrlDriverLicenseSummary1.LoadInfo(_PersonID);
                await ctrlQuickDriverLicensesInfo1.LoadInfo(_PersonID);
                await ctrlDriverLicenses1.LoadInfoByPersonID(obj);

        }

        private async void ctrlFilterPersonInformation1_OnPersonSelectedByNationalNo(string NationalNo)
        {
            _PersonID =await clsPerson.GetPersonIDAsync(NationalNo);

            if(_PersonID != -1)
            {
                await ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);

                await ctrlAciveDriverLicenses1.LoadInfo(_PersonID);
                await ctrlExpiredDriverLicenses1.LoadInfo(_PersonID);
                await ctrlInactiveDriverLicenses1.LoadInfo(_PersonID);
                await ctrlTotalInternationalDriverLicenses1.LoadInfo(_PersonID);
                await ctrlTotalLocalDriverLicenses1.LoadInfo(_PersonID);

                await ctrlDriverLicenseSummary1.LoadInfo(_PersonID);
                await ctrlQuickDriverLicensesInfo1.LoadInfo(_PersonID);
                await ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);

            }



        }

        private void ctrlFilterPersonInformation1_OnPersonSelectedNotFound()
        {
            MessageBox.Show("No Person Found", "Person Not Found",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void ctrlFilterPersonInformation1_OnPersonSelectedFound()
        {

        }
    }
}
