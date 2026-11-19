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
    public partial class ctrlGroupDetainReleaseLicensePermisisons : UserControl
    {
        public ctrlGroupDetainReleaseLicensePermisisons()
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
            private bool _manageDetainLicenseScreen;
            private bool _detainLicense;
            private bool _releaseLicense;
            private bool _viewDetainedLicenses;

            // Parameterized constructor
            public UserPermissions(
                bool manageDetainLicenseScreen,
                bool detainLicense,
                bool releaseLicense,
                bool viewDetainedLicenses)
            {
                _manageDetainLicenseScreen = manageDetainLicenseScreen;
                _detainLicense = detainLicense;
                _releaseLicense = releaseLicense;
                _viewDetainedLicenses = viewDetainedLicenses;
            }

            // Public get-only properties
            public bool ManageDetainLicenseScreen
            {
                get { return _manageDetainLicenseScreen; }
            }

            public bool DetainLicense
            {
                get { return _detainLicense; }
            }

            public bool ReleaseLicense
            {
                get { return _releaseLicense; }
            }

            public bool ViewDetainedLicenses
            {
                get { return _viewDetainedLicenses; }
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
            // Detained Licenses
            bool IsHasPermissionsForManageDetainLicenseScreen =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ManageDetainLicenseScreen);

            bool IsHasPermissionsForDetainLicense =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.DetainLicense);

            bool IsHasPermissionsForReleaseLicense =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ReleaseLicense);

            bool IsHasPermissionsForViewDetainedLicenses =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ViewDetainedLicenses);

            CurrentUserPermissions = new UserPermissions(
                IsHasPermissionsForManageDetainLicenseScreen,
                IsHasPermissionsForDetainLicense,
                IsHasPermissionsForReleaseLicense,
                IsHasPermissionsForViewDetainedLicenses);

            SetLablesControlsValue(
                btnManageDetainLicenseScreenValue,
                IsHasPermissionsForManageDetainLicenseScreen);

            SetLablesControlsValue(
                btnDetainLicenseValue,
                IsHasPermissionsForDetainLicense);

            SetLablesControlsValue(
                btnReleaseLicenseValue,
                IsHasPermissionsForReleaseLicense);

            SetLablesControlsValue(
                btnViewDetainedLicensesValue,
                IsHasPermissionsForViewDetainedLicenses);
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

            btnManageDetainLicenseScreenValue.Text = DefaultTextValue;
            btnDetainLicenseValue.Text = DefaultTextValue;
            btnReleaseLicenseValue.Text = DefaultTextValue;
            btnViewDetainedLicensesValue.Text = DefaultTextValue;
        }
    }
}
