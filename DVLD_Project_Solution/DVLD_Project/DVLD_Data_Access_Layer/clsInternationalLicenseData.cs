using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;



namespace DVLD_Data_Access_Layer
{
    /// <summary>
    /// Provides data access operations for international licenses.
    /// </summary>
    static public class clsInternationalLicenseData
    {
        /// <summary>
        /// Represents international license information and its retrieval status.
        /// </summary>
        public class clsInternationalLicenseInfo
        {
     
            /// <summary>
            /// Gets or sets the international license identifier.
            /// </summary>
            public int InternationalLicenseID { get; set; }

            /// <summary>
            /// Gets or sets the associated application identifier.
            /// </summary>
            public int ApplicationID { get; set; }

            /// <summary>
            /// Gets or sets the driver identifier.
            /// </summary>
            public int DriverID { get; set; }

            /// <summary>
            /// Gets or sets the local license identifier used to issue the international license.
            /// </summary>
            public int IssuedUsingLocalLicenseID { get; set; }

            /// <summary>
            /// Gets or sets the issue date of the international license.
            /// </summary>
            public DateTime IssueDate { get; set; }

            /// <summary>
            /// Gets or sets the expiration date of the international license.
            /// </summary>
            public DateTime ExpirationDate { get; set; }

            /// <summary>
            /// Gets or sets whether the international license is active.
            /// </summary>
            public bool IsActive { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the user who created the license record.
            /// </summary>
            public int CreatedByUserID { get; set; }

            /// <summary>
            /// Gets or sets the date of the associated application.
            /// </summary>
            public DateTime ApplicationDate { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="clsInternationalLicenseInfo"/> class with default values.
            /// </summary>
            public clsInternationalLicenseInfo()
            {
                InternationalLicenseID = -1;
                ApplicationID = -1;
                DriverID = -1;
                IssuedUsingLocalLicenseID = -1;
                IssueDate = DateTime.MinValue;
                ExpirationDate = DateTime.MinValue;
                IsActive = false;
                CreatedByUserID = -1;
                ApplicationDate = DateTime.MinValue;
            }
        }

        /// <summary>
        /// Retrieves international license information using its identifier.
        /// </summary>
        /// <param name="InternationalLicenseID">The international license identifier.</param>
        /// <returns>A task containing the international license information, or null if no record is found.</returns>
        public static async Task<clsInternationalLicenseInfo> GetInternationalLicenseInfoByIDAsync(
    int InternationalLicenseID)
        {
  
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT *
    FROM InternationalLicenses
    WHERE InternationalLicenseID = @InternationalLicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@InternationalLicenseID",
                            InternationalLicenseID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsInternationalLicenseInfo
                                {

                                    InternationalLicenseID = InternationalLicenseID,
                                    ApplicationID = (int)reader["ApplicationID"],
                                    DriverID = (int)reader["DriverID"],
                                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                                    IssueDate = (DateTime)reader["IssueDate"],
                                    ExpirationDate = (DateTime)reader["ExpirationDate"],
                                    IsActive = (bool)reader["IsActive"],
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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
        }

        public static clsInternationalLicenseInfo GetInternationalLicenseInfoByID(
int InternationalLicenseID)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT *
    FROM InternationalLicenses
    WHERE InternationalLicenseID = @InternationalLicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@InternationalLicenseID",
                            InternationalLicenseID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsInternationalLicenseInfo
                                {

                                    InternationalLicenseID = InternationalLicenseID,
                                    ApplicationID = (int)reader["ApplicationID"],
                                    DriverID = (int)reader["DriverID"],
                                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                                    IssueDate = (DateTime)reader["IssueDate"],
                                    ExpirationDate = (DateTime)reader["ExpirationDate"],
                                    IsActive = (bool)reader["IsActive"],
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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
        }



        /// <summary>
        /// Retrieves active international license information using the local license identifier.
        /// </summary>
        /// <param name="OrdinaryLicenseID">The local license identifier.</param>
        /// <returns>A task containing the international license information, or null if no record is found.</returns>
        public static async Task<clsInternationalLicenseInfo> GetInternationalLicenseInfoByOrdinaryLicenseIDAsync(
            int OrdinaryLicenseID)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT
                    InternationalLicenses.InternationalLicenseID,
                    InternationalLicenses.ApplicationID,
                    InternationalLicenses.DriverID,
                    InternationalLicenses.IssueDate,
                    InternationalLicenses.ExpirationDate,
                    InternationalLicenses.IsActive,
                    InternationalLicenses.CreatedByUserID,
                    Applications.ApplicationDate
                FROM dbo.InternationalLicenses
                INNER JOIN dbo.Applications
                    ON InternationalLicenses.ApplicationID =
                       Applications.ApplicationID
                WHERE InternationalLicenses.IssuedUsingLocalLicenseID =
                      @OrdinaryLicenseID
                  AND InternationalLicenses.IsActive = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@OrdinaryLicenseID",
                            OrdinaryLicenseID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())

                            {
                                return new clsInternationalLicenseInfo
                                {

                                    InternationalLicenseID =(int) reader[ "InternationalLicenseID"],
                                    ApplicationID = (int)reader["ApplicationID"],
                                    DriverID = (int)reader["DriverID"],
                                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                                    IssueDate = (DateTime)reader["IssueDate"],
                                    ExpirationDate = (DateTime)reader["ExpirationDate"],
                                    IsActive = (bool)reader["IsActive"],
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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
   
        }


        public static clsInternationalLicenseInfo GetInternationalLicenseInfoByOrdinaryLicenseID(
    int OrdinaryLicenseID)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT
                    InternationalLicenses.InternationalLicenseID,
                    InternationalLicenses.ApplicationID,
                    InternationalLicenses.DriverID,
                    InternationalLicenses.IssueDate,
                    InternationalLicenses.ExpirationDate,
                    InternationalLicenses.IsActive,
                    InternationalLicenses.CreatedByUserID,
                    Applications.ApplicationDate
                FROM dbo.InternationalLicenses
                INNER JOIN dbo.Applications
                    ON InternationalLicenses.ApplicationID =
                       Applications.ApplicationID
                WHERE InternationalLicenses.IssuedUsingLocalLicenseID =
                      @OrdinaryLicenseID
                  AND InternationalLicenses.IsActive = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@OrdinaryLicenseID",
                            OrdinaryLicenseID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.Read())

                            {
                                return new clsInternationalLicenseInfo
                                {

                                    InternationalLicenseID = (int)reader["InternationalLicenseID"],
                                    ApplicationID = (int)reader["ApplicationID"],
                                    DriverID = (int)reader["DriverID"],
                                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                                    IssueDate = (DateTime)reader["IssueDate"],
                                    ExpirationDate = (DateTime)reader["ExpirationDate"],
                                    IsActive = (bool)reader["IsActive"],
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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }

        }








        /// <summary>
        /// Adds a new international license record.
        /// </summary>
        /// <param name="ApplicationID">The associated application identifier.</param>
        /// <param name="DriverID">The driver identifier.</param>
        /// <param name="IssuedUsingLocalLicenseID">The local license identifier used for issuance.</param>
        /// <param name="IssueDate">The issue date of the international license.</param>
        /// <param name="ExpirationDate">The expiration date of the international license.</param>
        /// <param name="IsActive">Indicates whether the license is active.</param>
        /// <param name="CreatedByUserID">The identifier of the user creating the record.</param>
        /// <returns>A task containing the new international license identifier, or -1 if no identifier is obtained.</returns>
        public static async Task<int> AddNewInternationalLicenseAsync(
            int ApplicationID,
            int DriverID,
            int IssuedUsingLocalLicenseID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            bool IsActive,
            int CreatedByUserID)
        {
            int InternationalLicenseID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewInternationalLicense", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue(
                            "@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewInternationalLicenseID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (outputIdParam.Value != DBNull.Value)
                            InternationalLicenseID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
   

            return InternationalLicenseID;
        }

        /// <summary>
        /// Updates an existing international license record.
        /// </summary>
        /// <param name="InternationalLicenseID">The international license identifier.</param>
        /// <param name="ApplicationID">The associated application identifier.</param>
        /// <param name="DriverID">The driver identifier.</param>
        /// <param name="IssuedUsingLocalLicenseID">The local license identifier used for issuance.</param>
        /// <param name="IssueDate">The issue date of the international license.</param>
        /// <param name="ExpirationDate">The expiration date of the international license.</param>
        /// <param name="IsActive">Indicates whether the license is active.</param>
        /// <param name="CreatedByUserID">The identifier of the user who created the record.</param>
        /// <returns>A task containing true if one or more rows were updated; otherwise, false.</returns>
        public static async Task<bool> UpdateInternationalLicenseAsync(
            int InternationalLicenseID,
            int ApplicationID,
            int DriverID,
            int IssuedUsingLocalLicenseID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            bool IsActive,
            int CreatedByUserID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    UPDATE InternationalLicenses
    SET ApplicationID = @ApplicationID,
        DriverID = @DriverID,
        IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
        IssueDate = @IssueDate,
        ExpirationDate = @ExpirationDate,
        IsActive = @IsActive,
        CreatedByUserID = @CreatedByUserID
    WHERE InternationalLicenseID = @InternationalLicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@InternationalLicenseID",
                            InternationalLicenseID);
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue(
                            "@IssuedUsingLocalLicenseID",
                            IssuedUsingLocalLicenseID);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }


            return rowsAffected > 0;
        }
        /// <summary>
        /// Retrieves the international licenses associated with a specific driver.
        /// </summary>
        /// <param name="DriverID">The ID of the driver.</param>
        /// <returns>A DataTable containing the driver's international licenses.</returns>
        public static async Task<DataTable> GetDriverInternationalLicensesByDriverIDAsync(int DriverID)
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT
            InternationalLicenseID AS [Int.LicensesID],
            ApplicationID,
            IssuedUsingLocalLicenseID AS [L.LicenseID],
            IssueDate AS [Issue Date],
            ExpirationDate AS [Expiration Date],
            IsActive AS [Is Active]
        FROM InternationalLicenses
        WHERE DriverID = @DriverID";

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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
  


            return dt;
        }

        /// <summary>
        /// Retrieves all international licenses, ordered by their active status and expiration date.
        /// </summary>
        /// <returns>A DataTable containing all international licenses.</returns>
        public static async Task<DataTable> GetAllInternationalLicensesAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
       SELECT
            InternationalLicenseID,
            ApplicationID,
            DriverID,
            IssuedUsingLocalLicenseID,
            IssueDate = cast( IssueDate as date) ,
            ExpirationDate = cast(ExpirationDate as date) ,
            IsActive
        FROM InternationalLicenses
        ORDER BY IsActive, ExpirationDate DESC
";

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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
   


            return dt;
        }


        /// <summary>
        /// Retrieves international license information using display-friendly column names.
        /// </summary>
        /// <returns>A DataTable containing the formatted international license information.</returns>
        public static async Task<DataTable> GetSpecialInternationalLicensesInfoAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT
            InternationalLicenseID AS [Int License ID],
            ApplicationID AS [Application ID],
            DriverID AS [Driver ID],
            IssuedUsingLocalLicenseID AS [L.License ID],
            IssueDate AS [Issue Date],
            ExpirationDate AS [Expiration Date],
            IsActive AS [Is Active]
        FROM dbo.InternationalLicenses";

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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }


            return dt;
        }


        /// <summary>
        /// Deletes an international license by its ID.
        /// </summary>
        /// <param name="InternationalLicenseID">The ID of the international license to delete.</param>
        /// <returns>True if a record was deleted; otherwise, false.</returns>
        public static async Task<bool> DeleteInternationalLicenseAsync(int InternationalLicenseID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        DELETE FROM InternationalLicenses
        WHERE InternationalLicenseID = @InternationalLicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@InternationalLicenseID",
                            InternationalLicenseID);

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
  


            return rowsAffected > 0;
        }


        /// <summary>
        /// Checks whether an international license exists by its ID.
        /// </summary>
        /// <param name="InternationalLicenseID">The ID of the international license.</param>
        /// <returns>True if the international license exists; otherwise, false.</returns>
        public static async Task<bool> IsInternationalLicenseExistAsync(int InternationalLicenseID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckInternationalLicenseExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(
                            "@InternationalLicenseID", InternationalLicenseID);
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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
            

 


            return isFound;
        }


        /// <summary>
        /// Checks whether an international license exists for a specific ordinary license.
        /// </summary>
        /// <param name="OrdinarylLicenseID">The ID of the ordinary license.</param>
        /// <returns>True if an associated international license exists; otherwise, false.</returns>
        public static async Task<bool> IsInternationalLicenseExistByOrdinarylLicenseIDAsync(
            int OrdinarylLicenseID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand(
                            "SP_CheckInternationalLicenseExistsByOrdinaryLicenseID",
                            connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(
                            "@OrdinaryLicenseID", OrdinarylLicenseID);
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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }



            return isFound;
        }



        /// <summary>
        /// Checks whether an active international license exists for an ordinary license and license class.
        /// </summary>
        /// <param name="OrdinarylLicenseID">The ID of the ordinary license.</param>
        /// <param name="LicenseClassID">The ID of the license class.</param>
        /// <returns>True if an active international license exists; otherwise, false.</returns>
        public static async Task<bool> IsActiveInterLicenseExistByOrdinarylLicenseIDAndLicenseClassIDAsync(
           int OrdinarylLicenseID,
           int LicenseClassID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand(
                            "SP_CheckActiveInternationalLicenseExists",
                            connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(
                            "@OrdinaryLicenseID", OrdinarylLicenseID);
                        command.Parameters.AddWithValue(
                            "@LicenseClassID", LicenseClassID);
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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
  


            return isFound;
        }


        /// <summary>
        /// Gets the number of international licenses associated with a person.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>The number of international licenses associated with the person.</returns>
        public static async Task<int> GetInternationalDriverLicensesCountAsync(int PersonID)
        {
            int LicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT COUNT(*)
   FROM dbo.InternationalLicenses
   INNER JOIN Drivers
       ON Drivers.DriverID =
          dbo.InternationalLicenses.DriverID
   WHERE Drivers.PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            LicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
  


            return LicensesCount;
        }


        /// <summary>
        /// Gets the number of active international licenses associated with a person.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>The number of active international licenses associated with the person.</returns>
        public static async Task<int> GetActiveInternationalDriverLicensesCountAsync(int PersonID)
        {
            int LicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT COUNT(*)
   FROM dbo.InternationalLicenses
   INNER JOIN Drivers
       ON Drivers.DriverID =
          dbo.InternationalLicenses.DriverID
   WHERE Drivers.PersonID = @PersonID
     AND InternationalLicenses.IsActive = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            LicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
   


            return LicensesCount;
        }


        /// <summary>
        /// Gets the total number of international licenses.
        /// </summary>
        /// <returns>The total number of international licenses.</returns>
        public static async Task<int> GetAllInternationalLicensesCountAsync()
        {
            int LicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT COUNT(*)
   FROM dbo.InternationalLicenses";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            LicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
 

            return LicensesCount;
        }

        /// <summary>
        /// Gets the number of active international licenses that have not expired.
        /// </summary>
        /// <returns>The number of currently valid, active international licenses.</returns>
        public static async Task<int> GetActiveInternationalLicensesCountAsync()
        {
            int LicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT  COUNT(*)
   FROM dbo.InternationalLicenses
   WHERE IsActive = 1
     AND GETDATE() BETWEEN IssueDate AND ExpirationDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            LicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
 


            return LicensesCount;
        }


        /// <summary>
        /// Gets the number of active international licenses whose expiration dates have passed.
        /// </summary>
        /// <returns>The number of expired international licenses.</returns>
        public static async Task<int> GetExpiredInternationalLicensesCountAsync()
        {
            int LicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT ExpiredInternationalLicensesCount = COUNT(*)
   FROM dbo.InternationalLicenses
   WHERE IsActive = 1
           AND ExpirationDate < GETDATE()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            LicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
 


            return LicensesCount;
        }


        /// <summary>
        /// Gets the ID of the active international license for a specific driver.
        /// </summary>
        /// <param name="DriverID">The ID of the driver.</param>
        /// <returns>The active international license ID, or -1 if no matching license is found.</returns>
        public static async Task<int> GetActiveInternationalLicenseIDByDriverIDAsync(int DriverID)
        {
            int InternationalLicenseID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT TOP 1 InternationalLicenseID
   FROM InternationalLicenses
   WHERE DriverID = @DriverID
     AND GETDATE() BETWEEN IssueDate AND ExpirationDate
     AND IsActive = 1
   ORDER BY ExpirationDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriverID", DriverID);

                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int insertedID))
                        {
                            InternationalLicenseID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
  


            return InternationalLicenseID;
        }


        /// <summary>
        /// Gets the number of international licenses expiring between the specified number of days from today.
        /// </summary>
        /// <param name="From">The starting number of days from today.</param>
        /// <param name="To">The ending number of days from today.</param>
        /// <returns>The number of international licenses expiring within the specified period.</returns>
        public static async Task<int> GetInterLicensesCountExpiringBetweenNextDaysAsync(
            int From,
            int To)
        {
            int LicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
  SELECT COUNT(*)
  FROM dbo.InternationalLicenses
  WHERE ExpirationDate BETWEEN
        DATEADD(DAY, @FromDays, GETDATE())
        AND
        DATEADD(DAY, @ToDays, GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDays", From);
                        command.Parameters.AddWithValue("@ToDays", To);

                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            LicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }



            return LicensesCount;
        }


        /// <summary>
        /// Gets the number of international licenses issued between the specified number of days from today.
        /// </summary>
        /// <param name="From">The starting number of days from today.</param>
        /// <param name="To">The ending number of days from today.</param>
        /// <returns>The number of international licenses issued within the specified period.</returns>
        public static async Task<int> GetInterLicensesCountIssuedBetweenNextDaysAsync(
            int From,
            int To)
        {
            int LicensesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
  SELECT COUNT(*)
  FROM dbo.InternationalLicenses
  WHERE IssueDate BETWEEN
        DATEADD(DAY, @FromDays, GETDATE())
        AND
        DATEADD(DAY, @ToDays, GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDays", From);
                        command.Parameters.AddWithValue("@ToDays", To);

                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            LicensesCount = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }



            return LicensesCount;
        }


        /// <summary>
        /// Retrieves international license records that will expire within the next month.
        /// </summary>
        /// <param name="GetJustFirst_5Licenses">Specifies whether to retrieve only the first five licenses.</param>
        /// <returns>A DataTable containing the soon-to-expire international license records.</returns>
        public static async Task<DataTable> GetSoonExpirationLicensesRecordsAsync(
            bool GetJustFirst_5Licenses = false)
        {
            DataTable CurrentDataTable = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string top = GetJustFirst_5Licenses ? "5" : "";

                    string query = $@"
              SELECT Top {top}
                  Inter.InternationalLicenseID,
                  FullName =
                      People.FirstName + ' ' +
                      ISNULL(People.SecondName, '') + ' ' +
                      ISNULL(People.ThirdName, '') + ' ' +
                      ISNULL(People.LastName, ''),
                  Countries.CountryName,
                  LicenseClasses.ClassName,
                  DaysUntilExpiring =
                      DATEDIFF(DAY, GETDATE(), Inter.ExpirationDate)
              FROM dbo.InternationalLicenses AS Inter
              INNER JOIN dbo.Drivers
                  ON Inter.DriverID = Drivers.DriverID
              INNER JOIN dbo.People
                  ON Drivers.PersonID = People.PersonID
              INNER JOIN dbo.Countries
                  ON People.NationalityCountryID = Countries.CountryID
              INNER JOIN dbo.Licenses
                  ON Inter.IssuedUsingLocalLicenseID = Licenses.LicenseID
              INNER JOIN dbo.LicenseClasses
                  ON Licenses.LicenseClassID = LicenseClasses.LicenseClassID
              WHERE Inter.ExpirationDate BETWEEN
                    GETDATE() AND DATEADD(MONTH, 1, GETDATE())
                AND Inter.IsActive = 1
              ORDER BY Inter.ExpirationDate ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                CurrentDataTable.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }
 

            return CurrentDataTable;
        }


        /// <summary>
        /// Gets the date and time when the most recent international license was issued.
        /// </summary>
        /// <returns>The issue date of the most recently issued international license, or the current date and time if no result is found.</returns>
        public static async Task<DateTime> GetLastIssuedLicenseDateTimeAsync()
        {
            DateTime LicenseIssuedDate = DateTime.Now;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
  SELECT TOP 1 IssueDate
  FROM dbo.InternationalLicenses
  ORDER BY IssueDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            DateTime.TryParse(result.ToString(), out DateTime parsedDateTime))
                        {
                            LicenseIssuedDate = parsedDateTime;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }



            return LicenseIssuedDate;
        }


        /// <summary>
        /// Retrieves information about the most recently expired international license.
        /// </summary>
        /// <returns>A DataTable containing the ID and expiration date of the most recently expired international license.</returns>
        public static async Task<DataTable> GetLastExpiredInterLicenseInfoAsync()
        {
            DataTable dt = new DataTable();

            


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
  SELECT TOP 1
      InternationalLicenseID,
      ExpirationDate
  FROM dbo.InternationalLicenses
  WHERE ExpirationDate < GETDATE()
  ORDER BY ExpirationDate DESC";

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
                clsDataAccessEventLog.LogError(ex, "clsInternationalLicenseData");
                throw;
            }



            return dt;
        }


        /// <summary>
        /// Retrieves all records from the Licenses table.
        /// </summary>
        /// <returns>A DataTable containing all licenses.</returns>
        public static async Task<DataTable> GetAllLicenses()
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


    }
}
