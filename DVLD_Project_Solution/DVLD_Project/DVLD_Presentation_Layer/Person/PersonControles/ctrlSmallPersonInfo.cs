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

namespace DVLD_Presentation_Layer.Person.PersonControles
{
    public partial class ctrlPersonInfo_Small_ : UserControl
    {
        private clsPerson _CurrentPerson;
        public clsPerson CurrentPerson {
            get => _CurrentPerson;
        }

        public void LoadDefaultControlsValue()
        {
            string DefaultControlsString = "";
            lblName.Text = DefaultControlsString;
            lblNationalNo.Text = DefaultControlsString;
            lblGender.Text = DefaultControlsString;
            lblDateOfBirth.Text = DefaultControlsString;
            lblAddress.Text = DefaultControlsString;
            lblPhone.Text = DefaultControlsString;
            lblEmail.Text = DefaultControlsString;
            pbPersonPicture.Image = Resources.online;
        }

        public async Task LoadInfo(int PersonID)
        {
            _CurrentPerson = await clsPerson.FindAsync(PersonID);
            if(CurrentPerson != null)
            {
               lblName.Text = CurrentPerson.Name;
                lblNationalNo.Text = CurrentPerson.NationalNo;
                lblEmail.Text = CurrentPerson.Email;
                lblPhone.Text = CurrentPerson.Phone;
                lblAddress.Text = CurrentPerson.Address;
                lblDateOfBirth.Text = CurrentPerson.DateOfBirth.ToShortDateString();
                if(CurrentPerson.Gender==clsPerson.enGender.Male)
                    lblGender.Text= clsPerson.enGender.Male.ToString();
                else
                    lblGender.Text = clsPerson.enGender.Female.ToString();


                if (CurrentPerson.ImagePath != null && File.Exists(CurrentPerson.ImagePath))
                {
                    pbPersonPicture.ImageLocation = CurrentPerson.ImagePath;
                }
                else
                {
                    if (CurrentPerson.Gender == clsPerson.enGender.Male)
                    {

                        pbPersonPicture.BackgroundImage = Resources.little_boy;

                    }
                    else
                    {
                        pbPersonPicture.BackgroundImage = Resources.little_female;

                    }

                }
            }
          
        }

        public async Task LoadInfo(string NationalNo)
        {
            int PersonID=await clsPerson.GetPersonIDAsync(NationalNo);
            _CurrentPerson = await clsPerson.FindAsync(PersonID);
            if (CurrentPerson != null)
            {
                lblName.Text = CurrentPerson.Name;
                lblNationalNo.Text = CurrentPerson.NationalNo;
                lblEmail.Text = CurrentPerson.Email;
                lblPhone.Text = CurrentPerson.Phone;
                lblAddress.Text = CurrentPerson.Address;
                lblDateOfBirth.Text = CurrentPerson.DateOfBirth.ToShortDateString();
                if (CurrentPerson.Gender == clsPerson.enGender.Male)
                    lblGender.Text = clsPerson.enGender.Male.ToString();
                else
                    lblGender.Text = clsPerson.enGender.Female.ToString();


                if (CurrentPerson.ImagePath != null && File.Exists(CurrentPerson.ImagePath))
                {
                    pbPersonPicture.ImageLocation = CurrentPerson.ImagePath;
                }
                else
                {
                    if (CurrentPerson.Gender == clsPerson.enGender.Male)
                    {

                        pbPersonPicture.BackgroundImage = Resources.little_boy;

                    }
                    else
                    {
                        pbPersonPicture.BackgroundImage = Resources.little_female;

                    }

                }
            }

        }


        public ctrlPersonInfo_Small_()
        {
            InitializeComponent();
        }

        private void ctrlPersonInfo_Small__Load(object sender, EventArgs e)
        {
            LoadDefaultControlsValue();
        }
    }
}
