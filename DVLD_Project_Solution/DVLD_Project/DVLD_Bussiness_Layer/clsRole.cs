
using DVLD_Data_Access_Layer;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Provides business logic for managing system roles,
    /// including role creation, retrieval, updating, and user counts.
    /// </summary>
    public class clsRole
    {
        /// <summary>
        /// Gets or sets the unique identifier of the role.
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the permissions assigned to the role.
        /// </summary>
        public long Permissions { get; set; }

        /// <summary>
        /// Gets or sets the description of the role.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Specifies the persistence mode of a role.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Represents a new role that has not yet been saved.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Represents an existing role that can be updated.
            /// </summary>
            Update = 1
        }

        /// <summary>
        /// Gets or sets the current persistence mode of the role.
        /// Defaults to AddNew.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Defines the predefined roles available in the system.
        /// Each value identifies a specific role.
        /// </summary>
        public enum enRoles
        {
            /// <summary>
            /// Represents no assigned role.
            /// </summary>
            None = 0,

            /// <summary>
            /// Represents the system administrator role.
            /// </summary>
            SystemAdministrator = 1,

            /// <summary>
            /// Represents the user management role.
            /// </summary>
            UserManager = 2,

            /// <summary>
            /// Represents the people management role.
            /// </summary>
            PeopleManager = 3,

            /// <summary>
            /// Represents the application management role.
            /// </summary>
            ApplicationManager = 4,

            /// <summary>
            /// Represents the local driving license officer role.
            /// </summary>
            LocalLicenseOfficer = 5,

            /// <summary>
            /// Represents the international driving license officer role.
            /// </summary>
            InternationalLicenseOfficer = 6,

            /// <summary>
            /// Represents the test management role.
            /// </summary>
            TestManager = 7,

            /// <summary>
            /// Represents the application and test officer role.
            /// </summary>
            ApplicationAndTestOfficer = 8,

            /// <summary>
            /// Represents the license detention management role.
            /// </summary>
            DetentionOfficer = 9,

            /// <summary>
            /// Represents the application type management role.
            /// </summary>
            ApplicationTypeManager = 10,

            /// <summary>
            /// Represents the test type management role.
            /// </summary>
            TestTypeManager = 11,

            /// <summary>
            /// Represents the application type and test type management role.
            /// </summary>
            ApplicationTypesAndTestTypesManager = 12,

            /// <summary>
            /// Represents the receptionist role.
            /// </summary>
            Receptionist = 13,

            /// <summary>
            /// Represents the license service officer role.
            /// </summary>
            LicenseServiceOfficer = 14,

            /// <summary>
            /// Represents the test examiner role.
            /// </summary>
            TestExaminer = 15,

            /// <summary>
            /// Represents the test appointment management role.
            /// </summary>
            TestAppointmentOfficer = 16,

            /// <summary>
            /// Represents the license viewing role.
            /// </summary>
            LicenseViewer = 17,

            /// <summary>
            /// Represents the application viewing role.
            /// </summary>
            ApplicationViewer = 18
        }

        /// <summary>
        /// Initializes a new role in AddNew mode with default values.
        /// </summary>
        public clsRole()
        {
            RoleID = -1;
            RoleName = "";
            Permissions = 0;
            Description = "";
            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing role with the specified information.
        /// </summary>
        /// <param name="roleID">The unique identifier of the role.</param>
        /// <param name="roleName">The name of the role.</param>
        /// <param name="permissions">The permissions assigned to the role.</param>
        /// <param name="description">The description of the role.</param>
        public clsRole(
            int roleID,
            string roleName,
            long permissions,
            string description)
        {
            RoleID = roleID;
            RoleName = roleName;
            Permissions = permissions;
            Description = description;
            Mode = enMode.Update;
        }

        /// <summary>
        /// Retrieves all roles stored in the database.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with all role records.
        /// </returns>
        public static Task<DataTable> GetAllRolesAsync()
        {
            return clsRoleData.GetAllRolesAsync();
        }

        /// <summary>
        /// Retrieves the number of users assigned to each role.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with role IDs and their corresponding user counts.
        /// </returns>
        public static Task<DataTable> GetRolesUsersCountAsync()
        {
            return clsRoleData.GetRolesUsersCountAsync();
        }

        /// <summary>
        /// Finds a role using its unique identifier.
        /// </summary>
        /// <param name="RoleID">The unique identifier of the role.</param>
        /// <returns>
        /// A task containing the role if found; otherwise, null.
        /// </returns>
        public static async Task<clsRole> FindAsync(int RoleID)
        {
            clsRoleData.clsRoleInfo Result =
                await clsRoleData.GetRoleInfoByIDAsync(RoleID);

            if (Result == null )
                return null;

            return new clsRole(
                RoleID,
                Result.RoleName,
                Result.Permissions,
                Result.Description);
        }

        public static clsRole Find(int RoleID)
        {
            clsRoleData.clsRoleInfo Result =
                 clsRoleData.GetRoleInfoByID(RoleID);

            if (Result == null )
                return null;

            return new clsRole(
                RoleID,
                Result.RoleName,
                Result.Permissions,
                Result.Description);
        }

        /// <summary>
        /// Finds a role using its name.
        /// </summary>
        /// <param name="RoleName">The name of the role to find.</param>
        /// <returns>
        /// A task containing the role if found; otherwise, null.
        /// </returns>
        public static async Task<clsRole> FindAsync(string RoleName)
        {
            clsRoleData.clsRoleInfo Result =
                await clsRoleData.GetRoleInfoByNameAsync(RoleName);

            if (Result == null)
                return null;

            return new clsRole(
                Result.RoleID,
                RoleName,
                Result.Permissions,
                Result.Description);
        }

        public static clsRole  Find(string RoleName)
        {
            clsRoleData.clsRoleInfo Result =
                 clsRoleData.GetRoleInfoByName(RoleName);

            if (Result == null )
                return null;

            return new clsRole(
                Result.RoleID,
                RoleName,
                Result.Permissions,
                Result.Description);
        }


        /// <summary>
        /// Adds a new role to the database.
        /// </summary>
        /// <returns>
        /// A task containing the new role ID, or -1 if insertion fails.
        /// </returns>
        private async Task<bool> _AddNewRoleAsync()
        {
            RoleID = await clsRoleData.AddNewRoleAsync(
                RoleName,
                Permissions,
                Description);

            return RoleID != -1;
        }

        /// <summary>
        /// Updates an existing role in the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the update affects at least one row;
        /// otherwise, false.
        /// </returns>
        private Task<bool> _UpdateRoleAsync()
        {
            return clsRoleData.UpdateRoleAsync(
                RoleID,
                RoleName,
                Permissions,
                Description);
        }

        /// <summary>
        /// Saves the role according to its current persistence mode.
        /// Creates a new role in AddNew mode or updates an existing role
        /// in Update mode.
        /// </summary>
        /// <returns>
        /// A task containing true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewRoleAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:
                    return await _UpdateRoleAsync();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Retrieves the total number of roles stored in the database.
        /// </summary>
        /// <returns>
        /// A task containing the total number of roles.
        /// </returns>
        public static Task<int> GetRolesCountAsync()
        {
            return clsRoleData.GetRolesCountAsync();
        }

        /// <summary>
        /// Retrieves the number of users associated with the roles
        /// defined by the user management layer.
        /// </summary>
        /// <returns>
        /// A task containing the number of users associated with the defined roles.
        /// </returns>
        public Task<int> GetRoleUsersCountAsync()
        {
            return clsUser.GetRolesDefinedUsersCountAsync();
        }
    }
}