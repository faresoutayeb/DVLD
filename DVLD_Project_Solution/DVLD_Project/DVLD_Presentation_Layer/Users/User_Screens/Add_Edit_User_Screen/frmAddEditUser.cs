using DVLD_Bussiness_Layer;
using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Bussiness_Layer.GlobalClasses;
using DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_Screens;
using DVLD_Presentation_Layer.Person.PersonControles;
using DVLD_Presentation_Layer.Users.UserControles;
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

namespace DVLD_Presentation_Layer.Users.User_Screens
{
    public partial class frmAddEditUser : Form
    {
        public frmAddEditUser()
        {

            InitializeComponent();
            _Mode=enMode.AddNewMode;
            btnBack.Visible = false;
            btnNext.Visible = false;
            tbctrlLoginInfo.Visible = false;
            clsValidation.OnValidationError += _WhenObjectNotValid;
        }

        public frmAddEditUser(int UserId)
        {

            InitializeComponent();

            _CurrentUserId=UserId;
            _Mode = enMode.UpdateMode;
            clsValidation.OnValidationError += _WhenObjectNotValid;


        }



        private int _CurrentUserId=-1;
        private clsUser _User;

        private enum enMode { AddNewMode, UpdateMode };
        private enMode _Mode = enMode.AddNewMode;

        public delegate void OnCloseScreenEventHandler();
        public event OnCloseScreenEventHandler OnScreenClosed;

        //--------------------------- local functions -----------------------
        private void _WhenObjectNotValid(object sender, clsValidationErrorEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "UserName":
                    txtbUserName.BorderColor = Color.Red;
                    errorProvider1.SetError(txtbUserName, e.ErrorMessage);
                    break;

                case "Password":
                    txtBPassword.BorderColor = Color.Red;
                    errorProvider1.SetError(txtBPassword, e.ErrorMessage);
                    break;

            }

        }


        private async Task _LoadDefaultInfo()
        {


                ctrlFilterPersonInformation1.EnableFilter = true;
                lblScreenMode.Text = "Add New User";
            txtbUserName.Text = "";
            txtBPassword.Text = "";
            txtBConfirmPassword.Text = "";
            chkIsActive.Checked = true;
            chkLockUser.Checked = false;
            lblCustomPermissions.Enabled= false;
                btnNext.Visible = false;
                _User = new clsUser();
               await FillRolesCombobox();
            

        }

        private async Task _LoadExistingInfo(int UserID)
        {

            if (this._Mode == enMode.UpdateMode)
            {
                _User = await clsUser.FindByUserIDAsync(UserID);
                if (_User != null)
                {

                    lblScreenMode.Text = "Update User Info";
                    ctrlFilterPersonInformation1.EnableFilter = true;

                    ctrlFilterPersonInformation1.txtbFilter.Text= _User.PersonInfo.PersonID.ToString();
                    ctrlFilterPersonInformation1.btnSearch.PerformClick();

                    txtbUserName.Text = _User.UserName;
                    txtBPassword.Text = _User.Password;
                    txtBConfirmPassword.Text = _User.Password;
                    chkIsActive.Checked = (_User.IsActive);
                    chkLockUser.Checked = (_User.IsLock);
                    lblCustomPermissions.Enabled = true; 


                }


            }

        }


        private async Task FillRolesCombobox()
        {

            DataTable Roles=await clsRole.GetAllRolesAsync();
            for(int i = 0; i<=Roles.Rows.Count-1;i++)
            {
                cbRoles.Items.Add(Roles.Rows[i][1]);

            }


        }



        private async Task PerformLockingInLockingUser()
        {
            if (chkLockUser.Checked)
            {
                int LockingID =await _User.LockAsync();
                if (LockingID != -1)
                {

                    _WhenUserLocked(LockingID, _User.UserID);
                }
                else
                {
                    _WhenUserNotLocked(_User.UserID);
                }

            }
            else
            {
                if (_User.IsLock)
                {
                    if (await _User.UnlockAsync())
                    { 
                        _WhenUserUnLocked(_User.UserID);
                    }
                    else
                    {
                        _WhenUserNotLocked(_User.UserID);
                    }


                }

            }


        }




        private void ctrlFilterPersonInformation1_OnPersonWeSearchForFound()
        {
            btnSave.Visible = true;
            tbctrlLoginInfo.Visible = true; 
            btnNext.Visible = true;
   
        }

        private void ctrlFilterPersonInformation1_OnPersonWeSearchForNotFound()
        {
            btnSave.Visible = false;
            btnNext.Visible = false;
            _WhenPersonNotFound();

            ctrlFilterPersonInformation1.FocusOnFilterTextBox();
        }

        private async Task _FillControlInfo()
        {
            if (_User != null)
            {

                _CurrentUserId = _User.UserID;
                tbctrlLoginInfo.Visible = true;
                btnNext.Visible = true;

                txtbUserName.Text = _User.UserName;
                txtBPassword.PasswordChar = '*';
                txtBConfirmPassword.PasswordChar = '*';
                txtBPassword.Text = _User.Password;
                txtBConfirmPassword.Text = _User.Password;
                chkIsActive.Checked = (_User.IsActive);
                chkLockUser.Checked = (_User.IsLock);
                lblCustomPermissions.Enabled = true;
                clsRole role = await clsRole.FindAsync(_User.RoleID);
                if(role !=null)
                {         
                    cbRoles.SelectedIndex = cbRoles.FindString( role.RoleName);


                }

            }
            else
            {
                tbctrlLoginInfo.Visible = false;

                btnNext.Visible = false;
                ctrlFilterPersonInformation1.FocusOnFilterTextBox();
            }

        }

        private async void ctrlFilterPersonInformation1_OnPersonSelectedByPersonID(int PersonID)
        {

            _User = await clsUser.FindByPersonIDAsync(PersonID);
            if(_User != null)
            {
                _CurrentUserId = _User.PersonID;

               await _FillControlInfo();
                btnNext.Visible = true;
                tbctrlLoginInfo.Visible = true;
                lblCustomPermissions.Enabled=true;  
                return;
            }
            _User = new clsUser();

        }

        private async void ctrlFilterPersonInformation1_OnPersonSelectedByNationalNo(string NationalNo)
        {

            _User = await clsUser.FindByNationalNoAsync(NationalNo);
            if (_User != null)
            { 
                 _CurrentUserId = _User.PersonID;

                await  _FillControlInfo();
                btnNext.Visible = true;
                tbctrlLoginInfo.Visible = true;
                lblCustomPermissions.Enabled = true;

                return;
            }
            _User = new clsUser();



        }

        // ---------------------------- Controls Events -------------------------
        private void btnNextToLoginInfo_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tbctrlLoginInfo;
            btnNext.Visible = false;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty( txtBPassword.Text.Trim()) || string.IsNullOrEmpty(txtBConfirmPassword.Text.Trim()) || string.IsNullOrEmpty(txtbUserName.Text.Trim()))
            {
                MessageBox.Show("Some field connot be empty");
                return;
            }
            if (this.ValidateChildren())
            {

                int SelectedUserRoleID=-1;
                clsRole SelectedUserRoleTask =await clsRole.FindAsync(cbRoles.SelectedIndex);

                if(SelectedUserRoleTask != null)
                {
                 
                        SelectedUserRoleID = SelectedUserRoleTask.RoleID;

                    

                }
                if (this._Mode == enMode.AddNewMode)
                {
                    _User = new clsUser();

                    string EntredUserName = txtbUserName.Text.Trim();

                    if (await clsUser.IsUserNameAlreadyTakenAsync(EntredUserName))
                    {

                        if (MessageBox.Show("User Name Already Taken", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            txtbUserName.Focus();
                        }
                        return;
                    }


                    _User.RoleID = SelectedUserRoleID;
                    _User.UserName = EntredUserName;
                    _User.Password = txtBConfirmPassword.Text.Trim();
                    _User.IsActive = (chkIsActive.Checked) ? true : false;

                    _User.PersonID = ctrlFilterPersonInformation1.PersonId;
                    if(!clsValidation.IsValid(_User))
                    {
                        //MessageBox.Show("User object is not valid ");
                        return;
                    }
                    if (await _User.SaveAsync())
                    {

                        lblUserIdValue.Text = _User.UserID.ToString();
                        this.Text = "Update User Info";
                        _Mode = enMode.UpdateMode;

                        _WhenNewUserAdded(_User.UserID);
                        await PerformLockingInLockingUser();
                    }
                    else
                    {

                        _WhenNewUserNotAdded();


                    }
                }
                else
                {
                    string EntredUserName=  txtbUserName.Text.Trim();
                    
                    if (_User.UserName!= EntredUserName && await clsUser.IsUserNameAlreadyTakenAsync(EntredUserName))
                    {

                        if(MessageBox.Show("User Name Already Taken","Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            txtbUserName.Focus();
                        }
                            return;
                    }
                        _User.IsActive = (chkIsActive.Checked) ? true : false;

                    if (clsGlobalUserInfo.CurrentLogInUser.UserID == _User.UserID)
                    {
                        clsGlobalUserInfo.CurrentLogInUser = _User;
                    }
                    if (SelectedUserRoleID != _User.RoleID)
                    {
                        _User.RemoveCurrentRolePermissionsNumberFromPermissions();


                    }
                    _User.RoleID = SelectedUserRoleID;

                    if ( await _User.SaveAsync())
                    {

                        _WhenUserInfoUpdated(_User.UserID);
                       await PerformLockingInLockingUser();
                    }
                    else
                        _WhenUserInfoNotUpdated();

                }


            }
        }

        private async void Add_EditUserScreen_Load(object sender, EventArgs e)
        {
            await _LoadDefaultInfo();
            if (_Mode==enMode.UpdateMode)
            {
              await  _LoadExistingInfo(_CurrentUserId);
                  btnNext.Visible = true;
                tbctrlLoginInfo.Visible = true;


            }
            btnBack.Visible = false;

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

            if(!clsGlobalUserInfo.CurrentLogInUser.IsAdmin())
            {
                clsGlobal.ShowAccessDeniedScreen();
                return;
            }
            frmAddEditUserPermissions addEditUserPermissionsScreen = new frmAddEditUserPermissions(_User.UserID);
            addEditUserPermissionsScreen.ShowDialog();




        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if(chkLockUser.Checked)
            {
                chkLockUser.Text = "Unlock User";
            }
            else
            {
                chkLockUser.Text = "lock User";

            }

        }




        private void txtBPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtBPassword.Text.Trim().Length < 6)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBPassword, "This Field should has 6 characters minimaum allowed");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBPassword, null);
            }
        }

        private void txtBConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtBPassword.Text.Trim()!=txtBConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBConfirmPassword, "The 2 passwords not the same");

            }
            else
            {
                errorProvider1.SetError(txtBConfirmPassword, null);

            }
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(tabControl1.SelectedIndex==1)
            {
                btnBack.Visible = true;
                btnNext.Visible = false;
            }
            else
            {
                btnBack.Visible = false;
                btnNext.Visible = true;
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tbctrlPersonalInfo;
            btnBack.Visible=false;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tbctrlPersonalInfo;
            btnBack.Visible = false;
        }
    }
}
