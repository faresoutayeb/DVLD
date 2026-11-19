using DVLD_Bussiness_Layer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Users.UserScreens
{
    public partial class frmChangePassword : Form
    {


        public frmChangePassword(int UserID)
        {

            InitializeComponent();
            this._UserID=UserID;
        }
        //------------------------------ Local Varibles Definitions ---------------------------------

        private clsUser _CurrentUser;
        private int _UserID;





        //------------------------------ Local Functions ---------------------------------

        private void _ResetDefualtValues()
        {
            txtbCurrentPassword.Text = "";
            txtbNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void _WhenPasswordUpdated()
        {
            MessageBox.Show("Password Updated Successfully ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _WhenPasswordNotUpdated()
        {
            if(MessageBox.Show("Password Not Updated", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)== DialogResult.Retry)
            {
                txtConfirmPassword.Focus();
            }
            
        }

        private void _WhenValidationIssue()
        {
            MessageBox.Show("Some field not valid put the mouse on the red icon next to the control", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _InitilizeLocalEvents()
        {

            //OnPasswordUpdated += _WhenPasswordUpdated;
            //OnPasswordNotUpdated += _WhenPasswordNotUpdated;
            //OnValidationIssue += _WhenValidationIssue;
        }


        //------------------------------ Local Controls Events ---------------------------------


        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty( txtbCurrentPassword.Text.Trim()))
            {
                e.Cancel = false;
                return;
            }
            
            if (txtbNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim() )
            {         
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, "Password Confirmation does not match New Password!");

            }
            else
            {
                errorProvider.SetError(txtConfirmPassword, "");

            }
        }

 

        private void txtbNewPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtbCurrentPassword.Text.Trim()))
            {
                e.Cancel = false;
                return;
            }
            if ( txtbNewPassword.Text.Trim().Length<6)
            {
                e.Cancel = true;
                errorProvider.SetError(txtbNewPassword, "This Field should has 6 characters minimaum allowed");
                return;
            }
            else
            {
                errorProvider.SetError(txtbNewPassword, "");
            }

            if( clsSecurity.ComputeHash (txtbNewPassword.Text.Trim())== _CurrentUser.Password)
            {
                e.Cancel = true;
                errorProvider.SetError(txtbNewPassword, "Password is the same as previous choose another one");
            }
            else
            {
                errorProvider.SetError(txtbNewPassword, "");
            }
        }

        private async void btnSaveNewPassword_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty( txtbCurrentPassword.Text.Trim()) || string.IsNullOrEmpty(txtbNewPassword.Text.Trim()) || string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                MessageBox.Show("some fields are empty","Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                    return;
            }
                
            if (this.ValidateChildren())
            {
                _CurrentUser.Password =  txtConfirmPassword.Text;

                if (await _CurrentUser.ChangePasswordAsync(_CurrentUser.Password))
                {
                   
                    _WhenPasswordUpdated();

                    
                    return;
                }
                else
                {
                    _WhenPasswordNotUpdated();

                    return;
                }

            }
            else
            {
      
                _WhenValidationIssue();
                

                return;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.BorderColor = (txtbNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim()) ? Color.Red : Color.Green;

        }

        private async void ChangePasswordScreen_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _CurrentUser =await clsUser.FindByUserIDAsync(_UserID);

            if (_CurrentUser == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }
           await ctrlSmallUserInfoCard1.LoadInfo(_UserID);
            txtbCurrentPassword.PasswordChar = '*';
            txtbNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (btnShowHide1.Text == "Show")
            {
                txtbCurrentPassword.PasswordChar = '\0'; // Show password

            }
            else
            {
                txtbCurrentPassword.PasswordChar = '*';  // Hide password            }

            }
        }

        private void btnShowHide2_Click(object sender, EventArgs e)
        {
            if (btnShowHide2.Text == "Show")
            {
                txtbNewPassword.PasswordChar = '\0'; // Show password

            }
            else
            {
                txtbNewPassword.PasswordChar = '*';  // Hide password            }

            }
        }

        private void btnShowHide3_Click(object sender, EventArgs e)
        {
            if (btnShowHide3.Text == "Show")
            {
                txtConfirmPassword.PasswordChar = '\0'; // Show password

            }
            else
            {
                txtConfirmPassword.PasswordChar = '*';  // Hide password            }

            }
        }



        private void txtbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbCurrentPassword.Text.Trim()))
            {
                e.Cancel = false;
                return;
            }

            if (clsSecurity.ComputeHash(txtbCurrentPassword.Text.Trim()) != _CurrentUser.Password)
            {
                e.Cancel = true;
                errorProvider.SetError(txtbCurrentPassword, "Current password is not correct");
            }
            else
            {
                errorProvider.SetError(txtbCurrentPassword, "");
            }
        }

    }
}
