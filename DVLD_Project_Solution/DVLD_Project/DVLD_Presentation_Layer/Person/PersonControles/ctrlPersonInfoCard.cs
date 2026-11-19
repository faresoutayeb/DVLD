using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Person.PersonControles
{
    public partial class ctrlPersonInfoCard : UserControl
    {
        public ctrlPersonInfoCard()
        {
            InitializeComponent();
        }


        private int _PersonID;
        private string _NationalNo;

        private clsPerson _Person;

        public int PersonID => _PersonID;
        public string NationalNo => _NationalNo;


        public clsPerson Person
        {
            get => _Person;

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
            string DefaultControlsString = "????";
            lblFirstName.Text = DefaultControlsString;
            lblSecondName.Text = DefaultControlsString;
            lblThirdName.Text = DefaultControlsString;
            lblLastName.Text = DefaultControlsString;

            lblGendorValue.Text = DefaultControlsString;
            lblCountryValue.Text = DefaultControlsString;
            lblAddressValue.Text = DefaultControlsString;
            lblEmailValue.Text = DefaultControlsString;
            lblPhoneValue.Text = DefaultControlsString;
            lblBirthDayValue.Text = DefaultControlsString;
            lblGendorValue.Text = DefaultControlsString;

        }
        private void FillControls(clsPerson CurrentPerson)
        {
            lblFirstName.Text= _Person.FirstName;
            lblSecondName.Text= _Person.SecondName;
            lblThirdName.Text= _Person.ThirdName;
            lblLastName.Text= _Person.LastName;
            lblGendorValue.Text = _Person.Gender.ToString();
            if (_Person.Gender == clsPerson.enGender.Male)
                pbGender.Image = Resources.male;
            else
                pbGender.Image = Resources.female;

           lblCountryValue.Text = _Person.CountryInfo.CountryName;

            lblAddressValue.Text = _Person.Address;
            lblEmailValue.Text = _Person.Email;
            lblPhoneValue.Text = _Person.Phone;
            lblBirthDayValue.Text = _Person.DateOfBirth.ToShortDateString();
            lblName.Text = CurrentPerson.Name;
            lblPersonID.Text = CurrentPerson.PersonID.ToString();

            lblGender.Text = (CurrentPerson.Gender == clsPerson.enGender.Male) ? "Male" : "Female";
            lblNationalNo.Text = CurrentPerson.NationalNo;
            if (CurrentPerson.ImagePath == "" || CurrentPerson.ImagePath != null)
            {
                if(File.Exists(pbProfilePicture.ImageLocation))
                {

                    pbProfilePicture.ImageLocation = CurrentPerson.ImagePath;

                }
            }
            else
            {
                pbProfilePicture.Image = Resources.person_man;

            }


        }


        public async void LoadPersonInfo(int PersonID)
        {

            _Person =  await clsPerson.FindAsync(PersonID);
            if (clsUtil.IsObjectFull(_Person))
            {
                this._PersonID = _Person.PersonID;
                this._NationalNo = _Person.NationalNo;
                FillControls(_Person);
             
                    PersonFound();

                
            }
            else
            {
                LoadDefaultControlsValue();
              
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
              
                    PersonFound();

                

            }
            else
            {
                LoadDefaultControlsValue();
               
                    NoPersonFound();

                
            }

        }

        public void  TaskLoadPersonInfo(clsPerson CurrentPerson)
        {
            if (clsUtil.IsObjectFull(CurrentPerson))
            {
                this._Person = CurrentPerson;
                this._PersonID = _Person.PersonID;
                FillControls(_Person);
            
                    PersonFound();

                
            }
            else
            {
                LoadDefaultControlsValue();
             
                    NoPersonFound();

                
            }

        }


    }
}
