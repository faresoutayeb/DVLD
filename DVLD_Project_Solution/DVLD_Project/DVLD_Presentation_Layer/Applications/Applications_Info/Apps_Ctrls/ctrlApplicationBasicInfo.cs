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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer.DVLD_Applications.Applications_User_Controles
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private int _PersonID { get; set; }

        private int _ApplicationID;
        public int ApplicationID 
        {
            get {  return _ApplicationID; }
        }

        private clsApplication _ApplicationInfo;
        public clsApplication ApplicationInfo
        {
            get { return _ApplicationInfo; }
        }

        private void _FillControlsInfo()
        {

            lblApplicationID.Text = _ApplicationInfo.ApplicationID. ToString();
            lblStatus.Text=clsApplication.ApplicationStatusString((clsApplication.enApplicationStatus)_ApplicationInfo.ApplicationStatus);
            lblFees.Text= _ApplicationInfo.PaidFees.ToString();
            lblType.Text= _ApplicationInfo.ApplicationType.ApplicationTypeTitle;
            lblApplicantName.Text = _ApplicationInfo.PersonInfo.Name;
            lblDate.Text= _ApplicationInfo.ApplicationDate.ToShortDateString();
            lblStatusDate.Text= _ApplicationInfo.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _ApplicationInfo.UserInfo.UserName;
        }


        public  async Task LoadControlsInfo(int ApplicationID)
        {

             _ApplicationInfo = await clsApplication.FindApplicationAsync(ApplicationID);
            if (_ApplicationInfo != null) 
            {
                _ApplicationID = _ApplicationInfo.ApplicationID;
                this._PersonID = _ApplicationInfo.ApplicantPersonID;
                _FillControlsInfo();
                
            }

        }
        public void LoadDefaultInfo()
        {
            string DefaultString = "????";
            lblApplicationID.Text = DefaultString;
            lblStatus.Text = DefaultString;
            lblFees.Text = DefaultString;
            lblType.Text = DefaultString;
            lblApplicantName.Text = DefaultString;
            lblDate.Text = "??/??/????";
            lblStatusDate.Text = "??/??/????";
            lblCreatedBy.Text = DefaultString;

        }
        private void label9_Click(object sender, EventArgs e)
        {
            frmPersonInformationScreen CurrentPersonScreen = new frmPersonInformationScreen(this._PersonID);

            CurrentPersonScreen.ShowDialog();


        }
    }
}
