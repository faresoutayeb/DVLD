using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Users.Manage_Users_Permissions.User_Permissions_User_Controls
{
    public partial class ctrlUserPermissionsCard : UserControl
    {
        public ctrlUserPermissionsCard()
        {
            InitializeComponent();
        }

        public event Action OnUserNotFound;

        protected virtual void UserNotFound()
        {
            OnUserNotFound?.Invoke();
        }

        private clsUser _CurrentUser;
        public clsUser CurrentUser
        {
            get => _CurrentUser;
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

        private  Task ApplyUserPermissionsAsync()
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

            lblUserID.Text = CurrentUser.UserID.ToString();
            lblUserName.Text = CurrentUser.UserName;
            lblUserRole.Text = CurrentUser.RoleInfo.RoleName;
            //we going to to load all the permisison controls here 
            LoadControlsInfo();

            return Task.CompletedTask;
        }

        private async void LoadControlsInfo()
        {          
            await ctrlGroupApplicationsPermissions1.LoadUserPermissions(CurrentUser);
           await ctrlGroupDetainReleaseLicensePermisisons1.LoadUserPermissions(CurrentUser);
            await ctrlGroupInternationalPermissions1.LoadUserPermissions(CurrentUser);
            await ctrlGroupLocalLicensePermissions1.LoadUserPermissions(CurrentUser);
            await ctrlGroupPeoplePermissions1.LoadUserPermissions(CurrentUser);
            await ctrlGroupSystemPermissions1.LoadUserPermissions(CurrentUser);
            await ctrlGroupTestPermisions1.LoadUserPermissions(CurrentUser);
            await ctrlGroupUserPermissions1.LoadUserPermissions(CurrentUser); 


        }




        private void LoadDefaultInfoToControls()
        {
            string DefaultTextValue = "";
            lblUserID.Text = DefaultTextValue;
            lblUserName.Text = DefaultTextValue;
            lblUserRole.Text = DefaultTextValue;

            lblUserRole.Visible = false;
            lblUserName.Visible = true;
            lblUserID.Visible = false;



        }


    }
}
