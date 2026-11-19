using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{

    /// <summary>
    /// Provides asynchronous data access operations for managing tests,
    /// including retrieving test information and creating new test records.
    /// </summary>
    public static class clsTestData
    {
        /// <summary>
        /// Represents information about a test retrieved from the database.
        /// </summary>
        public class clsTestInfo
        {


            /// <summary>
            /// Gets or sets the unique identifier of the test.
            /// </summary>
            public int TestID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the identifier of the appointment associated with the test.
            /// </summary>
            public int TestAppointmentID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the result of the test, indicating whether the test was passed.
            /// </summary>
            public bool TestResult { get; set; } = false;

            /// <summary>
            /// Gets or sets the notes associated with the test.
            /// </summary>
            public string Notes { get; set; } = "";

            /// <summary>
            /// Gets or sets the identifier of the user who created the test.
            /// </summary>
            public int CreatedByUserID { get; set; } = -1;
        }

        /// <summary>
        /// Retrieves test information using the specified test ID.
        /// </summary>
        /// <param name="TestID">The unique identifier of the test to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the test
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally by returning null.
        /// </exception>
        public static async Task<clsTestInfo> GetTestInfoByIDAsync(int TestID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        TestAppointmentID,
        TestResult,
        Notes,
        CreatedByUserID
    FROM Tests
    WHERE TestID = @TestID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestID", TestID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsTestInfo
                                {
                                    TestID = TestID,
                                    TestAppointmentID =
                                        (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = reader["Notes"] != DBNull.Value
                                        ? (string)reader["Notes"]
                                        : "",
                                    CreatedByUserID =
                                        (int)reader["CreatedByUserID"],
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
    

        }


        public static clsTestInfo GetTestInfoByID(int TestID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT
        TestAppointmentID,
        TestResult,
        Notes,
        CreatedByUserID
    FROM Tests
    WHERE TestID = @TestID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestID", TestID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsTestInfo
                                {
                                    TestID = TestID,
                                    TestAppointmentID =
                                        (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = reader["Notes"] != DBNull.Value
                                        ? (string)reader["Notes"]
                                        : "",
                                    CreatedByUserID =
                                        (int)reader["CreatedByUserID"],
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }


        }


        /// <summary>
        /// Retrieves test information using the specified test appointment ID.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the appointment associated with the test.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the test
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally by returning null.
        /// </exception>
        public static async Task<clsTestInfo> GetTestByTestAppointmentIDAsync(
            int TestAppointmentID)
        {
  

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1
        TestID,
        TestAppointmentID,
        TestResult,
        Notes,
        CreatedByUserID
    FROM Tests
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
                                return new clsTestInfo
                                {
                                    TestID = (int)reader["TestID"],
                                    TestAppointmentID =
                                        (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = reader["Notes"] != DBNull.Value
                                        ? (string)reader["Notes"]
                                        : "",
                                    CreatedByUserID =
                                        (int)reader["CreatedByUserID"]
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
 


        }


        public static clsTestInfo GetTestByTestAppointmentID(
    int TestAppointmentID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1
        TestID,
        TestAppointmentID,
        TestResult,
        Notes,
        CreatedByUserID
    FROM Tests
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
                                return new clsTestInfo
                                {
                                    TestID = (int)reader["TestID"],
                                    TestAppointmentID =
                                        (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = reader["Notes"] != DBNull.Value
                                        ? (string)reader["Notes"]
                                        : "",
                                    CreatedByUserID =
                                        (int)reader["CreatedByUserID"]
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



        }

        /// <summary>
        /// Retrieves the most recent test for the specified person, test type,
        /// and license class.
        /// </summary>
        /// <param name="PersonID">
        /// The unique identifier of the person who took the test.
        /// </param>
        /// <param name="LicenseClassID">
        /// The identifier of the license class associated with the test.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the most
        /// recent test information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally by returning null.
        /// </exception>
        public static async Task<clsTestInfo> GetLastTestByPersonAndTestTypeAndLicenseClassAsync(
            int PersonID,
            int LicenseClassID,
            int TestTypeID)
        {
  


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1
        Tests.TestID,
        Tests.TestAppointmentID,
        Tests.TestResult,
        Tests.Notes,
        Tests.CreatedByUserID
    FROM Tests
    INNER JOIN TestAppointments
        ON Tests.TestAppointmentID =
           TestAppointments.TestAppointmentID
    INNER JOIN LocalDrivingLicenseApplications
        ON TestAppointments.LocalDrivingLicenseApplicationID =
           LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
    INNER JOIN Applications
        ON LocalDrivingLicenseApplications.ApplicationID =
           Applications.ApplicationID
    WHERE Applications.ApplicantPersonID = @PersonID
      AND LocalDrivingLicenseApplications.LicenseClassID =
          @LicenseClassID
      AND TestAppointments.TestTypeID = @TestTypeID
    ORDER BY Tests.TestAppointmentID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsTestInfo
                                {
                                    TestID = (int)reader["TestID"],
                                    TestAppointmentID = (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = (reader["Notes"] != DBNull.Value )? (string)reader["Notes"]: "",
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
 


        }


        public static clsTestInfo GetLastTestByPersonAndTestTypeAndLicenseClass(
    int PersonID,
    int LicenseClassID,
    int TestTypeID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1
        Tests.TestID,
        Tests.TestAppointmentID,
        Tests.TestResult,
        Tests.Notes,
        Tests.CreatedByUserID
    FROM Tests
    INNER JOIN TestAppointments
        ON Tests.TestAppointmentID =
           TestAppointments.TestAppointmentID
    INNER JOIN LocalDrivingLicenseApplications
        ON TestAppointments.LocalDrivingLicenseApplicationID =
           LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
    INNER JOIN Applications
        ON LocalDrivingLicenseApplications.ApplicationID =
           Applications.ApplicationID
    WHERE Applications.ApplicationPersonID = @PersonID
      AND LocalDrivingLicenseApplications.LicenseClassID =
          @LicenseClassID
      AND TestAppointments.TestTypeID = @TestTypeID
    ORDER BY Tests.TestAppointmentID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsTestInfo
                                {
                                    TestID = (int)reader["TestID"],
                                    TestAppointmentID = (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : "",
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



        }

        /// <summary>
        /// Creates a new test record in the database using the specified appointment,
        /// result, notes, and user information.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The identifier of the appointment associated with the test.
        /// </param>
        /// <param name="TestResult">
        /// Indicates whether the test was passed.
        /// </param>
        /// <param name="Notes">
        /// The notes associated with the test, or null if no notes are provided.
        /// </param>
        /// <param name="CreatedByUserID">
        /// The identifier of the user creating the test record.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the identifier
        /// of the newly created test, or -1 if no identifier was assigned.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<int> AddNewTestAsync(
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            int TestID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        command.Parameters.AddWithValue("@TestResult", TestResult);
                        command.Parameters.AddWithValue(
                            "@Notes", (object)Notes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewTestID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        TestID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



            return TestID;
        }



        /// <summary>
        /// Updates an existing test record in the database using the specified test details.
        /// </summary>
        /// <param name="TestID">The unique identifier of the test to update.</param>
        /// <param name="TestAppointmentID">The identifier of the appointment associated with the test.</param>
        /// <param name="TestResult">Indicates whether the test was passed.</param>
        /// <param name="Notes">The notes associated with the test, or null if no notes are provided.</param>
        /// <param name="CreatedByUserID">The identifier of the user who created the test.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one database row was updated; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while updating the test.
        /// The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<bool> UpdateTestAsync(
            int TestID,
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
     UPDATE Tests
     SET TestAppointmentID = @TestAppointmentID,
         TestResult = @TestResult,
         Notes = @Notes,
         CreatedByUserID = @CreatedByUserID
     WHERE TestID = @TestID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestID", TestID);
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        command.Parameters.AddWithValue("@TestResult", TestResult);
                        command.Parameters.AddWithValue("@Notes", Notes ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
  


            return rowsAffected > 0;
        }


        /// <summary>
        /// Retrieves all test records from the database, ordered by test ID.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with all test records. An empty DataTable is returned if no records
        /// are found or if an exception occurs during retrieval.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while retrieving test records.
        /// The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<DataTable> GetAllTestsAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
     SELECT *
     FROM Tests
     ORDER BY TestID";

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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
  


            return dt;
        }


        /// <summary>
        /// Deletes the test record with the specified test ID from the database.
        /// </summary>
        /// <param name="TestID">The unique identifier of the test to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one database row was deleted; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while deleting the test.
        /// The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<bool> DeleteTestAsync(int TestID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
     DELETE FROM Tests
     WHERE TestID = @TestID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestID", TestID);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
 


            return rowsAffected > 0;
        }


        /// <summary>
        /// Deletes all test records associated with the specified local driving
        /// license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application whose tests
        /// should be deleted.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at least
        /// one database row was deleted; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while deleting the tests.
        /// The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<bool> DeleteTestsAsync(
            int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
     DELETE Tests
     FROM dbo.Tests
     INNER JOIN dbo.TestAppointments
         ON dbo.TestAppointments.TestAppointmentID =
            dbo.Tests.TestAppointmentID
     WHERE dbo.TestAppointments.LocalDrivingLicenseApplicationID =
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



            return rowsAffected > 0;
        }


        /// <summary>
        /// Checks whether a test with the specified ID exists in the database
        /// by executing the corresponding stored procedure.
        /// </summary>
        /// <param name="TestID">The unique identifier of the test to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the
        /// test exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Occurs when an error is encountered while checking whether the test exists.
        /// The exception is logged and rethrown to the caller.
        /// </exception>
        public static async Task<bool> IsTestExistAsync(int TestID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckTestExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TestID", TestID);

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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



            return isFound;
        }
        /// <summary>
        /// Checks whether a test exists for the specified test appointment ID.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if a test
        /// exists for the specified appointment; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<bool> IsTestExistByTestAppointmentIDAsync(
            int TestAppointmentID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckTestExistsByTestAppointmentID", connection))
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



            return isFound;
        }


        /// <summary>
        /// Checks whether a test exists for the specified person ID.
        /// </summary>
        /// <param name="PersonID">
        /// The unique identifier of the person whose test records are being checked.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if a test
        /// exists for the specified person; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<bool> IsTestExistByPersonIDAsync(int PersonID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckTestExistsByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);

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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
   


            return isFound;
        }


        /// <summary>
        /// Checks whether a test exists for the specified person, test type,
        /// and license class.
        /// </summary>
        /// <param name="PersonID">
        /// The unique identifier of the person whose test records are being checked.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type to check.
        /// </param>
        /// <param name="LicenseClassID">
        /// The identifier of the license class associated with the test.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if a test
        /// exists matching the specified person, test type, and license class;
        /// otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<bool> IsTestExistByPersonIDAndTestTypeIDAndLicenseClassIDAsync(
            int PersonID,
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
                        new SqlCommand(
                            "SP_CheckTestExistsByPersonTestTypeAndLicenseClass",
                            connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
  


            return isFound;
        }


        /// <summary>
        /// Retrieves the latest test information associated with the specified person.
        /// </summary>
        /// <param name="PersonID">
        /// The unique identifier of the person whose latest test is being retrieved.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the latest
        /// test information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<clsTestInfo> GetLatestTestInfoByPersonIDAsync(
            int PersonID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
    SELECT TOP 1
        Tests.TestID,
        Tests.TestAppointmentID,
        Tests.TestResult,
        Tests.Notes,
        Tests.CreatedByUserID
    FROM dbo.Tests
    INNER JOIN dbo.TestAppointments
        ON dbo.TestAppointments.TestAppointmentID =
           dbo.Tests.TestAppointmentID
    INNER JOIN dbo.LocalDrivingLicenseApplications
        ON dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
           dbo.TestAppointments.LocalDrivingLicenseApplicationID
    INNER JOIN dbo.Applications
        ON dbo.Applications.ApplicationID =
           dbo.LocalDrivingLicenseApplications.ApplicationID
    WHERE dbo.Applications.ApplicationPersonID = @PersonID
    ORDER BY Tests.TestID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsTestInfo
                                {
                                    TestID = (int)reader["TestID"],
                                    TestAppointmentID = (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = reader["Notes"] != DBNull.Value
                                        ? (string)reader["Notes"]
                                        : "",
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
   


        }


        /// <summary>
        /// Retrieves the latest test information for the specified person,
        /// test type, and license class.
        /// </summary>
        /// <param name="PersonID">
        /// The unique identifier of the person whose test information is being retrieved.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type.
        /// </param>
        /// <param name="LicenseClassID">
        /// The identifier of the license class associated with the test.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the latest
        /// matching test information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally by returning null.
        /// </exception>
        public static async Task<clsTestInfo> GetLatestTestInfoByPersonIDAndTestTypeIDAndLicenseClassIDAsync(
            int PersonID,
            int TestTypeID,
            int LicenseClassID)
        {
   


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT TOP 1
     Tests.TestID,
     Tests.TestAppointmentID,
     Tests.TestResult,
     Tests.Notes,
     Tests.CreatedByUserID
 FROM dbo.Tests
 INNER JOIN dbo.TestAppointments
     ON dbo.TestAppointments.TestAppointmentID =
        dbo.Tests.TestAppointmentID
 INNER JOIN dbo.LocalDrivingLicenseApplications
     ON dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
        dbo.TestAppointments.LocalDrivingLicenseApplicationID
 INNER JOIN dbo.Applications
     ON dbo.Applications.ApplicationID =
        dbo.LocalDrivingLicenseApplications.ApplicationID
 WHERE dbo.Applications.ApplicationPersonID = @PersonID
   AND dbo.TestAppointments.TestTypeID = @TestTypeID
   AND dbo.LocalDrivingLicenseApplications.LicenseClassID =
       @LicenseClassID
 ORDER BY Tests.TestID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsTestInfo
                                {
                                    TestID = (int)reader["TestID"],
                                    TestAppointmentID = (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = reader["Notes"] != DBNull.Value
                                        ? (string)reader["Notes"]
                                        : "",
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



        }


        /// <summary>
        /// Retrieves the latest test information associated with the specified
        /// national number.
        /// </summary>
        /// <param name="NationalNo">
        /// The national identification number of the person whose latest test
        /// information is being retrieved.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the latest
        /// test information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally by returning null.
        /// </exception>
        public static async Task<clsTestInfo> GetLatestTestInfoByNationalNoAsync(
            string NationalNo)
        {
  


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT TOP 1
     Tests.TestID,
     Tests.TestAppointmentID,
     Tests.TestResult,
     Tests.Notes,
     Tests.CreatedByUserID
 FROM dbo.Tests
 INNER JOIN dbo.TestAppointments
     ON dbo.TestAppointments.TestAppointmentID =
        dbo.Tests.TestAppointmentID
 INNER JOIN dbo.LocalDrivingLicenseApplications
     ON dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
        dbo.TestAppointments.LocalDrivingLicenseApplicationID
 INNER JOIN dbo.Applications
     ON dbo.Applications.ApplicationID =
        dbo.LocalDrivingLicenseApplications.ApplicationID
 INNER JOIN dbo.People
     ON dbo.People.PersonID =
        dbo.Applications.ApplicationPersonID
 WHERE dbo.People.NationalNo = @NationalNo
 ORDER BY Tests.TestID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsTestInfo
                                {
                                    TestID = (int)reader["TestID"],
                                    TestAppointmentID = (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = reader["Notes"] != DBNull.Value
                                        ? (string)reader["Notes"]
                                        : "",
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
 


        }


        /// <summary>
        /// Retrieves the latest test information for the person identified by
        /// the specified national number, test type, and license class.
        /// </summary>
        /// <param name="NationalNo">
        /// The national identification number of the person.
        /// </param>
        /// <param name="TestTypeID">
        /// The identifier of the test type.
        /// </param>
        /// <param name="LicenseClassID">
        /// The identifier of the license class associated with the test.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the latest
        /// matching test information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// internally by returning null.
        /// </exception>
        public static async Task<clsTestInfo> GetLatestTestInfoByNationalNoAndTestTypeIDAndLicenseClassIDAsync(
            string NationalNo,
            int TestTypeID,
            int LicenseClassID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
 SELECT TOP 1
     Tests.TestID,
     Tests.TestAppointmentID,
     Tests.TestResult,
     Tests.Notes,
     Tests.CreatedByUserID
 FROM dbo.Tests
 INNER JOIN dbo.TestAppointments
     ON dbo.TestAppointments.TestAppointmentID =
        dbo.Tests.TestAppointmentID
 INNER JOIN dbo.LocalDrivingLicenseApplications
     ON dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
        dbo.TestAppointments.LocalDrivingLicenseApplicationID
 INNER JOIN dbo.Applications
     ON dbo.Applications.ApplicationID =
        dbo.LocalDrivingLicenseApplications.ApplicationID
 INNER JOIN dbo.People
     ON dbo.People.PersonID =
        dbo.Applications.ApplicationPersonID
 WHERE dbo.People.NationalNo = @NationalNo
   AND dbo.TestAppointments.TestTypeID = @TestTypeID
   AND dbo.LocalDrivingLicenseApplications.LicenseClassID =
       @LicenseClassID
 ORDER BY Tests.TestID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsTestInfo
                                {
                                    TestID = (int)reader["TestID"],
                                    TestAppointmentID = (int)reader["TestAppointmentID"],
                                    TestResult = (bool)reader["TestResult"],
                                    Notes = reader["Notes"] != DBNull.Value
                                        ? (string)reader["Notes"]
                                        : "",
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
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
   


        }


        /// <summary>
        /// Counts the total number of test trials associated with the specified person.
        /// </summary>
        /// <param name="PersonID">
        /// The unique identifier of the person whose test trials are being counted.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of test trials associated with the person. Returns zero if no
        /// trials are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<int> CountTestTrialsByPersonIDAsync(int PersonID)
        {
            int TotalTrials = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
     SELECT COUNT(*)
     FROM dbo.Tests
     INNER JOIN dbo.TestAppointments
         ON dbo.TestAppointments.TestAppointmentID =
            dbo.Tests.TestAppointmentID
     INNER JOIN dbo.LocalDrivingLicenseApplications
         ON dbo.TestAppointments.LocalDrivingLicenseApplicationID =
            dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
     INNER JOIN dbo.Applications
         ON dbo.LocalDrivingLicenseApplications.ApplicationID =
            dbo.Applications.ApplicationID
     WHERE dbo.Applications.ApplicationPersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            TotalTrials = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }


            return TotalTrials;
        }
        /// <summary>
        /// Counts the total number of test trials associated with the specified national number.
        /// </summary>
        /// <param name="NationalNo">
        /// The national identification number of the person whose test trials are being counted.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total number
        /// of test trials associated with the specified national number.
        /// Returns zero if no trials are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<int> CountTestTrialsByNationalNoAsync(string NationalNo)
        {
            int TotalTrials = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT COUNT(*)
        FROM dbo.Tests
        INNER JOIN dbo.TestAppointments
            ON dbo.TestAppointments.TestAppointmentID =
               dbo.Tests.TestAppointmentID
        INNER JOIN dbo.LocalDrivingLicenseApplications
            ON dbo.TestAppointments.LocalDrivingLicenseApplicationID =
               dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
        INNER JOIN dbo.Applications
            ON dbo.LocalDrivingLicenseApplications.ApplicationID =
               dbo.Applications.ApplicationID
        INNER JOIN dbo.People
            ON dbo.People.PersonID =
               dbo.Applications.ApplicationPersonID
        WHERE dbo.People.NationalNo = @NationalNo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            TotalTrials = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



            return TotalTrials;
        }


        /// <summary>
        /// Counts the number of passed tests associated with the specified
        /// local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The unique identifier of the local driving license application
        /// whose passed tests are being counted.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of passed tests as a byte value.
        /// Returns zero if no passed tests are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<byte> GetPassedTestCountAsync(
            int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT COUNT(*)
        FROM Tests
        INNER JOIN TestAppointments ON Tests.TestAppointmentID =
               TestAppointments.TestAppointmentID
        WHERE LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND TestResult = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@LocalDrivingLicenseApplicationID",
                            LocalDrivingLicenseApplicationID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            PassedTestCount = Convert.ToByte(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }



            return PassedTestCount;
        }


        /// <summary>
        /// Retrieves the total number of test records in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of test records as a byte value.
        /// Returns zero if no test records are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<int> GetAllTestsCountAsync()
        {
            int PassedTestCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
        SELECT COUNT(*)
        FROM Tests";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            PassedTestCount = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestData");
                throw;
            }
   


            return PassedTestCount;
        }


    }
}