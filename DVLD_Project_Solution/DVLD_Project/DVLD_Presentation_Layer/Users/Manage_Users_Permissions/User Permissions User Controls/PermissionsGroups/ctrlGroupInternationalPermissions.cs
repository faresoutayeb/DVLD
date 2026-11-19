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
    public partial class ctrlGroupInternationalPermissions : UserControl
    {
        public ctrlGroupInternationalPermissions()
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
            private bool _manageInternationalLicenses;
            private bool _issueInternationalLicense;
            private bool _viewInternationalLicense;

            // Parameterized constructor
            public UserPermissions(
                bool manageInternationalLicenses,
                bool issueInternationalLicense,
                bool viewInternationalLicense)
            {
                _manageInternationalLicenses = manageInternationalLicenses;
                _issueInternationalLicense = issueInternationalLicense;
                _viewInternationalLicense = viewInternationalLicense;
            }

            // Public get-only properties
            public bool ManageInternationalLicenses
            {
                get { return _manageInternationalLicenses; }
            }

            public bool IssueInternationalLicense
            {
                get { return _issueInternationalLicense; }
            }

            public bool ViewInternationalLicense
            {
                get { return _viewInternationalLicense; }
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
            // International Licenses
            bool IsHasPermissionsForManageInternationalLicenses =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ManageInternationalLicenses);

            bool IsHasPermissionsForIssueInternationalLicense =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.IssueInternationalLicense);

            bool IsHasPermissionsForViewInternationalLicense =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ViewInternationalLicense);

            CurrentUserPermissions = new UserPermissions(
                IsHasPermissionsForManageInternationalLicenses,
                IsHasPermissionsForIssueInternationalLicense,
                IsHasPermissionsForViewInternationalLicense);

            SetLablesControlsValue(
                btnManageInternationalLicensesValue,
                IsHasPermissionsForManageInternationalLicenses);

            SetLablesControlsValue(
                btnIssueInternationalLicenseValue,
                IsHasPermissionsForIssueInternationalLicense);

            SetLablesControlsValue(
                btnViewInternationalLicenseValue,
                IsHasPermissionsForViewInternationalLicense);
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

            btnManageInternationalLicensesValue.Text = DefaultTextValue;
            btnIssueInternationalLicenseValue.Text = DefaultTextValue;
            btnViewInternationalLicenseValue.Text = DefaultTextValue;
        }
    }
}
