using DVLD_Bussiness_Layer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;
using DVLD.Classes;

namespace DVLD_Presentation_Layer
{
    public partial class frmDVLD_Login_Screen : Form
    {
        public frmDVLD_Login_Screen()
        {
            InitializeComponent();
            InitilizeLocalEvents();
        }

        public event Action OnWrongLoginCredential;
        private void WrongLoginCredential()
        {
            OnWrongLoginCredential?.Invoke();
        }
        public event Action OnNotActiveUser;
        private void _NotActiveUser()
        {
            OnNotActiveUser?.Invoke();
        }
        public event Action OnValidationError;
        private void ValidationError()
        {
            OnValidationError?.Invoke();
        }

        public event Action OnUserAccountLocked;
        private void UserAccountLocked()
        {
            OnUserAccountLocked?.Invoke();
        }
        private void InitilizeLocalEvents()
        {
            OnWrongLoginCredential += _WhenWrongLoginCredential;
            OnNotActiveUser += _WhenNotActiveUser;
            OnValidationError += _WhenValidationError;
            OnUserAccountLocked += _WhenUserAccountLocked;
            clsSecurity.OnIssueGettingStoredCredentials += _WhenIssueGettingStoredCredentials;
            clsSecurity.OnRememberMeIssue += _WhenRememberStoredCredentialsIssue;
        }

        private void _WhenIssueGettingStoredCredentials(string ErroMessage)
        {
            MessageBox.Show( ErroMessage, "Issue Getting Stored Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _WhenRememberStoredCredentialsIssue(string ErroMessage)
        {
            MessageBox.Show(ErroMessage, "Issue Remembering Login Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _WhenValidationError()
        {
            MessageBox.Show("Error Some field not valid put the mouse on the red icons to see the error", "Validation Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
        }
        private void _WhenUserAccountLocked()
        {
            MessageBox.Show("User Account Locked call the admin to unlock your account", "Account Locked", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        private void _WhenWrongLoginCredential()
        {
            if(MessageBox.Show("Invalid UserName/Password","Wrong Login Credential", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)==DialogResult.Retry)
            {
                txtbUserName.Text = "";
                txtbPassword.Text = "";
                txtbUserName.Focus();

            }
        }

        private void _WhenNotActiveUser()
        {
            MessageBox.Show("User Not Active", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
        }



        private void DVLD_Login_Screen_Load(object sender, EventArgs e)
        {
            var credentials = clsSecurity.GetStoredCredentialFromRegistryWindowsCredentialManager();
            if (credentials.Username != "" && credentials.Password != "")
            {
                txtbUserName.Text = credentials.Username;
                txtbPassword.Text = credentials.Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }



        public clsUserLog UserLog {  get; set; }
        
        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
    
                    ValidationError();
                    return;
                
            }



            clsUser User =  clsUser.FindByUserNameAndPassword( txtbUserName.Text.Trim(),txtbPassword.Text.Trim());
            if(User == null)
            {
                WrongLoginCredential();
                return;
            }
            else
            {

                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsSecurity.RememberUsernameAndPasswordInWindowsCredentialManager(txtbUserName.Text.Trim(), txtbPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    clsSecurity.RememberUsernameAndPasswordInWindowsCredentialManager("","");

                }


                if (!User.IsActive)
                 {
                
                     _NotActiveUser();

                    
                    return;
                }

                if(!User.IsLock)
                {
                    _WhenUserAccountLocked();
                    return;
                }

                 clsGlobalUserInfo.CurrentLogInUser= User;
                UserLog=new clsUserLog();
                UserLog.UserID= clsGlobalUserInfo.CurrentLogInUser.UserID;
                UserLog.LoginDateTime = DateTime.Now;
                if(!await UserLog.SaveAsync())
                {    
                    MessageBox.Show("User Log Not Saved ");

                    return;
                }


                frmMainDVLDMenuScreen MainMenu=new frmMainDVLDMenuScreen(this);
                this.Hide();
                MainMenu.ShowDialog();


            }




        }

        private void txtbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(txtbUserName.Text.Trim()=="")
            {
                e.Cancel = true;    
                ErrorPLoginScreen.SetError(txtbUserName, "Field Cannot Be Empty");
            }
            else
            {
                ErrorPLoginScreen.SetError(txtbUserName, "");

            }
        }

        private void txtbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtbPassword.Text.Trim() == "" )
            {
                e.Cancel = true;
                ErrorPLoginScreen.SetError(txtbPassword, "Field Cannot Be Empty");
            }
            else
            {
                ErrorPLoginScreen.SetError(txtbPassword, "");

            }

        }

        private void txtbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShowHide2_Click(object sender, EventArgs e)
        {
            if (btnShowHide2.Text == "Show")
            {
                txtbPassword.PasswordChar = '\0'; // Show password
                btnShowHide2.Text = "Hide";

            }
            else
            {
                txtbPassword.PasswordChar = '*';  // Hide password            }
                btnShowHide2.Text = "Show";

            }
        }
    }
}
