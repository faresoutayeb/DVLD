using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{

    /// <summary>
    /// Provides data access operations for license classes.
    /// </summary>
    public static class clsLicensesClassData
    {
        /// <summary>
        /// Represents license class information and its retrieval status.
        /// </summary>
        public class clsLicenseClassInfo
        {


            /// <summary>
            /// Gets or sets the license class identifier.
            /// </summary>
            public int LicenseClassID { get; set; }

            /// <summary>
            /// Gets or sets the name of the license class.
            /// </summary>
            public string ClassName { get; set; }

            /// <summary>
            /// Gets or sets the description of the license class.
            /// </summary>
            public string ClassDescription { get; set; }

            /// <summary>
            /// Gets or sets the minimum age required for the license class.
            /// </summary>
            public byte MinimumAllowedAge { get; set; }

            /// <summary>
            /// Gets or sets the default validity period of the license in years.
            /// </summary>
            public byte DefaultValidityLength { get; set; }

            /// <summary>
            /// Gets or sets the fees associated with the license class.
            /// </summary>
            public float ClassFees { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="clsLicenseClassInfo"/> class
            /// with default values.
            /// </summary>
            public clsLicenseClassInfo()
            {
                LicenseClassID = -1;
                ClassName = string.Empty;
                ClassDescription = string.Empty;
                MinimumAllowedAge = 0;
                DefaultValidityLength = 0;
                ClassFees = 0;
            }
        }

        /// <summary>
        /// Retrieves license class information using its identifier.
        /// </summary>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task containing the license class information, or null if no record is found.
        /// </returns>
        public static async Task<clsLicenseClassInfo>
            GetLicenseClassInfoByIDAsync(int LicenseClassID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
             SELECT *
             FROM LicenseClasses
             WHERE LicenseClassID = @LicenseClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsLicenseClassInfo
                                {
                            LicenseClassID = LicenseClassID,
                                    ClassName = (string)reader["ClassName"],
                                    ClassDescription = (string)reader["ClassDescription"],
                                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"],
                                    DefaultValidityLength = (byte)reader["DefaultValidityLength"],
                                    ClassFees = Convert.ToSingle(reader["ClassFees"])

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
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



        }


        public static clsLicenseClassInfo
    GetLicenseClassInfoByID(int LicenseClassID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
             SELECT *
             FROM LicenseClasses
             WHERE LicenseClassID = @LicenseClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsLicenseClassInfo
                                {
                                    LicenseClassID = LicenseClassID,
                                    ClassName = (string)reader["ClassName"],
                                    ClassDescription = (string)reader["ClassDescription"],
                                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"],
                                    DefaultValidityLength = (byte)reader["DefaultValidityLength"],
                                    ClassFees = Convert.ToSingle(reader["ClassFees"]),

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
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



        }



        /// <summary>
        /// Retrieves license class information using its name.
        /// </summary>
        /// <param name="ClassName">The name of the license class.</param>
        /// <returns>
        /// A task containing the license class information, or null if no record is found.
        /// </returns>
        public static async Task<clsLicenseClassInfo>
            GetLicenseClassInfoByClassNameAsync(string ClassName)
        {
   


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
             SELECT *
             FROM LicenseClasses
             WHERE ClassName = @ClassName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassName", ClassName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsLicenseClassInfo
                                {
                                    LicenseClassID = (int)reader["LicenseClassID"],
                                    ClassName = (string)reader["ClassName"],
                                    ClassDescription = (string)reader["ClassDescription"],
                                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"],
                                    DefaultValidityLength = (byte)reader["DefaultValidityLength"],
                                    ClassFees = Convert.ToSingle(reader["ClassFees"])

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
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



        }


        public static clsLicenseClassInfo
    GetLicenseClassInfoByClassName(string ClassName)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
             SELECT *
             FROM LicenseClasses
             WHERE ClassName = @ClassName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassName", ClassName);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsLicenseClassInfo
                                {
                                    LicenseClassID = (int)reader["LicenseClassID"],
                                    ClassName = (string)reader["ClassName"],
                                    ClassDescription = (string)reader["ClassDescription"],
                                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"],
                                    DefaultValidityLength = (byte)reader["DefaultValidityLength"],
                                    ClassFees = Convert.ToSingle(reader["ClassFees"])

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
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



        }


        /// <summary>
        /// Adds a new license class to the database.
        /// </summary>
        /// <param name="ClassName">The name of the license class.</param>
        /// <param name="ClassDescription">The description of the license class.</param>
        /// <param name="MinimumAllowedAge">The minimum age required for the license class.</param>
        /// <param name="DefaultValidityLength">The default validity period in years.</param>
        /// <param name="ClassFees">The fees associated with the license class.</param>
        /// <returns>
        /// A task containing the new license class identifier, or -1 if no identifier is returned.
        /// </returns>
        public static async Task<int> AddNewLicenseClassAsync(
            string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge,
            byte DefaultValidityLength,
            float ClassFees)
        {
            int LicenseClassID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewLicenseClass", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClassName", ClassName);
                        command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                        command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                        command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                        command.Parameters.AddWithValue("@ClassFees", ClassFees);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewLicenseClassID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (outputIdParam.Value != DBNull.Value)
                            LicenseClassID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



            return LicenseClassID;
        }

        /// <summary>
        /// Updates an existing license class in the database.
        /// </summary>
        /// <param name="LicenseClassID">The identifier of the license class to update.</param>
        /// <param name="ClassName">The updated name of the license class.</param>
        /// <param name="ClassDescription">The updated description of the license class.</param>
        /// <param name="MinimumAllowedAge">The updated minimum age requirement.</param>
        /// <param name="DefaultValidityLength">The updated default validity period in years.</param>
        /// <param name="ClassFees">The updated fees associated with the license class.</param>
        /// <returns>
        /// A task containing true if at least one row was updated; otherwise, false.
        /// </returns>
        public static async Task<bool> UpdateLicenseClassAsync(
            int LicenseClassID,
            string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge,
            byte DefaultValidityLength,
            float ClassFees)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
             UPDATE LicenseClasses
             SET ClassName = @ClassName,
                 ClassDescription = @ClassDescription,
                 MinimumAllowedAge = @MinimumAllowedAge,
                 DefaultValidityLength = @DefaultValidityLength,
                 ClassFees = @ClassFees
             WHERE LicenseClassID = @LicenseClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        command.Parameters.AddWithValue("@ClassName", ClassName);
                        command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                        command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                        command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                        command.Parameters.AddWithValue("@ClassFees", ClassFees);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



            return rowsAffected > 0;
        }



        /// <summary>
        /// Retrieves all license classes from the database.
        /// </summary>
        /// <returns>A task containing a DataTable with all license class records.</returns>
        public static async Task<DataTable> GetAllLicenseClassesNameAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"

                      SELECT dbo.LicenseClasses.ClassName
           FROM DBO.LicenseClasses
";

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
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }
  


            return dt;
        }


        public static async Task<DataTable> GetAllLicenseClassesAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"

                          SELECT dbo.LicenseClasses.LicenseClassID ,dbo.LicenseClasses.ClassName,
                      dbo.LicenseClasses.ClassDescription,
                      dbo.LicenseClasses.ClassDescription,dbo.LicenseClasses.ClassFees,dbo.LicenseClasses.DefaultValidityLength
           FROM DBO.LicenseClasses
";

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
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



            return dt;
        }


        /// <summary>
        /// Deletes a license class from the database using its identifier.
        /// </summary>
        /// <param name="LicenseClassID">The identifier of the license class to delete.</param>
        /// <returns>A task containing true if at least one row was deleted; otherwise, false.</returns>
        public static async Task<bool> DeleteLicenseClassAsync(int LicenseClassID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
           DELETE FROM LicenseClasses
           WHERE LicenseClassID = @LicenseClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



            return rowsAffected > 0;
        }

        /// <summary>
        /// Checks whether a license class exists using its identifier.
        /// </summary>
        /// <param name="LicenseClassID">The identifier of the license class to check.</param>
        /// <returns>A task containing true if the license class exists; otherwise, false.</returns>
        public static async Task<bool> IsLicenseClassExistAsync(int LicenseClassID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckLicenseClassExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



            return isFound;
        }

        /// <summary>
        /// Checks whether a license class exists using its name.
        /// </summary>
        /// <param name="ClassName">The name of the license class to check.</param>
        /// <returns>A task containing true if the license class exists; otherwise, false.</returns>
        public static async Task<bool> IsLicenseClassExistAsync(string ClassName)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckLicenseClassExistsByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClassName", ClassName);
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
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



            return isFound;
        }


        /// <summary>
        /// Retrieves the fees associated with a license class using its identifier.
        /// </summary>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task containing the license class fees, or 0 if no fees are returned.
        /// </returns>
        public static async Task<float> GetLicenseClassFeesByIDAsync(int LicenseClassID)
        {
            float LicenseClassFees = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT ClassFees
FROM LicenseClasses
WHERE LicenseClassID = @LicenseClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            LicenseClassFees = Convert.ToSingle(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }
   


            return LicenseClassFees;
        }

        /// <summary>
        /// Retrieves the identifier of a license class using its name.
        /// </summary>
        /// <param name="LicenseClassName">The name of the license class.</param>
        /// <returns>
        /// A task containing the license class identifier, or -1 if no identifier is returned.
        /// </returns>
        public static async Task<int> GetLicenseClassIDByNameAsync(string LicenseClassName)
        {
            int LicenseClassID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT TOP 1 LicenseClassID
FROM LicenseClasses
WHERE ClassName = @ClassName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassName", LicenseClassName);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            LicenseClassID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }
  


            return LicenseClassID;
        }

        /// <summary>
        /// Retrieves the name of a license class using its identifier.
        /// </summary>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task containing the license class name, or an empty string if no name is returned.
        /// </returns>
        public static async Task<string> GetLicenseClassNameByIDAsync(int LicenseClassID)
        {
            string LicenseClassName = "";



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT TOP 1 ClassName
FROM LicenseClasses
WHERE LicenseClassID = @LicenseClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            LicenseClassName = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLicensesClassData");
                throw;
            }



            return LicenseClassName;
        }

    }
}