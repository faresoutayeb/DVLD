using DVLD_Data_Access_Layer;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer
{

    /// <summary>
    /// Represents a user login session and provides operations for managing
    /// user login records, retrieving login history, and tracking active sessions.
    /// </summary>
    public class clsUserLog
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user login record.
        /// </summary>
        public int UserLoginID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user associated with the login record.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user logged in.
        /// </summary>
        public DateTime LoginDateTime { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user logged out.
        /// Null indicates that no logout time has been recorded.
        /// </summary>
        public DateTime? LogoutDateTime { get; set; }

        /// <summary>
        /// Specifies whether the login record is new or already exists in the database.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Indicates that a new login record will be created.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates that an existing login record will be updated.
            /// </summary>
            Update = 1
        }

        /// <summary>
        /// Gets or sets the current operation mode of the login record.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Initializes a new instance of the <see cref="clsUserLog"/> class
        /// with default values for a new login record.
        /// </summary>
        public clsUserLog()
        {
            UserLoginID = -1;
            UserID = -1;
            LoginDateTime = DateTime.MinValue;
            LogoutDateTime = null;
            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="clsUserLog"/> class
        /// using the specified login record information.
        /// </summary>
        /// <param name="UserLoginID">The unique identifier of the login record.</param>
        /// <param name="UserID">The unique identifier of the associated user.</param>
        /// <param name="LoginDateTime">The date and time of the login.</param>
        /// <param name="LogoutDateTime">
        /// The date and time of the logout, or null if no logout time is recorded.
        /// </param>
        public clsUserLog(
            int UserLoginID,
            int UserID,
            DateTime LoginDateTime,
            DateTime? LogoutDateTime)
        {
            this.UserLoginID = UserLoginID;
            this.UserID = UserID;
            this.LoginDateTime = LoginDateTime;
            this.LogoutDateTime = LogoutDateTime;
            Mode = enMode.Update;
        }

        /// <summary>
        /// Saves the current login record by inserting a new record or updating
        /// an existing record according to <see cref="Mode"/>.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the record was saved successfully; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if(await _AddNewLogAsync())
                        {
                            Mode = enMode.Update;
                                return true;
                        }
                            return false;

                
                    }

                case enMode.Update:
                    return await _UpdateLogAsync();

                default:
                    return false;
            }
        }

        /// <summary>
        /// get logs info to display in the logs screen.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with all login records.
        /// </returns>
        public static Task<DataTable> GetAllLogsAsync()
        {
            return clsUserLogData.GetAllLogsAsync();
        }


        /// <summary>
        /// Retrieves login history information for all users asynchronously.
        /// </summary>
        /// <returns>
        /// A task containing a <see cref="DataTable"/> with user login records,
        /// including username, login date and time, logout date and time,
        /// and session duration.
        /// </returns>
        public static Task<DataTable> GetLogsInfoAsync()
        {
            return clsUserLogData.GetLogsInfoAsync();
        }


        /// <summary>
        /// Retrieves all login records associated with the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with the user's login records.
        /// </returns>
        public static Task<DataTable> GetLogsByUserIDAsync(int UserID)
        {
            return clsUserLogData.GetLogsByUserIDAsync(UserID);
        }

        /// <summary>
        /// Retrieves login records associated with the specified username.
        /// </summary>
        /// <param name="UserName">The username used to filter login records.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with the matching login records.
        /// </returns>
        public static Task<DataTable> GetLogsByUsernameAsync(string UserName)
        {
            return clsUserLogData.GetLogsByUsernameAsync(UserName);
        }

        /// <summary>
        /// Retrieves a login record using its unique identifier.
        /// </summary>
        /// <param name="UserLoginID">The unique identifier of the login record.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// matching <see cref="clsUserLog"/> if found; otherwise, null.
        /// </returns>
        public static async Task<clsUserLog> FindAsync(int UserLoginID)
        {
            clsUserLogData.clsUserLogInfo Result =
                await clsUserLogData.FindAsync(UserLoginID);

            if (Result != null)
            {
                return new clsUserLog(
                    UserLoginID,
                    Result.UserID,
                    Result.LoginDateTime,
                    Result.LogoutDateTime);
            }

            return null;
        }

        public static clsUserLog Find(int UserLoginID)
        {
            clsUserLogData.clsUserLogInfo Result =
                 clsUserLogData.Find(UserLoginID);

            if (Result  != null)
            {
                return new clsUserLog(
                    UserLoginID,
                    Result.UserID,
                    Result.LoginDateTime,
                    Result.LogoutDateTime);
            }

            return null;
        }


        /// <summary>
        /// Retrieves the most recent login record for the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// latest <see cref="clsUserLog"/> if found; otherwise, null.
        /// </returns>
        public static async Task<clsUserLog> FindLastLoginAsync(int UserID)
        {
            clsUserLogData.clsUserLogInfo Result =
                await clsUserLogData.FindLastLogByUserIDAsync(UserID);

            if (Result != null)
            {
                return new clsUserLog(
                    Result.UserLoginID,
                    Result.UserID,
                    Result.LoginDateTime,
                    Result.LogoutDateTime);
            }

            return null;
        }

        public static clsUserLog FindLastLogin(int UserID)
        {
            clsUserLogData.clsUserLogInfo Result =
                 clsUserLogData.FindLastLogByUserID(UserID);

            if (Result != null)
            {
                return new clsUserLog(
                    Result.UserLoginID,
                    Result.UserID,
                    Result.LoginDateTime,
                    Result.LogoutDateTime);
            }

            return null;
        }


        /// <summary>
        /// Creates a new login record in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// identifier of the newly created login record, or -1 if creation fails.
        /// </returns>
        private async Task<bool> _AddNewLogAsync()
        {
            this.UserLoginID=  await clsUserLogData.AddNewLogAsync(
                UserID,
                LoginDateTime,
                LogoutDateTime);
            return (this.UserLoginID !=-1);

        }

        /// <summary>
        /// Updates the existing login record in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the record was updated successfully; otherwise, false.
        /// </returns>
        private Task<bool> _UpdateLogAsync()
        {
            return clsUserLogData.UpdateLogAsync(
                UserLoginID,
                UserID,
                LoginDateTime,
                LogoutDateTime);
        }

        /// <summary>
        /// Retrieves the total number of login records.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// total number of login records.
        /// </returns>
        public static Task<int> GetAllLogsCountAsync()
        {
            return clsUserLogData.GetAllLogsCountAsync();
        }

        /// <summary>
        /// Retrieves the total number of login records for the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of login records associated with the user.
        /// </returns>
        public static Task<int> GetUserLogsCountAsync(int UserID)
        {
            return clsUserLogData.GetUserLogsCountAsync(UserID);
        }

        /// <summary>
        /// Retrieves the total number of login records created today.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of logins recorded today.
        /// </returns>
        public static Task<int> GetTotalLoginsTodayAsync()
        {
            return clsUserLogData.GetTotalLoginsTodayAsync();
        }

        /// <summary>
        /// Retrieves the number of login records within the specified date range.
        /// </summary>
        /// <param name="StartDate">The beginning of the date range.</param>
        /// <param name="EndDate">The end of the date range.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of login records within the specified period.
        /// </returns>
        public static Task<int> GetLogsCountByPeriodAsync(
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsUserLogData.GetLogsCountByPeriodAsync(
                StartDate,
                EndDate);
        }

        /// <summary>
        /// Retrieves the number of login records for a specific user within
        /// the specified date range.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <param name="StartDate">The beginning of the date range.</param>
        /// <param name="EndDate">The end of the date range.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of the user's login records within the specified period.
        /// </returns>
        public static Task<int> GetUserLogsCountByPeriodAsync(
            int UserID,
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsUserLogData.GetUserLogsCountByPeriodAsync(
                UserID,
                StartDate,
                EndDate);
        }

        /// <summary>
        /// Retrieves the number of currently active user sessions.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// number of active sessions.
        /// </returns>
        public static Task<int> GetActiveSessionsCountAsync()
        {
            return clsUserLogData.GetActiveSessionsCountAsync();
        }
    }
}

