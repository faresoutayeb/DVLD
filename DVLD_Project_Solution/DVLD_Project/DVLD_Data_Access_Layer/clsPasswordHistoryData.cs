using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{


    /// <summary>
    /// Provides asynchronous data access operations for password history records,
    /// including retrieving, searching, and updating password history information.
    /// </summary>
    static public class clsPasswordHistoryData
    {
        /// <summary>
        /// Retrieves all password history records from the database,
        /// ordered by password change date in descending order.
        /// </summary>
        /// <returns>
        /// A <see cref="DataTable"/> containing all password history records.
        /// Returns an empty table if no records are found or an error occurs.
        /// </returns>
        public static async Task<DataTable> GetAllPasswordHistoryAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT *
    FROM PasswordsHistory
    ORDER BY PasswordChange DESC";

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
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
     


            return dt;
        }


        /// <summary>
        /// Retrieves all password history records associated with a specific user,
        /// ordered by password change date in descending order.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user whose password history is requested.
        /// </param>
        /// <returns>
        /// A <see cref="DataTable"/> containing the user's password history records.
        /// Returns an empty table if no records are found.
        /// </returns>
        public static async Task<DataTable> GetPasswordHistoryByUserIDAsync(int UserID)
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT *
 FROM PasswordsHistory
 WHERE UserID = @UserID
 ORDER BY PasswordChange DESC";

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
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }



            return dt;
        }


        /// <summary>
        /// Represents a password history record and indicates whether
        /// the requested record was found in the database.
        /// </summary>
        public class clsPasswordHistoryInfo
        {


            /// <summary>
            /// Gets or sets the unique identifier of the password history record.
            /// </summary>
            public int PasswordHistoryID { get; set; }

            /// <summary>
            /// Gets or sets the unique identifier of the user associated with the record.
            /// </summary>
            public int UserID { get; set; }

            /// <summary>
            /// Gets or sets the date and time when the password was recorded.
            /// </summary>
            public DateTime PasswordChange { get; set; }
            public string PasswordSalt {  get; set; }
            /// <summary>
            /// Gets or sets the password value stored in the history record.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Initializes a new password history information object
            /// with default values indicating that no record has been found.
            /// </summary>
            public clsPasswordHistoryInfo()
            {
                PasswordHistoryID = -1;
                UserID = -1;
                PasswordChange = DateTime.MinValue;
                Password = string.Empty;
                PasswordSalt = string.Empty;
            }
        }


        /// <summary>
        /// Searches for a password history record using its unique identifier.
        /// </summary>
        /// <param name="PasswordHistoryID">
        /// The unique identifier of the password history record to retrieve.
        /// </param>
        /// <returns>
        /// A <see cref="clsPasswordHistoryInfo"/> object containing the record details
        /// if found; otherwise, returns null.
        /// </returns>
        public static async Task<clsPasswordHistoryInfo> FindAsync(int PasswordHistoryID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT *
    FROM PasswordsHistory
    WHERE PasswordHistoryID = @PasswordHistoryID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@PasswordHistoryID", PasswordHistoryID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsPasswordHistoryInfo
                                {

                                    PasswordHistoryID = PasswordHistoryID,
                                    UserID = (int)reader["UserID"],
                                    PasswordChange = (DateTime)reader["PasswordChange"],
                                    Password = (string)reader["Password"],
                                    PasswordSalt = (string)reader["PasswordSalt"]

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
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }



        }

        public static clsPasswordHistoryInfo Find(int PasswordHistoryID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT *
    FROM PasswordsHistory
    WHERE PasswordHistoryID = @PasswordHistoryID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@PasswordHistoryID", PasswordHistoryID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsPasswordHistoryInfo
                                {

                                    PasswordHistoryID = PasswordHistoryID,
                                    UserID = (int)reader["UserID"],
                                    PasswordChange = (DateTime)reader["PasswordChange"],
                                    Password = (string)reader["Password"],
                                     PasswordSalt = (string)reader["PasswordSalt"]

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
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }



        }


        /// <summary>
        /// Updates an existing password history record with the specified user,
        /// password change date, and password value.
        /// </summary>
        /// <param name="PasswordHistoryID">
        /// The unique identifier of the password history record to update.
        /// </param>
        /// <param name="UserID">
        /// The unique identifier of the user associated with the record.
        /// </param>
        /// <param name="PasswordChange">
        /// The date and time associated with the password change.
        /// </param>
        /// <param name="Password">
        /// The password value to store in the history record.
        /// </param>
        /// <returns>
        /// True if at least one database row was affected; otherwise, false.
        /// </returns>
        public static async Task<bool> UpdatePasswordHistoryAsync(
            int PasswordHistoryID,
            int UserID,
            DateTime PasswordChange,
            string Password,
            string PasswordSalt)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE PasswordsHistory
                 SET
                     UserID = @UserID,
                     PasswordChange = @PasswordChange,
                     Password = @Password,
                        PasswordSalt = @PasswordSalt
                 WHERE PasswordHistoryID = @PasswordHistoryID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PasswordHistoryID", PasswordHistoryID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@PasswordChange", PasswordChange);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
 

            return rowsAffected > 0;
        }


        /// <summary>
        /// Retrieves the most recent password history record for a specific user,
        /// using the password change date and record identifier to determine the latest entry.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user whose latest password history is requested.
        /// </param>
        /// <returns>
        /// A <see cref="clsPasswordHistoryInfo"/> object containing the latest record
        /// if one exists; otherwise, returns null.
        /// </returns>
        public static async Task<clsPasswordHistoryInfo> GetLatestPasswordHistoryAsync(
            int UserID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT TOP 1 *
                 FROM PasswordsHistory
                 WHERE UserID = @UserID
                 ORDER BY PasswordChange DESC,
                          PasswordHistoryID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsPasswordHistoryInfo
                                {

                                    PasswordHistoryID =(int) reader[ "PasswordHistoryID"],
                                    UserID = (int)reader["UserID"],
                                    PasswordChange = (DateTime)reader["PasswordChange"],
                                    Password = (string)reader["Password"],
                                    PasswordSalt = (string)reader["PasswordSalt"]

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
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
  

        }


        public static clsPasswordHistoryInfo GetLatestPasswordHistory(
       int UserID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT TOP 1 *
                 FROM PasswordsHistory
                 WHERE UserID = @UserID
                 ORDER BY PasswordChange DESC,
                          PasswordHistoryID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsPasswordHistoryInfo
                                {

                                    PasswordHistoryID = (int)reader["PasswordHistoryID"],
                                    UserID = (int)reader["UserID"],
                                    PasswordChange = (DateTime)reader["PasswordChange"],
                                    Password = (string)reader["Password"],
                                    PasswordSalt = (string)reader["PasswordSalt"]

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
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }


        }

        /// <summary>
        /// Adds a new password history record for the specified user,
        /// recording the current date and time of the password change.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user associated with the password history record.
        /// </param>
        /// <param name="Password">
        /// The password value to be stored in the password history record.
        /// </param>
        /// <returns>
        /// The unique identifier of the newly created password history record
        /// if the operation succeeds; otherwise, returns -1.
        /// </returns>
        public static async Task<int> AddNewPasswordHistoryAsync(int UserID, string Password,string PasswordSalt)
        {
            int PasswordHistoryID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewPasswordHistory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@PasswordChange", DateTime.Now);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);


                        SqlParameter outputIdParam =
                            new SqlParameter("@NewPasswordHistoryID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        PasswordHistoryID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
     


            return PasswordHistoryID;
        }


        /// <summary>
        /// Deletes a password history record using its unique identifier.
        /// </summary>
        /// <param name="PasswordHistoryID">
        /// The unique identifier of the password history record to delete.
        /// </param>
        /// <returns>
        /// True if at least one record was deleted; otherwise, returns false.
        /// </returns>
        public static async Task<bool> DeletePasswordHistoryAsync(int PasswordHistoryID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"DELETE FROM PasswordsHistory
                     WHERE PasswordHistoryID = @PasswordHistoryID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PasswordHistoryID", PasswordHistoryID);

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
    


            return rowsAffected > 0;
        }


        /// <summary>
        /// Deletes all password history records associated with a specific user.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user whose password history records will be deleted.
        /// </param>
        /// <returns>
        /// True if at least one record was deleted; otherwise, returns false.
        /// </returns>
        public static async Task<bool> DeleteUserPasswordHistoryAsync(int UserID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"DELETE FROM PasswordsHistory
                     WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
   


            return rowsAffected > 0;
        }

        public static async Task<DataTable> GetUserPasswordHistoryAsync(int UserID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string Query = @"SELECT Password, PasswordSalt
                         FROM PasswordHistory
                         WHERE UserID = @UserID";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@UserID", UserID);

                    await Connection.OpenAsync();

                    using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                    {
                        if (Reader.HasRows)
                            dt.Load(Reader);
                    }
                }
            }

            return dt;
        }
        /// <summary>
        /// Retrieves the total number of password history records stored in the database.
        /// </summary>
        /// <returns>
        /// The total number of password history records.
        /// Returns 0 if an error occurs.
        /// </returns>
        public static async Task<int> GetAllPasswordHistoryCountAsync()
        {
            int count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*)
                     FROM PasswordsHistory";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
  


            return count;
        }


        /// <summary>
        /// Retrieves the total number of password history records associated with a specific user.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user whose password history records will be counted.
        /// </param>
        /// <returns>
        /// The number of password history records belonging to the specified user.
        /// Returns 0 if an error occurs.
        /// </returns>
        public static async Task<int> GetUserPasswordHistoryCountAsync(int UserID)
        {
            int count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*)
                     FROM PasswordsHistory
                     WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();
                        count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
  


            return count;
        }


        /// <summary>
        /// Retrieves the total number of password changes recorded within a specified date and time period.
        /// </summary>
        /// <param name="StartDate">
        /// The inclusive starting date and time of the period.
        /// </param>
        /// <param name="EndDate">
        /// The exclusive ending date and time of the period.
        /// </param>
        /// <returns>
        /// The total number of password changes recorded during the specified period.
        /// </returns>
        public static async Task<int> GetPasswordChangesCountByPeriodAsync(
            DateTime StartDate,
            DateTime EndDate)
        {
            int count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*)
             FROM PasswordsHistory
             WHERE PasswordChange >= @StartDate
             AND PasswordChange < @EndDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        await connection.OpenAsync();
                        count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }



            return count;
        }


        /// <summary>
        /// Retrieves the number of password changes recorded for a specific user
        /// within a specified date and time period.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user whose password changes will be counted.
        /// </param>
        /// <param name="StartDate">
        /// The inclusive starting date and time of the period.
        /// </param>
        /// <param name="EndDate">
        /// The exclusive ending date and time of the period.
        /// </param>
        /// <returns>
        /// The number of password changes recorded for the specified user during the period.
        /// </returns>
        public static async Task<int> GetUserPasswordChangesCountByPeriodAsync(
            int UserID,
            DateTime StartDate,
            DateTime EndDate)
        {
            int count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*)
             FROM PasswordsHistory
             WHERE UserID = @UserID
             AND PasswordChange >= @StartDate
             AND PasswordChange < @EndDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        await connection.OpenAsync();
                        count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }
  


            return count;
        }


        /// <summary>
        /// Retrieves the most recent password change date recorded for a specific user.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user whose latest password change date is requested.
        /// </param>
        /// <returns>
        /// A nullable <see cref="DateTime"/> containing the latest password change date
        /// if a record exists; otherwise, returns null.
        /// </returns>
        public static async Task<DateTime?> GetLastPasswordChangeDateAsync(int UserID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT MAX(PasswordChange)
             FROM PasswordsHistory
             WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                            return (DateTime)result;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }



            return null;
        }


        /// <summary>
        /// Checks whether a specified password exists in the password history
        /// records associated with a particular user.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user whose password history will be checked.
        /// </param>
        /// <param name="Password">
        /// The password value to search for in the user's password history.
        /// </param>
        /// <returns>
        /// True if the password exists in the user's history; otherwise, returns false.
        /// </returns>
        public static async Task<bool> IsPasswordInHistoryAsync(
            int UserID,
            string Password)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckPasswordInHistory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Password", Password);
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();

                        isFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPasswordHistoryData");
                throw;
            }



            return isFound;
        }
    }
}