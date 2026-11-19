using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Users.UserControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_User_Controls
{
    public partial class ctrlUserPermissions : UserControl
    {
        public ctrlUserPermissions()
        {
            InitializeComponent();
        }

        private void ctrlUserPermissions_Load(object sender, EventArgs e)
        {

        }

        public event Action OnUserNotFound;
        protected virtual void UserNotFound()
        {
            OnUserNotFound?.Invoke();
        }

        public void LoadCurrentLogedUserPermissions()
        {

            //ctrlUserLoginInfo11.LoadUserInfo(clsGlobalUserInfo.CurrentLogInUser.UserID);
            lblUserID.Text = clsGlobalUserInfo.CurrentLogInUser.UserID.ToString();
            lblUserName.Text= clsGlobalUserInfo.CurrentLogInUser.UserName.ToString();
            // People
            SetLablesControlsValue(lblManagePeopleValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManagePeople));
            SetLablesControlsValue(lblAddEditPersonValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson));
            SetLablesControlsValue(lblDeletePersonValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeletePerson));

            // Users
            SetLablesControlsValue(lblManageUsersValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageUsers));
            SetLablesControlsValue(lblAddEditUserValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditUser));
            SetLablesControlsValue(lblEditUserPasswordValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditUserPassword));
            SetLablesControlsValue(lblDeleteUserValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeleteUser));

            // Applications
            SetLablesControlsValue(lblViewApplicationsValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewApplications));
            SetLablesControlsValue(lblManageNewLocalDrivingLicenseApplicationsValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageNewLocalDrivingLicenseApplications));
            SetLablesControlsValue(lblEditApplicationTypeValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditApplicationType));
            SetLablesControlsValue(lblEditApplicationTestTypeValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditApplicationTestType));
            SetLablesControlsValue(lblDeleteApplicationValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeleteApplication));
            SetLablesControlsValue(lblCancelApplicationValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.CancellApplication));

            // Local Licenses
            SetLablesControlsValue(lblManageLocalLicensesValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageLocalLicenses));
            SetLablesControlsValue(lblIssueFirstLicenseValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.IssueNewDrivingLicense));
            SetLablesControlsValue(lblRenewLicenseValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.RenewLicense));
            SetLablesControlsValue(lblReplaceDamagedOrLostLicenseValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ReplaceDamagedOrLostLicense));
            SetLablesControlsValue(lblViewLocalLicenseValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense));
            SetLablesControlsValue(lblViewLicenseHistoryValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLicenseHistory));

            // International Licenses
            SetLablesControlsValue(lblManageInternationalLicensesValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageInternationalLicenses));
            SetLablesControlsValue(lblIssueInternationalLicenseValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.IssueInternationalLicense));
            SetLablesControlsValue(lblViewInternationalLicenseValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewInternationalLicense));

            // Tests
            SetLablesControlsValue(lblManageTestAppointmentsValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageTestAppointments));
            SetLablesControlsValue(lblScheduleTestValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ScheduleTest));
            SetLablesControlsValue(lblTakeTestValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.TakeTest));

            // Detained Licenses
            SetLablesControlsValue(lblManageDetainLicenseScreenValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageDetainLicenseScreen));
            SetLablesControlsValue(lblDetainLicenseValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DetainLicense));
            SetLablesControlsValue(lblReleaseLicenseValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ReleaseLicense));
            SetLablesControlsValue(lblViewDetainedLicensesValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewDetainedLicenses));

            // System
            SetLablesControlsValue(lblManageApplicationTypesValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageApplicationTypes));
            SetLablesControlsValue(lblManageTestTypesValue, clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageTestTypes));

        }

        private void SetLablesControls(clsUser CurrentUser)
        {
            // People
            SetLablesControlsValue(lblManagePeopleValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManagePeople));
            SetLablesControlsValue(lblAddEditPersonValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson));
            SetLablesControlsValue(lblDeletePersonValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeletePerson));

            // Users
            SetLablesControlsValue(lblManageUsersValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageUsers));
            SetLablesControlsValue(lblAddEditUserValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditUser));
            SetLablesControlsValue(lblEditUserPasswordValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditUserPassword));
            SetLablesControlsValue(lblDeleteUserValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeleteUser));

            // Drivers
            SetLablesControlsValue(lblViewDriversValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewDrivers));


            // Applications
            SetLablesControlsValue(lblViewApplicationsValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewApplications));
            SetLablesControlsValue(lblManageNewLocalDrivingLicenseApplicationsValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageNewLocalDrivingLicenseApplications));
            SetLablesControlsValue(lblEditApplicationTypeValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditApplicationType));
            SetLablesControlsValue(lblEditApplicationTestTypeValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.EditApplicationTestType));
            SetLablesControlsValue(lblDeleteApplicationValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeleteApplication));
            SetLablesControlsValue(lblCancelApplicationValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.CancellApplication));

            // Local Licenses
            SetLablesControlsValue(lblManageLocalLicensesValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageLocalLicenses));
            SetLablesControlsValue(lblIssueFirstLicenseValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.IssueNewDrivingLicense));
            SetLablesControlsValue(lblRenewLicenseValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.RenewLicense));
            SetLablesControlsValue(lblReplaceDamagedOrLostLicenseValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ReplaceDamagedOrLostLicense));
            SetLablesControlsValue(lblViewLocalLicenseValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLocalLicense));
            SetLablesControlsValue(lblViewLicenseHistoryValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewLicenseHistory));

            // International Licenses
            SetLablesControlsValue(lblManageInternationalLicensesValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageInternationalLicenses));
            SetLablesControlsValue(lblIssueInternationalLicenseValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.IssueInternationalLicense));
            SetLablesControlsValue(lblViewInternationalLicenseValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewInternationalLicense));

            // Tests
            SetLablesControlsValue(lblManageTestAppointmentsValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageTestAppointments));
            SetLablesControlsValue(lblScheduleTestValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ScheduleTest));
            SetLablesControlsValue(lblTakeTestValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.TakeTest));

            // Detained Licenses
            SetLablesControlsValue(lblManageDetainLicenseScreenValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageDetainLicenseScreen));
            SetLablesControlsValue(lblDetainLicenseValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DetainLicense));
            SetLablesControlsValue(lblReleaseLicenseValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ReleaseLicense));
            SetLablesControlsValue(lblViewDetainedLicensesValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ViewDetainedLicenses));

            // System
            SetLablesControlsValue(lblManageApplicationTypesValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageApplicationTypes));
            SetLablesControlsValue(lblManageTestTypesValue, CurrentUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ManageTestTypes));


        }

        public  async Task LoadUserPermissions(int UserID)
        {
            clsUser CurrentUser=await clsUser.FindByUserIDAsync(UserID);
            if(clsUtil.IsObjectFull(CurrentUser))
            {
                if (clsUtil.IsObjectFull(CurrentUser.UserPermissionsInfo))
                {
                    //ctrlUserLoginInfo11.LoadUserInfo(UserID);
                    lblUserID.Text = clsGlobalUserInfo.CurrentLogInUser.UserID.ToString();
                    lblUserName.Text = clsGlobalUserInfo.CurrentLogInUser.UserName.ToString();
                    SetLablesControls(CurrentUser);
                }
                else
                {
                    LoadDefaultInfoToControls();
                }
            }
            else
            {
                UserNotFound();
            }

        }

        public async Task LoadUserPermissions(string UserName)
        {
            clsUser CurrentUser = await clsUser.FindByUserNameAsync(UserName);
            if (clsUtil.IsObjectFull(CurrentUser))
            {
                if (clsUtil.IsObjectFull(CurrentUser.UserPermissionsInfo))
                {
                    //ctrlUserLoginInfo11.LoadUserInfo(CurrentUser.UserID);
                    lblUserID.Text = clsGlobalUserInfo.CurrentLogInUser.UserID.ToString();
                    lblUserName.Text = clsGlobalUserInfo.CurrentLogInUser.UserName.ToString();
                    SetLablesControls(CurrentUser);
                }
                else
                {
                    LoadDefaultInfoToControls();
                }
            }
            else
            {
                UserNotFound();
            }

        }


        private void SetLablesControlsValue(Label lable,bool HasPermission)
        {
            if(HasPermission)
            {
                lable.Text = "✅";
                lable.ForeColor = Color.Green;
            }
            else
            {
                lable.Text = "X";
                lable.ForeColor = Color.Red;
            }


        }



        private void LoadDefaultInfoToControls()
        {
            lblManagePeopleValue.Text = "X";
            lblAddEditPersonValue.Text = "X";
            lblDeletePersonValue.Text = "X";

            lblManageUsersValue.Text = "X";
            lblAddEditUserValue.Text = "X";
            lblEditUserPasswordValue.Text = "X";
            lblDeleteUserValue.Text = "X";

            lblViewApplicationsValue.Text = "X";
            lblManageNewLocalDrivingLicenseApplicationsValue.Text = "X";
            lblEditApplicationTypeValue.Text = "X";
            lblEditApplicationTestTypeValue.Text = "X";
            lblDeleteApplicationValue.Text = "X";
            lblCancelApplicationValue.Text = "X";

            lblManageLocalLicensesValue.Text = "X";
            lblIssueFirstLicenseValue.Text = "X";
            lblRenewLicenseValue.Text = "X";
            lblReplaceDamagedOrLostLicenseValue.Text = "X";
            lblViewLocalLicenseValue.Text = "X";
            lblViewLicenseHistoryValue.Text = "X";

            lblManageInternationalLicensesValue.Text = "X";
            lblIssueInternationalLicenseValue.Text = "X";
            lblViewInternationalLicenseValue.Text = "X";

            lblManageTestAppointmentsValue.Text = "X";
            lblScheduleTestValue.Text = "X";
            lblTakeTestValue.Text = "X";

            lblManageDetainLicenseScreenValue.Text = "X";
            lblDetainLicenseValue.Text = "X";
            lblReleaseLicenseValue.Text = "X";
            lblViewDetainedLicensesValue.Text = "X";

            lblManageApplicationTypesValue.Text = "X";
            lblManageTestTypesValue.Text = "X";


        }



    }
}
