using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Bussiness_Layer.GlobalClasses;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Provides business logic for managing user accounts, including creating,
    /// updating, retrieving, and deleting users, managing permissions, and
    /// checking user account existence.
    /// </summary>
    public class clsUser
    {
        /// <summary>
        /// Specifies the operation mode of a user account.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Indicates that a new user account is being created.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates that an existing user account is being updated.
            /// </summary>
            Update = 1
        }

        /// <summary>
        /// Stores the current operation mode of the user account.
        /// </summary>
        private enMode _Mode = enMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the user account.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the person associated with the user account.
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// Gets or sets the username used to identify the user during login.
        /// </summary>
        [clsValidUsername(3, 20, "Username must be 3–20 characters and contain only letters, numbers, or underscores!")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user's password value.
        /// The password is hashed when a new user account is created.
        /// </summary>
        [clsValidPassword(6,100, "Password must contain at least 6 characters!")]
        public string Password { get; set; }

        public string PasswordSalt { set; get; }

        /// <summary>
        /// Gets or sets a value indicating whether the user account is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the role assigned to the user.
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user account is locked.
        /// </summary>
        public bool IsLock { get; set; }

        /// <summary>
        /// Gets the date and time when the user account was created.
        /// </summary>
        public DateTime SignUpDateTime { get; private set; }

        /// <summary>
        /// Stores the role information associated with the user.
        /// </summary>
        public clsRole _RoleInfo;

        /// <summary>
        /// Gets or sets the role information associated with the user.
        /// The role information is loaded lazily when first accessed.
        /// </summary>
        public clsRole RoleInfo
        {
            get
            {
                if (_RoleInfo == null && RoleID > 0)
                    _RoleInfo = clsRole.Find(RoleID);

                return _RoleInfo;
            }
            set
            {
                _RoleInfo = value;
            }
        }

        /// <summary>
        /// Stores the person information associated with the user.
        /// </summary>
        private clsPerson _PersonInfo;

        /// <summary>
        /// Gets the person information associated with the user.
        /// The information is loaded lazily when first accessed.
        /// </summary>
        public clsPerson PersonInfo
        {
            get
            {
                if (_PersonInfo == null && PersonID > 0)
                    _PersonInfo = clsPerson.Find(PersonID);

                return _PersonInfo;
            }
            private set
            {
                _PersonInfo = value;
            }
        }

        /// <summary>
        /// Stores the permission information associated with the user.
        /// </summary>
        private clsUserPermissions _UserPermissionsInfo;

        /// <summary>
        /// Gets or sets the user's permission information.
        /// The information is loaded lazily when first accessed.
        /// </summary>
        public clsUserPermissions UserPermissionsInfo
        {
            get
            {
                if (_UserPermissionsInfo == null && UserID > 0)
                    _UserPermissionsInfo = clsUserPermissions.FindByUserID(UserID);

                return _UserPermissionsInfo;
            }
            set
            {
                _UserPermissionsInfo = value;
            }
        }
        /// <summary>
        /// Initializes a new user account with default values.
        /// The account is initialized in AddNew mode.
        /// </summary>
        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = true;
            PersonInfo = null;
            UserPermissionsInfo = null;
            RoleID = -1;
            IsLock = false;

            _Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing user account with the specified information.
        /// The account is initialized in Update mode.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user account.</param>
        /// <param name="PersonID">The identifier of the associated person.</param>
        /// <param name="UserName">The username of the account.</param>
        /// <param name="Password">The stored password value.</param>
        /// <param name="IsActive">Indicates whether the account is active.</param>
        /// <param name="RoleID">The identifier of the assigned role.</param>
        /// <param name="IsLock">Indicates whether the account is locked.</param>
        /// <param name="SignUpDateTime">The date and time the account was created.</param>
        private clsUser(
            int UserID,
            int PersonID,
            string UserName,
            string Password,
            bool IsActive,
            int RoleID,
            bool IsLock,
            DateTime SignUpDateTime)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.RoleID = RoleID;
            this.IsLock = IsLock;
            this.SignUpDateTime = SignUpDateTime;

            UserPermissionsInfo = clsUserPermissions.FindByUserID(UserID);

            _Mode = enMode.Update;
        }

        /// <summary>
        /// Creates a new user account in the database.
        /// The password is hashed before being stored.
        /// </summary>
        /// <returns>
        /// A task containing true if the account is created successfully;
        /// otherwise, false.
        /// </returns>
        private async Task<bool> _AddNewUserAsync()
        {
            string PasswordSalt;

            string PasswordHash = clsSecurity.HashPassword(
                Password, out PasswordSalt);

            this.UserID = await DVLD_Data_Access_Layer.clsUserData.AddNewUserAsync(
                PersonID,
                UserName,
                PasswordHash,
                PasswordSalt,
                IsActive,
                IsLock
            );

            return UserID != -1;
        }
        private const byte  MinimaumAgeRequired= 18;
        public bool IsValidUserAge()
        {
            return clsValidation.IsValidAge(PersonInfo.DateOfBirth, MinimaumAgeRequired);
        }
        /// <summary>
        /// Updates the existing user account in the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the update succeeds; otherwise, false.
        /// </returns>
        private Task<bool> _UpdateUserAsync()
        {
            return DVLD_Data_Access_Layer.clsUserData.UpdateUserAsync(
                UserID,
                PersonID,
                UserName,
                IsActive,
                RoleID,
                IsLock
            );
        }

        /// <summary>
        /// Retrieves a user account using its unique identifier.
        /// </summary>
        /// <param name="UserID">The identifier of the user account.</param>
        /// <returns>
        /// A task containing the matching user account if found; otherwise, null.
        /// </returns>
        public static async Task<clsUser> FindByUserIDAsync(int UserID)
        {
            clsUserData.clsUserInfo Result =await DVLD_Data_Access_Layer.clsUserData .GetUserInfoByUserIDAsync(UserID);

            if (Result == null)
                return null;

            return new clsUser(
                Result.UserID,
                Result.PersonID,
                Result.UserName,
                Result.Password,
                Result.IsActive,
                Result.RoleID.Value,
                Result.IsLocked,
                Result.SignUpDateTime
            );
        }

        public static clsUser FindByUserID(int UserID)
        {
            clsUserData.clsUserInfo Result =
                 DVLD_Data_Access_Layer.clsUserData
                    .GetUserInfoByUserID(UserID);

            if (Result == null)
                return null;

            return new clsUser(
                Result.UserID,
                Result.PersonID,
                Result.UserName,
                Result.Password,
                Result.IsActive,
                Result.RoleID.Value,
                Result.IsLocked,
                Result.SignUpDateTime
            );
        }

        /// <summary>
        /// Removes the current role's permissions from the user's permission set
        /// when those role permissions are present.
        /// </summary>
        public async void RemoveCurrentRolePermissionsNumberFromPermissions()
        {
            long[] RolePermitions = await  clsUserPermissions.GetListOfRolePermissions(this.RoleID);

            for (int i = 0; i < RolePermitions.Length; i++)
            {
                if ((RolePermitions[i] & UserPermissionsInfo.Permisions) == RolePermitions[i])
                {
                    UserPermissionsInfo.RemovePermission(
                        (clsUserPermissions.enPermissions)RolePermitions[i]);
                }
            }
        }

        /// <summary>
        /// Retrieves a user account using its username.
        /// </summary>
        /// <param name="UserName">The username to search for.</param>
        /// <returns>
        /// A task containing the matching user account if found; otherwise, null.
        /// </returns>
        public static async Task<clsUser> FindByUserNameAsync(string UserName)
        {
            clsUserData.clsUserInfo Result =
                await DVLD_Data_Access_Layer.clsUserData
                    .GetUserInfoByUserNameAsync(UserName);

            if (Result == null )
                return null;

            return new clsUser(
                Result.UserID,
                Result.PersonID,
                Result.UserName,
                Result.Password,
                Result.IsActive,
                Result.RoleID.Value,
                Result.IsLocked,
                Result.SignUpDateTime
            );
        }

        /// <summary>
        /// Retrieves a user account using the identifier of its associated person.
        /// </summary>
        /// <param name="PersonID">The identifier of the associated person.</param>
        /// <returns>
        /// A task containing the matching user account if found; otherwise, null.
        /// </returns>
        public static async Task<clsUser> FindByPersonIDAsync(int PersonID)
        {
            clsUserData.clsUserInfo Result =
                await DVLD_Data_Access_Layer.clsUserData
                    .GetUserInfoByPersonIDAsync(PersonID);

            if (Result == null)
                return null;

            return new clsUser(
                Result.UserID,
                Result.PersonID,
                Result.UserName,
                Result.Password,
                Result.IsActive,
                Result.RoleID.Value,
                Result.IsLocked,
                Result.SignUpDateTime
            );
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            clsUserData.clsUserInfo Result =
                 DVLD_Data_Access_Layer.clsUserData
                    .GetUserInfoByPersonID(PersonID);

            if (Result == null)
                return null;

            return new clsUser(
                Result.UserID,
                Result.PersonID,
                Result.UserName,
                Result.Password,
                Result.IsActive,
                Result.RoleID.Value,
                Result.IsLocked,
                Result.SignUpDateTime
            );
        }

        /// <summary>
        /// Retrieves a user account using the national number of its associated person.
        /// </summary>
        /// <param name="NationalNo">The national number to search for.</param>
        /// <returns>
        /// A task containing the matching user account if found; otherwise, null.
        /// </returns>
        public static async Task<clsUser> FindByNationalNoAsync(string NationalNo)
        {
            clsUserData.clsUserInfo Result =
                await DVLD_Data_Access_Layer.clsUserData
                    .GetUserInfoByNationalNoAsync(NationalNo);

            if (Result == null)
                return null;

            return new clsUser(
                Result.UserID,
                Result.PersonID,
                Result.UserName,
                Result.Password,
                Result.IsActive,
                Result.RoleID.Value,
                Result.IsLocked,
                Result.SignUpDateTime
            );
        }

        public static clsUser FindByNationalNo(string NationalNo)
        {
            clsUserData.clsUserInfo Result =
                 DVLD_Data_Access_Layer.clsUserData
                    .GetUserInfoByNationalNo(NationalNo);

            if (Result == null)
                return null;

            return new clsUser(
                Result.UserID,
                Result.PersonID,
                Result.UserName,
                Result.Password,
                Result.IsActive,
                Result.RoleID.Value,
                Result.IsLocked,
                Result.SignUpDateTime
            );
        }


        public static bool  GetUserLoginInfoByUsername(string UserName, ref string PasswordHash,ref string PasswordSalt)
        {
            return clsUserData.GetUserLoginInfoByUsername(UserName,ref PasswordHash, ref PasswordSalt);

        }

        public static clsUser FindByUserNameAndPassword(string UserName, string Password)
        {
            string StoredHash = "";
            string StoredSalt = "";

            if (!clsUserData.GetUserLoginInfoByUsername( UserName, ref StoredHash, ref StoredSalt))
                return null;

            if (!clsSecurity.VerifyPassword(Password, StoredHash, StoredSalt))
                return null;

            clsUserData.clsUserInfo Result =  clsUserData.GetUserInfoByUserName(UserName);

            if (Result == null)
                return null;

            return new clsUser(
                Result.UserID,
                Result.PersonID,
                Result.UserName,
                Result.Password,
                Result.IsActive,
                Result.RoleID.Value,
                Result.IsLocked,
                Result.SignUpDateTime
            );
        }

        //public static async Task<clsUser> GetLoginInfoByUserNameAsync(string UserName)
        //{

        //    clsUserData.clsUserInfo Result = await DVLD_Data_Access_Layer.clsUserData.GetUserInfoByUserNameAsync(UserName);

        //    if (Result == null)
        //        return null;

        //    return new clsUser(
        //        Result.UserID,
        //        Result.PersonID,
        //        Result.UserName,
        //        Result.Password,
        //        Result.IsActive,
        //        Result.RoleID.Value,
        //        Result.IsLocked,
        //        Result.SignUpDateTime
        //    );
        //}

        //public  async Task<clsUser> GetLoginInfoByUserNameAsync()
        //{

        //    clsUserData.clsUserInfo Result = await DVLD_Data_Access_Layer.clsUserData.GetUserInfoByUserNameAsync(this.UserName);

        //    if (Result == null)
        //        return null;

        //    return new clsUser(
        //        Result.UserID,
        //        Result.PersonID,
        //        Result.UserName,
        //        Result.Password,
        //        Result.IsActive,
        //        Result.RoleID.Value,
        //        Result.IsLocked,
        //        Result.SignUpDateTime
        //    );
        //}

        /// <summary>
        /// Saves the current user account according to its operation mode.
        /// Creates a new account in AddNew mode or updates an existing account
        /// in Update mode.
        /// </summary>
        /// <returns>
        /// A task containing true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewUserAsync())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:
                    return await _UpdateUserAsync();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Deletes a user account using its unique identifier.
        /// </summary>
        /// <param name="UserID">The identifier of the user account to delete.</param>
        /// <returns>
        /// A task containing true if the account is deleted successfully;
        /// otherwise, false.
        /// </returns>
        public static Task<bool> DeleteUserAsync(int UserID)
        {
            return DVLD_Data_Access_Layer.clsUserData.DeleteUserAsync(UserID);
        }

        /// <summary>
        /// Determines whether a user account exists using its unique identifier.
        /// </summary>
        /// <param name="UserID">The identifier of the user account.</param>
        /// <returns>
        /// A task containing true if the account exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsUserExistAsync(int UserID)
        {
            return DVLD_Data_Access_Layer.clsUserData.IsUserExistAsync(UserID);
        }

        /// <summary>
        /// Determines whether a username is already assigned to a user account.
        /// </summary>
        /// <param name="UserName">The username to check.</param>
        /// <returns>
        /// A task containing true if the username is already taken; otherwise, false.
        /// </returns>
        public static Task<bool> IsUserNameAlreadyTakenAsync(string UserName)
        {
            return DVLD_Data_Access_Layer.clsUserData
                .IsUserExistByUserNameAsync(UserName);
        }

        /// <summary>
        /// Determines whether a user account exists for the specified person.
        /// </summary>
        /// <param name="PersonID">The identifier of the person to check.</param>
        /// <returns>
        /// A task containing true if a user account exists for the person;
        /// otherwise, false.
        /// </returns>
        public static Task<bool> IsUserExistByPersonIdAsync(int PersonID)
        {
            return DVLD_Data_Access_Layer.clsUserData
                .IsUserExistByPersonIdAsync(PersonID);
        }

        /// <summary>
        /// Determines whether a user account exists with the specified username.
        /// </summary>
        /// <param name="UserName">The username to check.</param>
        /// <returns>
        /// A task containing true if a matching user account exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsUserExistByUserNameAsync(string UserName)
        {
            return DVLD_Data_Access_Layer.clsUserData
                .IsUserExistByUserNameAsync(UserName);
        }



        /// <summary>
        /// Retrieves user information for the user management screen.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// DataTable with user information.
        /// </returns>
        public static Task<DataTable> GetUserScreenUsersInfoAsync()
        {
            return DVLD_Data_Access_Layer.clsUserData.GetUsersScreenUsersInfoAsync();
        }

        /// <summary>
        /// Retrieves user and role information for the role management screen.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// DataTable with user and role information.
        /// </returns>
        public static Task<DataTable> GetRolesManagementAsync()
        {
            return DVLD_Data_Access_Layer.clsUserData.GetUsersRolesAsync();
        }

        /// <summary>
        /// Retrieves the username associated with the specified user ID.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// username associated with the specified user ID.
        /// </returns>
        public static Task<string> GetUserNameAsync(int UserID)
        {
            return DVLD_Data_Access_Layer.clsUserData.GetUserNameByIDAsync(UserID);
        }

        /// <summary>
        /// Retrieves the user ID associated with the specified username.
        /// </summary>
        /// <param name="UserName">The username to search for.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// corresponding user ID.
        /// </returns>
        public static Task<int> GetUserIDAsync(string UserName)
        {
            return DVLD_Data_Access_Layer.clsUserData.GetUserIDByUserNameAsync(UserName);
        }

        /// <summary>
        /// Retrieves the number of users assigned to the specified role.
        /// </summary>
        /// <param name="RoleID">The unique identifier of the role.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of users assigned to the role.
        /// </returns>
        public static Task<int> GetRoleUsersCountAsync(int RoleID)
        {
            return clsUser.GetRoleUsersCountAsync(RoleID);
        }

        /// <summary>
        /// Changes the current user's password after validating that the new
        /// password differs from the current password and has not been used
        /// previously.
        /// </summary>
        /// <param name="NewPassword">The new password to assign to the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the password was changed and the password history was saved
        /// successfully; otherwise, false.
        /// </returns>
        public async Task<bool> ChangePasswordAsync(string NewPassword)
        {
            string NewSalt;
            string NewHashPassword = clsSecurity.HashPassword(NewPassword, out NewSalt);

            // Check current password using its saved salt.
            if (clsSecurity.VerifyPassword(NewPassword, Password, NewSalt))
                return false;

            // Check password history.
            if (await clsPasswordHistory.IsPasswordUsedBeforeAsync(UserID, NewPassword))
                return false;

            if (await DVLD_Data_Access_Layer.clsUserData.ChangePasswordAsync( UserID, NewHashPassword, NewSalt))
            {
                clsPasswordHistory NewPassHistory = new clsPasswordHistory();

                NewPassHistory.UserID = UserID;
                NewPassHistory.Password = NewHashPassword;
                NewPassHistory.PasswordSalt = NewSalt;

                if (await NewPassHistory.SaveAsync())
                {
                   this.Password = NewHashPassword;
                    this.PasswordSalt = NewSalt;
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Determines whether the specified user account is active.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the user account is active; otherwise, false.
        /// </returns>
        public static Task<bool> IsActiveUserAsync(int UserID)
        {
            return clsUserData.IsActiveUserAsync(UserID);
        }

        /// <summary>
        /// Determines whether the user account associated with the specified
        /// username is active.
        /// </summary>
        /// <param name="UserName">The username to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the user account is active; otherwise, false.
        /// </returns>
        public static Task<bool> IsActiveUserAsync(string UserName)
        {
            return clsUserData.IsActiveUserAsync(UserName);
        }

        /// <summary>
        /// Retrieves the number of users who signed up within the specified
        /// date and time range.
        /// </summary>
        /// <param name="StartDateTime">The beginning of the date and time range.</param>
        /// <param name="EndDateTime">The end of the date and time range.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of users who signed up during the specified period.
        /// </returns>
        public static Task<int> GetUserCountSigUpInPeriodeAsync(
            DateTime StartDateTime,
            DateTime EndDateTime)
        {
            return clsUserData.GetUserCountSignUpBetweenAsync(
                StartDateTime, EndDateTime);
        }

        /// <summary>
        /// Retrieves the total number of active user accounts.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of active users.
        /// </returns>
        public static Task<int> GetActiveUserCountAsync()
        {
            return clsUserData.GetActiveUsersCountAsync();
        }

        /// <summary>
        /// Retrieves the total number of inactive user accounts.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of inactive users.
        /// </returns>
        public static Task<int> GetInActiveUserCountAsync()
        {
            return clsUserData.GetActiveUsersCountAsync(false);
        }

        /// <summary>
        /// Retrieves the total number of locked user accounts.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of locked users.
        /// </returns>
        public static Task<int> GetLockedUserCountAsync()
        {
            return clsUserData.GetLockedUsersCountAsync();
        }

        /// <summary>
        /// Retrieves the total number of unlocked user accounts.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of unlocked users.
        /// </returns>
        public static Task<int> GetUnLockedUserCountAsync()
        {
            return clsUserData.GetLockedUsersCountAsync(false);
        }

        /// <summary>
        /// Retrieves the total number of user accounts.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// total number of users.
        /// </returns>
        public static Task<int> GetAllUserCountAsync()
        {
            return clsUserData.GetAllUsersCountAsync();
        }

        /// <summary>
        /// Retrieves the number of users assigned to defined roles.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of users assigned to roles.
        /// </returns>
        public static Task<int> GetRolesDefinedUsersCountAsync()
        {
            return clsUserData.GetRolesDefinedUsersCountAsync();
        }


        /// <summary>
        /// Retrieves the total number of currently online users.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of online users.
        /// </returns>
        public static Task<int> GetOnlineUsersCountAsync()
        {
            return clsUserData.GetOnlineUsersCountAsync();
        }

        /// <summary>
        /// Retrieves the total number of users who have never logged in.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of users who have never logged in.
        /// </returns>
        public static Task<int> GetNeverLogedInUsersCountAsync()
        {
            return clsUserData.GetNeverLogedInUsersCountAsync();
        }

        /// <summary>
        /// Retrieves the date and time of the most recent user login.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// date and time of the most recent login.
        /// </returns>
        public static Task<DateTime> GetLastLogedInUserDateTimeAsync()
        {
            return clsUserData.GetLastLogedInUserDateTimeAsync();
        }

        /// <summary>
        /// Retrieves the last login date and time for the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// user's last login date and time.
        /// </returns>
        public static Task<DateTime> GetLastLogedInDateTimeAsync(int UserID)
        {
            return clsUserData.GetLastLogedInDateTimeAsync(UserID);
        }

        /// <summary>
        /// Retrieves the last login date and time for the current user instance.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// last login date and time for the current user.
        /// </returns>
        public Task<DateTime> GetLastLogedInDateTimeAsync()
        {
            return clsUserData.GetLastLogedInDateTimeAsync(UserID);
        }

        /// <summary>
        /// Determines whether the current user has administrator permissions.
        /// </summary>
        /// <returns>
        /// True if the current user has administrator permissions; otherwise,
        /// false.
        /// </returns>
        public bool IsAdmin()
        {
            return UserPermissionsInfo.IsAdmin();
        }

        /// <summary>
        /// Locks the current user's account and records the locking operation.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// ID of the created lock record if successful; otherwise, -1.
        /// </returns>
        public async Task<int> LockAsync()
        {
            int LockedUserAccountID = -1;

            IsLock = true;
            _Mode = enMode.Update;

            if (await SaveAsync())
            {
                clsLock NewLock = new clsLock();
                NewLock.UserID = UserID;

                if (await NewLock.SaveAsync())
                    LockedUserAccountID = NewLock.LockedUserAccountID;
            }

            return LockedUserAccountID;
        }

        /// <summary>
        /// Unlocks the current user's account and records the unlocking operation.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the account was unlocked and the unlocking record was saved
        /// successfully; otherwise, false.
        /// </returns>
        public async Task<bool> UnlockAsync()
        {
            IsLock = false;
            _Mode = enMode.Update;

            if (await SaveAsync())
            {
                clsLock NewLock = new clsLock();
                NewLock.UserID = UserID;
                NewLock.UnlockedDateTime = DateTime.Now;

                if (await NewLock.SaveAsync())
                    return true;
            }

            return false;
        }
    }
}