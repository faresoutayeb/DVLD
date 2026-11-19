using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;



namespace DVLD_Data_Access_Layer
{
    /// <summary>
    /// Provides asynchronous data access operations for managing roles.
    /// </summary>
    public static class clsRoleData
    {
        /// <summary>
        /// Represents information about a role.
        /// </summary>
        public class clsRoleInfo
        {


            /// <summary>
            /// Gets or sets the unique identifier of the role.
            /// </summary>
            public int RoleID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the name of the role.
            /// </summary>
            public string RoleName { get; set; } = "";

            /// <summary>
            /// Gets or sets the permissions assigned to the role.
            /// </summary>
            public long Permissions { get; set; } = 0;

            /// <summary>
            /// Gets or sets the description of the role.
            /// </summary>
            public string Description { get; set; } = "";
        }

        /// <summary>
        /// Retrieves role information using the specified role ID.
        /// </summary>
        /// <param name="RoleID">The unique identifier of the role.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the role
        /// information if found; otherwise, null.
        /// </returns>
        public static async Task<clsRoleInfo> GetRoleInfoByIDAsync(int RoleID)
        {
  

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT RoleName, Permissions, Description
            FROM Roles
            WHERE RoleID = @RoleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", RoleID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsRoleInfo
                                {
                                    RoleID = RoleID,
                                    RoleName = (string)reader["RoleName"],
                                    Permissions = (long)reader["Permissions"],
                                    Description = (string)reader["Description"],
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
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }
   


        }


        public static clsRoleInfo GetRoleInfoByID(int RoleID)
        {
 


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT RoleName, Permissions, Description
            FROM Roles
            WHERE RoleID = @RoleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", RoleID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsRoleInfo
                                {
                                    RoleID = RoleID,
                                    RoleName = (string)reader["RoleName"],
                                    Permissions = (long)reader["Permissions"],
                                    Description = (string)reader["Description"]
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
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }


        }


        /// <summary>
        /// Retrieves role information using the specified role name.
        /// </summary>
        /// <param name="RoleName">The name of the role.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the role
        /// information if found; otherwise, null.
        /// </returns>
        public static async Task<clsRoleInfo> GetRoleInfoByNameAsync(string RoleName)
        {
       


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT RoleID, Permissions, Description
            FROM Roles
            WHERE RoleName = @RoleName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleName", RoleName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsRoleInfo
                                {
                                    RoleID = (int)reader["RoleID"],
                                    RoleName = RoleName,
                                    Permissions = (long)reader["Permissions"],
                                    Description = (string)reader["Description"]
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
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }
   


        }


        public static clsRoleInfo GetRoleInfoByName(string RoleName)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT RoleID, Permissions, Description
            FROM Roles
            WHERE RoleName = @RoleName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleName", RoleName);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsRoleInfo
                                {
                                    RoleID = (int)reader["RoleID"],
                                    RoleName = RoleName,
                                    Permissions = (long)reader["Permissions"],
                                    Description = (string)reader["Description"]
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
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }



        }
















        /// <summary>
        /// Retrieves all roles stored in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the role IDs, names, permissions, and descriptions.
        /// </returns>
        public static async Task<DataTable> GetAllRolesAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT RoleID, RoleName, Permissions, Description
            FROM Roles";

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
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }
            



            return dt;
        }

        /// <summary>
        /// Retrieves the number of users assigned to each role.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with each role ID and its corresponding user count.
        /// </returns>
        public static async Task<DataTable> GetRolesUsersCountAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT
                RoleID,
                TotalUsersPerRole =
                (
                    SELECT COUNT(*)
                    FROM Users
                    WHERE Users.RoleID = Roles.RoleID
                )
            FROM Roles";

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
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }
  

            return dt;
        }

        /// <summary>
        /// Adds a new role to the database.
        /// </summary>
        /// <param name="RoleName">The name of the role to add.</param>
        /// <param name="Permissions">The permissions assigned to the role.</param>
        /// <param name="Description">The description of the role.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the ID
        /// of the newly created role, or -1 if no ID was returned.
        /// </returns>
        public static async Task<int> AddNewRoleAsync(
            string RoleName,
            long Permissions,
            string Description)
        {
            int RoleID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewRole", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@RoleName", RoleName);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@Description", Description);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewRoleID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (outputIdParam.Value != null &&
                            outputIdParam.Value != DBNull.Value)
                        {
                            RoleID = Convert.ToInt32(outputIdParam.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }
   


            return RoleID;
        }





        /// <summary>
        /// Updates an existing role in the database.
        /// </summary>
        /// <param name="RoleID">The ID of the role to update.</param>
        /// <param name="RoleName">The updated name of the role.</param>
        /// <param name="Permissions">The updated permissions assigned to the role.</param>
        /// <param name="Description">The updated description of the role.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// at least one row was affected; otherwise, false.
        /// </returns>
        public static async Task<bool> UpdateRoleAsync(
            int RoleID,
            string RoleName,
            long Permissions,
            string Description)
        {
            int RowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                UPDATE Roles
                SET
                    RoleName = @RoleName,
                    Permissions = @Permissions,
                    Description = @Description
                WHERE RoleID = @RoleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", RoleID);
                        command.Parameters.AddWithValue("@RoleName", RoleName);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@Description", Description);

                        await connection.OpenAsync();

                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }
 


            return RowsAffected > 0;
        }

        /// <summary>
        /// Retrieves the total number of roles stored in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// total number of roles.
        /// </returns>
        public static async Task<int> GetRolesCountAsync()
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT COUNT(*)
                FROM Roles";

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
                clsDataAccessEventLog.LogError(ex, "clsRoleData");
                throw;
            }



            return Count;
        }
    }
}