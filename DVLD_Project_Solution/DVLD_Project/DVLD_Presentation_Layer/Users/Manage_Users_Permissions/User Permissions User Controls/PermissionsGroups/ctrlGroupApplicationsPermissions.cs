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
    public partial class ctrlGroupApplicationsPermissions : UserControl
    {
        public ctrlGroupApplicationsPermissions()
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
            private bool _viewApplications;
            private bool _manageNewLocalDrivingLicenseApplications;
            private bool _editApplicationType;
            private bool _editApplicationTestType;
            private bool _deleteApplication;
            private bool _cancellApplication;

            // Parameterized constructor
            public UserPermissions(
                bool viewApplications,
                bool manageNewLocalDrivingLicenseApplications,
                bool editApplicationType,
                bool editApplicationTestType,
                bool deleteApplication,
                bool cancellApplication)
            {
                _viewApplications = viewApplications;
                _manageNewLocalDrivingLicenseApplications = manageNewLocalDrivingLicenseApplications;
                _editApplicationType = editApplicationType;
                _editApplicationTestType = editApplicationTestType;
                _deleteApplication = deleteApplication;
                _cancellApplication = cancellApplication;
            }

            // Public get-only properties
            public bool ViewApplications
            {
                get { return _viewApplications; }
            }

            public bool ManageNewLocalDrivingLicenseApplications
            {
                get { return _manageNewLocalDrivingLicenseApplications; }
            }

            public bool EditApplicationType
            {
                get { return _editApplicationType; }
            }

            public bool EditApplicationTestType
            {
                get { return _editApplicationTestType; }
            }

            public bool DeleteApplication
            {
                get { return _deleteApplication; }
            }

            public bool CancellApplication
            {
                get { return _cancellApplication; }
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
            // Applications
            bool IsHasPermissionsForViewApplications =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ViewApplications);

            bool IsHasPermissionsForManageNewLocalDrivingLicenseApplications =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ManageNewLocalDrivingLicenseApplications);

            bool IsHasPermissionsForEditApplicationType =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.EditApplicationType);

            bool IsHasPermissionsForEditApplicationTestType =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.EditApplicationTestType);

            bool IsHasPermissionsForDeleteApplication =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.DeleteApplication);

            bool IsHasPermissionsForCancellApplication =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.CancellApplication);

            CurrentUserPermissions = new UserPermissions(
                IsHasPermissionsForViewApplications,
                IsHasPermissionsForManageNewLocalDrivingLicenseApplications,
                IsHasPermissionsForEditApplicationType,
                IsHasPermissionsForEditApplicationTestType,
                IsHasPermissionsForDeleteApplication,
                IsHasPermissionsForCancellApplication);

            SetLablesControlsValue(
                btnViewApplicationsValue,
                IsHasPermissionsForViewApplications);

            SetLablesControlsValue(
                btnManageNewLocalDrivingLicenseApplicationsValue,
                IsHasPermissionsForManageNewLocalDrivingLicenseApplications);

            SetLablesControlsValue(
                btnEditApplicationTypeValue,
                IsHasPermissionsForEditApplicationType);

            SetLablesControlsValue(
                btnEditApplicationTestTypeValue,
                IsHasPermissionsForEditApplicationTestType);

            SetLablesControlsValue(
                btnDeleteApplicationValue,
                IsHasPermissionsForDeleteApplication);

            SetLablesControlsValue(
                btnCancelApplicationValue,
                IsHasPermissionsForCancellApplication);
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

            btnViewApplicationsValue.Text = DefaultTextValue;
            btnManageNewLocalDrivingLicenseApplicationsValue.Text = DefaultTextValue;
            btnEditApplicationTypeValue.Text = DefaultTextValue;
            btnEditApplicationTestTypeValue.Text = DefaultTextValue;
            btnDeleteApplicationValue.Text = DefaultTextValue;
            btnCancelApplicationValue.Text = DefaultTextValue;
        }

    }
}
