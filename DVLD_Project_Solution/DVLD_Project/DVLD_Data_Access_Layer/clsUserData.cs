using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{

    /// <summary>
    /// Provides asynchronous data access operations for retrieving user information.
    /// </summary>
    public static class clsUserData
    {
        /// <summary>
        /// Represents information about a user.
        /// </summary>
        public class clsUserInfo
        {
    
            /// <summary>
            /// Gets or sets the unique identifier of the user.
            /// </summary>
            public int UserID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the identifier of the person associated with the user.
            /// </summary>
            public int PersonID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the username of the user.
            /// </summary>
            public string UserName { get; set; } = "";

            /// <summary>
            /// Gets or sets the password of the user.
            /// </summary>
            public string Password { get; set; } = "";
            public string PasswordSalt { get; set; } = "";
            /// <summary>
            /// Gets or sets whether the user account is active.
            /// </summary>
            public bool IsActive { get; set; } = false;

            /// <summary>
            /// Gets or sets the identifier of the user's role.
            /// </summary>
            public int? RoleID { get; set; } = null;

            /// <summary>
            /// Gets or sets whether the user account is locked.
            /// </summary>
            public bool IsLocked { get; set; } = false;

            /// <summary>
            /// Gets or sets the date and time when the user signed up.
            /// </summary>
            public DateTime SignUpDateTime { get; set; } = DateTime.MinValue;
        }

        /// <summary>
        /// Retrieves user information using the specified user ID.
        /// </summary>
        /// <param name="UserID">
        /// The unique identifier of the user.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the user
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get User Info By User ID
        public static async Task<clsUserInfo> GetUserInfoByUserIDAsync(int UserID)
        {
      
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT UserID, PersonID, UserName, Password, IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserID = @UserID
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {

                                return new clsUserInfo
                                {

                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"],

                                    RoleID = ( reader["RoleID"] != DBNull.Value)? (int)reader["RoleID"]:-1,



                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }

        }

        public static clsUserInfo GetUserInfoByUserID(int UserID)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT UserID, PersonID, UserName, Password , IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserID = @UserID
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {

                                return new clsUserInfo
                                {

                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"],

                                    RoleID = (reader["RoleID"] != DBNull.Value) ? (int)reader["RoleID"] : -1,



                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }

        }








        /// <summary>
        /// Retrieves user information using the specified username.
        /// </summary>
        /// <param name="UserName">
        /// The username of the user.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the user
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get User Info By User Name
        public static async Task<clsUserInfo> GetUserInfoByUserNameAsync(string UserName)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
              SELECT UserID, PersonID, UserName, Password ,IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserName = @UserName
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())

                            {

                                return new clsUserInfo
                                {

                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = (reader["RoleID"] != DBNull.Value) ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
 
        }

        public static clsUserInfo GetUserInfoByUserName(string UserName)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
              SELECT UserID, PersonID, UserName, Password ,IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserName = @UserName
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())

                            {

                                return new clsUserInfo
                                {

                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"],

                                    RoleID = (reader["RoleID"] != DBNull.Value) ? (int)reader["RoleID"] : -1,



                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }

        }



        /// <summary>
        /// Retrieves user information using the specified person ID.
        /// </summary>
        /// <param name="PersonID">
        /// The unique identifier of the person associated with the user.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the user
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get User Info By Person ID
        public static async Task<clsUserInfo> GetUserInfoByPersonIDAsync(int PersonID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT UserID, PersonID, UserName, Password , IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE PersonID = @PersonID
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsUserInfo
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = reader["RoleID"] != DBNull.Value
                                        ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]
                                };
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }


        }

        public static clsUserInfo GetUserInfoByPersonID(int PersonID)



        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT UserID, PersonID, UserName, Password, IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE PersonID = @PersonID
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsUserInfo
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = reader["RoleID"] != DBNull.Value
                                        ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]
                                };
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }


        }





        /// <summary>
        /// Retrieves user information using the specified national number.
        /// </summary>
        /// <param name="NationalNo">
        /// The national number of the person associated with the user.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the user
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        // Get User Info By National Number
        public static async Task<clsUserInfo> GetUserInfoByNationalNoAsync(string NationalNo)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT Users.UserID, Users.PersonID, Users.UserName,
                       Users.Password, Users.IsActive, Users.RoleID,
                       Users.SignUpDateTime, Users.IsLocked
                FROM dbo.Users
                INNER JOIN dbo.People
                    ON Users.PersonID = People.PersonID
                WHERE People.NationalNo = @NationalNo
                  AND Users.MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsUserInfo
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = reader["RoleID"] != DBNull.Value
                                        ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]
                                };
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
   

        }

        public static clsUserInfo GetUserInfoByNationalNo(string NationalNo)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT Users.UserID, Users.PersonID, Users.UserName,
                       Users.Password, Users.IsActive, Users.RoleID,
                       Users.SignUpDateTime, Users.IsLocked
                FROM dbo.Users
                INNER JOIN dbo.People
                    ON Users.PersonID = People.PersonID
                WHERE People.NationalNo = @NationalNo
                  AND Users.MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsUserInfo
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = reader["RoleID"] != DBNull.Value
                                        ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]
                                };
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }


        }



        /// <summary>
        /// Retrieves user information using the specified username and password.
        /// </summary>
        /// <param name="UserName">The username of the user.</param>
        /// <param name="Password">The password of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the user
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// by returning null.
        /// </exception>
        // Get User Info By User Name And Password
        public static async Task<clsUserInfo> GetUserInfoByUserNameAndPasswordAsync(
            string UserName,
            string Password)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT UserID, PersonID, UserName, IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserName = @UserName
                  AND Password = @Password
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);

                       await  connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsUserInfo
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = reader["RoleID"] != DBNull.Value
                                        ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]
                                };
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
       

        }


        // Get User Info By User Name And Password
        public static async Task<clsUserInfo> GetLoginInfoByUserNameAsync(
            string UserName)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT UserID, PersonID, UserName, IsActive,Password, PasswordSalt,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserName = @UserName
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsUserInfo
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = reader["RoleID"] != DBNull.Value
                                        ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"],
                                    Password = (string)reader["Password"],
                                    PasswordSalt = (string)reader["PasswordSalt"]


                                };
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }


        }
        // Get User Info By User Name And Password
        public static  clsUserInfo GetLoginInfoByUserName(
            string UserName)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT UserID, PersonID, UserName, IsActive,Password, PasswordSalt,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserName = @UserName
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsUserInfo
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = reader["RoleID"] != DBNull.Value
                                        ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"],
                                    Password = (string)reader["Password"],
                                    PasswordSalt = (string)reader["PasswordSalt"]


                                };
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }


        }

        public static clsUserInfo GetUserInfoByUserNameAndPassword(
    string UserName,
    string Password)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT UserID, PersonID, UserName, IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserName = @UserName
                  AND Password = @Password
                  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsUserInfo
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    IsActive = (bool)reader["IsActive"],
                                    RoleID = reader["RoleID"] != DBNull.Value
                                        ? (int)reader["RoleID"] : -1,
                                    SignUpDateTime = (DateTime)reader["SignUpDateTime"],
                                    IsLocked = (bool)reader["IsLocked"]
                                };
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }


        }


        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="PersonID">The identifier of the person associated with the user.</param>
        /// <param name="UserName">The username of the new user.</param>
        /// <param name="Password">The password of the new user.</param>
        /// <param name="IsActive">Indicates whether the user account is active.</param>
        /// <param name="IsLocked">Indicates whether the user account is locked.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the identifier
        /// of the newly added user, or -1 if the operation fails.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled.
        /// </exception>
        public static async Task<int> AddNewUserAsync(
        int PersonID,
        string UserName,
        string Password,string PasswordSalt,
        bool IsActive,
        bool IsLocked)
        {
            int UserID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);
                        command.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewUserID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        UserID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
    


            return UserID;
        }


        /// <summary>
        /// Updates the information of an existing user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user to update.</param>
        /// <param name="PersonID">The identifier of the person associated with the user.</param>
        /// <param name="UserName">The updated username.</param>
        /// <param name="IsActive">Indicates whether the user account is active.</param>
        /// <param name="RoleID">The identifier of the user's role, or null if no role is assigned.</param>
        /// <param name="IsLocked">Indicates whether the user account is locked.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one row was affected; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled.
        /// </exception>
        public static async Task<bool> UpdateUserAsync(
            int UserID,
            int PersonID,
            string UserName,
            bool IsActive,
            int? RoleID,
            bool IsLocked)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 UPDATE Users
 SET PersonID = @PersonID,
     UserName = @UserName,
     IsActive = @IsActive,
     RoleID = @RoleID,
     IsLocked = @IsLocked
 WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue(
                            "@RoleID", RoleID ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
   


            return rowsAffected > 0;
        }


        /// <summary>
        /// Marks a user for deletion and deactivates and locks the user account.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one row was affected; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled.
        /// </exception>
        public static async Task<bool> DeleteUserAsync(int UserID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 UPDATE Users
 SET MarkForDelete = 1,
     IsActive = 0,
     IsLocked = 1
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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }



            return rowsAffected > 0;
        }


        /// <summary>
        /// Determines whether a user with the specified identifier exists.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the user
        /// exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled.
        /// </exception>
        public static async Task<bool> IsUserExistAsync(int UserID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckUserExistsByID", connection))
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

                        isFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
 


            return isFound;
        }

        /// <summary>
        /// Determines whether a user with the specified username exists.
        /// </summary>
        /// <param name="UserName">The username of the user to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the user
        /// exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<bool> IsUserExistByUserNameAsync(string UserName)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckUserExistsByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
   


            return isFound;
        }


        public static bool GetUserLoginInfoByUsername( string UserName, ref string PasswordHash, ref string PasswordSalt)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string Query = @"SELECT Password, PasswordSalt
                         FROM Users
                         WHERE UserName = @UserName
                         AND MarkForDelete = 0";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@UserName", UserName);

                    Connection.Open();

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            PasswordHash = (string)Reader["Password"];
                            PasswordSalt = (string)Reader["PasswordSalt"];

                            IsFound = true;
                        }
                    }
                }
            }

            return IsFound;
        }

        /// <summary>
        /// Determines whether a user associated with the specified person ID exists.
        /// </summary>
        /// <param name="PersonId">The identifier of the person to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if a user
        /// associated with the specified person exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<bool> IsUserExistByPersonIdAsync(int PersonId)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckUserExistsByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonId", PersonId);

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
     


            return isFound;
        }

        /// <summary>
        /// Retrieves user information for displaying users in the users screen.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with user IDs, person IDs, full names, usernames, and account statuses.
        /// Returns an empty DataTable if no records are found or an exception occurs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<DataTable> GetUsersScreenUsersInfoAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        Users.UserID,
        Users.PersonID,
        People.FirstName + ' ' +
        ISNULL(People.SecondName + ' ', '') +
        ISNULL(People.ThirdName + ' ', '') +
        People.LastName AS FullName,
        Users.UserName,
        Users.IsActive
    FROM Users
    INNER JOIN People
        ON People.PersonID = Users.PersonID
    WHERE Users.MarkForDelete = 0";

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
  


            return dt;
        }

        /// <summary>
        /// Retrieves user role information, including role names, user counts,
        /// permissions, and descriptions.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the retrieved user role information. The DataTable is empty if
        /// no records are found or an exception occurs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<DataTable> GetUsersRolesAsync()
        {
            DataTable dt = new DataTable();

     


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        CurrentRole.RoleName AS [Role Name],
        Users = (
            SELECT COUNT(*)
            FROM dbo.Users
            WHERE dbo.Users.RoleID = CurrentRole.RoleID
              AND dbo.Users.MarkForDelete = 0
        ),
        dbo.UserPermissions.Permissions,
        CurrentRole.Description
    FROM dbo.Roles AS CurrentRole
    INNER JOIN dbo.Users
        ON dbo.Users.RoleID = CurrentRole.RoleID
    INNER JOIN dbo.UserPermissions
        ON dbo.Users.UserID = dbo.UserPermissions.UserID
    WHERE dbo.Users.MarkForDelete = 0";

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }



            return dt;
        }

        /// <summary>
        /// Retrieves the username associated with the specified user ID.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the username
        /// if found; otherwise, an empty string.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<string> GetUserNameByIDAsync(int UserID)
        {
            string UserNameFounded = "";



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT UserName
    FROM dbo.Users
    WHERE UserID = @UserID
      AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            UserNameFounded = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
      


            return UserNameFounded;
        }

        /// <summary>
        /// Retrieves the user ID associated with the specified username.
        /// </summary>
        /// <param name="UserName">The username of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the user ID
        /// if found; otherwise, -1.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetUserIDByUserNameAsync(string UserName)
        {
            int UserIDFounded = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT UserID
FROM dbo.Users
WHERE UserName = @UserName
  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int userIDParsed))
                        {
                            UserIDFounded = userIDParsed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }


            return UserIDFounded;
        }

        /// <summary>
        /// Retrieves the number of users who signed up within the specified date range.
        /// </summary>
        /// <param name="StartDateTime">The inclusive start date and time of the range.</param>
        /// <param name="EndDateTime">The exclusive end date and time of the range.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of users who signed up within the specified date range.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetUserCountSignUpBetweenAsync(
            DateTime StartDateTime,
            DateTime EndDateTime)
        {
            int Counter = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT COUNT(*)
FROM dbo.Users
WHERE SignUpDateTime >= @StartDateTime
  AND SignUpDateTime < @EndDateTime";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDateTime", StartDateTime);
                        command.Parameters.AddWithValue("@EndDateTime", EndDateTime);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Counter = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }



            return Counter;
        }

        /// <summary>
        /// Changes the password of the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <param name="NewPassword">The new password to assign to the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one row was affected; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<bool> ChangePasswordAsync(
            int UserID,
            string NewPassword,
            string PasswordSalt)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                        UPDATE Users
                        SET Password = @Password,
                        PasswordSalt=@PasswordSalt
                        WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Password", NewPassword);
                        command.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
 


            return rowsAffected > 0;
        }

        /// <summary>
        /// Determines whether the specified user ID belongs to an active user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the
        /// user is active; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<bool> IsActiveUserAsync(int UserID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckUserActiveByID", connection))
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

                        isFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
   


            return isFound;
        }

        /// <summary>
        /// Determines whether the specified username belongs to an active user.
        /// </summary>
        /// <param name="UserName">The username of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the
        /// user is active; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<bool> IsActiveUserAsync(string UserName)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckUserActiveByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", UserName);

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
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }



            return isFound;
        }

        /// <summary>
        /// Retrieves the number of users matching the specified account activity status.
        /// </summary>
        /// <param name="IsActive">
        /// Indicates whether to count active users. Defaults to true.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of users matching the specified activity status.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetActiveUsersCountAsync(bool IsActive = true)
        {
            int Counter = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT COUNT(*)
FROM Users
WHERE IsActive = @IsActive
  AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Counter = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }


            return Counter;
        }

        /// <summary>
        /// Retrieves the number of users matching the specified account lock status.
        /// </summary>
        /// <param name="IsLocked">
        /// Indicates whether to count locked users. Defaults to true.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of users matching the specified lock status.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetLockedUsersCountAsync(bool IsLocked = true)
        {
            int Counter = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT COUNT(*)
 FROM Users
 WHERE IsLocked = @IsLocked
   AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Counter = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
    


            return Counter;
        }

        /// <summary>
        /// Retrieves the total number of users who are not marked for deletion.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of users who are not marked for deletion.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetAllUsersCountAsync()
        {
            int Counter = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT COUNT(*)
 FROM Users
 WHERE MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Counter = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
 


            return Counter;
        }

        /// <summary>
        /// Retrieves the number of users who have a role assigned and are not marked
        /// for deletion.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of users with a non-null role ID who are not marked for deletion.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetRolesDefinedUsersCountAsync()
        {
            int Counter = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT COUNT(*)
 FROM dbo.Users
 WHERE RoleID IS NOT NULL
   AND MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Counter = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
  


            return Counter;
        }

        /// <summary>
        /// Retrieves the number of users assigned to the specified role.
        /// </summary>
        /// <param name="RoleID">The unique identifier of the role.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of users assigned to the specified role.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetRoleUsersCountAsync(int RoleID)
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT COUNT(*)
 FROM Users
 WHERE Users.RoleID = @RoleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", RoleID);

                        await connection.OpenAsync();

                        Count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
            




            return Count;
        }

        /// <summary>
        /// Retrieves the number of users who currently have an active session
        /// without a recorded logout time and are not marked for deletion.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of users who are currently online according to their user logs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetOnlineUsersCountAsync()
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT COUNT(*)
 FROM dbo.UsersLogs
 INNER JOIN Users
     ON Users.UserID = UsersLogs.UserID
 WHERE UsersLogs.LogoutDateTime IS NULL
   AND Users.MarkForDelete = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Count = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }



            return Count;
        }
        /// <summary>
        /// Retrieves the number of users who have never logged in.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of users who are not marked for deletion and have no records in UsersLogs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<int> GetNeverLogedInUsersCountAsync()
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT COUNT(*)
FROM dbo.Users
WHERE MarkForDelete = 0
  AND UserID NOT IN
  (
      SELECT UserID
      FROM dbo.UsersLogs
  )";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Count = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
   


            return Count;
        }

        /// <summary>
        /// Retrieves the date and time of the most recent user login.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the most recent
        /// login date and time, or the current date and time if no valid result is found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<DateTime> GetLastLogedInUserDateTimeAsync()
        {
            DateTime CurrentDateTime = DateTime.Now;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT TOP 1 LoginDateTime
FROM UsersLogs
ORDER BY LoginDateTime DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            DateTime.TryParse(result.ToString(), out DateTime parsedDateTime))
                        {
                            CurrentDateTime = parsedDateTime;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
 


            return CurrentDateTime;
        }

        /// <summary>
        /// Retrieves the most recent login date and time for the specified user.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the user's most
        /// recent login date and time, or the current date and time if no valid result is found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown.
        /// </exception>
        public static async Task<DateTime> GetLastLogedInDateTimeAsync(int UserID)
        {
            DateTime CurrentDateTime = DateTime.Now;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT TOP 1 UsersLogs.LoginDateTime
FROM UsersLogs
WHERE UsersLogs.UserID = @UserID
ORDER BY UsersLogs.LoginDateTime DESC;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            DateTime.TryParse(result.ToString(), out DateTime parsedDateTime))
                        {
                            CurrentDateTime = parsedDateTime;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsUserData");
                throw;
            }
    


            return CurrentDateTime;
        }
    }
}