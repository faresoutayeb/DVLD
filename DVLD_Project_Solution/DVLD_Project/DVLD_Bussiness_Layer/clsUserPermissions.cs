using DVLD_Data_Access_Layer;
using DVLD_Presentation_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer
{

    /// <summary>
    /// Represents a user's permissions and provides methods for retrieving,
    /// modifying, saving, and checking permission assignments.
    /// </summary>
    public class clsUserPermissions
    {
        /// <summary>
        /// Gets or sets the ID of the user associated with these permissions.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user's permission record.
        /// </summary>
        public int UserPermisionsID { get; set; }

        /// <summary>
        /// Gets the permission flags assigned to the user.
        /// Each permission is represented by a bit flag.
        /// </summary>
        public long Permisions { get; private set; }

        /// <summary>
        /// Specifies whether the permission record is new or existing.
        /// </summary>
        private enum enMode
        {
            AddNewMode,
            UpdateMode
        }

        /// <summary>
        /// Gets or sets the current persistence mode of the permission record.
        /// </summary>
        private enMode _Mode;

        /// <summary>
        /// Initializes a new permission record with default values.
        /// The record is configured for insertion.
        /// </summary>
        public clsUserPermissions()
        {
            UserID = -1;
            UserPermisionsID = -1;
            Permisions = -1;
            _Mode = enMode.AddNewMode;
        }

        /// <summary>
        /// Initializes an existing permission record with the specified values.
        /// If the permission value is -1, the administrator permission mask is applied.
        /// </summary>
        /// <param name="UserPermisionsID">
        /// The unique identifier of the permission record.
        /// </param>
        /// <param name="UserID">
        /// The ID of the user associated with the permissions.
        /// </param>
        /// <param name="Permisions">
        /// The permission bitmask assigned to the user.
        /// </param>
        public clsUserPermissions(
            int UserPermisionsID,
            int UserID,
            long Permisions)
        {
            this.UserPermisionsID = UserPermisionsID;
            this.UserID = UserID;
            this.Permisions = Permisions;
            _Mode = enMode.UpdateMode;

            if (this.Permisions == -1)
            {
                this.Permisions = _AdminPermissisonNumber();
            }
        }

        /// <summary>
        /// Retrieves a permission record by its unique identifier.
        /// </summary>
        /// <param name="UserPermisionsID">
        /// The ID of the permission record to retrieve.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// contains the permission record if found; otherwise, null.
        /// </returns>
        public static async Task<clsUserPermissions> FindAsync(
            int UserPermisionsID)
        {
            clsUserPermissionsData.stUserPermissionsInfo Result =
                await clsUserPermissionsData.GetPermissionsByIDAsync(
                    UserPermisionsID);

            if (Result != null)
            {
                return new clsUserPermissions(
                    Result.UserPermissionsID,
                    Result.UserID,
                    Result.Permissions);
            }

            return null;
        }

        public static clsUserPermissions Find(
    int UserPermisionsID)
        {
            clsUserPermissionsData.stUserPermissionsInfo Result =
                 clsUserPermissionsData.GetPermissionsByID(
                    UserPermisionsID);

            if (Result != null)
            {
                return new clsUserPermissions(
                    Result.UserPermissionsID,
                    Result.UserID,
                    Result.Permissions);
            }

            return null;
        }



        /// <summary>
        /// Retrieves a permission record associated with a specific user.
        /// </summary>
        /// <param name="UserID">
        /// The ID of the user whose permissions are requested.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// contains the user's permission record if found; otherwise, null.
        /// </returns>
        public static clsUserPermissions FindByUserID(
            int UserID)
        {
            clsUserPermissionsData.stUserPermissionsInfo Result =
                 clsUserPermissionsData.GetPermissionsByUserID(
                    UserID);

            if (Result != null)
            {
                return new clsUserPermissions(
                    Result.UserPermissionsID,
                    Result.UserID,
                    Result.Permissions);
            }

            return null;
        }

        public static async Task<clsUserPermissions> FindByUserIDAsync(
     int UserID)
        {
            clsUserPermissionsData.stUserPermissionsInfo Result =
                await clsUserPermissionsData.GetPermissionsByUserIDAsync(
                    UserID);

            if (Result != null)
            {
                return new clsUserPermissions(
                    Result.UserPermissionsID,
                    Result.UserID,
                    Result.Permissions);
            }

            return null;
        }

        /// <summary>
        /// Retrieves the permission bitmask associated with a user.
        /// </summary>
        /// <param name="UserID">
        /// The ID of the user whose permissions are requested.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// contains the user's permission bitmask.
        /// </returns>
        public Task<long> UserPermissions(int UserID)
        {
            return clsUserPermissionsData
                .GetUserPermissionsByUserIDAsync(UserID);
        }

        /// <summary>
        /// Adds a permission to the current permission bitmask.
        /// Existing permissions are preserved.
        /// </summary>
        /// <param name="permissionToAdd">
        /// The permission to add.
        /// </param>
        public void AddPermission(enPermissions permissionToAdd)
        {
            Permisions |= (long)permissionToAdd;
        }

        /// <summary>
        /// Removes a permission from the current permission bitmask.
        /// Other permissions are preserved.
        /// </summary>
        /// <param name="permissionToRemove">
        /// The permission to remove.
        /// </param>
        public void RemovePermission(enPermissions permissionToRemove)
        {
            Permisions &= ~(long)permissionToRemove;
        }

        /// <summary>
        /// Inserts a new permission record into the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is true if the record was created successfully; otherwise, false.
        /// </returns>
        private async Task<bool> _AddNewUserPermissions()
        {
            UserPermisionsID =
                await clsUserPermissionsData.AddNewUserPermissionsAsync(
                    UserID,
                    Permisions);

            return UserPermisionsID != -1;
        }

        /// <summary>
        /// Updates an existing permission record in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is true if the record was updated successfully; otherwise, false.
        /// </returns>
        private Task<bool> _UpdateUserPermissions()
        {
            return clsUserPermissionsData.UpdateUserPermissionsAsync(
                UserPermisionsID,
                UserID,
                Permisions);
        }

        /// <summary>
        /// Retrieves the individual permissions granted to a specific role.
        /// </summary>
        /// <param name="RoleID">
        /// The ID of the role whose permissions are requested.
        /// </param>
        /// <returns>
        /// An array containing the individual permission bit values granted
        /// to the role. Returns an empty array if the role does not exist.
        /// </returns>
        public static async Task<long[]> GetListOfRolePermissions(int RoleID)
        {
            clsRole Role =await clsRole.FindAsync(RoleID);

            if (Role == null)
                return new long[0];

            long RolePermissions = Role.Permissions;
            List<long> RolePermissionsList = new List<long>();

            foreach (enPermissions Permission in Enum.GetValues(
                typeof(enPermissions)))
            {
                long PermissionValue = (long)Permission;

                if (PermissionValue == 0)
                    continue;

                if ((RolePermissions & PermissionValue) == PermissionValue)
                {
                    RolePermissionsList.Add(PermissionValue);
                }
            }

            return RolePermissionsList.ToArray();
        }

        /// <summary>
        /// Retrieves user and role permission information for the
        /// permission management interface.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// contains the retrieved information in a DataTable.
        /// </returns>
        public static Task<DataTable> GetManageUsersPermissionsInfo()
        {
            return clsUserPermissionsData.GetUserRoleInfoAsync();
        }

        /// <summary>
        /// Saves the current permission record.
        /// Inserts a new record when the object is in AddNewMode,
        /// or updates the existing record when it is in UpdateMode.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewMode:
                    if (await _AddNewUserPermissions())
                    {
                        _Mode = enMode.UpdateMode;
                        return true;
                    }

                    return false;

                case enMode.UpdateMode:
                    return await _UpdateUserPermissions();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Defines the individual permissions supported by the application.
        /// Each permission uses a distinct bit flag, allowing multiple
        /// permissions to be combined into a single long value.
        /// </summary>
        public enum enPermissions : long
        {
            /// <summary>No permissions are granted.</summary>
            None = 0,

            // People

            /// <summary>Allows access to people management functionality.</summary>
            ManagePeople = 1,

            /// <summary>Allows adding and editing people.</summary>
            AddEditPerson = 2,

            /// <summary>Allows deleting people.</summary>
            DeletePerson = 4,

            // Users

            /// <summary>Allows access to user management functionality.</summary>
            ManageUsers = 8,

            /// <summary>Allows adding and editing users.</summary>
            AddEditUser = 16,

            /// <summary>Allows editing user passwords.</summary>
            EditUserPassword = 32,

            /// <summary>Allows deleting users.</summary>
            DeleteUser = 64,

            // Applications

            /// <summary>Allows viewing applications.</summary>
            ViewApplications = 128,

            /// <summary>
            /// Allows managing new local driving license applications.
            /// </summary>
            ManageNewLocalDrivingLicenseApplications = 256,

            /// <summary>Allows editing application types.</summary>
            EditApplicationType = 512,

            /// <summary>Allows editing application test types.</summary>
            EditApplicationTestType = 1024,

            /// <summary>Allows deleting applications.</summary>
            DeleteApplication = 2048,

            /// <summary>Allows cancelling applications.</summary>
            CancellApplication = 4096,

            // Local Licenses

            /// <summary>Allows managing local driving licenses.</summary>
            ManageLocalLicenses = 8192,

            /// <summary>Allows viewing drivers.</summary>
            ViewDrivers = 16384,

            /// <summary>Allows issuing new driving licenses.</summary>
            IssueNewDrivingLicense = 32768,

            /// <summary>Allows renewing driving licenses.</summary>
            RenewLicense = 65536,

            /// <summary>
            /// Allows replacing damaged or lost driving licenses.
            /// </summary>
            ReplaceDamagedOrLostLicense = 131072,

            /// <summary>Allows viewing local driving licenses.</summary>
            ViewLocalLicense = 262144,

            /// <summary>Allows viewing driving license history.</summary>
            ViewLicenseHistory = 524288,

            // International Licenses

            /// <summary>Allows managing international driving licenses.</summary>
            ManageInternationalLicenses = 1048576,

            /// <summary>Allows issuing international driving licenses.</summary>
            IssueInternationalLicense = 2097152,

            /// <summary>Allows viewing international driving licenses.</summary>
            ViewInternationalLicense = 4194304,

            // Tests

            /// <summary>Allows managing test appointments.</summary>
            ManageTestAppointments = 8388608,

            /// <summary>Allows scheduling tests.</summary>
            ScheduleTest = 16777216,

            /// <summary>Allows recording test results.</summary>
            TakeTest = 33554432,

            // Detained Licenses

            /// <summary>
            /// Allows access to the detained license management screen.
            /// </summary>
            ManageDetainLicenseScreen = 67108864,

            /// <summary>Allows detaining driving licenses.</summary>
            DetainLicense = 134217728,

            /// <summary>Allows releasing detained driving licenses.</summary>
            ReleaseLicense = 268435456,

            /// <summary>Allows viewing detained driving licenses.</summary>
            ViewDetainedLicenses = 536870912,

            // System

            /// <summary>Allows managing application types.</summary>
            ManageApplicationTypes = 1073741824,

            /// <summary>Allows managing test types.</summary>
            ManageTestTypes = 2147483648
        }

        /// <summary>
        /// Determines whether the current user has the specified permission.
        /// </summary>
        /// <param name="permission">
        /// The permission to check.
        /// </param>
        /// <returns>
        /// true if the user has the specified permission; otherwise, false.
        /// </returns>
        public bool HasPermissionFor(enPermissions permission)
        {
            return _IsHasPermission(permission);
        }

        /// <summary>
        /// Determines whether the specified user has the requested permission.
        /// </summary>
        /// <param name="User">
        /// The user whose permissions will be checked.
        /// </param>
        /// <param name="permission">
        /// The permission to verify.
        /// </param>
        /// <returns>
        /// true if the user exists, has permission information, and possesses
        /// the requested permission; otherwise, false.
        /// </returns>
        public static bool HasPermission(
            clsUser User,
            enPermissions permission)
        {
            return User != null &&
                   User.UserPermissionsInfo != null &&
                   User.UserPermissionsInfo._IsHasPermission(permission);
        }

        /// <summary>
        /// Checks whether the current permission bitmask contains the specified
        /// permission.
        /// </summary>
        /// <param name="permission">
        /// The permission to check.
        /// </param>
        /// <returns>
        /// true if the specified permission is granted; otherwise, false.
        /// </returns>
        private bool _IsHasPermission(enPermissions permission)
        {
            return (Permisions & (long)permission) == (long)permission;
        }

        /// <summary>
        /// Returns the display-friendly name of the specified permission.
        /// </summary>
        /// <param name="CurrentPermission">
        /// The permission whose display name is requested.
        /// </param>
        /// <returns>
        /// The display name corresponding to the specified permission,
        /// or "No Permission" if no matching permission is found.
        /// </returns>
        public string PermisisonsString(enPermissions CurrentPermission)
        {
            switch (CurrentPermission)
            {
                case enPermissions.ManagePeople:
                    return "Manage People";

                case enPermissions.AddEditPerson:
                    return "Add/Edit Person";

                case enPermissions.DeletePerson:
                    return "Delete Person";

                case enPermissions.ManageUsers:
                    return "Manage Users";

                case enPermissions.AddEditUser:
                    return "Add/Edit User";

                case enPermissions.EditUserPassword:
                    return "Edit User Password";

                case enPermissions.DeleteUser:
                    return "Delete User";

                case enPermissions.ViewApplications:
                    return "View Applications";

                case enPermissions.ManageNewLocalDrivingLicenseApplications:
                    return "Manage New Local Driving License Applications";

                case enPermissions.EditApplicationType:
                    return "Edit Application Type";

                case enPermissions.EditApplicationTestType:
                    return "Edit Application Test Type";

                case enPermissions.DeleteApplication:
                    return "Delete Application";

                case enPermissions.CancellApplication:
                    return "Cancel Application";

                case enPermissions.ManageLocalLicenses:
                    return "Manage Local Licenses";

                case enPermissions.ViewDrivers:
                    return "View Drivers";

                case enPermissions.IssueNewDrivingLicense:
                    return "Issue New Driving License";

                case enPermissions.RenewLicense:
                    return "Renew License";

                case enPermissions.ReplaceDamagedOrLostLicense:
                    return "Replace Damaged or Lost License";

                case enPermissions.ViewLocalLicense:
                    return "View Local License";

                case enPermissions.ViewLicenseHistory:
                    return "View License History";

                case enPermissions.ManageInternationalLicenses:
                    return "Manage International Licenses";

                case enPermissions.IssueInternationalLicense:
                    return "Issue International License";

                case enPermissions.ViewInternationalLicense:
                    return "View International License";

                case enPermissions.ManageTestAppointments:
                    return "Manage Test Appointments";

                case enPermissions.ScheduleTest:
                    return "Schedule Test";

                case enPermissions.TakeTest:
                    return "Take Test";

                case enPermissions.ManageDetainLicenseScreen:
                    return "Manage Detained Licenses";

                case enPermissions.DetainLicense:
                    return "Detain License";

                case enPermissions.ReleaseLicense:
                    return "Release License";

                case enPermissions.ViewDetainedLicenses:
                    return "View Detained Licenses";

                case enPermissions.ManageApplicationTypes:
                    return "Manage Application Types";

                case enPermissions.ManageTestTypes:
                    return "Manage Test Types";

                default:
                    return "No Permission";
            }
        }

        /// <summary>
        /// Calculates the permission bitmask representing all available permissions.
        /// </summary>
        /// <returns>
        /// A long value containing all defined permission flags combined.
        /// </returns>
        private long _AdminPermissisonNumber()
        {
            long Permissions = 0;

            foreach (enPermissions Permission in Enum.GetValues(
                typeof(enPermissions)))
            {
                Permissions |= (long)Permission;
            }

            return Permissions;
        }

        /// <summary>
        /// Determines whether the current permission record grants all available
        /// permissions.
        /// </summary>
        /// <returns>
        /// true if all defined permissions are granted; otherwise, false.
        /// </returns>
        /// 

        public bool IsAdmin()
        {
            return Permisions == _AdminPermissisonNumber();
        }

        /// <summary>
        /// Determines whether the currently logged-in user has all available
        /// permissions.
        /// </summary>
        /// <returns>
        /// true if the current user exists, has permission information,
        /// and possesses all defined permissions; otherwise, false.
        /// </returns>
        public bool IsAdminLoged()
        {
            return clsGlobalUserInfo.CurrentLogInUser != null &&
                   clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo != null &&
                   clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.Permisions
                   == _AdminPermissisonNumber();
        }

        /// <summary>
        /// Stores the list of individual permissions supported by the application.
        /// This list is used to retrieve the permissions assigned to a user.
        /// </summary>
        private List<enPermissions> PermissionsList = new List<enPermissions>
{
    enPermissions.None,

    // People
    enPermissions.ManagePeople,
    enPermissions.AddEditPerson,
    enPermissions.DeletePerson,

    // Users
    enPermissions.ManageUsers,
    enPermissions.AddEditUser,
    enPermissions.EditUserPassword,
    enPermissions.DeleteUser,

    // Applications
    enPermissions.ViewApplications,
    enPermissions.ManageNewLocalDrivingLicenseApplications,
    enPermissions.EditApplicationType,
    enPermissions.EditApplicationTestType,
    enPermissions.DeleteApplication,
    enPermissions.CancellApplication,

    // Local Licenses
    enPermissions.ManageLocalLicenses,
    enPermissions.ViewDrivers,
    enPermissions.IssueNewDrivingLicense,
    enPermissions.RenewLicense,
    enPermissions.ReplaceDamagedOrLostLicense,
    enPermissions.ViewLocalLicense,
    enPermissions.ViewLicenseHistory,

    // International Licenses
    enPermissions.ManageInternationalLicenses,
    enPermissions.IssueInternationalLicense,
    enPermissions.ViewInternationalLicense,

    // Tests
    enPermissions.ManageTestAppointments,
    enPermissions.ScheduleTest,
    enPermissions.TakeTest,

    // Detained Licenses
    enPermissions.ManageDetainLicenseScreen,
    enPermissions.DetainLicense,
    enPermissions.ReleaseLicense,
    enPermissions.ViewDetainedLicenses,

    // System
    enPermissions.ManageApplicationTypes,
    enPermissions.ManageTestTypes
};

        /// <summary>
        /// Retrieves the display names of all permissions granted to the current user.
        /// </summary>
        /// <returns>
        /// A list of strings containing the display names of the user's permissions.
        /// </returns>
        public List<string> GetUserPermissionsList()
        {
            List<string> UserPermissions = new List<string>();

            foreach (enPermissions Permission in PermissionsList)
            {
                if (Permission == enPermissions.None)
                    continue;
                if (HasPermissionFor(Permission))
                {
                    UserPermissions.Add(PermisisonsString(Permission));
                }
            }

            return UserPermissions;
        }
    }
}