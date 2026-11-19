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
    public partial class ctrlGroupPeoplePermissions : UserControl
    {
        public ctrlGroupPeoplePermissions()
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
            private bool _managePeople;
            private bool _addEditPerson;
            private bool _deletePerson;

            // Parameterized constructor
            public UserPermissions(
                bool managePeople,
                bool addEditPerson,
                bool deletePerson)
            {
                _managePeople = managePeople;
                _addEditPerson = addEditPerson;
                _deletePerson = deletePerson;
            }

            // Public get-only properties
            public bool ManagePeople
            {
                get { return _managePeople; }
            }

            public bool AddEditPerson
            {
                get { return _addEditPerson; }
            }

            public bool DeletePerson
            {
                get { return _deletePerson; }
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
            // People
            bool IsHasPermissionsForManagePeople =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.ManagePeople);

            bool IsHasPermissionsForAddEditPerson =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.AddEditPerson);

            bool IsHasPermissionsForDeletePerson =
                CurrentUser.UserPermissionsInfo.HasPermissionFor(
                    clsUserPermissions.enPermissions.DeletePerson);

            CurrentUserPermissions = new UserPermissions(
                IsHasPermissionsForManagePeople,
                IsHasPermissionsForAddEditPerson,
                IsHasPermissionsForDeletePerson);

            SetLablesControlsValue(
                btnManagePeopleValue,
                IsHasPermissionsForManagePeople);

            SetLablesControlsValue(
                btnAddEditPersonValue,
                IsHasPermissionsForAddEditPerson);

            SetLablesControlsValue(
                btnDeletePersonValue,
                IsHasPermissionsForDeletePerson);
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

            btnManagePeopleValue.Text = DefaultTextValue;
            btnAddEditPersonValue.Text = DefaultTextValue;
            btnDeletePersonValue.Text = DefaultTextValue;
        }
    }
}
