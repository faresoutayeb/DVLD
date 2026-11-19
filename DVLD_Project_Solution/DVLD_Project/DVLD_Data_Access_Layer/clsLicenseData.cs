using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;




namespace DVLD_Data_Access_Layer
{

        /// <summary>
        /// Provides data access operations for driving licenses.
        /// </summary>
        public static class clsLicenseData
        {
            /// <summary>
            /// Represents license information and its retrieval status.
            /// </summary>
            public class clsLicenseInfo
            {
 

                /// <summary>
                /// Gets or sets the license identifier.
                /// </summary>
                public int LicenseID { get; set; }

                /// <summary>
                /// Gets or sets the associated application identifier.
                /// </summary>
                public int ApplicationID { get; set; }

                /// <summary>
                /// Gets or sets the driver identifier.
                /// </summary>
                public int DriverID { get; set; }

                /// <summary>
                /// Gets or sets the license class identifier.
                /// </summary>
                public int LicenseClassID { get; set; }

                /// <summary>
                /// Gets or sets the license issue date.
                /// </summary>
                public DateTime IssueDate { get; set; }

                /// <summary>
                /// Gets or sets the license expiration date.
                /// </summary>
                public DateTime ExpirationDate { get; set; }

                /// <summary>
                /// Gets or sets the notes associated with the license.
                /// </summary>
                public string Notes { get; set; }

                /// <summary>
                /// Gets or sets the fees paid for the license.
                /// </summary>
                public float PaidFees { get; set; }

                /// <summary>
                /// Gets or sets whether the license is active.
                /// </summary>
                public bool IsActive { get; set; }

                /// <summary>
                /// Gets or sets the reason for issuing the license.
                /// </summary>
                public byte IssueReason { get; set; }

                /// <summary>
                /// Gets or sets the identifier of the user who created the license record.
                /// </summary>
                public int CreatedByUserID { get; set; }

                /// <summary>
                /// Initializes a new instance of the <see cref="clsLicenseInfo"/> class
                /// with default values.
                /// </summary>
                public clsLicenseInfo()
                {
                    LicenseID = -1;
                    ApplicationID = -1;
                    DriverID = -1;
                    LicenseClassID = -1;
                    IssueDate = DateTime.MinValue;
                    ExpirationDate = DateTime.MinValue;
                    Notes = "";
                    PaidFees = 0;
                    IsActive = false;
                    IssueReason = 0;
                    CreatedByUserID = -1;
                }
            }

            /// <summary>
            /// Retrieves license information using its identifier.
            /// </summary>
            /// <param name="LicenseID">The license identifier.</param>
            /// <returns>
            /// A task containing the license information, or null if no record is found.
            /// </returns>
            public static async Task<clsLicenseInfo> GetLicenseInfoByIDAsync(int LicenseID)
            {


                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
                  SELECT *
                  FROM dbo.Licenses
                  WHERE LicenseID = @LicenseID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);

                            await connection.OpenAsync();

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
                            {
                            if (await reader.ReadAsync())
                            {
                                return new clsLicenseInfo
                                {
                                    LicenseID = (int)reader["LicenseID"],
                                    ApplicationID = (int)reader["ApplicationID"], DriverID = (int)reader["DriverID"],
                                    LicenseClassID = (int)reader["LicenseClassID"],
                                    IssueDate = (DateTime)reader["IssueDate"],
                                    ExpirationDate = (DateTime)reader["ExpirationDate"],
                                    Notes = reader["Notes"] != DBNull.Value
                                            ? (string)reader["Notes"]
                                            : "",
                                    PaidFees = Convert.ToSingle(reader["PaidFees"]),
                                    IsActive = (bool)reader["IsActive"],
                                    IssueReason = (byte)reader["IssueReason"],
                                    CreatedByUserID = (int)reader["CreatedByUserID"]

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
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }



            }

        public static clsLicenseInfo GetLicenseInfoByID(int LicenseID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                  SELECT *
                  FROM dbo.Licenses
                  WHERE LicenseID = @LicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsLicenseInfo
                                {
                                    LicenseID = (int)reader["LicenseID"],
                                    ApplicationID = (int)reader["ApplicationID"],
                                    DriverID = (int)reader["DriverID"],
                                    LicenseClassID = (int)reader["LicenseClassID"],
                                    IssueDate = (DateTime)reader["IssueDate"],
                                    ExpirationDate = (DateTime)reader["ExpirationDate"],
                                    Notes = reader["Notes"] != DBNull.Value
                                            ? (string)reader["Notes"]
                                            : "",
                                    PaidFees = Convert.ToSingle(reader["PaidFees"]),
                                    IsActive = (bool)reader["IsActive"],
                                    IssueReason = (byte)reader["IssueReason"],
                                    CreatedByUserID = (int)reader["CreatedByUserID"]

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
                clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                throw;
            }



        }





        /// <summary>
        /// Retrieves the most recently issued license associated with a person.
        /// </summary>
        /// <param name="PersonID">The identifier of the person.</param>
        /// <returns>
        /// A task containing the latest license information, or null if no record is found.
        /// </returns>
        public static async Task<clsLicenseInfo> GetLastLicenseInfoByPersonIDAsync(int PersonID)
            {
         


            try
            {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
                  SELECT TOP 1 *
                  FROM Licenses
                  INNER JOIN Drivers
                      ON Drivers.DriverID = Licenses.DriverID
                  WHERE Drivers.PersonID = @PersonID
                  ORDER BY Licenses.IssueDate DESC";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);

                            await connection.OpenAsync();

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    return new clsLicenseInfo
                                    {

                                        LicenseID = (int)reader["LicenseID"],
                                        ApplicationID = (int)reader["ApplicationID"],
                                        DriverID = (int)reader["DriverID"],
                                        LicenseClassID = (int)reader["LicenseClassID"],
                                        IssueDate = (DateTime)reader["IssueDate"],
                                        ExpirationDate = (DateTime)reader["ExpirationDate"],
                                        Notes = reader["Notes"] != DBNull.Value
                                                ? (string)reader["Notes"]
                                                : "",
                                        PaidFees = Convert.ToSingle(reader["PaidFees"]),
                                        IsActive = (bool)reader["IsActive"],
                                        IssueReason = (byte)reader["IssueReason"],
                                        CreatedByUserID = (int)reader["CreatedByUserID"]

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
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
     


            }


        public static clsLicenseInfo GetLastLicenseInfoByPersonID(int PersonID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                  SELECT TOP 1 *
                  FROM Licenses
                  INNER JOIN Drivers
                      ON Drivers.DriverID = Licenses.DriverID
                  WHERE Drivers.PersonID = @PersonID
                  ORDER BY Licenses.IssueDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsLicenseInfo
                                {

                                    LicenseID = (int)reader["LicenseID"],
                                    ApplicationID = (int)reader["ApplicationID"],
                                    DriverID = (int)reader["DriverID"],
                                    LicenseClassID = (int)reader["LicenseClassID"],
                                    IssueDate = (DateTime)reader["IssueDate"],
                                    ExpirationDate = (DateTime)reader["ExpirationDate"],
                                    Notes = reader["Notes"] != DBNull.Value
                                            ? (string)reader["Notes"]
                                            : "",
                                    PaidFees = Convert.ToSingle(reader["PaidFees"]),
                                    IsActive = (bool)reader["IsActive"],
                                    IssueReason = (byte)reader["IssueReason"],
                                    CreatedByUserID = (int)reader["CreatedByUserID"]

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
                clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                throw;
            }



        }













        /// <summary>
        /// Adds a new license record to the database.
        /// </summary>
        /// <param name="ApplicationID">The associated application identifier.</param>
        /// <param name="DriverID">The driver identifier.</param>
        /// <param name="LicenseClassID">The license class identifier.</param>
        /// <param name="IssueDate">The license issue date.</param>
        /// <param name="ExpirationDate">The license expiration date.</param>
        /// <param name="Notes">The notes associated with the license.</param>
        /// <param name="PaidFees">The fees paid for the license.</param>
        /// <param name="IsActive">Whether the license is active.</param>
        /// <param name="IssueReason">The reason for issuing the license.</param>
        /// <param name="CreatedByUserID">The identifier of the user creating the record.</param>
        /// <returns>
        /// A task containing the new license identifier, or -1 if the operation fails.
        /// </returns>
        public static async Task<int> AddNewLicenseAsync(
                int ApplicationID,
                int DriverID,
                int LicenseClassID,
                DateTime IssueDate,
                DateTime ExpirationDate,
                string Notes,
                float PaidFees,
                bool IsActive,
                byte IssueReason,
                int CreatedByUserID)
            {
                int LicenseID = -1;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command =
                            new SqlCommand("SP_AddNewLicense", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                            command.Parameters.AddWithValue("@DriverID", DriverID);
                            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                            command.Parameters.AddWithValue("@IssueDate", IssueDate);
                            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                            command.Parameters.AddWithValue(
                                "@Notes",
                                string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                            command.Parameters.AddWithValue("@PaidFees", PaidFees);
                            command.Parameters.AddWithValue("@IsActive", IsActive);
                            command.Parameters.AddWithValue("@IssueReason", IssueReason);
                            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                            SqlParameter outputIdParam =
                                new SqlParameter("@NewLicenseID", SqlDbType.Int)
                                {
                                    Direction = ParameterDirection.Output
                                };

                            command.Parameters.Add(outputIdParam);

                            await connection.OpenAsync();
                            await command.ExecuteNonQueryAsync();

                            if (outputIdParam.Value != DBNull.Value)
                                LicenseID = Convert.ToInt32(command.Parameters["@NewLicenseID"].Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
   


                return LicenseID;
            }


            /// <summary>
            /// Updates an existing license record in the database.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license to update.</param>
            /// <param name="ApplicationID">The associated application identifier.</param>
            /// <param name="DriverID">The driver identifier.</param>
            /// <param name="LicenseClassID">The license class identifier.</param>
            /// <param name="IssueDate">The license issue date.</param>
            /// <param name="ExpirationDate">The license expiration date.</param>
            /// <param name="Notes">The notes associated with the license.</param>
            /// <param name="PaidFees">The fees paid for the license.</param>
            /// <param name="IsActive">Indicates whether the license is active.</param>
            /// <param name="IssueReason">The reason for issuing the license.</param>
            /// <param name="CreatedByUserID">The identifier of the user who created the license record.</param>
            /// <returns>
            /// A task containing true if at least one row was updated; otherwise, false.
            /// </returns>
            public static async Task<bool> UpdateLicenseAsync(
                int LicenseID,
                int ApplicationID,
                int DriverID,
                int LicenseClassID,
                DateTime IssueDate,
                DateTime ExpirationDate,
                string Notes,
                float PaidFees,
                bool IsActive,
                byte IssueReason,
                int CreatedByUserID)
            {
                int rowsAffected = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
            UPDATE Licenses
            SET ApplicationID = @ApplicationID,
                DriverID = @DriverID,
                LicenseClassID = @LicenseClassID,
                IssueDate = @IssueDate,
                ExpirationDate = @ExpirationDate,
                Notes = @Notes,
                PaidFees = @PaidFees,
                IsActive = @IsActive,
                IssueReason = @IssueReason,
                CreatedByUserID = @CreatedByUserID
            WHERE LicenseID = @LicenseID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);
                            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                            command.Parameters.AddWithValue("@DriverID", DriverID);
                            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                            command.Parameters.AddWithValue("@IssueDate", IssueDate);
                            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                            command.Parameters.AddWithValue(
                                "@Notes",
                                string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                            command.Parameters.AddWithValue("@PaidFees", PaidFees);
                            command.Parameters.AddWithValue("@IsActive", IsActive);
                            command.Parameters.AddWithValue("@IssueReason", IssueReason);
                            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                            await connection.OpenAsync();
                            rowsAffected = await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
                

 


                return rowsAffected > 0;
            }

            /// <summary>
            /// Retrieves all license records from the database.
            /// </summary>
            /// <returns>
            /// A task containing a DataTable with all license records.
            /// Returns an empty DataTable if no records are found.
            /// </returns>
            public static async Task<DataTable> GetAllLicensesAsync()
            {
                DataTable dt = new DataTable();



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
            SELECT *
            FROM dbo.Licenses";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            await connection.OpenAsync();

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
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
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
     


                return dt;
            }

            /// <summary>
            /// Deletes a license record using its identifier.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license to delete.</param>
            /// <returns>
            /// A task containing true if at least one row was deleted; otherwise, false.
            /// </returns>
            public static async Task<bool> DeleteLicenseAsync(int LicenseID)
            {
                int rowsAffected = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    DELETE FROM Licenses
    WHERE LicenseID = @LicenseID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);

                            await connection.OpenAsync();
                            rowsAffected = await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
     


                return rowsAffected > 0;
            }

            /// <summary>
            /// Determines whether a license exists using its identifier.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license to check.</param>
            /// <returns>
            /// A task containing true if the license exists; otherwise, false.
            /// </returns>
            public static async Task<bool> IsLicenseExistAsync(int LicenseID)
            {
                bool isFound = false;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT Found = 1
    FROM Licenses
    WHERE LicenseID = @LicenseID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);

                            await connection.OpenAsync();

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
                            {
                                isFound = await reader.ReadAsync();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
      


                return isFound;
            }

            /// <summary>
            /// Determines whether a person already has a license for a specific license class.
            /// </summary>
            /// <param name="PersonID">The identifier of the person.</param>
            /// <param name="LicenseClassID">The identifier of the license class.</param>
            /// <returns>
            /// A task containing true if the person has a license in the specified class;
            /// otherwise, false.
            /// </returns>
            public static async Task<bool> IsLicenseExistAsync(int PersonID, int LicenseClassID)
            {
                bool isFound = false;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT TOP 1 Found = 1
    FROM dbo.Licenses
    INNER JOIN dbo.Drivers
        ON Drivers.DriverID = dbo.Licenses.DriverID
    WHERE dbo.Licenses.LicenseClassID = @LicenseClassID
      AND dbo.Drivers.PersonID = @PersonID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);
                            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                            await connection.OpenAsync();

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
                            {
                                isFound = await reader.ReadAsync();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
      


                return isFound;
            }

            /// <summary>
            /// Retrieves all license information associated with a specific driver.
            /// </summary>
            /// <param name="DriverID">The identifier of the driver.</param>
            /// <returns>
            /// A task containing a DataTable with the driver's license information.
            /// Returns an empty DataTable if no records are found.
            /// </returns>
            public static async Task<DataTable> GetAllDriverLicensesInfoByDriverIDAsync(int DriverID)
            {
                DataTable dt = new DataTable();



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT
        LicenseID AS [Lic.ID],
        ApplicationID AS [App.ID],
        LicenseClasses.ClassName AS [Class Name],
        Licenses.IssueDate AS [Issue Date],
        Licenses.ExpirationDate AS [Expiration Date],
        Licenses.IsActive AS [Is Active]
    FROM Licenses
    INNER JOIN LicenseClasses
        ON LicenseClasses.LicenseClassID =
           Licenses.LicenseClassID
    WHERE Licenses.DriverID = @DriverID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DriverID", DriverID);

                            await connection.OpenAsync();

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
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
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
  


                return dt;
            }

            /// <summary>
            /// Determines whether an active license exists for the specified license
            /// identifier and license class.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license.</param>
            /// <param name="LicenseClassID">The identifier of the license class.</param>
            /// <returns>
            /// A task containing true if an active license exists; otherwise, false.
            /// </returns>
            public static async Task<bool> IsActiveLicenseExistByLicenseIDAndClassIDAsync(
                int LicenseID,
                int LicenseClassID)
            {
                bool isFound = false;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(
                            "SP_CheckActiveLicenseExistsByLicenseIDAndClassID", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);
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
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }



                return isFound;
            }

            /// <summary>
            /// Determines whether the specified license has expired.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license to check.</param>
            /// <returns>
            /// A task containing true if the license has expired; otherwise, false.
            /// </returns>
            public static async Task<bool> IsExpiredLicenseByLicenseIDAsync(int LicenseID)
            {
                bool isFound = false;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(
                            "SP_CheckExpiredLicenseByLicenseID", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
      


                return isFound;
            }

            /// <summary>
            /// Determines whether the specified license matches the requested issuance reason.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license.</param>
            /// <param name="IssueLicenseReason">The license issuance reason to check.</param>
            /// <returns>
            /// A task containing true if the license matches the specified issuance reason;
            /// otherwise, false.
            /// </returns>
            public static async Task<bool> IsIssueLicenseReasonAsync(
                int LicenseID,
                byte IssueLicenseReason)
            {
                bool isFound = false;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(
                            "SP_CheckIssueLicenseReason", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);
                            command.Parameters.AddWithValue("@IssueLicenseReason", IssueLicenseReason);
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
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
   


                return isFound;
            }

            /// <summary>
            /// Determines whether a license has been issued for replacement.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license to check.</param>
            /// <returns>
            /// A task containing true if the license has been issued for replacement;
            /// otherwise, false.
            /// </returns>
            public static async Task<bool> IsLicenseIssuedForReplacementByLicenseIDAsync(int LicenseID)
            {
                bool isFound = false;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(
                            "SP_CheckLicenseIssuedForReplacement", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
     


                return isFound;
            }

            /// <summary>
            /// Retrieves the expiration date of a license using its identifier.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license.</param>
            /// <returns>
            /// A task containing the license expiration date.
            /// Returns the current date and time if no valid expiration date is retrieved.
            /// </returns>
            public static async Task<DateTime> GetLicenseExpirationDateByLicenseIDAsync(int LicenseID)
            {
                DateTime LicenseExpirationDate = DateTime.Now;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT ExpirationDate
    FROM dbo.Licenses
    WHERE LicenseID = @LicenseID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                DateTime.TryParse(result.ToString(), out DateTime parsedDateTime))
                            {
                                LicenseExpirationDate = parsedDateTime;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
     


                return LicenseExpirationDate;
            }

            /// <summary>
            /// Retrieves the number of licenses matching the specified active status.
            /// </summary>
            /// <param name="IsActive">Indicates whether to count active or inactive licenses.</param>
            /// <returns>
            /// A task containing the number of licenses matching the specified status.
            /// </returns>
            public static async Task<int> GetAllLicensesCountAsync(bool IsActive)
            {
                int ActiveLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT COUNT(*)
    FROM dbo.Licenses
    WHERE IsActive = @IsActive";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IsActive", IsActive);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                ActiveLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
     


                return ActiveLicensesCount;
            }

            /// <summary>
            /// Retrieves the number of licenses belonging to a person that match
            /// the specified active status.
            /// </summary>
            /// <param name="PersonID">The identifier of the person.</param>
            /// <param name="IsActive">Indicates whether to count active or inactive licenses.</param>
            /// <returns>
            /// A task containing the number of matching licenses.
            /// </returns>
            public static async Task<int> GetLicensesCountAsync(int PersonID, bool IsActive)
            {
                int ActiveLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT COUNT(*)
    FROM dbo.Licenses
    INNER JOIN Drivers
        ON Drivers.DriverID = Licenses.DriverID
    WHERE Drivers.PersonID = @PersonID
      AND Licenses.IsActive = @IsActive";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);
                            command.Parameters.AddWithValue("@IsActive", IsActive);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                ActiveLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
 


                return ActiveLicensesCount;
            }

            /// <summary>
            /// Retrieves the number of licenses belonging to a person that match
            /// the specified active status and issuance reason.
            /// </summary>
            /// <param name="PersonID">The identifier of the person.</param>
            /// <param name="IsActive">Indicates whether to count active or inactive licenses.</param>
            /// <param name="issueReason">The reason for issuing the license.</param>
            /// <returns>
            /// A task containing the number of matching licenses.
            /// </returns>
            public static async Task<int> GetLicensesCountAsync(int PersonID, bool IsActive, byte issueReason)
            {
                int ActiveLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT TotalLicenseCount=COUNT(*)
    FROM dbo.Licenses INNER JOIN dbo.Drivers ON dbo.Drivers.DriverID = dbo.Licenses.DriverID
    WHERE Drivers.PersonID = @PersonID
    AND dbo.Licenses.IsActive = @IsActive
    and dbo.Licenses.IssueReason=@IssueReason;";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);
                            command.Parameters.AddWithValue("@IsActive", IsActive);
                            command.Parameters.AddWithValue("@issueReason", issueReason);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                ActiveLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
       


                return ActiveLicensesCount;
            }

            /// <summary>
            /// Retrieves the total number of license records in the database.
            /// </summary>
            /// <returns>
            /// A task containing the total number of licenses.
            /// </returns>
            public static async Task<int> GetTotalLocalLicensesCountAsync()
            {
                int TotalLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT COUNT(*)
    FROM dbo.Licenses";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                TotalLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
  


                return TotalLicensesCount;
            }


            /// <summary>
            /// Retrieves the total number of active ordinary licenses for a specific license class.
            /// </summary>
            /// <param name="LicenseClassID">The identifier of the license class.</param>
            /// <returns>A task containing the total number of active licenses in the specified class.</returns>
            public static async Task<int> GetTotalActiveOrdinaryLicensesCountAsync(int LicenseClassID)
            {
                int TotalLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
            SELECT COUNT(*)
            FROM Licenses
            WHERE Licenses.LicenseClassID = @LicenseClassID
              AND Licenses.IsActive = 1";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                TotalLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }



                return TotalLicensesCount;
            }



        public static async Task<int> GetTotalInActiveLicensesCountAsync()
        {
            int TotalLicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT COUNT(*)
            FROM Licenses
            WHERE 
               Licenses.IsActive = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            TotalLicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                throw;
            }



            return TotalLicensesCount;
        }

        /// <summary>
        /// Retrieves the total number of active licenses in the database.
        /// </summary>
        /// <returns>A task containing the total number of active licenses.</returns>
        public static async Task<int> GetTotalActiveLicensesCountAsync()
            {
                int TotalLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
            SELECT COUNT(*)
            FROM Licenses
            WHERE Licenses.IsActive = 1";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                TotalLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
      


                return TotalLicensesCount;
            }


        public static async Task<int> GetTotalActiveExpiredLocalLicensesCountAsync()
        {
            int TotalLicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
           SELECT COUNT(*)
            FROM Licenses
            WHERE Licenses.IsActive = 1 and (GETDATE()>Licenses.ExpirationDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            TotalLicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                throw;
            }



            return TotalLicensesCount;
        }



        /// <summary>
        /// Retrieves the issue date of the first license issued to a person.
        /// </summary>
        /// <param name="PersonID">The identifier of the person.</param>
        /// <returns>
        /// A task containing the first license issue date.
        /// Returns the current date and time if no valid issue date is retrieved.
        /// </returns>
        public static async Task<DateTime> GetFirstLicenseIssuedDateAsync(int PersonID)
            {
                DateTime LicenseIssuedDate = DateTime.Now;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
            SELECT TOP 1 Licenses.IssueDate
            FROM Licenses
            INNER JOIN Drivers
                ON Licenses.DriverID = Drivers.DriverID
            WHERE Drivers.PersonID = @PersonID
            ORDER BY Licenses.IssueDate ASC";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                DateTime.TryParse(result.ToString(), out DateTime parsedDateTime))
                            {
                                LicenseIssuedDate = parsedDateTime;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
 


                return LicenseIssuedDate;
            }

            /// <summary>
            /// Retrieves the total number of licenses associated with a person.
            /// </summary>
            /// <param name="PersonID">The identifier of the person.</param>
            /// <returns>A task containing the total number of licenses associated with the person.</returns>
            public static async Task<int> GetLicensesCountAsync(int PersonID)
            {
                int TotalLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
            SELECT COUNT(*)
            FROM dbo.Licenses
            INNER JOIN Drivers
                ON Drivers.DriverID = Licenses.DriverID
            WHERE Drivers.PersonID = @PersonID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                TotalLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
   


                return TotalLicensesCount;
            }

            /// <summary>
            /// Retrieves the total number of expired licenses in the database.
            /// </summary>
            /// <returns>A task containing the total number of expired licenses.</returns>
            public static async Task<int> GetAllExpiredLicensesCountAsync()
            {
                int ExpiredLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
            SELECT COUNT(*)
            FROM dbo.Licenses
              where Licenses.ExpirationDate < GETDATE()";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                ExpiredLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
   


                return ExpiredLicensesCount;
            }
            /// <summary>
            /// Retrieves the number of expired licenses associated with a specific person.
            /// </summary>
            /// <param name="PersonID">The identifier of the person.</param>
            /// <returns>A task containing the number of expired licenses associated with the person.</returns>
            public static async Task<int> GetExpiredLicensesCountAsync(int PersonID)
            {
                int ExpiredLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT COUNT(*)
    FROM dbo.Licenses
    INNER JOIN Drivers
        ON Drivers.DriverID = Licenses.DriverID
    WHERE Drivers.PersonID = @PersonID
      AND Licenses.ExpirationDate < GETDATE()";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                ExpiredLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
     


                return ExpiredLicensesCount;
            }

            /// <summary>
            /// Retrieves the number of licenses that expired within the specified date range.
            /// </summary>
            /// <param name="StartDate">The beginning of the date range.</param>
            /// <param name="EndDate">The end of the date range.</param>
            /// <returns>A task containing the number of licenses that expired within the specified date range.</returns>
            public static async Task<int> GetExpiredLicensesCountBetweenAsync(DateTime StartDate, DateTime EndDate)
            {
                int ExpiredLicensesCount = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
            SELECT  COUNT(*)
            FROM dbo.Licenses
            WHERE Licenses.ExpirationDate >=  Cast(@StartDate as date) and  Licenses.ExpirationDate < CAST(@EndDate as Date);
            ";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@StartDate", StartDate);
                            command.Parameters.AddWithValue("@EndDate", EndDate);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedInt))
                            {
                                ExpiredLicensesCount = parsedInt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
   

                return ExpiredLicensesCount;
            }

            /// <summary>
            /// Retrieves the identifier of an active license belonging to a person
            /// for a specific license class.
            /// </summary>
            /// <param name="PersonID">The identifier of the person.</param>
            /// <param name="LicenseClassID">The identifier of the license class.</param>
            /// <returns>
            /// A task containing the active license identifier, or -1 if no matching license is found.
            /// </returns>
            public static async Task<int> GetActiveLicenseIDByPersonIDAndClassIDAsync(
                int PersonID,
                int LicenseClassID)
            {
                int LicenseID = -1;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    SELECT TOP 1 Licenses.LicenseID
    FROM Licenses
    INNER JOIN Drivers
        ON Licenses.DriverID = Drivers.DriverID
    WHERE Licenses.LicenseClassID = @LicenseClassID
      AND Drivers.PersonID = @PersonID
      AND Licenses.IsActive = 1";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);
                            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                            await connection.OpenAsync();
                            object result = await command.ExecuteScalarAsync();

                            if (result != null &&
                                result != DBNull.Value &&
                                int.TryParse(result.ToString(), out int parsedID))
                            {
                                LicenseID = parsedID;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
       


                return LicenseID;
            }

            /// <summary>
            /// Deactivates a license by setting its active status to false.
            /// </summary>
            /// <param name="LicenseID">The identifier of the license to deactivate.</param>
            /// <returns>A task containing true if at least one row was updated; otherwise, false.</returns>
            public static async Task<bool> DeactivateLicenseAsync(int LicenseID)
            {
                int rowsAffected = 0;



                try
                {
                    using (SqlConnection connection =
                        new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        string query = @"
    UPDATE Licenses
    SET IsActive = 0
    WHERE LicenseID = @LicenseID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LicenseID", LicenseID);

                            await connection.OpenAsync();
                            rowsAffected = await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessEventLog.LogError(ex, "clsLicenseData");
                    throw;
                }
   


                return rowsAffected > 0;
            }

        }



}


