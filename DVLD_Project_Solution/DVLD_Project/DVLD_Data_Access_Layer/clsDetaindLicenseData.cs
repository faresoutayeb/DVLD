using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{

    /// <summary>
    /// Provides data access operations for detained driving licenses.
    /// </summary>
    static public class clsDetaindLicenseData
    {
        /// <summary>
        /// Represents the result of retrieving detained license information.
        /// </summary>
        public class DetainedLicenseInfoResult
        {
  
            /// <summary>
            /// Gets or sets the detention record identifier.
            /// </summary>
            public int DetainID { get; set; }

            /// <summary>
            /// Gets or sets the license identifier.
            /// </summary>
            public int LicenseID { get; set; }

            /// <summary>
            /// Gets or sets the detention date.
            /// </summary>
            public DateTime DetainDate { get; set; }

            /// <summary>
            /// Gets or sets the fine fees.
            /// </summary>
            public float FineFees { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the user who created the record.
            /// </summary>
            public int CreatedByUserID { get; set; }

            /// <summary>
            /// Gets or sets whether the license has been released.
            /// </summary>
            public bool IsReleased { get; set; }

            /// <summary>
            /// Gets or sets the release date, if available.
            /// </summary>
            public DateTime? ReleaseDate { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the user who released the license, if available.
            /// </summary>
            public int? ReleasedByUserID { get; set; }

            /// <summary>
            /// Gets or sets the release application identifier, if available.
            /// </summary>
            public int? ReleaseApplicationID { get; set; }

            /// <summary>
            /// Gets or sets the date and time of the last action.
            /// </summary>
            public DateTime LastActionDateTime { get; set; }

            /// <summary>
            /// Gets or sets the detention reason identifier.
            /// </summary>
            public int DetainReasonID { get; set; }
        }

        /// <summary>
        /// Retrieves detained license information using a detention record identifier.
        /// </summary>
        /// <param name="DetainID">The detention record identifier.</param>
        /// <returns>A task containing the detained license information and whether the record was found.</returns>
        public static async Task<DetainedLicenseInfoResult>  GetDetainedLicenseInfoByIDAsync(int DetainID)
        {
 
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT
                    DetainID,
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID,
                    LastActionDateTime,
                    DetainReasonID
                FROM dbo.DetainedLicenses
                WHERE DetainID = @DetainID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetainID", DetainID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new DetainedLicenseInfoResult
                                {

                                    DetainID = (int)reader["DetainID"],
                                    LicenseID = (int)reader["LicenseID"],
                                    DetainDate = (DateTime)reader["DetainDate"],
                                    FineFees = Convert.ToSingle(reader["FineFees"]),
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    IsReleased = (bool)reader["IsReleased"],

                                    ReleaseDate =
                                        reader["ReleaseDate"] != DBNull.Value
                                            ? (DateTime?)reader["ReleaseDate"]
                                            : null,

                                    ReleasedByUserID =
                                        reader["ReleasedByUserID"] != DBNull.Value
                                            ? (int?)reader["ReleasedByUserID"]
                                            : null,

                                    ReleaseApplicationID =
                                        reader["ReleaseApplicationID"] != DBNull.Value
                                            ? (int?)reader["ReleaseApplicationID"]
                                            : null,

                                    LastActionDateTime =
                                        (DateTime)reader["LastActionDateTime"],

                                    DetainReasonID =
                                        (int)reader["DetainReasonID"]
                                        
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
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


        }

        public static DetainedLicenseInfoResult GetDetainedLicenseInfoByID(int DetainID)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT
                    DetainID,
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID,
                    LastActionDateTime,
                    DetainReasonID
                FROM dbo.DetainedLicenses
                WHERE DetainID = @DetainID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetainID", DetainID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new DetainedLicenseInfoResult
                                {

                                    DetainID = (int)reader["DetainID"],
                                    LicenseID = (int)reader["LicenseID"],
                                    DetainDate = (DateTime)reader["DetainDate"],
                                    FineFees = Convert.ToSingle(reader["FineFees"]),
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    IsReleased = (bool)reader["IsReleased"],

                                    ReleaseDate =
                                        reader["ReleaseDate"] != DBNull.Value
                                            ? (DateTime?)reader["ReleaseDate"]
                                            : null,

                                    ReleasedByUserID =
                                        reader["ReleasedByUserID"] != DBNull.Value
                                            ? (int?)reader["ReleasedByUserID"]
                                            : null,

                                    ReleaseApplicationID =
                                        reader["ReleaseApplicationID"] != DBNull.Value
                                            ? (int?)reader["ReleaseApplicationID"]
                                            : null,

                                    LastActionDateTime =
                                        (DateTime)reader["LastActionDateTime"],

                                    DetainReasonID =
                                        (int)reader["DetainReasonID"]

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
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


        }



        /// <summary>
        /// Retrieves the most recent detained license information using a license identifier.
        /// </summary>
        /// <param name="LicenseID">The license identifier.</param>
        /// <returns>A task containing the detained license information and whether the record was found.</returns>
        public static async Task<DetainedLicenseInfoResult>
            GetDetainedLicenseInfoByLicenseIDAsync(int LicenseID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT TOP 1
                    DetainID,
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID,
                    LastActionDateTime,
                    DetainReasonID
                FROM dbo.DetainedLicenses
                WHERE LicenseID = @LicenseID
                ORDER BY DetainID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =  await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new DetainedLicenseInfoResult
                                {

                                    DetainID = (int)reader["DetainID"],
                                    LicenseID = (int)reader["LicenseID"],
                                    DetainDate = (DateTime)reader["DetainDate"],
                                    FineFees = Convert.ToSingle(reader["FineFees"]),
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    IsReleased = (bool)reader["IsReleased"],

                                    ReleaseDate =
                                        reader["ReleaseDate"] != DBNull.Value
                                            ? (DateTime?)reader["ReleaseDate"]
                                            : null,

                                    ReleasedByUserID =
                                        reader["ReleasedByUserID"] != DBNull.Value
                                            ? (int?)reader["ReleasedByUserID"]
                                            : null,

                                    ReleaseApplicationID =
                                        reader["ReleaseApplicationID"] != DBNull.Value
                                            ? (int?)reader["ReleaseApplicationID"]
                                            : null,

                                    LastActionDateTime =
                                        (DateTime)reader["LastActionDateTime"],

                                    DetainReasonID =
                                        (int)reader["DetainReasonID"]

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
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


        }

        public static DetainedLicenseInfoResult
    GetDetainedLicenseInfoByLicenseID(int LicenseID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT TOP 1
                    DetainID,
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID,
                    LastActionDateTime,
                    DetainReasonID
                FROM dbo.DetainedLicenses
                WHERE LicenseID = @LicenseID
                ORDER BY DetainID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new DetainedLicenseInfoResult
                                {

                                    DetainID = (int)reader["DetainID"],
                                    LicenseID = (int)reader["LicenseID"],
                                    DetainDate = (DateTime)reader["DetainDate"],
                                    FineFees = Convert.ToSingle(reader["FineFees"]),
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    IsReleased = (bool)reader["IsReleased"],

                                    ReleaseDate =
                                        reader["ReleaseDate"] != DBNull.Value
                                            ? (DateTime?)reader["ReleaseDate"]
                                            : null,

                                    ReleasedByUserID =
                                        reader["ReleasedByUserID"] != DBNull.Value
                                            ? (int?)reader["ReleasedByUserID"]
                                            : null,

                                    ReleaseApplicationID =
                                        reader["ReleaseApplicationID"] != DBNull.Value
                                            ? (int?)reader["ReleaseApplicationID"]
                                            : null,

                                    LastActionDateTime =
                                        (DateTime)reader["LastActionDateTime"],

                                    DetainReasonID =
                                        (int)reader["DetainReasonID"]

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
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


        }


        /// <summary>
        /// Adds a new detained license record.
        /// </summary>
        /// <param name="LicenseID">The license identifier.</param>
        /// <param name="DetainDate">The date of detention.</param>
        /// <param name="FineFees">The fine fees associated with the detention.</param>
        /// <param name="CreatedByUserID">The identifier of the user creating the record.</param>
        /// <param name="IsReleased">Indicates whether the license has been released.</param>
        /// <param name="ReleaseDate">The release date, if available.</param>
        /// <param name="ReleasedByUserID">The identifier of the releasing user, if available.</param>
        /// <param name="ReleaseApplicationID">The release application identifier, if available.</param>
        /// <param name="DetainReasonID">The detention reason identifier.</param>
        /// <returns>A task containing the new detention record identifier, or -1 if no identifier was obtained.</returns>
        public static async Task<int> AddNewDetainedLicenseAsync(
            int LicenseID,
            DateTime DetainDate,
            float FineFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime? ReleaseDate,
            int? ReleasedByUserID,
            int? ReleaseApplicationID,
            int DetainReasonID)
        {
            int DetainID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewDetainedLicense", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@DetainDate", DetainDate);
                        command.Parameters.AddWithValue("@FineFees", FineFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        command.Parameters.AddWithValue(
                            "@ReleaseDate",
                            ReleaseDate.HasValue
                                ? (object)ReleaseDate.Value
                                : DBNull.Value);

                        command.Parameters.AddWithValue(
                            "@ReleasedByUserID",
                            ReleasedByUserID.HasValue
                                ? (object)ReleasedByUserID.Value
                                : DBNull.Value);

                        command.Parameters.AddWithValue(
                            "@ReleaseApplicationID",
                            ReleaseApplicationID.HasValue
                                ? (object)ReleaseApplicationID.Value
                                : DBNull.Value);

                        command.Parameters.AddWithValue(
                            "@LastActionDateTime", DateTime.Now);

                        command.Parameters.AddWithValue(
                            "@DetainReasonID", DetainReasonID);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewDetainID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            DetainID = Convert.ToInt32(outputIdParam.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return DetainID;
        }

        /// <summary>
        /// Updates an existing detained license record.
        /// </summary>
        /// <param name="DetainID">The detention record identifier.</param>
        /// <param name="LicenseID">The license identifier.</param>
        /// <param name="DetainDate">The date of detention.</param>
        /// <param name="FineFees">The fine fees associated with the detention.</param>
        /// <param name="CreatedByUserID">The identifier of the user who created the record.</param>
        /// <param name="IsReleased">Indicates whether the license has been released.</param>
        /// <param name="ReleaseDate">The release date, if available.</param>
        /// <param name="ReleasedByUserID">The identifier of the releasing user, if available.</param>
        /// <param name="ReleaseApplicationID">The release application identifier, if available.</param>
        /// <param name="DetainReasonID">The detention reason identifier.</param>
        /// <returns>A task containing true if one or more rows were affected; otherwise, false.</returns>
        public static async Task<bool> UpdateDetainedLicenseAsync(
            int DetainID,
            int LicenseID,
            DateTime DetainDate,
            float FineFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime? ReleaseDate,
            int? ReleasedByUserID,
            int? ReleaseApplicationID,
            int DetainReasonID)
        {
            int RowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                UPDATE dbo.DetainedLicenses
                SET LicenseID = @LicenseID,
                    DetainDate = @DetainDate,
                    FineFees = @FineFees,
                    CreatedByUserID = @CreatedByUserID,
                    IsReleased = @IsReleased,
                    ReleaseDate = @ReleaseDate,
                    ReleasedByUserID = @ReleasedByUserID,
                    ReleaseApplicationID = @ReleaseApplicationID,
                    LastActionDateTime = @LastActionDateTime,
                    DetainReasonID = @DetainReasonID
                WHERE DetainID = @DetainID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetainID", DetainID);
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@DetainDate", DetainDate);
                        command.Parameters.AddWithValue("@FineFees", FineFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        command.Parameters.AddWithValue(
                            "@ReleaseDate",
                            ReleaseDate.HasValue
                                ? (object)ReleaseDate.Value
                                : DBNull.Value);

                        command.Parameters.AddWithValue(
                            "@ReleasedByUserID",
                            ReleasedByUserID.HasValue
                                ? (object)ReleasedByUserID.Value
                                : DBNull.Value);

                        command.Parameters.AddWithValue(
                            "@ReleaseApplicationID",
                            ReleaseApplicationID.HasValue
                                ? (object)ReleaseApplicationID.Value
                                : DBNull.Value);

                        command.Parameters.AddWithValue(
                            "@LastActionDateTime", DateTime.Now);

                        command.Parameters.AddWithValue(
                            "@DetainReasonID", DetainReasonID);

                        await connection.OpenAsync();

                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return RowsAffected > 0;
        }


        /// <summary>
        /// Retrieves all detained license records.
        /// </summary>
        /// <returns>A task containing a DataTable with all detained license records.</returns>
        public static async Task<DataTable> GetAllDetainedLicensesAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    SELECT
                    DetainID as [Detain ID],
                    LicenseID as [License ID],
                    [Detain Date] = cast(DetainDate as date),
                    FineFees as [Fine Fees] ,
                    CreatedByUserID as [Created By UserID],
                    IsReleased as [Is Released],
                    [Release Date] =  cast(ReleaseDate as date),
                    ReleasedByUserID as [Released By UserID],
                    ReleaseApplicationID as [Release Application ID] ,
                    LastActionDateTime as [Last Action DateTime],
                    DetainReasonID as [Detain Reason ID]
                FROM dbo.DetainedLicenses;
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
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return dt;
        }

        /// <summary>
        /// Retrieves all detained license records from the management view.
        /// </summary>
        /// <returns>A task containing a DataTable with the detained license view data.</returns>
        public static async Task<DataTable> GetAllDetainedLicensesViewAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    select 
                    DetainID as [Detain ID],
                    LicenseID as [License ID],
                    [Detain Date] = cast(DetainDate as date),
                      IsReleased as [Is Released],
                                          FineFees as [Fine Fees] ,
                    [Release Date] =  cast(ReleaseDate as date),
                   NationalNo as [National No]  ,
                   FullName as [Full Name],
                   ReleaseApplicationID as [Release Application ID]

                from DetainedLicenses_View";

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
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return dt;
        }

        /// <summary>
        /// Retrieves the six most frequent detention reasons.
        /// </summary>
        /// <returns>A task containing a DataTable with the top detention reasons and their counts.</returns>
        public static async Task<DataTable> GetTopDetainReasonsAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT TOP 6
            dbo.DetainReasons.ReasonText,
            TotalCount = COUNT(*)
        FROM dbo.DetainedLicenses
        INNER JOIN dbo.DetainReasons
            ON dbo.DetainReasons.DetainReasonID =
               dbo.DetainedLicenses.DetainReasonID
        GROUP BY dbo.DetainReasons.ReasonText
        ORDER BY TotalCount DESC;";

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
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
   

            return dt;
        }

        /// <summary>
        /// Retrieves the five most recent detained license activities.
        /// </summary>
        /// <returns>A task containing a DataTable with recent detention activity records.</returns>
        public static async Task<DataTable> GetRecenttActivityAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 5
        DetainID,
        IsReleased,
        dbo.DetainReasons.ReasonText,
        DetainDate,
        ReleaseDate,
        LastActionDateTime
    FROM dbo.DetainedLicenses
    INNER JOIN dbo.DetainReasons
        ON dbo.DetainReasons.DetainReasonID =
           dbo.DetainedLicenses.DetainReasonID
    ORDER BY dbo.DetainedLicenses.LastActionDateTime DESC;";

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
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
         

            return dt;
        }

        /// <summary>
        /// Deletes a detained license record using its detention identifier.
        /// </summary>
        /// <param name="DetainID">The identifier of the detention record to delete.</param>
        /// <returns>A task containing true if one or more rows were affected; otherwise, false.</returns>
        public static async Task<bool> DeleteDetainedLicenseAsync(int DetainID)
        {
            int RowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        DELETE FROM dbo.DetainedLicenses
        WHERE DetainID = @DetainID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetainID", DetainID);

                        await connection.OpenAsync();

                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
 

            return RowsAffected > 0;
        }
        /// <summary>
        /// Checks whether a license has a detention record matching the specified release status.
        /// </summary>
        /// <param name="LicenseID">The license identifier.</param>
        /// <param name="IsReleased">Indicates whether to check for a released detention. Defaults to false.</param>
        /// <returns>A task containing true if a matching detention record exists; otherwise, false.</returns>
        public static async Task<bool> IsLicenseDetainedAsync(
            int LicenseID,
            bool IsReleased = false)
        {
            bool IsFound = false;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckLicenseDetained", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();

                        IsFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return IsFound;
        }

        public static bool IsLicenseDetained(
    int LicenseID,
    bool IsReleased = false)
        {
            bool IsFound = false;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckLicenseDetained", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                         connection.Open();

                         command.ExecuteNonQuery();

                        IsFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return IsFound;
        }





        /// <summary>
        /// Releases a detained license and records the associated release information.
        /// </summary>
        /// <param name="DetainID">The detention record identifier.</param>
        /// <param name="ReleasedByUserID">The identifier of the user releasing the license.</param>
        /// <param name="ReleaseApplicationID">The identifier of the release application.</param>
        /// <returns>A task containing true if one or more rows were affected; otherwise, false.</returns>
        public static async Task<bool> ReleaseDetainedLicenseAsync(
            int DetainID,
            int ReleasedByUserID,
            int ReleaseApplicationID)
        {
            int RowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    UPDATE dbo.DetainedLicenses
    SET IsReleased = 1,
        ReleaseDate = @ReleaseDate,
        ReleaseApplicationID = @ReleaseApplicationID,
        ReleasedByUserID = @ReleasedByUserID,
        LastActionDateTime = @LastActionDateTime
    WHERE DetainID = @DetainID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        DateTime Now = DateTime.Now;

                        command.Parameters.AddWithValue("@DetainID", DetainID);
                        command.Parameters.AddWithValue(
                            "@ReleasedByUserID", ReleasedByUserID);
                        command.Parameters.AddWithValue(
                            "@ReleaseApplicationID", ReleaseApplicationID);
                        command.Parameters.AddWithValue("@ReleaseDate", Now);
                        command.Parameters.AddWithValue("@LastActionDateTime", Now);

                        await connection.OpenAsync();

                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return RowsAffected > 0;
        }

        /// <summary>
        /// Retrieves the number of detained license records matching the specified release status.
        /// </summary>
        /// <param name="IsReleased">Indicates whether to count released records. Defaults to false.</param>
        /// <returns>A task containing the number of matching detained license records.</returns>
        public static async Task<int> DetainedLicensesCountAsync(
            bool IsReleased = false)
        {
            int Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT COUNT(*)
    FROM dbo.DetainedLicenses
    WHERE IsReleased = @IsReleased;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            Result != DBNull.Value &&
                            int.TryParse(Result.ToString(), out int ParsedInt))
                        {
                            Count = ParsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return Count;
        }

        /// <summary>
        /// Retrieves the total number of detained license records.
        /// </summary>
        /// <returns>A task containing the total number of detained license records.</returns>
        public static async Task<int> TotalDetainedLicensesCountAsync()
        {
            int Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT COUNT(*)
    FROM dbo.DetainedLicenses;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            int.TryParse(Result.ToString(), out int ParsedInt))
                        {
                            Count = ParsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return Count;
        }

        /// <summary>
        /// Retrieves the sum of fine fees for all detained license records.
        /// </summary>
        /// <returns>A task containing the total fine fees.</returns>
        public static async Task<float> GetAllDetainedLicensesFeesAsync()
        {
            float Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT ISNULL(SUM(FineFees), 0)
FROM dbo.DetainedLicenses;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            float.TryParse(Result.ToString(), out float ParsedFloat))
                        {
                            Count = ParsedFloat;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
      

            return Count;
        }

        /// <summary>
        /// Retrieves the sum of fine fees for currently detained, unreleased licenses.
        /// </summary>
        /// <returns>A task containing the total fine fees for currently detained licenses.</returns>
        public static async Task<float> TotalCurrentlyDetainedLicensesFeesAsync()
        {
            float Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT ISNULL(SUM(FineFees), 0)
    FROM dbo.DetainedLicenses
    WHERE IsReleased = 0;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            float.TryParse(Result.ToString(), out float ParsedFloat))
                        {
                            Count = ParsedFloat;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
  

            return Count;
        }

        /// <summary>
        /// Retrieves the number of unreleased detained licenses from the last 30 days.
        /// </summary>
        /// <returns>A task containing the count of detained licenses in the last 30 days.</returns>
        public static async Task<int> GetDetainedLicensesCountInLast30DaysAsync()
        {
            int Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT COUNT(*)
   FROM dbo.DetainedLicenses
   WHERE IsReleased = 0
     AND DetainDate >= DATEADD(DAY, -30, GETDATE())
     AND DetainDate <= GETDATE();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            int.TryParse(Result.ToString(), out int ParsedInt))
                        {
                            Count = ParsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
 

            return Count;
        }

        /// <summary>
        /// Retrieves the number of unreleased detained licenses for the current month.
        /// </summary>
        /// <returns>A task containing the count of detained licenses for the current month.</returns>
        public static async Task<int> GetDetainedLicensesCountThisMonthAsync()
        {
            int Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT COUNT(*)
   FROM dbo.DetainedLicenses
   WHERE IsReleased = 0
     AND DetainDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
     AND DetainDate < DATEADD(MONTH, 1,
         DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1));";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            int.TryParse(Result.ToString(), out int ParsedInt))
                        {
                            Count = ParsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return Count;
        }

        /// <summary>
        /// Retrieves the number of licenses released during the last month.
        /// </summary>
        /// <returns>A task containing the count of licenses released during the last month.</returns>
        public static async Task<int> ReleasedLicensesCountInLastMonthAsync()
        {
            int Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT COUNT(*)
   FROM dbo.DetainedLicenses
   WHERE IsReleased = 1
     AND ReleaseDate BETWEEN
         DATEADD(MONTH, -1, GETDATE())
         AND GETDATE();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            int.TryParse(Result.ToString(), out int ParsedInt))
                        {
                            Count = ParsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
 

            return Count;
        }

        /// <summary>
        /// Retrieves the most recent detention date and time.
        /// </summary>
        /// <returns>A task containing the most recent detention date and time, or the current date and time if no value is retrieved.</returns>
        public static async Task<DateTime> LastDetainedDateTimeAsync()
        {
            DateTime LastDetainedDate = DateTime.Now;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT TOP 1 DetainDate
   FROM dbo.DetainedLicenses
   ORDER BY DetainDate DESC;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            Result != DBNull.Value &&
                            DateTime.TryParse(
                                Result.ToString(),
                                out DateTime ParsedDate))
                        {
                            LastDetainedDate = ParsedDate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }


            return LastDetainedDate;
        }

        /// <summary>
        /// Retrieves the most recent license release date and time.
        /// </summary>
        /// <returns>A task containing the most recent release date and time, or the current date and time if no value is retrieved.</returns>
        public static async Task<DateTime> LastReleasedDateTimeAsync()
        {
            DateTime LastReleasedDate = DateTime.Now;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT TOP 1 ReleaseDate
   FROM dbo.DetainedLicenses
   WHERE ReleaseDate IS NOT NULL
   ORDER BY ReleaseDate DESC;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            Result != DBNull.Value &&
                            DateTime.TryParse(
                                Result.ToString(),
                                out DateTime ParsedDate))
                        {
                            LastReleasedDate = ParsedDate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
            

            return LastReleasedDate;
        }

        /// <summary>
        /// Retrieves the total collected fine fees for released licenses.
        /// </summary>
        /// <returns>A task containing the total collected fine fees.</returns>
        public static async Task<float> CollectedFeesAsync()
        {
            float Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
   SELECT ISNULL(SUM(FineFees), 0)
   FROM dbo.DetainedLicenses
   WHERE IsReleased = 1;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            float.TryParse(Result.ToString(), out float ParsedFloat))
                        {
                            Count = ParsedFloat;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetaindLicenseData");
                throw;
            }
         

            return Count;
        }
    }
}
