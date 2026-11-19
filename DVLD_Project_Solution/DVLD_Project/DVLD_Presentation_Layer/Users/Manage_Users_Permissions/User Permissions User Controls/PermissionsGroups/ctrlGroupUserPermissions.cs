using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Users.Manage_Users_Permissions.User_Permissions_User_Controls.PermissionsGroups
{
    public partial class ctrlGroupUserPermissions : UserControl
    {
        public ctrlGroupUserPermissions()
        {
            InitializeComponent();
        }

        public event Action OnUserNotFound;

        protected virtual void UserNotFound()
        {
            OnUserNotFound?.Invoke();
        }
        public UserPermissions CurrentUserPermissions {  get;private set; }
        public class UserPermissions
        {
            // Private variables
            private bool _manageUsers;
            private bool _addEditUser;
            private bool _editUserPassword;
            private bool _deleteUser;

            // Parameterized constructor
            public UserPermissions(bool manageUsers, bool addEditUser, bool editUserPassword, bool deleteUser)
            {
                _manageUsers = manageUsers;
                _addEditUser = addEditUser;
                _editUserPassword = editUserPassword;
                _deleteUser = deleteUser;
            }

            // Public get-only properties
            public bool ManageUsers
            {
                get { return _manageUsers; }
            }

            public bool AddEditUser
            {
                get { return _addEditUser; }
            }

            public bool EditUserPassword
            {
                get { return _editUserPassword; }
            }

            public bool DeleteUser
            {
                get { return _deleteUser; }
            }
        }

        private clsUser _CurrentUser;
        public clsUser CurrentUser
        {
            get => _CurrentUser;
        }

        public void LoadCurrentLogedUserPermissions()
        {
            SetLablesControls(clsGlobalUserInfo.CurrentLogInUser);

        }

        private void SetLablesControls(clsUser CurrentUser)
        {


            // Users

            bool IsHasPermissionsForManageUsers = CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageUsers);
            bool IsHasPermissionsForAddEditUser = CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditUser);
            bool IsHasPermissionsForEditUserPassword = CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageUsers);
            bool IsHasPermissionsForDeleteUser = CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageUsers);

            CurrentUserPermissions = new UserPermissions(IsHasPermissionsForManageUsers, IsHasPermissionsForAddEditUser, IsHasPermissionsForEditUserPassword, IsHasPermissionsForDeleteUser);

            SetLablesControlsValue(btnManageUsersValue, IsHasPermissionsForManageUsers);
            SetLablesControlsValue(btnAddEditUserValue, IsHasPermissionsForAddEditUser);
            SetLablesControlsValue(btnEditUserPasswordValue, IsHasPermissionsForEditUserPassword);
            SetLablesControlsValue(btnDeleteUserValue, IsHasPermissionsForDeleteUser);

    


        }

        public async Task LoadUserPermissions(int userID)
        {
            _CurrentUser = await clsUser.FindByUserIDAsync(userID);

            await ApplyUserPermissionsAsync();
        }

        public async Task LoadUserPermissions(string userName)
        {
            _CurrentUser = await clsUser.FindByUserNameAsync(userName);

            await ApplyUserPermissionsAsync();
        }
        public async Task LoadUserPermissions(clsUser user)
        {
            _CurrentUser = user;

            await ApplyUserPermissionsAsync();
        }


        private Task ApplyUserPermissionsAsync()
        {
            // هذه الدالة يجب أن تعمل على UI Thread.
            if (IsDisposed || Disposing)
                return Task.CompletedTask;

            if (!clsUtil.IsObjectFull(CurrentUser))
            {
                LoadDefaultInfoToControls();
                UserNotFound();
                return Task.CompletedTask;
            }

            if (!clsUtil.IsObjectFull(CurrentUser.UserPermissionsInfo))
            {
                LoadDefaultInfoToControls();
                return Task.CompletedTask;
            }
            // تحديث عناصر الواجهة مباشرة على UI Thread.
            SetLablesControls(CurrentUser);

            return Task.CompletedTask;
        }


        private void SetLablesControlsValue(Guna2GradientButton Button, bool HasPermission)
        {
            if (HasPermission)
            {
                Button.Text = "Has";
                Button.Image = Resources.cocher;
                Button.ForeColor = Color.Green;
                Button.FillColor = Color.Green;
                Button.FillColor2 = Color.DarkGreen;
                Button.ForeColor = Color.White;

            }
            else
            {
                Button.Text = "No";
                Button.Image = Resources.close;

                Button.ForeColor = Color.Red;
                Button.FillColor = Color.OrangeRed;
                Button.FillColor2 = Color.Red;
                Button.ForeColor = Color.White;

            }


        }



        private void LoadDefaultInfoToControls()
        {
            string DefaultTextValue = "";

            btnManageUsersValue.Text = DefaultTextValue;
            btnAddEditUserValue.Text = DefaultTextValue;
            btnEditUserPasswordValue.Text = DefaultTextValue;
            btnDeleteUserText.Text = DefaultTextValue;




        }


    }
}
