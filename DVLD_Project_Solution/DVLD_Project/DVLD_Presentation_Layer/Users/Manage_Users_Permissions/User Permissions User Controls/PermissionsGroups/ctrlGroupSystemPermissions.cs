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
    public partial class ctrlGroupSystemPermissions : UserControl
    {
        public ctrlGroupSystemPermissions()
        {
            InitializeComponent();
        }
        public event Action OnUserNotFound;

        protected virtual void UserNotFound()
        {
            OnUserNotFound?.Invoke();
        }

        public UserPermissions CurrentUserPermissions { get; private set; }

        public class UserPermissions
        {
            // Private variables
            private bool _manageApplicationTypes;
            private bool _manageTestTypes;
            private bool _viewDrivers;

            // Parameterized constructor
            public UserPermissions(
                bool manageApplicationTypes,
                bool manageTestTypes,
                bool viewDrivers)
            {
                _manageApplicationTypes = manageApplicationTypes;
                _manageTestTypes = manageTestTypes;
                _viewDrivers = viewDrivers;
            }

            // Public get-only properties
            public bool ManageApplicationTypes
            {
                get { return _manageApplicationTypes; }
            }

            public bool ManageTestTypes
            {
                get { return _manageTestTypes; }
            }

            public bool ViewDrivers
            {
                get { return _viewDrivers; }
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
            // Application Permissions
            bool IsHasPermissionsForManageApplicationTypes =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ManageApplicationTypes);

            bool IsHasPermissionsForManageTestTypes =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ManageTestTypes);

            bool IsHasPermissionsForViewDrivers =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ViewDrivers);

            CurrentUserPermissions = new UserPermissions(
                IsHasPermissionsForManageApplicationTypes,
                IsHasPermissionsForManageTestTypes,
                IsHasPermissionsForViewDrivers);

            SetLablesControlsValue(
                btnManageApplicationTypesValue,
                IsHasPermissionsForManageApplicationTypes);

            SetLablesControlsValue(
                btnManageTestTypesValue,
                IsHasPermissionsForManageTestTypes);

            SetLablesControlsValue(
                btnViewDriverValue,
                IsHasPermissionsForViewDrivers);
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
            // This method should run on the UI thread.
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

            // Update UI controls.
            SetLablesControls(CurrentUser);

            return Task.CompletedTask;
        }

        private void SetLablesControlsValue(
            Guna2GradientButton Button,
            bool HasPermission)
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

            btnManageApplicationTypesValue.Text = DefaultTextValue;
            btnManageTestTypesValue.Text = DefaultTextValue;
            btnViewDriverValue.Text = DefaultTextValue;
        }

    }
}
