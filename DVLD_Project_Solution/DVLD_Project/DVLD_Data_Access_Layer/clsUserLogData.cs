using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace DVLD_Data_Access_Layer
{

    /// <summary>
    /// Provides asynchronous data access operations for retrieving and managing user login logs.
    /// </summary>
    public static class clsUserLogData
    {
        /// <summary>
        /// Retrieves all user login logs ordered by login date and time in descending order.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with all user login logs, or an empty DataTable if no records are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get All Logs
        public static async Task<DataTable> GetAllLogsAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT 
                        UserLoginID,
                        UserID,
                        LoginDateTime,
                        LogoutDateTime
                     FROM UsersLogs
                     ORDER BY LoginDateTime DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }


            return dt;
        }

        /// <summary>
        /// Retrieves the login logs for the specified user ID, ordered by login date
        /// and time in descending order.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the user's login logs, or an empty DataTable if no records are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get Logs For Specific User By UserID
        public static async Task<DataTable> GetLogsByUserIDAsync(int UserID)
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT 
                        UserLoginID,
                        UserID,
                        LoginDateTime,
                        LogoutDateTime
                     FROM UsersLogs
                     WHERE UserID = @UserID
                     ORDER BY LoginDateTime DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }
    


            return dt;
        }


        /// <summary>
        /// Retrieves the login logs for the specified username, ordered by login date
        /// and time in descending order.
        /// </summary>
        /// <param name="UserName">The username whose login logs are requested.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the user's login logs, or an empty DataTable if no records are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get Logs For Specific User By Username
        public static async Task<DataTable> GetLogsByUsernameAsync(string UserName)
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    SELECT 
                        CurrentUserLog.UserLoginID,
                        CurrentUserLog.UserID,
                        CurrentUserLog.LoginDateTime,
                        CurrentUserLog.LogoutDateTime
                    FROM UsersLogs CurrentUserLog
                    INNER JOIN Users CurrentUser
                        ON CurrentUserLog.UserID = CurrentUser.UserID
                    WHERE CurrentUser.UserName = @UserName
                    ORDER BY CurrentUserLog.LoginDateTime DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }



            return dt;
        }

        /// <summary>
        /// Retrieves login history information for all users,
        /// including login time, logout time, and session duration.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
        /// containing a <see cref="DataTable"/> with the user login records.
        /// </returns>
        public static async Task<DataTable> GetLogsInfoAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                                select UserLoginID as [Login ID] ,
                                Users.UserName as [User Name] ,
                                userslogs.LoginDateTime as [Login Date & Time],
                                userslogs.LogoutDateTime as [Logout Date & Time],
                                [Durration Session] =  cast( day(LogoutDateTime - LoginDateTime) as nvarchar) + ' D '+
                                cast(
                                   cast (LogoutDateTime  - LoginDateTime as time)

                                as nvarchar)
                                from userslogs inner join Users  on USERS.UserID = UsersLogs.UserID;

                                ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }
  


            return dt;
        }


        /// <summary>
        /// Represents information about a user login log.
        /// </summary>
        public class clsUserLogInfo
        {


            /// <summary>
            /// Gets or sets the unique identifier of the user login log.
            /// </summary>
            public int UserLoginID { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the user associated with the login log.
            /// </summary>
            public int UserID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the date and time when the user logged in.
            /// </summary>
            public DateTime LoginDateTime { get; set; } = DateTime.MinValue;

            /// <summary>
            /// Gets or sets the date and time when the user logged out, or null
            /// if no logout time has been recorded.
            /// </summary>
            public DateTime? LogoutDateTime { get; set; } = null;
        }

        /// <summary>
        /// Finds a user login log using its unique identifier.
        /// </summary>
        /// <param name="UserLoginID">The unique identifier of the user login log.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the login log
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Find Log By UserLoginID
        public static async Task<clsUserLogInfo> FindAsync(int UserLoginID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT 
                        UserID,
                        LoginDateTime,
                        LogoutDateTime
                     FROM UsersLogs
                     WHERE UserLoginID = @UserLoginID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserLoginID", UserLoginID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsUserLogInfo
                                {


                                    UserID = Convert.ToInt32(reader["UserID"]),

                                    LoginDateTime =
                                            Convert.ToDateTime(reader["LoginDateTime"]),
                                    UserLoginID = UserLoginID,

                                    LogoutDateTime = reader["LogoutDateTime"] != DBNull.Value ? Convert.ToDateTime(reader["LogoutDateTime"])
                                                    : (DateTime?)null

                                };
   
                            }
                            else
                                { return null; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }
 

        }


        public static clsUserLogInfo Find(int UserLoginID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT 
                        UserID,
                        LoginDateTime,
                        LogoutDateTime
                     FROM UsersLogs
                     WHERE UserLoginID = @UserLoginID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserLoginID", UserLoginID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsUserLogInfo
                                {


                                    UserID = Convert.ToInt32(reader["UserID"]),

                                    LoginDateTime =
                                            Convert.ToDateTime(reader["LoginDateTime"]),
                                    UserLoginID = UserLoginID,

                                    LogoutDateTime = reader["LogoutDateTime"] != DBNull.Value ? Convert.ToDateTime(reader["LogoutDateTime"])
                                                    : (DateTime?)null

                                };

                            }
                            else
                            { return null; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }


        }


        /// <summary>
        /// Adds a new user login log to the database.
        /// </summary>
        /// <param name="UserID">The identifier of the user associated with the log.</param>
        /// <param name="LoginDateTime">The date and time when the user logged in.</param>
        /// <param name="LogoutDateTime">
        /// The date and time when the user logged out, or null if no logout time is available.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the identifier
        /// of the newly created login log, or -1 if the operation fails.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Add New Log
        public static async Task<int> AddNewLogAsync(
        int UserID,
        DateTime LoginDateTime,
        DateTime? LogoutDateTime)
        {
            int UserLoginID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewUserLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@LoginDateTime", LoginDateTime);

                        command.Parameters.AddWithValue(
                            "@LogoutDateTime",
                            (object)LogoutDateTime ?? DBNull.Value);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewUserLoginID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        UserLoginID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }
 


            return UserLoginID;
        }


        /// <summary>
        /// Updates an existing user login log in the database.
        /// </summary>
        /// <param name="UserLoginID">The unique identifier of the user login log to update.</param>
        /// <param name="UserID">The identifier of the user associated with the log.</param>
        /// <param name="LoginDateTime">The updated login date and time.</param>
        /// <param name="LogoutDateTime">
        /// The updated logout date and time, or null if no logout time is available.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one row was affected; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Update Log
        public static async Task<bool> UpdateLogAsync(
            int UserLoginID,
            int UserID,
            DateTime LoginDateTime,
            DateTime? LogoutDateTime)
        {
            int RowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE UsersLogs
                     SET UserID = @UserID,
                         LoginDateTime = @LoginDateTime,
                         LogoutDateTime = @LogoutDateTime
                     WHERE UserLoginID = @UserLoginID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserLoginID", UserLoginID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@LoginDateTime", LoginDateTime);
                        command.Parameters.AddWithValue(
                            "@LogoutDateTime",
                            (object)LogoutDateTime ?? DBNull.Value);

                        await connection.OpenAsync();

                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }



            return RowsAffected > 0;
        }


        /// <summary>
        /// Retrieves the total number of user login logs in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of user login logs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get All Logs Count
        public static async Task<int> GetAllLogsCountAsync()
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*) FROM UsersLogs";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }



            return Count;
        }


        /// <summary>
        /// Retrieves the total number of login logs associated with the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of login logs associated with the specified user.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get Logs Count For Specific User
        public static async Task<int> GetUserLogsCountAsync(int UserID)
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*)
                     FROM UsersLogs
                     WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        Count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }



            return Count;
        }


        /// <summary>
        /// Retrieves the total number of user logins recorded for the current day.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of logins recorded on the current database server date.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get Total Logins Today
        public static async Task<int> GetTotalLoginsTodayAsync()
        {
            int Count = 0;

    


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT COUNT(*)
        FROM UsersLogs
        WHERE YEAR(LoginDateTime) = YEAR(GETDATE())
          AND MONTH(LoginDateTime) = MONTH(GETDATE())
          AND DAY(LoginDateTime) = DAY(GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }
  


            return Count;
        }


        /// <summary>
        /// Retrieves the number of user login logs recorded within the specified date range.
        /// </summary>
        /// <param name="StartDate">The inclusive start date and time of the period.</param>
        /// <param name="EndDate">The exclusive end date and time of the period.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of login logs recorded within the specified date range.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get Logs Count In Specific Period
        public static async Task<int> GetLogsCountByPeriodAsync(
            DateTime StartDate,
            DateTime EndDate)
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*)
                     FROM UsersLogs
                     WHERE LoginDateTime >= @StartDate
                     AND LoginDateTime < @EndDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        await connection.OpenAsync();

                        Count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }
 


            return Count;
        }
        /// <summary>
        /// Retrieves the number of login logs for a specific user within the specified date range.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <param name="StartDate">The inclusive start date and time of the period.</param>
        /// <param name="EndDate">The exclusive end date and time of the period.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of login logs recorded for the specified user within the date range.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get Specific User Logs Count In Specific Period
        public static async Task<int> GetUserLogsCountByPeriodAsync(
            int UserID,
            DateTime StartDate,
            DateTime EndDate)
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*)
                     FROM UsersLogs
                     WHERE UserID = @UserID
                     AND LoginDateTime >= @StartDate
                     AND LoginDateTime < @EndDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        await connection.OpenAsync();

                        Count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }



            return Count;
        }

        /// <summary>
        /// Retrieves the number of currently active user sessions.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of login logs whose logout date and time have not been recorded.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get Currently Active Sessions
        public static async Task<int> GetActiveSessionsCountAsync()
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*)
                     FROM UsersLogs
                     WHERE LogoutDateTime IS NULL";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }



            return Count;
        }

        /// <summary>
        /// Retrieves the most recent login log for the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the most recent
        /// login log information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Find Last Log By User ID
        public static async Task<clsUserLogInfo> FindLastLogByUserIDAsync(int UserID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT TOP 1
                        UserLoginID,
                        UserID,
                        LoginDateTime,
                        LogoutDateTime
                     FROM UsersLogs
                     WHERE UserID = @UserID
                     ORDER BY LoginDateTime DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                           await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsUserLogInfo
                                {

                                    UserLoginID = Convert.ToInt32(reader["UserLoginID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    LoginDateTime = Convert.ToDateTime(reader["LoginDateTime"]),
                                    LogoutDateTime = (reader["LogoutDateTime"] == DBNull.Value) ? (DateTime?)null:Convert.ToDateTime(reader["LogoutDateTime"])


                                };
                       

                    
                            }
                            else
                                { return null; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }



        }

        public static clsUserLogInfo FindLastLogByUserID(int UserID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT TOP 1
                        UserLoginID,
                        UserID,
                        LoginDateTime,
                        LogoutDateTime
                     FROM UsersLogs
                     WHERE UserID = @UserID
                     ORDER BY LoginDateTime DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsUserLogInfo
                                {

                                    UserLoginID = Convert.ToInt32(reader["UserLoginID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    LoginDateTime = Convert.ToDateTime(reader["LoginDateTime"]),
                                    LogoutDateTime = (reader["LogoutDateTime"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["LogoutDateTime"])


                                };



                            }
                            else
                            { return null; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserLogData");
                throw;
            }



        }


    }
}