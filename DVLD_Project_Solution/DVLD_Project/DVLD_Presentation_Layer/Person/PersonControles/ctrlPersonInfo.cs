using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class ctrlPersonInfo : UserControl
    {


        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        //----------------------------------initialize variables -----------------------------------------------------

        private int _PersonID;
        private string _NationalNo;

        private clsPerson _Person;

        public int PersonID => _PersonID ;
        public string NationalNo => _NationalNo;


        public clsPerson Person
        {
                get => _Person;

        }
        private bool _IsPersonFounded;
        public bool IsPersonFounded
        {
            get { return _IsPersonFounded; }
        }


        //----------------------------------initialize events and delegate -----------------------------------------------------
        public event Action OnNoPersonFound;
        protected virtual void NoPersonFound()
        {
            OnNoPersonFound?.Invoke();

        }

        public event Action OnPersonFound;
        protected virtual void PersonFound()
        {
            OnPersonFound?.Invoke();

        }

        //----------------------------------locals funtions  -----------------------------------------------------


        public void LoadDefaultControlsValue()
        {
            string DefaultControlsString = "";
                lblPersonIDValue.Text = DefaultControlsString;
                lblNameValue.Text = DefaultControlsString;
                lblNationalNoValue.Text = DefaultControlsString;
                lblGendorValue.Text = DefaultControlsString;
                lblCountryValue.Text = DefaultControlsString;
                lblAddressValue.Text = DefaultControlsString;
                lblEmailValue.Text = DefaultControlsString;
                lblPhoneValue.Text = DefaultControlsString;
                lblBirthDayValue.Text = DefaultControlsString;
                pbProfileInfoPicture.ImageLocation = "";
                lblGendorValue.Text = DefaultControlsString;
            pbProfileInfoPicture.BackgroundImage= null;
                pbProfileInfoPicture.Image =Resources.watchman;

        }

        private void FillControls(clsPerson CurrentPerson)
        {
                lblPersonIDValue.Text=_Person.PersonID.ToString();
                lblNameValue.Text = _Person.FullName;
                lblNationalNoValue.Text = _Person.NationalNo.ToString();
                lblGendorValue.Text = _Person.Gender.ToString();
      
                
                lblCountryValue.Text = _Person.CountryInfo.CountryName;
                
                lblAddressValue.Text = _Person.Address;
                lblEmailValue.Text = _Person.Email;
                lblPhoneValue.Text = _Person.Phone;
                lblBirthDayValue.Text =  _Person.DateOfBirth.ToShortDateString();
                if(_Person.ImagePath != "")
                {
                        if(File.Exists(_Person.ImagePath))
                        {
                    
                            pbProfileInfoPicture.Load(_Person.ImagePath);
                            return;
                        }


                }
                  
                // pbProfileInfoPicture.ImageLocation = null;
                if (_Person.Gender == clsPerson.enGender.Male)
                {

                    pbProfileInfoPicture.BackgroundImage = Resources.little_boy;

                }
                else
                {
                    pbProfileInfoPicture.BackgroundImage = Resources.little_female;

                }


                
        }

        public async Task LoadPersonInfo(int PersonID )
        {

             _Person =await clsPerson.FindAsync(PersonID);
            if(clsUtil.IsObjectFull(_Person))
            {
                this._PersonID = _Person.PersonID;
                this._NationalNo = _Person.NationalNo;
                FillControls(_Person);
                        _IsPersonFounded = true;

                    PersonFound();


            }
            else
            {
                LoadDefaultControlsValue();
                           _IsPersonFounded = false;

                    NoPersonFound();


            }

        }

        public async Task LoadPersonInfo(string NationalNo)
        {

            _Person = await clsPerson.FindAsync(NationalNo);
            if (clsUtil.IsObjectFull(_Person))
            {
                this._PersonID = _Person.PersonID;
                this._NationalNo = _Person.NationalNo;
                FillControls(_Person);
                           _IsPersonFounded=true;

                    PersonFound();



            }
            else
            {
                LoadDefaultControlsValue();
                         _IsPersonFounded=false;

                    NoPersonFound();


            }

        }

        public async Task LoadPersonInfo(clsPerson CurrentPerson)
        {
            CurrentPerson = await clsPerson.FindAsync(PersonID);
            if (clsUtil.IsObjectFull(_Person))
            {
                this._Person = CurrentPerson;
                this._PersonID = _Person.PersonID;
                FillControls(_Person);
                       _IsPersonFounded = true;

                    PersonFound();


            }
            else
            {
                LoadDefaultControlsValue();
                    _IsPersonFounded = false;

                    NoPersonFound();


            }

        }


        //---------------------------------- controls events  -----------------------------------------------------

        private async void  LoadPersonInfoWhenDataBack(object sender, int PersonID)
        {
           await LoadPersonInfo(PersonID);

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }

            frmAddEditPerson EditPersonInfo = new frmAddEditPerson(_PersonID);
            EditPersonInfo.OnDataBack += LoadPersonInfoWhenDataBack;
            EditPersonInfo.ShowDialog();


        }
    }
}
