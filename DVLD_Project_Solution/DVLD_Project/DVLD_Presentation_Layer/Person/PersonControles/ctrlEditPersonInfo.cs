using DVLD.Classes;
using DVLD_Bussiness_Layer;
using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Bussiness_Layer.GlobalClasses;
using DVLD_Presentation_Layer.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLD_Presentation_Layer.Person.PersonControles
{
    public partial class ctrlEditPersonInfo : UserControl
    {


        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;


        private int _PersonID = -1;
        public enum enMode { eAddNewPerson, eUpdatePerson };
        public enMode _Mode=enMode.eAddNewPerson;

        public int PersonID { get { return _PersonID; } set { _PersonID = value; } }
        private clsPerson _Person;

        public clsPerson CurrentPersonInfo
        {
            get
            {
                return _Person;
            }
        }

        public ctrlEditPersonInfo()
        {
            InitializeComponent();
            clsValidation.OnValidationError += _WhenObjectNotValid;

        }



        public event Action OnNoPersonFound;
        protected virtual void NoPersonFound()
        {
            OnNoPersonFound?.Invoke();

        }


        public delegate void OnPersonObjectNotValidEventHandler(  object sender, clsValidationErrorEventArgs e);

        public static event OnPersonObjectNotValidEventHandler OnPersonObjectNotValid;

        protected virtual void PersonObjectNotValid( object sender, clsValidationErrorEventArgs e)
        {
            OnPersonObjectNotValid?.Invoke(sender, e);
        }


        public event Action OnPersonFound;
        protected virtual void PersonFound()
        {
            OnPersonFound?.Invoke();

        }


        public event Action<int> OnPersonUpdated;
        protected virtual void PersonUpdated(int PersonID)
        {
            OnPersonUpdated?.Invoke(PersonID);

        }

        public event Action OnPersonNotUpdated;
        protected virtual void PersonNotUpdated()
        {
            OnPersonNotUpdated?.Invoke();

        }


        public event Action<int> OnNewPersonAdded;
        protected virtual void NewPersonAdded(int PersonId)
        {
            OnNewPersonAdded?.Invoke(PersonId);
        }

        public event Action OnNewPersonNotAdded;
        protected virtual void NewPersonNotAdded()
        {
            OnNewPersonNotAdded?.Invoke();
        }
        private void _WhenPersonObjectNotValid()
        {
            MessageBox.Show($"Object Not Valid");
        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                //we are in update image mode
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any because we change it .
                    // at this point we are setting new image using teh picturebox control so we have to delete the old image from teh project folder
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException CurrentIoException)
                    {
                        // We could not delete the file.
                        //log it later   
                        MessageBox.Show($"{CurrentIoException.Message}", "Error Deleting old profile image");
                    }
                }

                //when we set new image using the picture box
                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();
                    //at tis point we going send the old image path  by refrence to make it back to us with te new file path in our project folder
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }


            return true;
        }


        private  bool _IsEmailProviderExistInComboBox(string EmailProvider)
        {
            foreach (string eProvider in cbEmailProvider.Items)
            {
                if (eProvider == EmailProvider)
                {
                    return true;
                }
            }
            return false;
        }

        public async void LoadDefaultValues()
        {
            _Mode = enMode.eAddNewPerson;
            _Person = new clsPerson();
            //this will initialize the reset the defaule values
            await _FillCountriesInComoboBox();
            rbMale.Checked = true;
            //set default image for the person.
            pbPersonImage.BackgroundImage = Resources.little_boy;
      

            //hide/show the remove linke incase there is no image for the person.
            btnRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            cbEmailProvider.SelectedIndex = 0;
            txtAddress.Text = "";


        }

        private async Task _FillCountriesInComoboBox()
        {
            DataTable dtCountries =await clsCountry.GetAllCountriesNamesAsync();
            if (dtCountries.Rows.Count != 0)
            {
                foreach (DataRow row in dtCountries.Rows)
                {
                    if( row["CountryName"] != null)
                    {
                        cbCountry.Items.Add(row["CountryName"]);

                    }
                }

            }

        }




        private async Task _SavePersonInfoToDataBase()
        {

            if (_Mode == enMode.eUpdatePerson)
            {
                _Person = await clsPerson.FindAsync(_PersonID);
                if (_Person != null)
                {

                    _Person.FirstName = txtFirstName.Text.Trim();
                    _Person.SecondName = txtSecondName.Text.Trim();
                    _Person.ThirdName = txtThirdName.Text.Trim();
                    _Person.LastName = txtLastName.Text.Trim();
                    _Person.Phone = txtPhone.Text.Trim();
                    _Person.Address = txtAddress.Text.Trim();
                    _Person.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;


                    if (_ImagePath != "" && _ImagePath != null)
                        _Person.ImagePath = _ImagePath;
                    else
                        _Person.ImagePath = "";
                    _Person.DateOfBirth = dtpDateOfBirth.Value;
                    _Person.NationalNo = txtNationalNo.Text.Trim();
                    clsCountry SelectedCountry = await clsCountry.FindAsync(cbCountry.Text);
                    if (clsUtil.IsObjectFull(SelectedCountry))
                    {
                        _Person.NationalityCountryID = SelectedCountry.CountryID;

                    }

                    if (chkbCustomEmail.Checked)
                    {
                        if (clsValidation.IsValidEmail(txtEmail.Text))
                        {
                            _Person.Email = txtEmail.Text.Trim();

                        }

                    }
                    else
                    {

                        if (clsValidation.IsValidEmail(txtEmail.Text + cbEmailProvider.Text))
                        {
                            _Person.Email = txtEmail.Text.Trim() + cbEmailProvider.Text;

                        }
                    }
                    if (!clsValidation.IsValid(_Person))
                    {
                        return ;
                    }
                    if (await _Person.SaveAsync())
                    {
                        PersonUpdated(_Person.PersonID);

                        DataBack?.Invoke(this,_Person.PersonID);

                    }
                    else
                    {

                            PersonNotUpdated();
                    }

                }
            }


            if (_Mode == enMode.eAddNewPerson)
            {
                 _Person = new clsPerson();


                _Person.FirstName = txtFirstName.Text.Trim();
                _Person.SecondName = txtSecondName.Text.Trim();
                _Person.ThirdName = txtThirdName.Text.Trim();
                _Person.LastName = txtLastName.Text.Trim();
                _Person.Phone = txtPhone.Text.Trim();
                _Person.Address = txtAddress.Text.Trim();
                _Person.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;

                if (_ImagePath != "" && _ImagePath != null)
                    _Person.ImagePath = _ImagePath;
                else
                    _Person.ImagePath = "";
                _Person.DateOfBirth = dtpDateOfBirth.Value;
                _Person.NationalNo = txtNationalNo.Text.Trim();
                clsCountry SelectedCountry = await clsCountry.FindAsync(cbCountry.Text);
                if (clsUtil.IsObjectFull(SelectedCountry))
                {
                    _Person.NationalityCountryID = SelectedCountry.CountryID;

                }

                if (chkbCustomEmail.Checked)
                {
                    if (clsValidation.IsValidEmail(txtEmail.Text))
                    {
                        _Person.Email = txtEmail.Text.Trim();

                    }

                }
                else
                {

                    if (clsValidation.IsValidEmail(txtEmail.Text + cbEmailProvider.Text))
                    {
                        _Person.Email = txtEmail.Text.Trim() + cbEmailProvider.Text;

                    }
                }
                if (!clsValidation.IsValid(_Person))
                {
                    return;
                }
                if (await _Person.SaveAsync())
                {
                    _Mode = enMode.eUpdatePerson;
                    PersonID = _Person.PersonID;
                    NewPersonAdded(_Person.PersonID);
                    DataBack?.Invoke(this, _Person.PersonID);
                }
                else
                {
                        NewPersonNotAdded();
                }


            }
            



        }

  
        public async Task<bool> LoadPersonInfoToControl(int PersonId)
        {
            _Mode = enMode.eUpdatePerson;
            _Person = await clsPerson.FindAsync(PersonId);

            if (_Person == null)
            {
                //MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    NoPersonFound();
                return false;
            }
                PersonFound();
            if(cbCountry.Items.Count == 0)
            {
               await _FillCountriesInComoboBox();

            }

                _PersonID = PersonId;
            txtNationalNo.Text = _Person.NationalNo;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtPhone.Text = _Person.Phone;
            int @Index = _Person.Email.IndexOf("@");
            string EmailProvider = _Person.Email.Substring(@Index, _Person.Email.Length - @Index);
            string EmailTitle = _Person.Email.Substring(0, @Index);
            if (_Person.Email.Contains("@") || _Person.Email.Contains(".") || _IsEmailProviderExistInComboBox(EmailProvider))
            {
                chkbCustomEmail.Checked = true;
                txtEmail.Text = _Person.Email;

            }
            else
            {
                txtEmail.Text = EmailTitle;
                cbEmailProvider.SelectedItem = cbEmailProvider.FindStringExact(EmailProvider);
            }
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            cbCountry.SelectedItem = cbCountry.FindString( _Person.CountryInfo.CountryName);
            cbCountry.Text = _Person.CountryInfo.CountryName;

            if (_Person.Gender == clsPerson.enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                if (File.Exists(_Person.ImagePath))
                {
                    _ImagePath = _Person.ImagePath;
                    pbPersonImage.Load(_ImagePath);

                }
                else
                {
                    if (_Person.Gender == clsPerson.enGender.Male)
                        pbPersonImage.Image = Resources.little_boy;
                    else
                        pbPersonImage.Image = Resources.little_female;

                }

            }

            //hide/show the remove linke incase there is no image for the person.
            btnRemoveImage.Visible = (_Person.ImagePath != "");


            return true;
            



        }





        private void ctrlEditPersonInfo_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (chkbCustomEmail.Checked)
            {
                cbEmailProvider.Enabled = false;
            }
            else
            {
                cbEmailProvider.Enabled = true;
            }
        }







        private void ValidateEmptyTextBox(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                ErrorProvider1.SetError(Temp, null);
            }

        }


        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            clsUtil.AllowOnlyNumberAndControlsToPress(sender,e);

        }

        private async Task txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                ErrorProvider1.SetError(txtNationalNo, null);
            }

            //Make sure the national number is not used by another person
            if (txtNationalNo.Text.Trim() != _Person.NationalNo && await clsPerson.IsPersonExistAsync(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }
            else
            {
                ErrorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidation.IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                ErrorProvider1.SetError(txtEmail, null);
            }
            ;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                _ImagePath=openFileDialog1.FileName;
                pbPersonImage.Load(_ImagePath);
                btnRemoveImage.Visible = true;
                // ...
            }
        }

        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.little_boy;
            else
                pbPersonImage.Image = Resources.little_female;

            btnRemoveImage.Visible = false;
        }

        private void _WhenObjectNotValid(object sender, clsValidationErrorEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Email":
                    txtEmail.BorderColor = Color.Red;
                    ErrorProvider1.SetError(txtEmail, e.ErrorMessage);
                    break;

                case "Phone":
                    txtPhone.BorderColor = Color.Red;
                    ErrorProvider1.SetError(txtPhone, e.ErrorMessage);
                    break;

                case "FirstName":
                    txtFirstName.BorderColor = Color.Red;
                    ErrorProvider1.SetError(txtFirstName, e.ErrorMessage);
                    break;

                case "LastName":
                    txtLastName.BorderColor = Color.Red;
                    ErrorProvider1.SetError(txtLastName, e.ErrorMessage);
                    break;

                case "DateOfBirth":
                    dtpDateOfBirth.BorderColor = Color.Red;
                    ErrorProvider1.SetError(dtpDateOfBirth, e.ErrorMessage);
                    break;
                case "NationalNo":
                    txtNationalNo.BorderColor = Color.Red;
                    ErrorProvider1.SetError(txtNationalNo, e.ErrorMessage);
                    break;


            }
                PersonObjectNotValid(sender,e);

        }

        private async void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

           await _SavePersonInfoToDataBase();
        }

        private void chkbCustomEmail_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbCustomEmail.Checked)
            {
                cbEmailProvider.Enabled = false;

            }
            else
            {
                cbEmailProvider.Enabled = true;

            }
        }
        bool IsEmailCharacter(char character) => (character == '@' || character == '.');

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if(cbEmailProvider.Enabled==true)
            {

                if(txtEmail.Text.Contains("@") || txtEmail.Text.Contains("."))
                {
                    e.Cancel = true;
                    ErrorProvider1.SetError(txtEmail, "Invalid Email Address! Caracters ('@' or '.') not allowed when you set custom email desable ");
                }
                else
                {
                    ErrorProvider1.SetError(txtEmail, null);
                }
            }
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.BackgroundImage = Resources.little_boy;
            else
                pbPersonImage.BackgroundImage = Resources.little_female;

            btnRemoveImage.Visible = false;
        }


        private string _ImagePath = "";
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _ImagePath = openFileDialog1.FileName;

                pbPersonImage.Load(_ImagePath);

                btnRemoveImage.Visible = true;
            }
        }
        private void rbFemale_CheckedChanged_1(object sender, EventArgs e)
        {
            pbPersonImage.BackgroundImage=Resources.little_female;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.BackgroundImage = Resources.little_boy;

        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbPersonImage.Image = null;
            pbPersonImage.BackgroundImage = (rbMale.Checked) ? Resources.little_boy : Resources.little_female;  
        }
    }

}

