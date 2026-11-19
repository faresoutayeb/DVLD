using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace DVLD_Data_Access_Layer
{
    /// <summary>
    /// Provides data access operations for locked user accounts.
    /// </summary>
    public static class clsLockData
    {
        //=============================================================
        // Find By LockedUserAccountID
        //=============================================================

        /// <summary>
        /// Represents information about a locked user account record.
        /// </summary>
        public class clsLockInfo
        {
 

            /// <summary>
            /// Gets or sets the identifier of the locked user account record.
            /// </summary>
            public int LockedUserAccountID { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the associated user.
            /// </summary>
            public int UserID { get; set; }

            /// <summary>
            /// Gets or sets the date and time when the account was locked.
            /// </summary>
            public DateTime LockedDateTime { get; set; }

            /// <summary>
            /// Gets or sets the date and time when the account was unlocked,
            /// or null if it has not been unlocked.
            /// </summary>
            public DateTime? UnlockedDateTime { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="clsLockInfo"/> class
            /// with default values.
            /// </summary>
            public clsLockInfo()
            {
                LockedUserAccountID = -1;
                UserID = -1;
                LockedDateTime = DateTime.MinValue;
                UnlockedDateTime = null;
            }
        }

        //=============================================================
        // Find By LockedUserAccountID
        //=============================================================

        /// <summary>
        /// Retrieves locked account information using its record identifier.
        /// </summary>
        /// <param name="LockedUserAccountID">
        /// The identifier of the locked user account record.
        /// </param>
        /// <returns>
        /// A task containing the locked account information, or null if no record
        /// is found or an exception occurs.
        /// </returns>
        public static async Task<clsLockInfo> FindAsync(
            int LockedUserAccountID)
        {

        

            try
            {
                string query = @"SELECT LockedUserAccountID, UserID,
                            LockedDateTime, UnlockedDateTime
                     FROM Lockings
                     WHERE LockedUserAccountID = @LockedUserAccountID";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LockedUserAccountID", LockedUserAccountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsLockInfo
                                {
                                    LockedUserAccountID =
                                        Convert.ToInt32(reader["LockedUserAccountID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    LockedDateTime =
                                        Convert.ToDateTime(reader["LockedDateTime"]),

                                    UnlockedDateTime =
                                        reader["UnlockedDateTime"] == DBNull.Value
                                            ? (DateTime?)null
                                            : Convert.ToDateTime(reader["UnlockedDateTime"])

                                };

                            }
                            else
                                return null;
                                
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }
  


        }

        public static clsLockInfo Find(
    int LockedUserAccountID)
        {



            try
            {
                string query = @"SELECT LockedUserAccountID, UserID,
                            LockedDateTime, UnlockedDateTime
                     FROM Lockings
                     WHERE LockedUserAccountID = @LockedUserAccountID";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LockedUserAccountID", LockedUserAccountID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsLockInfo
                                {
                                    LockedUserAccountID =
                                        Convert.ToInt32(reader["LockedUserAccountID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    LockedDateTime =
                                        Convert.ToDateTime(reader["LockedDateTime"]),

                                    UnlockedDateTime =
                                        reader["UnlockedDateTime"] == DBNull.Value
                                            ? (DateTime?)null
                                            : Convert.ToDateTime(reader["UnlockedDateTime"])

                                };

                            }
                            else
                                return null;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }



        }


        //=============================================================
        // Add New Locked Account
        //=============================================================

        /// <summary>
        /// Creates a new locked account record.
        /// </summary>
        /// <param name="UserID">The identifier of the user to lock.</param>
        /// <param name="UnlockedDateTime">
        /// The scheduled or recorded unlock date and time, or null if unspecified.
        /// </param>
        /// <returns>
        /// A task containing the identifier of the newly created record,
        /// or -1 if the operation fails.
        /// </returns>
        public static async Task<int> AddNewAsync(
            int UserID, DateTime? UnlockedDateTime)
        {
            int LockedUserAccountID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewLocking", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue(
                            "@LockedDateTime", DateTime.Now);

                        command.Parameters.AddWithValue(
                            "@UnlockedDateTime",
                            (object)UnlockedDateTime ?? DBNull.Value);

                        SqlParameter outputIdParam =
                            new SqlParameter(
                                "@NewLockedUserAccountID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        LockedUserAccountID =
                            Convert.ToInt32(outputIdParam.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }



            return LockedUserAccountID;
        }

        //=============================================================
        // Update Locked Account
        //=============================================================

        /// <summary>
        /// Updates an existing locked account record.
        /// </summary>
        /// <param name="LockedUserAccountID">
        /// The identifier of the locked user account record to update.
        /// </param>
        /// <param name="UserID">The identifier of the associated user.</param>
        /// <param name="UnlockedDateTime">
        /// The unlock date and time, or null if unspecified.
        /// </param>
        /// <returns>
        /// A task containing true if at least one row was updated; otherwise, false.
        /// </returns>
        public static async Task<bool> UpdateAsync(
            int LockedUserAccountID,
            int UserID,
            DateTime? UnlockedDateTime)
        {
            int RowsAffected = 0;



            try
            {
                string query = @"UPDATE Lockings
                     SET UserID = @UserID,
                         LockedDateTime = @LockedDateTime,
                         UnlockedDateTime = @UnlockedDateTime
                     WHERE LockedUserAccountID = @LockedUserAccountID";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LockedUserAccountID", LockedUserAccountID);

                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue(
                            "@LockedDateTime", DateTime.Now);

                        command.Parameters.AddWithValue(
                            "@UnlockedDateTime",
                            (object)UnlockedDateTime ?? DBNull.Value);

                        await connection.OpenAsync();

                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }



            return RowsAffected > 0;
        }

        //=============================================================
        // Get All Locked Account Records
        //=============================================================

        /// <summary>
        /// Retrieves all locked account records, ordered by lock date in descending
        /// order.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with all locked account records.
        /// </returns>
        public static async Task<DataTable> GetAllAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                string query = @"SELECT
                        LockedUserAccountID,
                        UserID,
                        LockedDateTime,
                        UnlockedDateTime
                     FROM Lockings
                     ORDER BY LockedDateTime DESC";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }
      


            return dt;
        }

        //=============================================================
        // Get All Lock Records For Specific User
        //=============================================================

        /// <summary>
        /// Retrieves all locked account records associated with a specific user,
        /// ordered by lock date in descending order.
        /// </summary>
        /// <param name="UserID">The identifier of the user.</param>
        /// <returns>
        /// A task containing a DataTable with the user's locked account records.
        /// </returns>
        public static async Task<DataTable> GetAllByUserIDAsync(int UserID)
        {
            DataTable dt = new DataTable();



            try
            {
                string query = @"SELECT
                        LockedUserAccountID,
                        UserID,
                        LockedDateTime,
                        UnlockedDateTime
                     FROM Lockings
                     WHERE UserID = @UserID
                     ORDER BY LockedDateTime DESC";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }
 


            return dt;
        }

        /// <summary>
        /// Retrieves all lock records associated with a specific username.
        /// Includes the lock record ID, user ID, username, lock date, and unlock date.
        /// Results are ordered by lock date in descending order.
        /// </summary>
        /// <param name="UserName">The username used to filter lock records.</param>
        /// <returns>
        /// A DataTable containing all lock records associated with the specified username.
        /// Returns an empty DataTable if no matching records are found or an error occurs.
        /// </returns>
        //=============================================================
        // Get All Lock Records By Username
        //=============================================================

        public static async Task<DataTable> GetAllByUsernameAsync(string UserName)
        {
            DataTable dt = new DataTable();



            try
            {
                string query = @"SELECT
                    LUA.LockedUserAccountID,
                    LUA.UserID,
                    U.UserName,
                    LUA.LockedDateTime,
                    LUA.UnlockedDateTime
                 FROM Lockings LUA
                 INNER JOIN Users U
                    ON LUA.UserID = U.UserID
                 WHERE U.UserName = @UserName
                 ORDER BY LUA.LockedDateTime DESC";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }



            return dt;
        }


        /// <summary>
        /// Retrieves all currently locked user accounts.
        /// A lock record is considered active when its UnlockedDateTime is NULL.
        /// Results are ordered by lock date in descending order.
        /// </summary>
        /// <returns>
        /// A DataTable containing currently locked user accounts and their lock details.
        /// Returns an empty DataTable if no records are found or an error occurs.
        /// </returns>
        //=============================================================
        // Get Currently Locked Users
        //=============================================================

        public static async Task<DataTable> GetCurrentlyLockedUsersAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                string query = @"SELECT
                    LUA.LockedUserAccountID,
                    LUA.UserID,
                    U.UserName,
                    LUA.LockedDateTime,
                    LUA.UnlockedDateTime
                 FROM Lockings LUA
                 INNER JOIN Users U
                    ON LUA.UserID = U.UserID
                 WHERE LUA.UnlockedDateTime IS NULL
                 ORDER BY LUA.LockedDateTime DESC";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }
   


            return dt;
        }


        /// <summary>
        /// Retrieves the total number of lock records stored in the Lockings table.
        /// Includes both currently locked and previously unlocked accounts.
        /// </summary>
        /// <returns>
        /// The total number of lock records.
        /// Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get All Locks Count
        //=============================================================

        public static async Task<int> GetAllLocksCountAsync()
        {
            int Count = 0;



            try
            {
                string query = @"SELECT COUNT(*) FROM Lockings";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }
    

            return Count;
        }


        /// <summary>
        /// Retrieves the total number of lock records associated with a specific user.
        /// Includes both currently locked and previously unlocked accounts.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// The total number of lock records associated with the specified user.
        /// Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get Locks Count For Specific User
        //=============================================================

        public static async Task<int> GetUserLocksCountAsync(int UserID)
        {
            int Count = 0;



            try
            {
                string query = @"SELECT COUNT(*)
                 FROM Lockings
                 WHERE UserID = @UserID";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }



            return Count;
        }


        /// <summary>
        /// Retrieves the number of lock records representing currently locked accounts.
        /// A record is considered currently locked when UnlockedDateTime is NULL.
        /// </summary>
        /// <returns>
        /// The number of currently locked account records.
        /// Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get Currently Locked Users Count
        //=============================================================

        public static async Task<int> GetCurrentlyLockedUsersCountAsync()
        {
            int Count = 0;

  


            try
            {
                string query = @"SELECT COUNT(*)
                 FROM Lockings
                 WHERE UnlockedDateTime IS NULL";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }



            return Count;
        }


        /// <summary>
        /// Retrieves the number of lock records representing accounts that have been unlocked.
        /// A record is considered unlocked when UnlockedDateTime is not NULL.
        /// </summary>
        /// <returns>
        /// The number of unlocked account records.
        /// Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get Unlocked Accounts Count
        //=============================================================

        public static async Task<int> GetUnlockedUsersCountAsync()
        {
            int Count = 0;



            try
            {
                string query = @"SELECT COUNT(*)
                 FROM Lockings
                 WHERE UnlockedDateTime IS NOT NULL";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }



            return Count;
        }

        /// <summary>
        /// Retrieves the total number of lock records created within a specified period.
        /// The start date is inclusive, while the end date is exclusive.
        /// </summary>
        /// <param name="StartDate">The beginning of the period to search, inclusive.</param>
        /// <param name="EndDate">The end of the period to search, exclusive.</param>
        /// <returns>
        /// The total number of lock records created during the specified period.
        /// Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get Locks Count In Specific Period
        //=============================================================

        public static async Task<int> GetLocksCountByPeriodAsync(
            DateTime StartDate,
            DateTime EndDate)
        {
            int Count = 0;



            try
            {
                string query = @"SELECT COUNT(*)
                     FROM Lockings
                     WHERE LockedDateTime >= @StartDate
                     AND LockedDateTime < @EndDate";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }
   


            return Count;
        }


        /// <summary>
        /// Retrieves the number of lock records created for a specific user
        /// within a specified period.
        /// The start date is inclusive, while the end date is exclusive.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <param name="StartDate">The beginning of the period to search, inclusive.</param>
        /// <param name="EndDate">The end of the period to search, exclusive.</param>
        /// <returns>
        /// The number of lock records belonging to the specified user
        /// during the specified period. Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get User Locks Count In Specific Period
        //=============================================================

        public static async Task<int> GetUserLocksCountByPeriodAsync(
            int UserID,
            DateTime StartDate,
            DateTime EndDate)
        {
            int Count = 0;



            try
            {
                string query = @"SELECT COUNT(*)
                     FROM Lockings
                     WHERE UserID = @UserID
                     AND LockedDateTime >= @StartDate
                     AND LockedDateTime < @EndDate";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }


            return Count;
        }


        /// <summary>
        /// Retrieves the number of lock records created for a specific username
        /// within a specified period.
        /// The start date is inclusive, while the end date is exclusive.
        /// </summary>
        /// <param name="UserName">The username used to identify the user.</param>
        /// <param name="StartDate">The beginning of the period to search, inclusive.</param>
        /// <param name="EndDate">The end of the period to search, exclusive.</param>
        /// <returns>
        /// The number of lock records associated with the specified username
        /// during the specified period. Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get Locks Count By Username In Specific Period
        //=============================================================

        public static async Task<int> GetUserLocksCountByUsernameAndPeriodAsync(
            string UserName,
            DateTime StartDate,
            DateTime EndDate)
        {
            int Count = 0;



            try
            {
                string query = @"SELECT COUNT(*)
                     FROM Lockings LUA
                     INNER JOIN Users U
                        ON LUA.UserID = U.UserID
                     WHERE U.UserName = @UserName
                     AND LUA.LockedDateTime >= @StartDate
                     AND LUA.LockedDateTime < @EndDate";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                throw;
            }



            return Count;
        }


        /// <summary>
        /// Retrieves the total number of lock records created today,
        /// based on the SQL Server's current date.
        /// Includes records from midnight up to, but not including,
        /// midnight of the following day.
        /// </summary>
        /// <returns>
        /// The number of lock records created today.
        /// Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get Locks Count Today
        //=============================================================

        public static async Task<int> GetTodayLocksCountAsync()
        {
            int Count = 0;



            try
            {
                string query = @"
        SELECT COUNT(*)
        FROM Lockings
        WHERE LockedDateTime >= CAST(GETDATE() AS DATE)
        AND LockedDateTime < DATEADD(DAY, 1, CAST(GETDATE() AS DATE));";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                 throw;
            }
    


            return Count;
        }


        /// <summary>
        /// Retrieves the total number of lock records created during the current month,
        /// from the first day of the month up to the current SQL Server date and time.
        /// </summary>
        /// <returns>
        /// The number of lock records created during the current month.
        /// Returns 0 if an error occurs.
        /// </returns>
        //=============================================================
        // Get Locks Count This Month
        //=============================================================

        public static async Task<int> GetThisMonthLocksCountAsync()
        {
            int Count = 0;



            try
            {
                string query = @"SELECT COUNT(*)
                     FROM Lockings
                     WHERE LockedDateTime >=
                         DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
                     AND LockedDateTime <= GETDATE();";

                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                 throw;
            }



            return Count;
        }


        /// <summary>
        /// Checks whether a specific user's account is currently locked.
        /// Uses the SP_CheckUserCurrentlyLocked stored procedure to perform the check.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user to check.</param>
        /// <returns>
        /// True if the stored procedure returns 1, indicating that the user is locked;
        /// otherwise, false. Returns false if an error occurs.
        /// </returns>
        //=============================================================
        // Check If User Is Currently Locked
        //=============================================================

        public static async Task<bool> IsUserCurrentlyLockedAsync(int UserID)
        {
            bool IsLocked = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckUserCurrentlyLocked", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();

                        IsLocked = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLockData");
                 throw;
            }
 


            return IsLocked;
        }


    }
}