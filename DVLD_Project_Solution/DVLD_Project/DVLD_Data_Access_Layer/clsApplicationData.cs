using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace DVLD_Data_Access_Layer
{
    static public class clsApplicationData
    {
        public class ApplicationInfoResult
        {
            public int ApplicationPersonID { get; set; }
            public DateTime ApplicationDate { get; set; }
            public int ApplicationTypeID { get; set; }
            public byte ApplicationStatus { get; set; }
            public DateTime LastStatusDate { get; set; }
            public float PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
        }

        public class ApplicationBasicInfoResult
        {
            public bool IsFound { get; set; } = false;
            public string ApplicationStatus { get; set; } = "";
            public float ApplicationFees { get; set; }
            public string ApplicationTypeTitle { get; set; } = "";
            public int ApplicationPersonID { get; set; }
            public string FullName { get; set; } = "";
            public DateTime ApplicationDate { get; set; }
            public DateTime LastStatusDate { get; set; }
            public string UserName { get; set; } = "";
        }

        /// <summary>
        /// Retrieves application information asynchronously using its application ID.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing an
        /// ApplicationInfoResult indicating whether the application was found
        /// and its information when available.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails. The exception is logged
        /// before being rethrown.
        /// </exception>
        public static async Task<ApplicationInfoResult> GetApplicationInfoByIDAsync(int ApplicationID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT ApplicationID,
                        ApplicantPersonID,
                        ApplicationDate,
                        ApplicationTypeID,
                        ApplicationStatus,
                        LastStatusDate,
                        PaidFees,
                        CreatedByUserID
                FROM Applications
                WHERE ApplicationID = @ApplicationID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ApplicationInfoResult
                                {

                                    ApplicationPersonID = (int)reader["ApplicantPersonID"],
                                    ApplicationDate = (DateTime)reader["ApplicationDate"],
                                    ApplicationTypeID = (int)reader["ApplicationTypeID"],
                                    ApplicationStatus = (byte)reader["ApplicationStatus"],
                                    LastStatusDate = (DateTime)reader["LastStatusDate"],
                                    PaidFees = Convert.ToSingle(reader["PaidFees"]),
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }

        }

        public static ApplicationInfoResult GetApplicationInfoByID(int ApplicationID)
        {



            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT ApplicationID,
                        ApplicantPersonID,
                        ApplicationDate,
                        ApplicationTypeID,
                        ApplicationStatus,
                        LastStatusDate,
                        PaidFees,
                        CreatedByUserID
                FROM Applications
                WHERE ApplicationID = @ApplicationID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ApplicationInfoResult
                                {

                                    ApplicationPersonID = (int)reader["ApplicantPersonID"],
                                    ApplicationDate = (DateTime)reader["ApplicationDate"],
                                    ApplicationTypeID = (int)reader["ApplicationTypeID"],
                                    ApplicationStatus = (byte)reader["ApplicationStatus"],
                                    LastStatusDate = (DateTime)reader["LastStatusDate"],
                                    PaidFees = Convert.ToSingle(reader["PaidFees"]),
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }

        }

        /// <summary>
        /// Retrieves basic application information asynchronously using its application ID.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application.</param>
        /// <returns>
        /// A task containing the application basic information result.
        /// IsFound indicates whether the application exists.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails.
        /// </exception>
        public static async Task<ApplicationBasicInfoResult>  GetApplicationBasicInfoByApplicationIDAsync(int ApplicationID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT
                [Status],
                ApplicationFees,
                ApplicationTypeTitle,
                ApplicantPersonID,
                FullName,
                ApplicationDate,
                LastStatusDate,
                UserName
            FROM ApplicationBasicInfo_View
            WHERE ApplicationID = @ApplicationID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ApplicationBasicInfoResult
                                {


                                    ApplicationStatus = (string)reader["Status"],
                                    ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]),
                                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"],
                                    ApplicationPersonID = (int)reader["ApplicantPersonID"],
                                    FullName = (string)reader["FullName"],
                                    ApplicationDate = (DateTime)reader["ApplicationDate"],
                                    LastStatusDate = (DateTime)reader["LastStatusDate"],
                                    UserName = (string)reader["UserName"]



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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


        }


        public static  ApplicationBasicInfoResult GetApplicationBasicInfoByApplicationID(int ApplicationID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT
                [Status],
                ApplicationFees,
                ApplicationTypeTitle,
                ApplicantPersonID,
                FullName,
                ApplicationDate,
                LastStatusDate,
                UserName
            FROM ApplicationBasicInfo_View
            WHERE ApplicationID = @ApplicationID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ApplicationBasicInfoResult
                                {



                                    ApplicationStatus = (string)reader["Status"],
                                    ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]),
                                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"],
                                    ApplicationPersonID = (int)reader["ApplicantPersonID"],
                                    FullName = (string)reader["FullName"],
                                    ApplicationDate = (DateTime)reader["ApplicationDate"],
                                    LastStatusDate = (DateTime)reader["LastStatusDate"],
                                    UserName = (string)reader["UserName"]




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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }

        }

        /// <summary>
        /// Creates a new application asynchronously using the stored procedure
        /// SP_AddNewApplication.
        /// </summary>
        /// <param name="ApplicationPersonID">The ID of the person associated with the application.</param>
        /// <param name="ApplicationDate">The date the application was created.</param>
        /// <param name="ApplicationTypeID">The ID of the application type.</param>
        /// <param name="ApplicationStatus">The current status of the application.</param>
        /// <param name="LastStatusDate">The date the application status was last updated.</param>
        /// <param name="PaidFees">The fees paid for the application.</param>
        /// <param name="CreatedByUserID">The ID of the user who created the application.</param>
        /// <returns>
        /// A task containing the newly created application ID.
        /// Returns -1 if no ID is assigned by the stored procedure.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails.
        /// </exception>
        public static async Task<int> AddNewApplicationAsync(
            int ApplicationPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            byte ApplicationStatus,
            DateTime LastStatusDate,
            float PaidFees,
            int CreatedByUserID)
        {
            int ApplicationID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewApplication", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
                        command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                        command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                        command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewApplicationID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        ApplicationID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }

            return ApplicationID;
        }

        /// <summary>
        /// Updates an existing application's information asynchronously.
        /// </summary>
        /// <param name="ApplicationID">The ID of the application to update.</param>
        /// <param name="ApplicationPersonID">The ID of the associated person.</param>
        /// <param name="ApplicationDate">The application creation date.</param>
        /// <param name="ApplicationTypeID">The application type ID.</param>
        /// <param name="ApplicationStatus">The current application status.</param>
        /// <param name="LastStatusDate">The date the status was last updated.</param>
        /// <param name="PaidFees">The fees paid for the application.</param>
        /// <param name="CreatedByUserID">The ID of the user who created the application.</param>
        /// <returns>
        /// A task containing true if at least one row was affected; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails.
        /// </exception>
        public static async Task<bool> UpdateApplicationAsync(
            int ApplicationID,
            int ApplicationPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            byte ApplicationStatus,
            DateTime LastStatusDate,
            float PaidFees,
            int CreatedByUserID)
        {
            int rowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Applications 
            SET ApplicantPersonID = @ApplicationPersonID,
                ApplicationDate = @ApplicationDate,
                ApplicationTypeID = @ApplicationTypeID,
                ApplicationStatus = @ApplicationStatus,
                LastStatusDate = @LastStatusDate,
                PaidFees = @PaidFees,
                CreatedByUserID = @CreatedByUserID
            WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
                        command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                        command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                        command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return rowsAffected > 0;
        }

        /// <summary>
        /// Deletes an application asynchronously using its application ID.
        /// </summary>
        /// <param name="ApplicationID">The ID of the application to delete.</param>
        /// <returns>
        /// A task containing true if at least one row was deleted; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails.
        /// </exception>
        public static async Task<bool> DeleteApplicationAsync(int ApplicationID)
        {
            int rowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"DELETE FROM dbo.Applications 
            WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return (rowsAffected > 0);
        }


        /// <summary>
        /// Updates the status and last status date of an application asynchronously.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application.</param>
        /// <param name="ApplicationStatus">The new status of the application.</param>
        /// <returns>
        /// A task containing true if at least one row was updated; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails.
        /// </exception>
        public static async Task<bool> UpdateStatusAsync(
            int ApplicationID, byte ApplicationStatus)
        {
            int rowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Applications 
        SET ApplicationStatus = @ApplicationStatus,
            LastStatusDate = @LastStatusDate
        WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                        command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return (rowsAffected > 0);
        }

        /// <summary>
        /// Determines whether a person has an active application of the specified type.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person.</param>
        /// <param name="ApplicationTypeID">The application type identifier.</param>
        /// <returns>
        /// A task containing true if an active application exists; otherwise, false.
        /// </returns>
        public static async Task<bool> DoesPersonHaveActiveApplicationAsync(
            int PersonID, int ApplicationTypeID)
        {
            // In case the ActiveApplication ID != -1, return true.
            return (await GetActiveApplicationIDAsync(PersonID, ApplicationTypeID) != -1);
        }

        /// <summary>
        /// Checks whether an application exists in the database.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application.</param>
        /// <returns>
        /// A task containing true if the application exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails.
        /// </exception>
        public static async Task<bool> IsApplicationExistAsync(int ApplicationID)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckApplicationExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return isFound;
        }

        /// <summary>
        /// Retrieves the person ID associated with an application.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application.</param>
        /// <returns>
        /// A task containing the person's ID, or -1 if no valid ID is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails.
        /// </exception>
        public static async Task<int> GetApplicationPersonIDAsync(int ApplicationID)
        {
            int ApplicationPersonID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT ApplicantPersonID 
        FROM Applications 
        WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            int.TryParse(Result.ToString(), out int ApplicationPersonIDParsed))
                        {
                            ApplicationPersonID = ApplicationPersonIDParsed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }

            return ApplicationPersonID;
        }

        /// <summary>
        /// Retrieves the ID of an active application for a person and application type.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person.</param>
        /// <param name="ApplicationTypeID">The application type identifier.</param>
        /// <returns>
        /// A task containing the active application ID, or -1 if none is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when a database operation fails.
        /// </exception>
        public static async Task<int> GetActiveApplicationIDAsync(
            int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT ApplicationID 
        FROM Applications 
        WHERE ApplicantPersonID = @ApplicantPersonID
        AND ApplicationTypeID = @ApplicationTypeID
        AND ApplicationStatus = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            int.TryParse(Result.ToString(), out int AppID))
                        {
                            ActiveApplicationID = AppID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return ActiveApplicationID;
        }

        /// <summary>
        /// Retrieves the active application ID for a person, application type,
        /// and license class.
        /// </summary>
        /// <param name="PersonID">The person's unique identifier.</param>
        /// <param name="ApplicationTypeID">The application type identifier.</param>
        /// <param name="LicenseClassID">The license class identifier.</param>
        /// <returns>
        /// The active application ID, or -1 if no matching application is found.
        /// </returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<int> GetActiveApplicationIDForLicenseClassAsync(
            int PersonID,
            int ApplicationTypeID,
            int LicenseClassID)
        {
            int ActiveApplicationID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT Applications.ApplicationID
        FROM Applications
        INNER JOIN LocalDrivingLicenseApplications
        ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
        WHERE ApplicantPersonID = @ApplicantPersonID
        AND ApplicationTypeID = @ApplicationTypeID
        AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
        AND ApplicationStatus = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null &&
                            int.TryParse(Result.ToString(), out int AppID))
                        {
                            ActiveApplicationID = AppID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return ActiveApplicationID;
        }

        /// <summary>
        /// Retrieves basic information for all applications from the
        /// ApplicationBasicInfo_View database view.
        /// </summary>
        /// <returns>A DataTable containing the basic information of all applications.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<DataTable> GetAllApplicationsBasicInfoAsync()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ApplicationBasicInfo_View";

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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }

            return dt;
        }

        /// <summary>
        /// Retrieves all application records from the Applications table.
        /// </summary>
        /// <returns>A DataTable containing all application records.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<DataTable> GetAllApplicationsAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT ApplicationID,
                ApplicantPersonID,
                ApplicationDate,
                ApplicationTypeID,
                ApplicationStatus,
                LastStatusDate,
                PaidFees,
                CreatedByUserID
            FROM Applications";

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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return dt;
        }

        /// <summary>
        /// Retrieves all applications associated with a specified applicant.
        /// </summary>
        /// <param name="ApplicantPersonID">The applicant's unique person ID.</param>
        /// <returns>A DataTable containing the applicant's applications.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<DataTable> GetApplicationsByPersonIDAsync(
            int ApplicantPersonID)
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT ApplicationID,
                ApplicantPersonID,
                ApplicationDate,
                ApplicationTypeID,
                ApplicationStatus,
                LastStatusDate,
                PaidFees,
                CreatedByUserID
            FROM Applications
            WHERE ApplicantPersonID = @ApplicantPersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return dt;
        }

        /// <summary>
        /// Retrieves recent application records with applicant names,
        /// application types, statuses, and dates.
        /// </summary>
        /// <returns>A DataTable containing recent application information.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<DataTable> GetRecentApplicationsAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        select 
        Applications.ApplicationID as [App ID],  
        Applicant= People.FirstName+' '+ People.LastName,
        ApplicationTypes.ApplicationTypeTitle as [Type],
        case 
        when Applications.ApplicationTypeID=1 then 'New'
        when Applications.ApplicationTypeID = 1 then  'Canceled'
        else 'Completed'
        end as Status ,
        cast (Applications.ApplicationDate as Date)as Date

        from Applications
        inner join People on Applications.ApplicantPersonID=People.PersonID
        inner join applicationTypes on Applications.ApplicationTypeID=ApplicationTypes.ApplicationTypeID;
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return dt;
        }

        /// <summary>
        /// Counts the applications having the specified status.
        /// </summary>
        /// <param name="Status">The application status to count.</param>
        /// <returns>The number of applications matching the specified status.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<int> GetApplicationCountByStatusAsync(byte Status)
        {
            int Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"select count(*) from Applications where Applications.ApplicationStatus=@Status";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", Status);

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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }


            return Count;
        }

        /// <summary>
        /// Retrieves the total number of application records.
        /// </summary>
        /// <returns>The total number of applications.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<int> GetApplicationsCountAsync()
        {
            int Count = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        select TotalApplicationsCount =count(*) from Applications;";

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
                clsDataAccessEventLog.LogError(ex, "clsApplicationData");
                throw;
            }
  

            return Count;
        }

    }
}

