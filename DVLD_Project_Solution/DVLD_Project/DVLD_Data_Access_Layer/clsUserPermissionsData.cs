using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    /// <summary>
    /// Provides asynchronous data access operations for managing user permissions.
    /// </summary>
    public static class clsUserPermissionsData
    {
        /// <summary>
        /// Represents information about a user's permissions.
        /// </summary>
        public class stUserPermissionsInfo
        {

            /// <summary>
            /// Gets or sets the unique identifier of the user permissions record.
            /// </summary>
            public int UserPermissionsID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the unique identifier of the user associated with these permissions.
            /// </summary>
            public int UserID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the numeric value representing the user's permissions.
            /// </summary>
            public long Permissions { get; set; } = 0;
        }

        /// <summary>
        /// Retrieves user permissions using the specified permissions record ID.
        /// </summary>
        /// <param name="UserPermissionsID">The unique identifier of the user permissions record.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the permissions
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<stUserPermissionsInfo> GetPermissionsByIDAsync(
            int UserPermissionsID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT *
                FROM dbo.UserPermissions
                WHERE UserPermissionsID = @UserPermissionsID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@UserPermissionsID", UserPermissionsID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new stUserPermissionsInfo
                                {
                                    UserPermissionsID = UserPermissionsID,
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Permissions = Convert.ToInt64(reader["Permissions"])
                                };
   
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserPermissionsData");
                throw;
            }



        }


        public static stUserPermissionsInfo GetPermissionsByID(
    int UserPermissionsID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT *
                FROM dbo.UserPermissions
                WHERE UserPermissionsID = @UserPermissionsID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@UserPermissionsID", UserPermissionsID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new stUserPermissionsInfo
                                {
                                    UserPermissionsID = UserPermissionsID,
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Permissions = Convert.ToInt64(reader["Permissions"])
                                };

                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserPermissionsData");
                throw;
            }



        }





        /// <summary>
        /// Retrieves user permissions using the specified user ID.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the permissions
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static stUserPermissionsInfo GetPermissionsByUserID(
            int UserID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT *
                FROM dbo.UserPermissions
                WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new stUserPermissionsInfo
                                {
                                    UserPermissionsID =
                                        Convert.ToInt32(reader["UserPermissionsID"]),
                                    UserID = UserID,
                                    Permissions =
                                        Convert.ToInt64(reader["Permissions"])
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
                clsDataAccessEventLog.LogError(ex, "clsUserPermissionsData");
                throw;
            }
  


        }


        public static async Task<stUserPermissionsInfo> GetPermissionsByUserIDAsync(
    int UserID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT *
                FROM dbo.UserPermissions
                WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                       await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if ( await reader.ReadAsync())
                            {
                                return new stUserPermissionsInfo
                                {
                                    UserPermissionsID =
                                        Convert.ToInt32(reader["UserPermissionsID"]),
                                    UserID = UserID,
                                    Permissions =
                                        Convert.ToInt64(reader["Permissions"])
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
                clsDataAccessEventLog.LogError(ex, "clsUserPermissionsData");
                throw;
            }



        }





        /// <summary>
        /// Adds a new user permissions record to the database.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <param name="Permissions">The numeric value representing the user's permissions.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the identifier
        /// of the newly created permissions record, or -1 if the operation fails.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> AddNewUserPermissionsAsync(
            int UserID,
            long Permissions)
        {
            int UserPermissionsID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewUserPermissions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Permissions", Permissions);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewUserPermissionsID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        UserPermissionsID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserPermissionsData");
                throw;
            }


            return UserPermissionsID;
        }

        /// <summary>
        /// Updates an existing user permissions record in the database.
        /// </summary>
        /// <param name="UserPermissionsID">The unique identifier of the permissions record to update.</param>
        /// <param name="UserID">The unique identifier of the user associated with the permissions.</param>
        /// <param name="Permissions">The updated numeric value representing the user's permissions.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one row was affected; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<bool> UpdateUserPermissionsAsync(
            int UserPermissionsID,
            int UserID,
            long Permissions)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            UPDATE UserPermissions
            SET UserID = @UserID,
                Permissions = @Permissions
            WHERE UserPermissionsID = @UserPermissionsID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@UserPermissionsID", UserPermissionsID);

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Permissions", Permissions);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserPermissionsData");
                throw;
            }
 


            return rowsAffected > 0;
        }

        /// <summary>
        /// Retrieves the permissions assigned to the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the user's
        /// permissions value, or 0 if no valid result is found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<long> GetUserPermissionsByUserIDAsync(int UserID)
        {
            long UserPermissions = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT Permissions
                FROM dbo.UserPermissions
                WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            long.TryParse(
                                result.ToString(),
                                out long parsedUserPermissions))
                        {
                            UserPermissions = parsedUserPermissions;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserPermissionsData");
                throw;
            }
     


            return UserPermissions;
        }

        /// <summary>
        /// Retrieves user and role information, including each user's full name,
        /// username, role name, account status, and most recent login date.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the retrieved user and role information, or an empty DataTable
        /// if no records are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<DataTable> GetUserRoleInfoAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT 
                    CurrentUser.UserID AS [User ID],

                    [Full Name] =
                        People.FirstName + ' ' +
                        ISNULL(People.SecondName, '') +
                        ISNULL(People.ThirdName, '') + ' ' +
                        People.LastName,

                    CurrentUser.UserName AS [User Name],

                    Roles.RoleName AS [Role Name],

                    [Is Active] =
                        CASE
                            WHEN CurrentUser.IsActive = 1
                                THEN 'Active'
                            ELSE 'Inactive'
                        END,

                    (
                        SELECT TOP 1
                            UsersLogs.LoginDateTime
                        FROM UsersLogs
                        WHERE UsersLogs.UserID = CurrentUser.UserID
                        ORDER BY UsersLogs.LoginDateTime DESC
                    ) AS [Last Login]

                FROM Users AS CurrentUser

                INNER JOIN People
                    ON People.PersonID = CurrentUser.PersonID

                INNER JOIN Roles
                    ON Roles.RoleID = CurrentUser.RoleID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserPermissionsData");
                throw;
            }



            return dt;
        }
    }
}