using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Manage_Local_Driving_License_Applications_Screen;
using DVLD_Presentation_Layer.Detained_License.Detained_License_Screens;
using DVLD_Presentation_Layer.Detained_License.Manage_Detain_Licenses_Screens;
using DVLD_Presentation_Layer.Driver.Driver_Screens;
using DVLD_Presentation_Layer.International_Driving_License.International_Driving_License_Screens;
using DVLD_Presentation_Layer.LicenseHistory.License_History_Screens;
using DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_Screens;
using DVLD_Presentation_Layer.Release_License.Realease_License_Screens;
using DVLD_Presentation_Layer.Renew_Driving_License.Renew_Driving_License_Screens;
using DVLD_Presentation_Layer.Replacement_for_Damaged_Or_Lost_Licenses.Replacement_Screens;
using DVLD_Presentation_Layer.Users;
using DVLD_Presentation_Layer.Users.User_Logs.User_logs_Screen;
using DVLD_Presentation_Layer.Users.User_Screens;
using DVLD_Presentation_Layer.Users.UserScreens;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer
{
    public partial class frmMainDVLDMenuScreen : Form
    {
        public frmMainDVLDMenuScreen()
        {
            InitializeComponent();
        }
        private frmDVLD_Login_Screen _CurrentLoginScreen;
        public frmMainDVLDMenuScreen(frmDVLD_Login_Screen CurrentLoginForm)
        {
            InitializeComponent();
            _CurrentLoginScreen = CurrentLoginForm;
        }


        private async void LogoutButtonClicked(object sender, EventArgs e)
        {
            _CurrentLoginScreen.UserLog.LogoutDateTime=DateTime.Now;
            if(!await _CurrentLoginScreen.UserLog.SaveAsync())
            {
                MessageBox.Show("User log not updated");
                return;
            }
            clsGlobalUserInfo.CurrentLogInUser = null;
            this.Close();
            _CurrentLoginScreen.Show();
        }

        private void ManageApplicationsTypesButtonClicked(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ManageApplicationTypes))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmManageAppTypes ManageApplicationsTypes = new frmManageAppTypes();
            ManageApplicationsTypes.ShowDialog();
        }

        private void ManagePeopleScreenButtonClick(object sender, EventArgs e)
        {
            if(!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser,clsUserPermissions.enPermissions.ManagePeople))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }

            frmManagePeopleScreen People = new frmManagePeopleScreen();
            People.ShowDialog();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            ManagePeopleScreenButtonClick(sender, e);
        }

        private void ManageDetainLicenseScreenButton_Click(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ManageDetainLicenseScreen))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmManageDetainLicenses OpenManageDetainLicenseScreen = new frmManageDetainLicenses();
            OpenManageDetainLicenseScreen.ShowDialog();
        }

        private void ManageLocalDrivingLicenseButtonClicked(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ManageLocalLicenses))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmManageLocalLiApp OpenManageLocalDrivingLicensesScreen = new frmManageLocalLiApp();
            OpenManageLocalDrivingLicensesScreen.ShowDialog();
        }

        private void ManageUsersPermisionsButtonClicked(object sender, EventArgs e)
        {
            if ( !clsGlobalUserInfo.CurrentLogInUser.IsAdmin())
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmManageUsersPermisions OpenUsersPermisions = new frmManageUsersPermisions();
            OpenUsersPermisions.ShowDialog();
        }

        private void ManageUsersScreenButtonClicked(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ManageUsers))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            DVLD_Presentation_Layer.Users.User_Screens.frmManageUsersScreen OpenUsersScreen = new DVLD_Presentation_Layer.Users.User_Screens.frmManageUsersScreen();
            OpenUsersScreen.ShowDialog();
        }

        private void DriversScreenButotnClicked(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ViewDrivers))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmDriversScreen OpenDriversScreen = new frmDriversScreen();
            OpenDriversScreen.ShowDialog();
        }

        private void ManageInternationalLicensesScreenButtonClicked(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ManageInternationalLicenses))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmManageInterLicenses InternationalLicensesScreen = new frmManageInterLicenses();
            InternationalLicensesScreen.ShowDialog();
        }

        private void ManageTestTypeButtonClicked(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ManageTestTypes))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmManageTestType ManageTestsTypes = new frmManageTestType();
            ManageTestsTypes.ShowDialog();
        }

        private async void frmMainDVLDMenuScreen_Load(object sender, EventArgs e)
        {


             ctrlWelcomeUser1.LoadInfo(clsGlobalUserInfo.CurrentLogInUser);

            await ctrlMainMenueCounter1.LoadInfo();
            await ctrlRecentApplications1.LoadInfo();
            await ctrlSystemInformations1.LoadInfo(clsGlobalUserInfo.CurrentLogInUser);
            await ctrlSystemOverview1.LoadInfo();


        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbApplicationsOptions.SelectedIndex == 1)
            {
                if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.IssueInternationalLicense))
                {


                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmIssueInternationalLicense IssueInternationalLicenseScreen = new frmIssueInternationalLicense();
                IssueInternationalLicenseScreen.ShowDialog();
            }
            if (cbApplicationsOptions.SelectedIndex == 2)
            {
                if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.DetainLicense))
                {


                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmDetainLicense OpenDetainLicenseScreen = new frmDetainLicense();
                OpenDetainLicenseScreen.ShowDialog();
            }
            if (cbApplicationsOptions.SelectedIndex == 3)
            {
                if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ReleaseLicense))
                {


                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmReleaseLicenseScreen OpenReleaseLicenseScreen = new frmReleaseLicenseScreen();
                OpenReleaseLicenseScreen.ShowDialog();
            }
            if (cbApplicationsOptions.SelectedIndex == 4)
            {
                if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.RenewLicense))
                {


                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmRenewDrivingLicenseScreen OpenRenewDrivingLicenseScreen = new frmRenewDrivingLicenseScreen();
                OpenRenewDrivingLicenseScreen.ShowDialog();


            }
            if (cbApplicationsOptions.SelectedIndex == 5)
            {
                if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ReplaceDamagedOrLostLicense))
                {


                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmReplaceLicense OpenReplacementForDamagedOrLostLicensesScreen = new frmReplaceLicense();
                OpenReplacementForDamagedOrLostLicensesScreen.ShowDialog();

            } 
            if(cbApplicationsOptions.SelectedIndex == 6)
            {
                if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ManageLocalLicenses))
                {


                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmManageLocalLiApp OpenManageLocalDrivingLicensesScreen = new frmManageLocalLiApp();
                OpenManageLocalDrivingLicensesScreen.ShowDialog();
            }
        
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            cbAccountSettings.Show();
        }

        private void cbAccountSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAccountSettings.SelectedIndex == 1)
            {
                frmShowUserInfoScreen userInfoScreen = new frmShowUserInfoScreen(clsGlobalUserInfo.CurrentLogInUser.UserID);

                userInfoScreen.ShowDialog();

            }
            if (cbAccountSettings.SelectedIndex == 2)
            {

                frmAddEditUser EditUserInfo= new frmAddEditUser(clsGlobalUserInfo.CurrentLogInUser.UserID);
                EditUserInfo.ctrlFilterPersonInformation1.EnableFilter = false;
                EditUserInfo.ShowDialog();
            }
            if (cbAccountSettings.SelectedIndex == 3)
            {

                frmChangePassword ChangePasswordScreen = new frmChangePassword(clsGlobalUserInfo.CurrentLogInUser.UserID);
                ChangePasswordScreen.ShowDialog();  
            }

            if(cbAccountSettings.SelectedIndex==4)
            {
                if(!clsGlobalUserInfo.CurrentLogInUser.IsAdmin())
                {
                    clsGlobal.ShowAccessDeniedScreen();
                    return;
                }
                frmUsersLogs UsersLogsScreen = new frmUsersLogs();
                UsersLogsScreen.ShowDialog();

            }


        }

        private void licenseHistoryScreenButtonClicked(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ViewLicenseHistory))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmLicenseHistoryScreen licenseHistoryScreen = new frmLicenseHistoryScreen();
                licenseHistoryScreen.ShowDialog();
        }



        private void cbAccountSettings2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccountSettings.SelectedIndex == 0)
            {

                frmShowUserInfoScreen userInfoScreen = new frmShowUserInfoScreen(clsGlobalUserInfo.CurrentLogInUser.UserID);

                userInfoScreen.ShowDialog();

            }
            if (cbAccountSettings.SelectedIndex == 1)
            {
                frmAddEditUser EditUserInfo = new frmAddEditUser(clsGlobalUserInfo.CurrentLogInUser.UserID);
                EditUserInfo.ctrlFilterPersonInformation1.EnableFilter = false;
                EditUserInfo.ShowDialog();
            }
            if (cbAccountSettings.SelectedIndex == 2)
            {
 
                frmChangePassword ChangePasswordScreen = new frmChangePassword(clsGlobalUserInfo.CurrentLogInUser.UserID);
                ChangePasswordScreen.ShowDialog();
            }


        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            cbApplicationsOptions.Show();
        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {
            cbQuickActions.Show();
        }

        private void cbQuickActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbQuickActions.SelectedIndex==0)
            {
                if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.AddEditPerson))
                {


                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmAddEditPerson AddNewPersonScreen = new frmAddEditPerson();
                AddNewPersonScreen.ShowDialog();
            }
            if (cbQuickActions.SelectedIndex == 1)
            {
                if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.AddEditUser))
                {


                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmAddEditUser AddNewUserScreen=new frmAddEditUser();
                AddNewUserScreen.ShowDialog();
            }
            if (cbQuickActions.SelectedIndex == 2)
            {
                if (!clsGlobalUserInfo.CurrentLogInUser.IsAdmin())
                {

                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmAddEditUserPermissions addEditUserPermissionsScreen = new frmAddEditUserPermissions();
                addEditUserPermissionsScreen.ShowDialog();
            }
            if (cbQuickActions.SelectedIndex == 3)
            {
                if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DetainLicense))
                {

                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmDetainLicense frm = new frmDetainLicense();
                frm.ShowDialog();
                //refresh

            }
            if (cbQuickActions.SelectedIndex == 4)
            {
                if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.ReleaseLicense))
                {

                    clsGlobal.ShowAccessDeniedScreen();
                    return;

                }
                frmReleaseLicenseScreen frm = new frmReleaseLicenseScreen();
                frm.ShowDialog();
                //refresh
                
            }



        }

        private void FindUserPermisionsScreenButtonClicked(object sender, EventArgs e)
        {
            frmFindUserPermisions CurrentUserPermissions = new frmFindUserPermisions(clsGlobalUserInfo.CurrentLogInUser.UserID);
            if(clsGlobalUserInfo.CurrentLogInUser.IsAdmin())
            {
                CurrentUserPermissions.ctrlFindUserFilter1.Enabled = true;

            }
            else
                CurrentUserPermissions.ctrlFindUserFilter1.Enabled = false;

            CurrentUserPermissions.ShowDialog();
        }

        private void ManageUsersScreenButton2Clicked(object sender, EventArgs e)
        {
            ManageUsersScreenButtonClicked(sender, e);
        }

        private void DriversScreenButtonClicked(object sender, EventArgs e)
        {
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.ViewDrivers))
            {


                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmDriversScreen OpenDriversScreen = new frmDriversScreen();
            OpenDriversScreen.ShowDialog();
        }
    }
    
}








        


   