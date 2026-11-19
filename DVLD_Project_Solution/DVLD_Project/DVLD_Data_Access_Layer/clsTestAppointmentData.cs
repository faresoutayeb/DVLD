using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace DVLD_Data_Access_Layer
{

    /// <summary>
    /// Provides asynchronous data access operations for managing test appointments,
    /// including retrieving appointment information and creating new appointments.
    /// </summary>
    public static class clsTestAppointmentData
    {
        /// <summary>
        /// Represents information about a test appointment retrieved from the database.
        /// </summary>
        public class clsTestAppointmentInfo
        {
   

            /// <summary>
            /// Gets or sets the unique identifier of the test appointment.
            /// </summary>
            public int TestAppointmentID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the identifier of the test type associated with the appointment.
            /// </summary>
            public int TestTypeID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the identifier of the local driving license application
            /// associated with the appointment.
            /// </summary>
            public int LocalDrivingLicenseApplicationID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the date and time scheduled for the test appointment.
            /// </summary>
            public DateTime AppointmentDate { get; set; } = DateTime.MinValue;

            /// <summary>
            /// Gets or sets the fees paid for the test appointment.
            /// </summary>
            public float PaidFees { get; set; } = 0;

            /// <summary>
            /// Gets or sets the identifier of the user who created the appointment.
            /// </summary>
            public int CreatedByUserID { get; set; } = -1;

            /// <summary>
            /// Gets or sets whether the test appointment is locked.
            /// </summary>
            public bool IsLocked { get; set; } = false;

            /// <summary>
            /// Gets or sets the identifier of the retake test application associated
            /// with the appointment, or -1 if no retake application is associated.
            /// </summary>
            public int RetakeTestApplicationID { get; set; } = -1;
        }

        /// <summary>
        /// Retrieves test appointment information using the specified appointment ID.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment to retrieve.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the appointment
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while accessing the database.
        /// The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<clsTestAppointmentInfo> GetTestAppointmentInfoByIDAsync(  int TestAppointmentID)
        {
    


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        TestTypeID,
        LocalDrivingLicenseApplicationID,
        AppointmentDate,
        PaidFees,
        CreatedByUserID,
        IsLocked,
        RetakeTestApplicationID
    FROM TestAppointments
    WHERE TestAppointmentID = @TestAppointmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@TestAppointmentID", TestAppointmentID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsTestAppointmentInfo
                                {
                                    TestAppointmentID = TestAppointmentID,
                                    TestTypeID =
                                        Convert.ToInt32(reader["TestTypeID"]),
                                    LocalDrivingLicenseApplicationID =
                                        Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                                    AppointmentDate =
                                        Convert.ToDateTime(reader["AppointmentDate"]),
                                    PaidFees =
                                        Convert.ToSingle(reader["PaidFees"]),
                                    CreatedByUserID =
                                        Convert.ToInt32(reader["CreatedByUserID"]),
                                    IsLocked =
                                        Convert.ToBoolean(reader["IsLocked"]),
                                    RetakeTestApplicationID =
                                        reader["RetakeTestApplicationID"] != DBNull.Value
                                            ? Convert.ToInt32(reader["RetakeTestApplicationID"])
                                            : -1
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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }



        }

        public static clsTestAppointmentInfo GetTestAppointmentInfoByID(int TestAppointmentID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        TestTypeID,
        LocalDrivingLicenseApplicationID,
        AppointmentDate,
        PaidFees,
        CreatedByUserID,
        IsLocked,
        RetakeTestApplicationID
    FROM TestAppointments
    WHERE TestAppointmentID = @TestAppointmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@TestAppointmentID", TestAppointmentID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsTestAppointmentInfo
                                {
                                    TestAppointmentID = TestAppointmentID,
                                    TestTypeID =
                                        Convert.ToInt32(reader["TestTypeID"]),
                                    LocalDrivingLicenseApplicationID =
                                        Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                                    AppointmentDate =
                                        Convert.ToDateTime(reader["AppointmentDate"]),
                                    PaidFees =
                                        Convert.ToSingle(reader["PaidFees"]),
                                    CreatedByUserID =
                                        Convert.ToInt32(reader["CreatedByUserID"]),
                                    IsLocked =
                                        Convert.ToBoolean(reader["IsLocked"]),
                                    RetakeTestApplicationID =
                                        reader["RetakeTestApplicationID"] != DBNull.Value
                                            ? Convert.ToInt32(reader["RetakeTestApplicationID"])
                                            : -1
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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }



        }


        /// <summary>
        /// Retrieves the most recently created test appointment for the specified
        /// local driving license application and test type.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the most recent
        /// appointment information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while accessing the database.
        /// The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<clsTestAppointmentInfo> GetLastTestAppointmentAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1
        TestAppointmentID,
         TestTypeID,   
                LocalDrivingLicenseApplicationID,
        AppointmentDate,
        PaidFees,
        CreatedByUserID,
        IsLocked,
        RetakeTestApplicationID
    FROM TestAppointments
    WHERE TestTypeID = @TestTypeID
      AND LocalDrivingLicenseApplicationID =
          @LocalDrivingLicenseApplicationID
    ORDER BY TestAppointmentID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsTestAppointmentInfo
                                {
                                    TestAppointmentID = (int)reader[ "TestAppointmentID"],
                                    TestTypeID = Convert.ToInt32(reader["TestTypeID"]),
                                    LocalDrivingLicenseApplicationID =  Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                                    AppointmentDate =  Convert.ToDateTime(reader["AppointmentDate"]),
                                    PaidFees =   Convert.ToSingle(reader["PaidFees"]),
                                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]),
                                    IsLocked = Convert.ToBoolean(reader["IsLocked"]),
                                    RetakeTestApplicationID =  reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1
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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }
  

        }

        public static clsTestAppointmentInfo GetLastTestAppointment(
    int LocalDrivingLicenseApplicationID,
    int TestTypeID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1
        TestAppointmentID,
        AppointmentDate,
        PaidFees,
        CreatedByUserID,
        IsLocked,
        RetakeTestApplicationID
    FROM TestAppointments
    WHERE TestTypeID = @TestTypeID
      AND LocalDrivingLicenseApplicationID =
          @LocalDrivingLicenseApplicationID
    ORDER BY TestAppointmentID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsTestAppointmentInfo
                                {
                                    TestAppointmentID = (int)reader["TestAppointmentID"],
                                    TestTypeID =
                                        Convert.ToInt32(reader["TestTypeID"]),
                                    LocalDrivingLicenseApplicationID =
                                        Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                                    AppointmentDate =
                                        Convert.ToDateTime(reader["AppointmentDate"]),
                                    PaidFees =
                                        Convert.ToSingle(reader["PaidFees"]),
                                    CreatedByUserID =
                                        Convert.ToInt32(reader["CreatedByUserID"]),
                                    IsLocked =
                                        Convert.ToBoolean(reader["IsLocked"]),
                                    RetakeTestApplicationID =
                                        reader["RetakeTestApplicationID"] != DBNull.Value
                                            ? Convert.ToInt32(reader["RetakeTestApplicationID"])
                                            : -1
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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }


        }



        /// <summary>
        /// Creates a new test appointment in the database using the specified
        /// appointment details.
        /// </summary>
        /// <param name="TestTypeID">
        /// The identifier of the test type associated with the appointment.
        /// </param>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application associated
        /// with the appointment.
        /// </param>
        /// <param name="AppointmentDate">
        /// The date and time scheduled for the test appointment.
        /// </param>
        /// <param name="PaidFees">
        /// The fees paid for the test appointment.
        /// </param>
        /// <param name="CreatedByUserID">
        /// The identifier of the user creating the appointment.
        /// </param>
        /// <param name="IsLocked">
        /// Indicates whether the appointment should be locked.
        /// </param>
        /// <param name="RetakeTestApplicationID">
        /// The identifier of the associated retake test application,
        /// or -1 if no retake application is associated.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the identifier
        /// of the newly created appointment, or -1 if no identifier was assigned.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while creating the appointment
        /// in the database. The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<int> AddNewTestAppointmentAsync(
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            float PaidFees,
            int CreatedByUserID,
            bool IsLocked,
            int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewTestAppointment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);

                        command.Parameters.AddWithValue(
                            "@RetakeTestApplicationID",
                            RetakeTestApplicationID == -1
                                ? (object)DBNull.Value
                                : RetakeTestApplicationID);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewTestAppointmentID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        TestAppointmentID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }



            return TestAppointmentID;
        }


        /// <summary>
        /// Updates an existing test appointment in the database using the specified
        /// appointment details.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment to update.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type associated with the appointment.
        /// </param>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application associated
        /// with the appointment.
        /// </param>
        /// <param name="AppointmentDate">
        /// The updated date and time scheduled for the test appointment.
        /// </param>
        /// <param name="PaidFees">
        /// The updated fees paid for the test appointment.
        /// </param>
        /// <param name="CreatedByUserID">
        /// The identifier of the user who created the appointment.
        /// </param>
        /// <param name="IsLocked">
        /// Indicates whether the appointment should be locked.
        /// </param>
        /// <param name="RetakeTestApplicationID">
        /// The identifier of the associated retake test application,
        /// or -1 if no retake application is associated.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one database row was updated; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while updating the appointment
        /// in the database. The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<bool> UpdateTestAppointmentAsync(
            int TestAppointmentID,
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            float PaidFees,
            int CreatedByUserID,
            bool IsLocked,
            int RetakeTestApplicationID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
UPDATE TestAppointments
SET
    TestTypeID = @TestTypeID,
    LocalDrivingLicenseApplicationID =
        @LocalDrivingLicenseApplicationID,
    AppointmentDate = @AppointmentDate,
    PaidFees = @PaidFees,
    CreatedByUserID = @CreatedByUserID,
    IsLocked = @IsLocked,
    RetakeTestApplicationID =
        @RetakeTestApplicationID
WHERE TestAppointmentID = @TestAppointmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);
                        command.Parameters.AddWithValue(
                            "@RetakeTestApplicationID",
                            RetakeTestApplicationID == -1
                                ? (object)DBNull.Value
                                : RetakeTestApplicationID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }
  


            return rowsAffected > 0;
        }

        /// <summary>
        /// Retrieves all test appointments from the database, ordered by appointment ID
        /// in descending order.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the test appointment records. An empty DataTable is returned if no
        /// records are found or if an exception occurs during retrieval.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged. The exception
        /// is handled internally and is not rethrown.
        /// </exception>
        public static async Task<DataTable> GetAllTestsAppointmentsAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT
    TestAppointmentID,
    TestTypeID,
    LocalDrivingLicenseApplicationID,
    AppointmentDate,
    PaidFees,
    CreatedByUserID,
    IsLocked,
    RetakeTestApplicationID
FROM TestAppointments
ORDER BY TestAppointmentID DESC";

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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }
   


            return dt;
        }

        /// <summary>
        /// Retrieves test appointments associated with the specified local driving
        /// license application and test type, ordered by appointment ID in descending
        /// order.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type used to filter the appointments.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the matching appointment records. An empty DataTable is returned
        /// if no records are found or if an exception occurs during retrieval.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged. The exception
        /// is handled internally and is not rethrown.
        /// </exception>
        public static async Task<DataTable> GetApplicationTestAppointmentsPerTestTypeAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT
    TestAppointmentID,
    AppointmentDate,
    PaidFees,
    IsLocked
FROM TestAppointments
WHERE TestTypeID = @TestTypeID
  AND LocalDrivingLicenseApplicationID =
      @LocalDrivingLicenseApplicationID
ORDER BY TestAppointmentID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }
   

            return dt;
        }


        //=============================================================
        // Delete Test Appointment
        //=============================================================

        /// <summary>
        /// Deletes the test appointment with the specified appointment ID from the database.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment to delete.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one database row was deleted; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<bool> DeleteTestAppointmentAsync(int TestAppointmentID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
DELETE FROM TestAppointments
WHERE TestAppointmentID = @TestAppointmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }
 

            return rowsAffected > 0;
        }

        /// <summary>
        /// Deletes all test appointments associated with the specified local driving
        /// license application from the database.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application whose appointments
        /// should be deleted.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one database row was deleted; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<bool> DeleteTestAppointmentsAsync(
            int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
DELETE FROM TestAppointments
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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }
 


            return rowsAffected > 0;
        }

        /// <summary>
        /// Checks whether a test appointment with the specified ID exists in the database
        /// by executing the corresponding stored procedure.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the
        /// appointment exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<bool> IsTestAppointmentExistAsync(
            int TestAppointmentID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckTestAppointmentExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(
                            "@TestAppointmentID", TestAppointmentID);

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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }
   


            return isFound;
        }


        public static async Task<bool> IsTestAppointmentExistAsync(int LocalDrivingLicenseApplicationID,int LicenseClassID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_IsTestAppointmentExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }



            return isFound;
        }

        /// <summary>
        /// Retrieves test appointments associated with the specified local driving
        /// license application and test type, ordered by appointment ID in descending
        /// order.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application used to filter
        /// the appointments.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type used to filter the appointments.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the matching appointment IDs, dates, fees, and lock statuses.
        /// An empty DataTable is returned if no records are found or if an exception
        /// occurs during retrieval.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<DataTable> GetAllTestsAppointmentsAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT
    TestAppointments.TestAppointmentID,
    TestAppointments.AppointmentDate,
    TestAppointments.PaidFees,
    TestAppointments.IsLocked
FROM TestAppointments
INNER JOIN LocalDrivingLicenseApplications
    ON TestAppointments.LocalDrivingLicenseApplicationID =
       LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
WHERE TestAppointments.TestTypeID = @TestTypeID
  AND LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
      @LocalDrivingLicenseApplicationID
ORDER BY TestAppointments.TestAppointmentID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }



            return dt;
        }


        /// <summary>
        /// Retrieves the total number of trials recorded for the specified local
        /// driving license application and test type.
        /// </summary>
        /// <param name="LocalDrivingApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type used to filter the trials.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total number
        /// of trials. Returns 0 if no trials are found or an exception occurs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<int> GetAllTrialsCountAsync(
            int LocalDrivingApplicationID,
            int TestTypeID)
        {
            int TotalTrials = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT COUNT(*)
FROM Tests
INNER JOIN TestAppointments
    ON Tests.TestAppointmentID =
       TestAppointments.TestAppointmentID
WHERE TestAppointments.LocalDrivingLicenseApplicationID =
      @LocalDrivingLicenseApplicationID
  AND TestAppointments.TestTypeID = @TestTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int totalCount))
                        {
                            TotalTrials = totalCount;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }




            return TotalTrials;
        }

        /// <summary>
        /// Checks whether an active test appointment exists for the specified local
        /// driving license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type.
        /// </param>
        /// <param name="LicenseClassID">
        /// The identifier of the license class.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if an
        /// active appointment exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<bool> IsHasActiveAppointmentAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID,
            int LicenseClassID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckHasActiveAppointment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }
   


            return isFound;
        }

        /// <summary>
        /// Checks whether the specified test appointment is locked.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the
        /// appointment is locked; otherwise, false. Returns false if the result is
        /// null, DBNull, or an exception occurs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<bool> IsLockedAppointmentAsync(int TestAppointmentID)
        {
            bool IsLocked = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckLockedAppointment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(
                            "@TestAppointmentID", TestAppointmentID);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();

                        IsLocked = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }
  


            return IsLocked;
        }

        /// <summary>
        /// Retrieves the total number of test appointments associated with the specified
        /// local driving license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type.
        /// </param>
        /// <param name="LicenseClassID">
        /// The identifier of the license class associated with the application.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total number
        /// of matching appointments. Returns 0 if no appointments are found or an
        /// exception occurs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<int> TotalAppointmentsCountAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID,
            int LicenseClassID)
        {
            int TotalAppointmentsCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT COUNT(*)
FROM dbo.TestAppointments
INNER JOIN dbo.LocalDrivingLicenseApplications
    ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
       TestAppointments.LocalDrivingLicenseApplicationID
WHERE TestAppointments.LocalDrivingLicenseApplicationID =
      @LocalDrivingLicenseApplicationID
  AND TestAppointments.TestTypeID = @TestTypeID
  AND LocalDrivingLicenseApplications.LicenseClassID =
      @LicenseClassID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue( "@LocalDrivingLicenseApplicationID",  LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int totalCount))
                        {
                            TotalAppointmentsCount = totalCount;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;

            }



            return TotalAppointmentsCount;
        }

        /// <summary>
        /// Retrieves the total number of locked test appointments associated with the
        /// specified local driving license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type.
        /// </param>
        /// <param name="LicenseClassID">
        /// The identifier of the license class associated with the application.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total number
        /// of matching locked appointments. Returns 0 if no appointments are found or
        /// an exception occurs.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally without being rethrown.
        /// </exception>
        public static async Task<int> TotalLockedAppointmentsCountAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID,
            int LicenseClassID)
        {
            int TotalAppointmentsCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
SELECT COUNT(*)
FROM dbo.TestAppointments
INNER JOIN dbo.LocalDrivingLicenseApplications
    ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
       TestAppointments.LocalDrivingLicenseApplicationID
WHERE TestAppointments.LocalDrivingLicenseApplicationID =
      @LocalDrivingLicenseApplicationID
  AND TestAppointments.TestTypeID = @TestTypeID
  AND LocalDrivingLicenseApplications.LicenseClassID =
      @LicenseClassID
  AND TestAppointments.IsLocked = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int totalCount))
                        {
                            TotalAppointmentsCount = totalCount;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }
 


            return TotalAppointmentsCount;
        }

        //=============================================================
        // Get Total Unlocked Appointments Count
        //=============================================================

        /// <summary>
        /// Retrieves the total number of unlocked appointments associated with
        /// the specified local driving license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of unlocked appointments.
        /// </returns>
        public static async Task<int> TotalUnLockedAppointmentsCountAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID,
            int LicenseClassID)
        {
            int TotalAppointmentsCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT COUNT(*)
        FROM dbo.TestAppointments
        INNER JOIN dbo.LocalDrivingLicenseApplications
            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
               TestAppointments.LocalDrivingLicenseApplicationID
        WHERE TestAppointments.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND TestAppointments.TestTypeID = @TestTypeID
          AND LocalDrivingLicenseApplications.LicenseClassID =
              @LicenseClassID
          AND TestAppointments.IsLocked = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int totalCount))
                        {
                            TotalAppointmentsCount = totalCount;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }
            

 


            return TotalAppointmentsCount;
        }

        //=============================================================
        // Get All Unlocked Appointments Count
        //=============================================================

        /// <summary>
        /// Retrieves the total number of unlocked test appointments in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of unlocked appointments.
        /// </returns>
        public static async Task<int> GetAllUnLockedAppointmentsCountAsync()
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT AllUnlockedAppointmentsCount = COUNT(*)
        FROM dbo.TestAppointments
        WHERE TestAppointments.IsLocked = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int totalCount))
                        {
                            Count = totalCount;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }
  


            return Count;
        }

        //=============================================================
        // Get Last Appointment Date
        //=============================================================

        /// <summary>
        /// Retrieves the most recent appointment date for the specified local
        /// driving license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the most
        /// recent appointment date, or the current date and time if no date is found.
        /// </returns>
        public static async Task<DateTime?> LastAppointmentsDateAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID,
            int LicenseClassID)
        {
            DateTime? LastAppointmentDate = null ;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT TOP 1 AppointmentDate
        FROM dbo.TestAppointments
        INNER JOIN dbo.LocalDrivingLicenseApplications
            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
               TestAppointments.LocalDrivingLicenseApplicationID
        WHERE TestAppointments.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND TestAppointments.TestTypeID = @TestTypeID
          AND LocalDrivingLicenseApplications.LicenseClassID =
              @LicenseClassID
        ORDER BY AppointmentDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            LastAppointmentDate = Convert.ToDateTime(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }
   


            return LastAppointmentDate;
        }

        /// <summary>
        /// Locks the specified test appointment in the database.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment to lock.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at
        /// least one database row was updated; otherwise, false.
        /// </returns>
        public static async Task<bool> LockAppointmentAsync(int TestAppointmentID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        UPDATE TestAppointments
        SET IsLocked = 1
        WHERE TestAppointmentID = @TestAppointmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@TestAppointmentID", TestAppointmentID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestAppointmentData");
                throw;
            }
 


            return rowsAffected > 0;
        }



    }


}