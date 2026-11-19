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
    /// Provides data access operations for local driving license applications.
    /// </summary>
    static public class clsLocalDrivingLicenseApplicationData
    {
        /// <summary>
        /// Represents local driving license application information and its retrieval status.
        /// </summary>
        public class clsLocalDrivingLicenseApplicationInfo
        {


            /// <summary>
            /// Gets or sets the local driving license application identifier.
            /// </summary>
            public int LocalDrivingLicenseApplicationID { get; set; }

            /// <summary>
            /// Gets or sets the associated application identifier.
            /// </summary>
            public int ApplicationID { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the requested license class.
            /// </summary>
            public int LicenseClassID { get; set; }

            /// <summary>
            /// Initializes a new instance of the
            /// <see cref="clsLocalDrivingLicenseApplicationInfo"/> class
            /// with default values.
            /// </summary>
            public clsLocalDrivingLicenseApplicationInfo()
            {
                LocalDrivingLicenseApplicationID = -1;
                ApplicationID = -1;
                LicenseClassID = -1;
            }
        }


        //=============================================================
        // Get Local Driving License Application Info By ID
        //=============================================================

        /// <summary>
        /// Retrieves local driving license application information using its identifier.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <returns>
        /// A task containing the application information, or null if no record is found.
        /// </returns>
        public static async Task<clsLocalDrivingLicenseApplicationInfo>
            GetLocalDrivingLicenseApplicationInfoByIDAsync(
                int LocalDrivingLicenseApplicationID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT *
    FROM LocalDrivingLicenseApplications
    WHERE LocalDrivingLicenseApplicationID =
          @LocalDrivingLicenseApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsLocalDrivingLicenseApplicationInfo
                                {


                                    LocalDrivingLicenseApplicationID =
                                        (int)reader["LocalDrivingLicenseApplicationID"],

                                    ApplicationID = (int)reader["ApplicationID"],

                                    LicenseClassID = (int)reader["LicenseClassID"]

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
                clsDataAccessEventLog.LogError( ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }



        }


        public static clsLocalDrivingLicenseApplicationInfo
    GetLocalDrivingLicenseApplicationInfoByID(
        int LocalDrivingLicenseApplicationID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT *
    FROM LocalDrivingLicenseApplications
    WHERE LocalDrivingLicenseApplicationID =
          @LocalDrivingLicenseApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsLocalDrivingLicenseApplicationInfo
                                {


                                    LocalDrivingLicenseApplicationID =
                                        (int)reader["LocalDrivingLicenseApplicationID"],

                                    ApplicationID = (int)reader["ApplicationID"],

                                    LicenseClassID = (int)reader["LicenseClassID"]

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
                clsDataAccessEventLog.LogError(ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }



        }



        //=============================================================
        // Get Local Driving License Application Info By Application ID
        //=============================================================

        /// <summary>
        /// Retrieves local driving license application information using its application identifier.
        /// </summary>
        /// <param name="ApplicationID">The associated application identifier.</param>
        /// <returns>
        /// A task containing the local driving license application information,
        /// or null if no record is found.
        /// </returns>
        public static async Task<clsLocalDrivingLicenseApplicationInfo>
            GetLocalDrivingLicenseApplicationInfoByApplicationIDAsync(
                int ApplicationID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        LocalDrivingLicenseApplicationID,
        ApplicationID,
        LicenseClassID
    FROM LocalDrivingLicenseApplications
    WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsLocalDrivingLicenseApplicationInfo
                                {

                                    LocalDrivingLicenseApplicationID =
                                        (int)reader["LocalDrivingLicenseApplicationID"],

                                    ApplicationID = ApplicationID,

                                    LicenseClassID = (int)reader["LicenseClassID"],

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
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }
   


        }

        public static clsLocalDrivingLicenseApplicationInfo
     GetLocalDrivingLicenseApplicationInfoByApplicationID(
         int ApplicationID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        LocalDrivingLicenseApplicationID,
        ApplicationID,
        LicenseClassID
    FROM LocalDrivingLicenseApplications
    WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsLocalDrivingLicenseApplicationInfo
                                {

                                    LocalDrivingLicenseApplicationID =
                                        (int)reader["LocalDrivingLicenseApplicationID"],

                                    ApplicationID = ApplicationID,

                                    LicenseClassID = (int)reader["LicenseClassID"],

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
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }



        }


        /// <summary>
        /// Adds a new local driving license application to the database.
        /// </summary>
        /// <param name="ApplicationID">The identifier of the associated application.</param>
        /// <param name="LicenseClassID">The identifier of the requested license class.</param>
        /// <returns>
        /// A task containing the new local driving license application identifier,
        /// or -1 if no identifier is returned.
        /// </returns>
        public static async Task<int> AddNewLocalDrivingLicenseApplicationAsync(
            int ApplicationID,
            int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(
                        "SP_AddNewLocalDrivingLicenseApplication", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        SqlParameter outputIdParam = new SqlParameter(
                            "@NewLocalDrivingLicenseApplicationID",
                            SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            LocalDrivingLicenseApplicationID =
                                (int)outputIdParam.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }
  


            return LocalDrivingLicenseApplicationID;
        }

        /// <summary>
        /// Updates an existing local driving license application in the database.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application to update.
        /// </param>
        /// <param name="ApplicationID">The updated associated application identifier.</param>
        /// <param name="LicenseClassID">The updated license class identifier.</param>
        /// <returns>
        /// A task containing true if at least one row was updated; otherwise, false.
        /// </returns>
        public static async Task<bool> UpdateLocalDrivingLicenseApplicationAsync(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int LicenseClassID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        UPDATE LocalDrivingLicenseApplications
        SET
            ApplicationID = @ApplicationID,
            LicenseClassID = @LicenseClassID
        WHERE LocalDrivingLicenseApplicationID =
            @LocalDrivingLicenseApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }
  

            return rowsAffected > 0;
        }




        /// <summary>
        /// Deletes a local driving license application using its identifier.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application to delete.
        /// </param>
        /// <returns>
        /// A task containing true if at least one row was deleted; otherwise, false.
        /// </returns>
        public static async Task<bool> DeleteLocalDrivingLicenseApplicationAsync(
            int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    DELETE FROM LocalDrivingLicenseApplications
    WHERE LocalDrivingLicenseApplicationID =
        @LocalDrivingLicenseApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }



            return rowsAffected > 0;
        }

        /// <summary>
        /// Checks whether a local driving license application exists.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application to check.
        /// </param>
        /// <returns>
        /// A task containing true if the application exists; otherwise, false.
        /// </returns>
        public static async Task<bool> IsLocalDrivingLicenseApplicationExistAsync(
            int LocalDrivingLicenseApplicationID)
        {
            bool IsFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(
                        "SP_CheckLocalDrivingLicenseApplicationExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
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
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }



            return IsFound;
        }

        /// <summary>
        /// Checks whether a person meets the minimum age requirement for a license class.
        /// </summary>
        /// <param name="PersonID">The identifier of the person.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task containing true if the minimum age requirement is met; otherwise, false.
        /// </returns>
        public static async Task<bool> IsHasMinimaumAgeRequireAsync(
            int PersonID,
            int LicenseClassID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =  new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand( "SP_CheckMinimumAgeRequirement", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);
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
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }
    

            return isFound;
        }

        /// <summary>
        /// Retrieves all local driving license applications from the database.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with the local driving license application records.
        /// </returns>
        public static async Task<DataTable> GetAllLocalDrivingLicenseApplicationsAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        LocalDrivingLicenseApplicationID,
        ApplicationID,
        LicenseClassID
    FROM LocalDrivingLicenseApplications";

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
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }



            return dt;
        }

        /// <summary>
        /// Retrieves all records from the local driving license application view.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with the records returned by
        /// LocalDrivingLicenseApplications_View.
        /// </returns>
        public static async Task<DataTable>
            GetAllLocalDrivingLicenseApplicationViewAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
  select LocalDrivingLicenseApplicationID,ClassName,NationalNo,FullName,ApplicationDate,PassedTestCount,Status
 from LocalDrivingLicenseApplications_View order by  ApplicationDate desc
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
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }
    


            return dt;
        }
        /// <summary>
        /// Determines whether the applicant passed the most recent test of the specified type
        /// for the given local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <returns>
        /// A task containing true if the most recent test was passed; otherwise, false.
        /// </returns>
        /// 

        public static async Task<bool> DoesPassTestTypeAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            bool result = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1 TestResult
    FROM LocalDrivingLicenseApplications
    INNER JOIN TestAppointments
        ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
           TestAppointments.LocalDrivingLicenseApplicationID
    INNER JOIN Tests
        ON TestAppointments.TestAppointmentID =
           Tests.TestAppointmentID
    WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
          @LocalDrivingLicenseApplicationID
      AND TestAppointments.TestTypeID = @TestTypeID
    ORDER BY TestAppointments.TestAppointmentID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        await connection.OpenAsync();

                        object resultValue = await command.ExecuteScalarAsync();

                        if (resultValue != null &&
                            resultValue != DBNull.Value)
                        {
                            result = Convert.ToBoolean(resultValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }
      


            return result;
        }

        /// <summary>
        /// Determines whether the applicant has attended a test of the specified type
        /// for the given local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <returns>
        /// A task containing true if a matching test record exists; otherwise, false.
        /// </returns>
        public static async Task<bool> DoesAttendTestTypeAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1 1
    FROM LocalDrivingLicenseApplications
    INNER JOIN TestAppointments
        ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
           TestAppointments.LocalDrivingLicenseApplicationID
    INNER JOIN Tests
        ON TestAppointments.TestAppointmentID =
           Tests.TestAppointmentID
    WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
          @LocalDrivingLicenseApplicationID
      AND TestAppointments.TestTypeID = @TestTypeID
    ORDER BY TestAppointments.TestAppointmentID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        isFound = result != null && result != DBNull.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }


            return isFound;
        }

        /// <summary>
        /// Retrieves the total number of trials for a specific test type
        /// associated with a local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <returns>
        /// A task containing the total number of trials as a byte.
        /// </returns>
        public static async Task<byte> TotalTrialsPerTestAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            byte totalTrials = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT COUNT(*)
    FROM LocalDrivingLicenseApplications
    INNER JOIN TestAppointments
        ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
           TestAppointments.LocalDrivingLicenseApplicationID
    INNER JOIN Tests
        ON TestAppointments.TestAppointmentID =
           Tests.TestAppointmentID
    WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
          @LocalDrivingLicenseApplicationID
      AND TestAppointments.TestTypeID = @TestTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            totalTrials = Convert.ToByte(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(
                    ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }
  


            return totalTrials;
        }

        /// <summary>
        /// Determines whether an active scheduled test exists for the specified
        /// local driving license application and test type.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <returns>
        /// A task containing true if an active scheduled test exists; otherwise, false.
        /// </returns>
        public static async Task<bool> IsThereAnActiveScheduledTestAsync( int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =  new SqlCommand("SP_CheckActiveScheduledTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue( "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();

                        result = (Convert.ToInt32( returnParameter.Value) == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                clsDataAccessEventLog.LogError( ex, "clsLocalDrivingLicenseApplicationData");
                throw;
            }



            return result;
        }
    }
}