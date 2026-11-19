using DVLD.Classes;
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
using System.IO;

namespace DVLD_Presentation_Layer.License.License_User_Controls
{
    public partial class ctrlInterLicenseInfo : UserControl
    {
        private int _InternationalLicenseID;
        private clsInternationalLicense _InternationalLicense;

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }
        public clsInternationalLicense InternationalLicense
        {

            get { return _InternationalLicense; }
        }


        public ctrlInterLicenseInfo()
        {
            InitializeComponent();
        }


        public event Action OnInternationalLicenseNotFound;
        protected virtual void InternationalLicenseNotFound()
        {

            OnInternationalLicenseNotFound?.Invoke();
        }
        public event Action OnLicenseImageNotFound;
        protected virtual void LicenseImageNotFound()
        {

            OnLicenseImageNotFound?.Invoke();
        }


        private void _LoadPersonImage()
        {
            //if (_InternationalLicense.DriverInfo.PersonInfo.Gender== clsPerson.enGender.Male)
            //    pbPersonImage.BackgroundImage = Resources.person_man;
            //else
            //    pbPersonImage.BackgroundImage = Resources.little_female;

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.Load(ImagePath);

                }
                else
                {
                     LicenseImageNotFound();
                    
                }
            }

        }

        public async Task LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = await clsInternationalLicense.FindAsync(_InternationalLicenseID);
            if (_InternationalLicense == null)
            { 
                _InternationalLicenseID = -1;
         

                    InternationalLicenseNotFound();
               
                return;
            }

            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male? "Male" : "Female";
            lblDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblExpirationDate.Text =_InternationalLicense.ExpirationDate.ToShortDateString();

            _LoadPersonImage();



        }
    }
}
