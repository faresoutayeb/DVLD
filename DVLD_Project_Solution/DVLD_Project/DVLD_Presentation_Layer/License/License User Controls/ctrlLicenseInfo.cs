using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.License.License_User_Controls
{
    public partial class ctrlLicenseInfo : UserControl
    {
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }
        private int _LicenseID=-1;
        private clsLicense _CurrentLicense;

        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense SelectedLicenseInfo
        { get { return _CurrentLicense; } }
        private bool _IsLicenseFound;
        public bool IsLicenseFound
        {

            get => _IsLicenseFound;

        }

        private async Task _FillLicenseInfoToControls(clsLicense CurrentLicense)
        {

            lblDriverID.Text = CurrentLicense.DriverID.ToString();
            lblIssueDate.Text = CurrentLicense.IssueDate.ToShortDateString();
            lblIssueReason.Text = CurrentLicense.IssueReasonString;
            lblIsDetainedLicense.Text = (await clsDetainedLicense.IsLicenseDetainedAsync(CurrentLicense.LicenseID)) ? "Yes" : "No";
            lblLicenseID.Text = CurrentLicense.LicenseID.ToString();
            lblNotes.Text = CurrentLicense.Notes;
            lblExpirationDate.Text = CurrentLicense.ExpirationDate.ToShortDateString();
            lblIsActive.Text = CurrentLicense.IsActive.ToString();

            lblName.Text = CurrentLicense.DriverInfo.PersonInfo.Name;
            lblDateOfBirth.Text = CurrentLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblGendor.Text = CurrentLicense.DriverInfo.PersonInfo.Gender.ToString();
            lblNationalNo.Text = CurrentLicense.DriverInfo.PersonInfo.NationalNo;
            lblLicenseClass.Text = await clsLicenseClass.GetLicenseClassNameAsync(CurrentLicense.LicenseClassID);
            _LoadPersonImage();

        }
        private void _LoadPersonImage()
        {


            string ImagePath = _CurrentLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.Load(ImagePath);
                }
                else
                {
                    if (_CurrentLicense.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male)
                        pbPersonImage.Image = Resources.person_man;
                    else
                        pbPersonImage.Image = Resources.little_female;
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        }

        public event Action OnNoLicenseFound;
        protected virtual void NoLicenseFound()
        {
            OnNoLicenseFound?.Invoke();

        }


        public async Task LoadLicenseInfoToControls(int LicenseID)
        {
            _LicenseID= LicenseID;
            _CurrentLicense =await  clsLicense.FindByAsync  (LicenseID);
            if(clsUtil.IsObjectFull(_CurrentLicense))
            {
                _IsLicenseFound = true;
                 await _FillLicenseInfoToControls(_CurrentLicense);

                    
                
            }
            else
            {
                _IsLicenseFound = false;
                NoLicenseFound();
            }

        }


    }
}
