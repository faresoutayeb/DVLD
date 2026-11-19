using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_Screens
{
    public partial class frmAddEditUserPermissions
    {       
        private enum enMode { AddNew = 0, Update = 1 };

        private clsUser _CurrentUser;
        private enMode _CurrentScreenMode = enMode.AddNew;
        private int _UserID;


        //-----------------------------------------------------------------------------------------------------

        private void _WhenUserPermissionsAdded(int UserPermissionsID)
        {
            MessageBox.Show("User Permissions Added Successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void _WhenUserPermissionsNotAdded()
        {
            MessageBox.Show("Failed to Add User Permissions.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void _WhenUserPermissionsUpdated()
        {
            MessageBox.Show("User Permissions Updated Successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void _WhenUserPermissionsNotUpdated()
        {
            MessageBox.Show("Failed to Update User Permissions.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void _WhenNoUserSelected()
        {
            MessageBox.Show("No User Selected.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        //--------------------------------- LocalFunctions ------------------------

        private void _FillCheckboxesPermissions(CheckBox CurrentCheckBox, bool HasPermission)
        {
            if (HasPermission)
            {
                CurrentCheckBox.Checked = true;
            }
            else
            {
                CurrentCheckBox.Checked = false;
            }

        }

        private void _LoadCurrentUserPermissionToAddAndUpdate()
        {
            if (clsUtil.IsObjectFull(_CurrentUser.UserPermissionsInfo))
            {

                _FillCheckboxesPermissions(chkAddEditPerson, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.AddEditPerson));
                // People
                _FillCheckboxesPermissions(chkManagePeople, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManagePeople));
                _FillCheckboxesPermissions(chkAddEditPerson, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.AddEditPerson));
                _FillCheckboxesPermissions(chkDeletePerson, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.DeletePerson));

                // Users
                _FillCheckboxesPermissions(chkManageUsers, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManageUsers));
                _FillCheckboxesPermissions(chkAddEditUser, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.AddEditUser));
                _FillCheckboxesPermissions(chkEditUserPassword, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.EditUserPassword));
                _FillCheckboxesPermissions(chkDeleteUser, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.DeleteUser));

                // Applications
                _FillCheckboxesPermissions(chkViewApplications, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ViewApplications));
                _FillCheckboxesPermissions(chkManageNewLocalDrivingLicenseApplications, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManageNewLocalDrivingLicenseApplications));
                _FillCheckboxesPermissions(chkEditApplicationType, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.EditApplicationType));
                _FillCheckboxesPermissions(chkEditApplicationTestType, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.EditApplicationTestType));
                _FillCheckboxesPermissions(chkDeleteApplication, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.DeleteApplication));
                _FillCheckboxesPermissions(chkCancellApplication, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.CancellApplication));

                // Local Licenses
                _FillCheckboxesPermissions(chkManageLocalLicenses, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManageLocalLicenses));
                _FillCheckboxesPermissions(chkIssueFirstLicense, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.IssueNewDrivingLicense));
                _FillCheckboxesPermissions(chkRenewLicense, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.RenewLicense));
                _FillCheckboxesPermissions(chkReplaceDamagedOrLostLicense, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ReplaceDamagedOrLostLicense));
                _FillCheckboxesPermissions(chkViewLocalLicense, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ViewLocalLicense));
                _FillCheckboxesPermissions(chkViewLicenseHistory, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ViewLicenseHistory));

                // International Licenses
                _FillCheckboxesPermissions(chkManageInternationalLicenses, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManageInternationalLicenses));
                _FillCheckboxesPermissions(chkIssueInternationalLicense, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.IssueInternationalLicense));
                _FillCheckboxesPermissions(chkViewInternationalLicense, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ViewInternationalLicense));

                // Tests
                _FillCheckboxesPermissions(chkManageTestAppointments, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManageTestAppointments));
                _FillCheckboxesPermissions(chkScheduleTest, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ScheduleTest));
                _FillCheckboxesPermissions(chkTakeTest, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.TakeTest));

                // Detained Licenses
                _FillCheckboxesPermissions(chkManageDetainLicenseScreen, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManageDetainLicenseScreen));
                _FillCheckboxesPermissions(chkDetainLicense, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.DetainLicense));
                _FillCheckboxesPermissions(chkReleaseLicense, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ReleaseLicense));
                _FillCheckboxesPermissions(chkViewDetainedLicenses, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ViewDetainedLicenses));

                // System
                _FillCheckboxesPermissions(chkManageApplicationTypes, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManageApplicationTypes));
                _FillCheckboxesPermissions(chkManageTestTypes, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ManageTestTypes));
                _FillCheckboxesPermissions(chkViewDrivers, clsUserPermissions.HasPermission(_CurrentUser, clsUserPermissions.enPermissions.ViewDrivers));


            }

        }

        //-----------------------------------------------------------------------------------------------------

        private async Task InitializeLocalPrivateVariables(int UserID)
        {
            _CurrentUser = await clsUser.FindByUserIDAsync(UserID);

            if (clsUtil.IsObjectFull(_CurrentUser))
            {
            _UserID= _CurrentUser.UserID;

                if(_CurrentUser.UserPermissionsInfo != null)
                {
                    _CurrentScreenMode = enMode.Update;
                }
                else
                {
                    _CurrentScreenMode = enMode.Update;

                }



            }
            else
            {
                MessageBox.Show("User not found","No user with this id",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                _CurrentUser = null;
            }
        }

        private async Task InitializeLocalPrivateVariables(string UserName)
        {

            _CurrentUser = await clsUser.FindByUserNameAsync(UserName);
            if (clsUtil.IsObjectFull(_CurrentUser))
            {
            _UserID = _CurrentUser.UserID;

                if (_CurrentUser.UserPermissionsInfo != null)
                {
                    _CurrentScreenMode = enMode.Update;
                }
                else
                {
                    _CurrentScreenMode = enMode.Update;

                }


            }
            else
            {
                MessageBox.Show("User not found", "No user with this id", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                _CurrentUser = null;
            }
        }

        //-----------------------------------------------------------------------------------------------------

        private void _SetCurrentUserPermissions(clsUserPermissions UserPermissions)
        {

            if (chkAddEditPerson.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.AddEditPerson);

            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.AddEditPerson);

            // People
            if (chkManagePeople.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManagePeople);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManagePeople);

            if (chkAddEditPerson.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.AddEditPerson);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.AddEditPerson);

            if (chkDeletePerson.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.DeletePerson);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.DeletePerson);

            // Users
            if (chkManageUsers.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageUsers);
            else
                _CurrentUser.UserPermissionsInfo.RemovePermission(clsUserPermissions.enPermissions.ManageUsers);

            // Users
            if (chkManageUsers.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageUsers);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManageUsers);

            if (chkAddEditUser.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.AddEditUser);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.AddEditUser);

            if (chkEditUserPassword.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.EditUserPassword);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.EditUserPassword);

            if (chkDeleteUser.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.DeleteUser);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.DeleteUser);

            // Applications
            if (chkViewApplications.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ViewApplications);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ViewApplications);

            if (chkManageNewLocalDrivingLicenseApplications.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageNewLocalDrivingLicenseApplications);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManageNewLocalDrivingLicenseApplications);

            if (chkEditApplicationType.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.EditApplicationType);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.EditApplicationType);

            if (chkEditApplicationTestType.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.EditApplicationTestType);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.EditApplicationTestType);

            if (chkDeleteApplication.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.DeleteApplication);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.DeleteApplication);

            if (chkCancellApplication.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.CancellApplication);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.CancellApplication);

            // Local Licenses
            if (chkManageLocalLicenses.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageLocalLicenses);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManageLocalLicenses);
            if (chkIssueFirstLicense.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.IssueNewDrivingLicense);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.IssueNewDrivingLicense);

            if (chkRenewLicense.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.RenewLicense);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.RenewLicense);

            if (chkReplaceDamagedOrLostLicense.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ReplaceDamagedOrLostLicense);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ReplaceDamagedOrLostLicense);

            if (chkViewLocalLicense.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ViewLocalLicense);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ViewLocalLicense);

            if (chkViewLicenseHistory.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ViewLicenseHistory);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ViewLicenseHistory);

            // International Licenses
            if (chkManageInternationalLicenses.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageInternationalLicenses);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManageInternationalLicenses);

            if (chkIssueInternationalLicense.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.IssueInternationalLicense);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.IssueInternationalLicense);

            if (chkViewInternationalLicense.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ViewInternationalLicense);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ViewInternationalLicense);

            // Tests
            if (chkManageTestAppointments.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageTestAppointments);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManageTestAppointments);

            if (chkScheduleTest.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ScheduleTest);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ScheduleTest);

            if (chkTakeTest.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.TakeTest);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.TakeTest);

            // Detained Licenses
            if (chkManageDetainLicenseScreen.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageDetainLicenseScreen);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManageDetainLicenseScreen);

            if (chkDetainLicense.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.DetainLicense);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.DetainLicense);

            if (chkReleaseLicense.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ReleaseLicense);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ReleaseLicense);

            if (chkViewDetainedLicenses.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ViewDetainedLicenses);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ViewDetainedLicenses);

            // System
            if (chkManageApplicationTypes.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageApplicationTypes);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManageApplicationTypes);

            if (chkManageTestTypes.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ManageTestTypes);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ManageTestTypes);

            if (chkViewDrivers.Checked)
                UserPermissions.AddPermission(clsUserPermissions.enPermissions.ViewDrivers);
            else
                UserPermissions.RemovePermission(clsUserPermissions.enPermissions.ViewDrivers);





        }


        //-----------------------------------------------------------------------------------------------------
        private async Task PerformUpdatePermissions()
        {
            if (clsUtil.IsObjectFull(_CurrentUser.UserPermissionsInfo))
            {
                _SetCurrentUserPermissions(_CurrentUser.UserPermissionsInfo);
                if ( await _CurrentUser.UserPermissionsInfo.Save())
                {            
                    _WhenUserPermissionsUpdated();

                    await ctrlUserPermissionsCard1.LoadUserPermissions(this._CurrentUser.UserID);
                }
                else
                {                  
                    _WhenUserPermissionsNotUpdated();
                }
                return;

            }
        }

        private async Task PerformAddNewPermissions()
        {

            if(_CurrentScreenMode==enMode.AddNew)
            {
                _CurrentUser.UserPermissionsInfo = new clsUserPermissions();

            }


            _CurrentUser.UserPermissionsInfo.UserID = _CurrentUser.UserID;
            _SetCurrentUserPermissions(_CurrentUser.UserPermissionsInfo);
            if (await _CurrentUser.UserPermissionsInfo.Save())
            {                
                _CurrentScreenMode = enMode.Update;
                //lblTitle.Text = "Update User Permissisons";
                _WhenUserPermissionsAdded(_CurrentUser.UserPermissionsInfo.UserPermisionsID);
                 await ctrlUserPermissionsCard1.LoadUserPermissions(this._CurrentUser.UserID);

                return;
            }
            else
            {
                
                _WhenUserPermissionsNotAdded();
                return;
            }
        }

        private async Task PerformSaveCurrentUserPermissionsInfo()
        {
            if (_CurrentScreenMode == enMode.Update)
            {
                await PerformUpdatePermissions();
                return;
            }
            if (_CurrentScreenMode == enMode.AddNew)
            {
                await PerformAddNewPermissions();

                return;
            }
        }


    }
}
