using DVLD_Data_Access_Layer;
using System;
using System.Data;
using System.Threading.Tasks;
namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Represents a user account lock record and provides operations
    /// for creating, updating, retrieving, and tracking locked accounts.
    /// </summary>
    public class clsLock
    {
        /// <summary>
        /// Specifies whether a lock record is being created or updated.
        /// </summary>
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        /// <summary>
        /// Gets or sets the current operation mode of the lock record.
        /// </summary>
        public enMode _Mode = enMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the locked user account record.
        /// </summary>
        public int LockedUserAccountID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user whose account was locked.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets the date and time when the account was locked.
        /// </summary>
        public DateTime LockedDateTime { get; private set; }

        /// <summary>
        /// Gets or sets the date and time when the account was unlocked.
        /// A null value indicates that no unlock date has been recorded.
        /// </summary>
        public DateTime? UnlockedDateTime { get; set; }

        // Lazy loading

        private clsUser _LockedUserInfo;

        /// <summary>
        /// Gets or sets the user information associated with this lock record.
        /// The user information is retrieved when first accessed if it has
        /// not already been loaded and the user ID is valid.
        /// </summary>
        public clsUser LockedUserInfo
        {
            get
            {
                if (_LockedUserInfo == null && UserID > 0)
                {
                    _LockedUserInfo =
                        clsUser.FindByUserID(UserID);
                }

                return _LockedUserInfo;
            }
            set
            {
                _LockedUserInfo = value;
            }
        }

        /// <summary>
        /// Initializes a new lock record with default values.
        /// The record is initialized in AddNew mode.
        /// </summary>
        public clsLock()
        {
            LockedUserAccountID = -1;
            UserID = -1;
            LockedDateTime = DateTime.Now;
            UnlockedDateTime = null;

            _Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing lock record with the specified values.
        /// The record is initialized in Update mode.
        /// </summary>
        /// <param name="LockedUserAccountID">
        /// The unique identifier of the lock record.
        /// </param>
        /// <param name="UserID">
        /// The identifier of the locked user.
        /// </param>
        /// <param name="LockedDateTime">
        /// The date and time when the account was locked.
        /// </param>
        /// <param name="UnlockedDateTime">
        /// The date and time when the account was unlocked, or null if
        /// no unlock date has been recorded.
        /// </param>
        private clsLock(
            int LockedUserAccountID,
            int UserID,
            DateTime LockedDateTime,
            DateTime? UnlockedDateTime)
        {
            this.LockedUserAccountID = LockedUserAccountID;
            this.UserID = UserID;
            this.LockedDateTime = LockedDateTime;
            this.UnlockedDateTime = UnlockedDateTime;

            _Mode = enMode.Update;
        }

        /// <summary>
        /// Creates a new lock record in the database.
        /// Updates LockedUserAccountID with the generated record ID.
        /// </summary>
        /// <returns>
        /// A task containing true if the lock record is created successfully;
        /// otherwise, false.
        /// </returns>
        private async Task<bool> AddNewLockAsync()
        {
            LockedUserAccountID =
                await clsLockData.AddNewAsync(
                    UserID,
                    UnlockedDateTime);

            return LockedUserAccountID != -1;
        }

        /// <summary>
        /// Updates an existing lock record in the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the record is updated successfully;
        /// otherwise, false.
        /// </returns>
        private Task<bool> UpdateLockAsync()
        {
            return clsLockData.UpdateAsync(
                LockedUserAccountID,
                UserID,
                UnlockedDateTime);
        }

        /// <summary>
        /// Retrieves a lock record by its unique identifier.
        /// </summary>
        /// <param name="LockedUserAccountID">
        /// The unique identifier of the lock record to retrieve.
        /// </param>
        /// <returns>
        /// A task containing the matching clsLock object, or null if
        /// no matching record is found.
        /// </returns>
        public static async Task<clsLock> FindAsync(
            int LockedUserAccountID)
        {
            clsLockData.clsLockInfo Result =
                await clsLockData.FindAsync(LockedUserAccountID);

            if (Result != null)
            {
                return new clsLock(
                    Result.LockedUserAccountID,
                    Result.UserID,
                    Result.LockedDateTime,
                    Result.UnlockedDateTime);
            }

            return null;
        }

        public static clsLock Find(
    int LockedUserAccountID)
        {
            clsLockData.clsLockInfo Result =
                 clsLockData.Find(LockedUserAccountID);

            if (Result != null)
            {
                return new clsLock(
                    Result.LockedUserAccountID,
                    Result.UserID,
                    Result.LockedDateTime,
                    Result.UnlockedDateTime);
            }

            return null;
        }


        /// <summary>
        /// Saves the current lock record by creating a new record or
        /// updating an existing one, depending on the current mode.
        /// </summary>
        /// <returns>
        /// A task containing true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await AddNewLockAsync())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:
                    return await UpdateLockAsync();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Retrieves all lock records.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with all lock records.
        /// </returns>
        public static Task<DataTable> GetAllLocksAsync()
        {
            return clsLockData.GetAllAsync();
        }

        /// <summary>
        /// Retrieves all lock records associated with a specific user.
        /// </summary>
        /// <param name="UserID">
        /// The identifier of the user whose lock records are requested.
        /// </param>
        /// <returns>
        /// A task containing a DataTable with the user's lock records.
        /// </returns>
        public static Task<DataTable> GetAllLocksByUserIDAsync(
            int UserID)
        {
            return clsLockData.GetAllByUserIDAsync(UserID);
        }

        /// <summary>
        /// Retrieves all lock records associated with a specific username.
        /// </summary>
        /// <param name="UserName">
        /// The username whose lock records are requested.
        /// </param>
        /// <returns>
        /// A task containing a DataTable with the matching lock records.
        /// </returns>
        public static Task<DataTable> GetAllLocksByUsernameAsync(
            string UserName)
        {
            return clsLockData.GetAllByUsernameAsync(UserName);
        }

        /// <summary>
        /// Retrieves records for users who are currently locked.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with currently locked users.
        /// </returns>
        public static Task<DataTable> GetCurrentlyLockedUsersAsync()
        {
            return clsLockData.GetCurrentlyLockedUsersAsync();
        }

        /// <summary>
        /// Retrieves the total number of lock records.
        /// </summary>
        /// <returns>
        /// A task containing the total number of lock records.
        /// </returns>
        public static Task<int> GetAllLocksCountAsync()
        {
            return clsLockData.GetAllLocksCountAsync();
        }

        /// <summary>
        /// Retrieves the total number of lock records associated with a user.
        /// </summary>
        /// <param name="UserID">
        /// The identifier of the user whose lock records are counted.
        /// </param>
        /// <returns>
        /// A task containing the number of lock records for the specified user.
        /// </returns>
        public static Task<int> GetUserLocksCountAsync(int UserID)
        {
            return clsLockData.GetUserLocksCountAsync(UserID);
        }

        /// <summary>
        /// Retrieves the number of users who are currently locked.
        /// </summary>
        /// <returns>
        /// A task containing the number of currently locked users.
        /// </returns>
        public static Task<int> GetCurrentlyLockedUsersCountAsync()
        {
            return clsLockData.GetCurrentlyLockedUsersCountAsync();
        }

        /// <summary>
        /// Retrieves the number of users whose lock records indicate
        /// that they have been unlocked.
        /// </summary>
        /// <returns>
        /// A task containing the number of unlocked users.
        /// </returns>
        public static Task<int> GetUnlockedUsersCountAsync()
        {
            return clsLockData.GetUnlockedUsersCountAsync();
        }

        /// <summary>
        /// Retrieves the number of lock records created within a specified
        /// date and time range.
        /// </summary>
        /// <param name="StartDate">
        /// The beginning of the date and time range.
        /// </param>
        /// <param name="EndDate">
        /// The end of the date and time range.
        /// </param>
        /// <returns>
        /// A task containing the number of lock records within the range.
        /// </returns>
        public static Task<int> GetLocksCountByPeriodAsync(
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsLockData.GetLocksCountByPeriodAsync(
                StartDate,
                EndDate);
        }

        /// <summary>
        /// Retrieves the number of lock records for a specific user
        /// within a specified date and time range.
        /// </summary>
        /// <param name="UserID">
        /// The identifier of the user whose lock records are counted.
        /// </param>
        /// <param name="StartDate">
        /// The beginning of the date and time range.
        /// </param>
        /// <param name="EndDate">
        /// The end of the date and time range.
        /// </param>
        /// <returns>
        /// A task containing the number of matching lock records.
        /// </returns>
        public static Task<int> GetUserLocksCountByPeriodAsync(
            int UserID,
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsLockData.GetUserLocksCountByPeriodAsync(
                UserID,
                StartDate,
                EndDate);
        }

        /// <summary>
        /// Retrieves the number of lock records associated with a specific
        /// username within a specified date and time range.
        /// </summary>
        /// <param name="UserName">
        /// The username whose lock records are counted.
        /// </param>
        /// <param name="StartDate">
        /// The beginning of the date and time range.
        /// </param>
        /// <param name="EndDate">
        /// The end of the date and time range.
        /// </param>
        /// <returns>
        /// A task containing the number of matching lock records.
        /// </returns>
        public static Task<int> GetUserLocksCountByUsernameAndPeriodAsync(
            string UserName,
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsLockData.GetUserLocksCountByUsernameAndPeriodAsync(
                UserName,
                StartDate,
                EndDate);
        }

        /// <summary>
        /// Retrieves the number of lock records created today.
        /// </summary>
        /// <returns>
        /// A task containing the number of lock records created today.
        /// </returns>
        public static Task<int> GetTodayLocksCountAsync()
        {
            return clsLockData.GetTodayLocksCountAsync();
        }

        /// <summary>
        /// Retrieves the number of lock records created during the current month.
        /// </summary>
        /// <returns>
        /// A task containing the number of lock records created this month.
        /// </returns>
        public static Task<int> GetThisMonthLocksCountAsync()
        {
            return clsLockData.GetThisMonthLocksCountAsync();
        }

        /// <summary>
        /// Determines whether a specific user's account is currently locked.
        /// </summary>
        /// <param name="UserID">
        /// The identifier of the user whose account status is checked.
        /// </param>
        /// <returns>
        /// A task containing true if the user's account is currently locked;
        /// otherwise, false.
        /// </returns>
        public static Task<bool> IsUserCurrentlyLockedAsync(int UserID)
        {
            return clsLockData.IsUserCurrentlyLockedAsync(UserID);
        }
    }
}