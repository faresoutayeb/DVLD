using DVLD_Data_Access_Layer;
using System;
using System.Data;
using System.Threading.Tasks;




namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Represents a user's password history record and provides operations
    /// for managing password changes, retrieving historical passwords,
    /// and tracking password change statistics.
    /// </summary>
    public class clsPasswordHistory
    {
        /// <summary>
        /// Gets or sets the unique identifier of the password history record.
        /// </summary>
        public int PasswordHistoryID { get; set; }
        public string PasswordSalt { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the user associated with this
        /// password history record.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the password was changed.
        /// </summary>
        public DateTime PasswordChange { get; set; }

        /// <summary>
        /// Gets or sets the stored password value associated with this record.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Specifies whether the password history record is new or already exists.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Indicates that a new password history record will be created.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates that an existing password history record will be updated.
            /// </summary>
            Update = 1
        };

        /// <summary>
        /// Gets or sets the current operation mode of the password history record.
        /// Defaults to <see cref="enMode.AddNew"/>.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Initializes a new password history record with default values.
        /// The record is configured for insertion.
        /// </summary>
        public clsPasswordHistory()
        {
            PasswordHistoryID = -1;
            UserID = -1;
            PasswordChange = DateTime.MinValue;
            Password = "";
            PasswordSalt = "";
            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing password history record with the specified values.
        /// </summary>
        /// <param name="PasswordHistoryID">
        /// The unique identifier of the password history record.
        /// </param>
        /// <param name="UserID">
        /// The identifier of the user associated with the record.
        /// </param>
        /// <param name="PasswordChange">
        /// The date and time of the password change.
        /// </param>
        /// <param name="Password">
        /// The stored password value.
        /// </param>
        public clsPasswordHistory(
            int PasswordHistoryID,
            int UserID,
            DateTime PasswordChange,
            string Password,string PasswordSalt)
        {
            this.PasswordHistoryID = PasswordHistoryID;
            this.UserID = UserID;
            this.PasswordChange = PasswordChange;
            this.Password = Password;
            this.PasswordSalt = PasswordSalt;
            Mode = enMode.Update;
        }

        /// <summary>
        /// Retrieves a password history record by its unique identifier.
        /// </summary>
        /// <param name="PasswordHistoryID">
        /// The identifier of the password history record to retrieve.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// contains the matching <see cref="clsPasswordHistory"/> object,
        /// or <see langword="null"/> if no record is found.
        /// </returns>
        public static async Task<clsPasswordHistory> FindAsync(
            int PasswordHistoryID)
        {
            clsPasswordHistoryData.clsPasswordHistoryInfo Result =
                await clsPasswordHistoryData.FindAsync(PasswordHistoryID);

            if (Result != null)
            {
                return new clsPasswordHistory(
                    Result.PasswordHistoryID,
                    Result.UserID,
                    Result.PasswordChange,
                    Result.Password,
                    Result.PasswordSalt
                    );
            }

            return null;
        }

        /// <summary>
        /// Saves the current password history record.
        /// Inserts a new record when the mode is <see cref="enMode.AddNew"/>,
        /// or updates an existing record when the mode is
        /// <see cref="enMode.Update"/>.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is <see langword="true"/> if the operation succeeds; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if( await _AddNewPasswordHistoryAsync())
                        {
                           Mode = enMode.Update;
                            return true;

                        }
                        break;
                    }

                case enMode.Update:
                    return await _UpdatePasswordHistoryAsync();

                   
            } 
            return false;
        }

        /// <summary>
        /// Retrieves all password history records.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is a <see cref="DataTable"/> containing all password history records.
        /// </returns>
        public static Task<DataTable> GetAllPasswordHistoryAsync()
        {
            return clsPasswordHistoryData.GetAllPasswordHistoryAsync();
        }

        /// <summary>
        /// Retrieves password history records belonging to a specific user.
        /// </summary>
        /// <param name="UserID">The identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is a <see cref="DataTable"/> containing the user's password history.
        /// </returns>
        public static Task<DataTable> GetPasswordHistoryByUserIDAsync(
            int UserID)
        {
            return clsPasswordHistoryData.GetPasswordHistoryByUserIDAsync(
                UserID);
        }

        /// <summary>
        /// Retrieves the most recent password history record for a user.
        /// </summary>
        /// <param name="UserID">The identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// contains the latest <see cref="clsPasswordHistory"/> record,
        /// or <see langword="null"/> if no record is found.
        /// </returns>
        public static async Task<clsPasswordHistory> GetLatestPasswordHistoryAsync(
            int UserID)
        {
            clsPasswordHistoryData.clsPasswordHistoryInfo Result =
                await clsPasswordHistoryData.GetLatestPasswordHistoryAsync(UserID);

            if (Result !=null)
            {
                return new clsPasswordHistory(
                    Result.PasswordHistoryID,
                    Result.UserID,
                    Result.PasswordChange,
                    Result.Password,Result.PasswordSalt);
            }

            return null;
        }


        public static clsPasswordHistory GetLatestPasswordHistory(
    int UserID)
        {
            clsPasswordHistoryData.clsPasswordHistoryInfo Result =
                 clsPasswordHistoryData.GetLatestPasswordHistory(UserID);

            if (Result != null)
            {
                return new clsPasswordHistory(
                    Result.PasswordHistoryID,
                    Result.UserID,
                    Result.PasswordChange,
                    Result.Password, Result.PasswordSalt);
            }

            return null;
        }

        /// <summary>
        /// Inserts the current password history record into the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is the identifier of the newly created record, or -1 if insertion fails.
        /// </returns>
        private async Task<bool> _AddNewPasswordHistoryAsync()
        {
         this.PasswordHistoryID=await clsPasswordHistoryData.AddNewPasswordHistoryAsync( this.UserID,  this.Password, this.PasswordSalt);
            return (this.PasswordHistoryID != -1);
        }

        /// <summary>
        /// Updates an existing password history record in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// indicates whether the update succeeded.
        /// </returns>
        private Task<bool> _UpdatePasswordHistoryAsync()
        {
            return clsPasswordHistoryData.UpdatePasswordHistoryAsync(
                this.PasswordHistoryID,
                this.UserID,
                this.PasswordChange,
                this.Password,
                this.PasswordSalt);
        }

        /// <summary>
        /// Deletes a password history record by its unique identifier.
        /// </summary>
        /// <param name="PasswordHistoryID">
        /// The identifier of the record to delete.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// indicates whether the deletion succeeded.
        /// </returns>
        public static Task<bool> DeletePasswordHistoryAsync(
            int PasswordHistoryID)
        {
            return clsPasswordHistoryData.DeletePasswordHistoryAsync(
                PasswordHistoryID);
        }

        /// <summary>
        /// Deletes all password history records associated with a specific user.
        /// </summary>
        /// <param name="UserID">The identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// indicates whether the deletion succeeded.
        /// </returns>
        public static Task<bool> DeleteUserPasswordHistoryAsync(
            int UserID)
        {
            return clsPasswordHistoryData.DeleteUserPasswordHistoryAsync(
                UserID);
        }

        /// <summary>
        /// Retrieves the total number of password history records.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is the total number of records.
        /// </returns>
        public static Task<int> GetAllPasswordHistoryCountAsync()
        {
            return clsPasswordHistoryData.GetAllPasswordHistoryCountAsync();
        }

        /// <summary>
        /// Retrieves the number of password history records belonging to a user.
        /// </summary>
        /// <param name="UserID">The identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is the number of password history records for the specified user.
        /// </returns>
        public static Task<int> GetUserPasswordHistoryCountAsync(
            int UserID)
        {
            return clsPasswordHistoryData.GetUserPasswordHistoryCountAsync(
                UserID);
        }

        /// <summary>
        /// Counts password changes recorded within a specified date range.
        /// </summary>
        /// <param name="StartDate">The beginning of the date range.</param>
        /// <param name="EndDate">The end of the date range.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is the number of password changes within the specified period.
        /// </returns>
        public static Task<int> GetPasswordChangesCountByPeriodAsync(
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsPasswordHistoryData
                .GetPasswordChangesCountByPeriodAsync(
                    StartDate,
                    EndDate);
        }

        /// <summary>
        /// Counts password changes recorded during the current day.
        /// The date range begins at midnight today and ends at midnight tomorrow.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is the number of password changes recorded today.
        /// </returns>
        public static Task<int> GetTodayPasswordChangesCountAsync()
        {
            DateTime StartDate = DateTime.Today;
            DateTime EndDate = StartDate.AddDays(1);

            return clsPasswordHistoryData
                .GetPasswordChangesCountByPeriodAsync(
                    StartDate,
                    EndDate);
        }

        /// <summary>
        /// Counts password changes made by a specific user within a date range.
        /// </summary>
        /// <param name="UserID">The identifier of the user.</param>
        /// <param name="StartDate">The beginning of the date range.</param>
        /// <param name="EndDate">The end of the date range.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is the number of password changes made by the specified user
        /// during the period.
        /// </returns>
        public static Task<int> GetUserPasswordChangesCountByPeriodAsync(
            int UserID,
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsPasswordHistoryData
                .GetUserPasswordChangesCountByPeriodAsync(
                    UserID,
                    StartDate,
                    EndDate);
        }

        /// <summary>
        /// Retrieves the date and time of a user's most recent password change.
        /// </summary>
        /// <param name="UserID">The identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is the last password change date, or <see langword="null"/> if
        /// no password change date is available.
        /// </returns>
        public static Task<DateTime?> GetLastPasswordChangeDateAsync(
            int UserID)
        {
            return clsPasswordHistoryData
                .GetLastPasswordChangeDateAsync(UserID);
        }
        /// <summary>
        /// Checks whether a specified password has been used previously by a user.
        /// </summary>
        /// <param name="UserID">The identifier of the user whose password history will be checked.</param>
        /// <param name="Password">The plain-text password to check against the user's password history.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is <see langword="true"/> if the password was previously used;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static async Task<bool> IsPasswordUsedBeforeAsync(  int UserID, string Password)
        {
            DataTable History = await clsPasswordHistoryData.GetUserPasswordHistoryAsync(UserID);

            foreach (DataRow Row in History.Rows)
            {
                string StoredHash = Row["Password"].ToString();
                string StoredSalt = Row["PasswordSalt"].ToString();

                string NewHash = clsSecurity.HashPassword(Password, out StoredSalt);

                if (NewHash == StoredHash)
                    return true;
            }

            return false;
        }
    }
}