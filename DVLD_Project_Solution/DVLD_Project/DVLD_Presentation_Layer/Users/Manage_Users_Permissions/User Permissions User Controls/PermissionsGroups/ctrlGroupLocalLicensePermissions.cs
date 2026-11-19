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
    public partial class ctrlGroupLocalLicensePermissions : UserControl
    {
        public ctrlGroupLocalLicensePermissions()
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
            private bool _manageLocalLicenses;
            private bool _issueNewDrivingLicense;
            private bool _renewLicense;
            private bool _replaceDamagedOrLostLicense;
            private bool _viewLocalLicense;
            private bool _viewLicenseHistory;

            // Parameterized constructor
            public UserPermissions(
                bool manageLocalLicenses,
                bool issueNewDrivingLicense,
                bool renewLicense,
                bool replaceDamagedOrLostLicense,
                bool viewLocalLicense,
                bool viewLicenseHistory)
            {
                _manageLocalLicenses = manageLocalLicenses;
                _issueNewDrivingLicense = issueNewDrivingLicense;
                _renewLicense = renewLicense;
                _replaceDamagedOrLostLicense = replaceDamagedOrLostLicense;
                _viewLocalLicense = viewLocalLicense;
                _viewLicenseHistory = viewLicenseHistory;
            }

            // Public get-only properties
            public bool ManageLocalLicenses
            {
                get { return _manageLocalLicenses; }
            }

            public bool IssueNewDrivingLicense
            {
                get { return _issueNewDrivingLicense; }
            }

            public bool RenewLicense
            {
                get { return _renewLicense; }
            }

            public bool ReplaceDamagedOrLostLicense
            {
                get { return _replaceDamagedOrLostLicense; }
            }

            public bool ViewLocalLicense
            {
                get { return _viewLocalLicense; }
            }

            public bool ViewLicenseHistory
            {
                get { return _viewLicenseHistory; }
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
            // Local Licenses
            bool IsHasPermissionsForManageLocalLicenses =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ManageLocalLicenses);

            bool IsHasPermissionsForIssueNewDrivingLicense =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.IssueNewDrivingLicense);

            bool IsHasPermissionsForRenewLicense =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.RenewLicense);

            bool IsHasPermissionsForReplaceDamagedOrLostLicense =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ReplaceDamagedOrLostLicense);

            bool IsHasPermissionsForViewLocalLicense =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ViewLocalLicense);

            bool IsHasPermissionsForViewLicenseHistory =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ViewLicenseHistory);

            CurrentUserPermissions = new UserPermissions(
                IsHasPermissionsForManageLocalLicenses,
                IsHasPermissionsForIssueNewDrivingLicense,
                IsHasPermissionsForRenewLicense,
                IsHasPermissionsForReplaceDamagedOrLostLicense,
                IsHasPermissionsForViewLocalLicense,
                IsHasPermissionsForViewLicenseHistory);

            SetLablesControlsValue(
                btnManageLocalLicensesValue,
                IsHasPermissionsForManageLocalLicenses);

            SetLablesControlsValue(
                btnIssueFirstLicenseValue,
                IsHasPermissionsForIssueNewDrivingLicense);

            SetLablesControlsValue(
                btnRenewLicenseValue,
                IsHasPermissionsForRenewLicense);

            SetLablesControlsValue(
                btnReplaceDamagedOrLostLicenseValue,
                IsHasPermissionsForReplaceDamagedOrLostLicense);

            SetLablesControlsValue(
                btnViewLocalLicenseValue,
                IsHasPermissionsForViewLocalLicense);

            SetLablesControlsValue(
                btnViewLicenseHistoryValue,
                IsHasPermissionsForViewLicenseHistory);
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

            btnManageLocalLicensesValue.Text = DefaultTextValue;
            btnIssueFirstLicenseValue.Text = DefaultTextValue;
            btnRenewLicenseValue.Text = DefaultTextValue;
            btnReplaceDamagedOrLostLicenseValue.Text = DefaultTextValue;
            btnViewLocalLicenseValue.Text = DefaultTextValue;
            btnViewLicenseHistoryValue.Text = DefaultTextValue;
        }
    }
}
