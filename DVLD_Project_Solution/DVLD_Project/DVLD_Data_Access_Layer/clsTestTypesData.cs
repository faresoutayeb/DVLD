using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;





namespace DVLD_Data_Access_Layer
{
    /// <summary>
    /// Provides asynchronous data access operations for managing test types.
    /// </summary>
    public static class clsTestTypesData
    {
        /// <summary>
        /// Represents information about a test type.
        /// </summary>
        public class stTestTypeInfo
        {


            /// <summary>
            /// Gets or sets the unique identifier of the test type.
            /// </summary>
            public int TestTypeID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the title of the test type.
            /// </summary>
            public string TestTypeTitle { get; set; } = "";

            /// <summary>
            /// Gets or sets the description of the test type.
            /// </summary>
            public string TestTypeDescription { get; set; } = "";

            /// <summary>
            /// Gets or sets the fees associated with the test type.
            /// </summary>
            public float TestTypeFees { get; set; } = 0;
        }


        /// <summary>
        /// Retrieves test type information using the specified test type ID.
        /// </summary>
        /// <param name="TestTypeID">
        /// The unique identifier of the test type.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the test type
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// by returning null.
        /// </exception>
        public static async Task<stTestTypeInfo> GetTestTypeInfoByIDAsync(int TestTypeID)
        {
  


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT
                TestTypeTitle,
                TestTypeDescription,
                TestTypeFees
            FROM TestTypes
            WHERE TestTypeID = @TestTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new stTestTypeInfo
                                {
                                    TestTypeID = TestTypeID,
                                    TestTypeTitle = reader["TestTypeTitle"].ToString(),
                                    TestTypeDescription =
                                        reader["TestTypeDescription"].ToString(),
                                    TestTypeFees =
                                        Convert.ToSingle(reader["TestTypeFees"])

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
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }
   

        }
        public static stTestTypeInfo GetTestTypeInfoByID(int TestTypeID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT
                TestTypeTitle,
                TestTypeDescription,
                TestTypeFees
            FROM TestTypes
            WHERE TestTypeID = @TestTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new stTestTypeInfo
                                {
                                    TestTypeID = TestTypeID,
                                    TestTypeTitle = reader["TestTypeTitle"].ToString(),
                                    TestTypeDescription =
                                        reader["TestTypeDescription"].ToString(),
                                    TestTypeFees =
                                        Convert.ToSingle(reader["TestTypeFees"])

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
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }


        }


        /// <summary>
        /// Retrieves test type information using the specified test type title.
        /// </summary>
        /// <param name="TestTypeTitle">
        /// The title of the test type.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the test type
        /// information if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// by returning null.
        /// </exception>
        public static async Task<stTestTypeInfo> GetTestTypeInfoByTitleAsync(
            string TestTypeTitle)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT
                TestTypeID,
                TestTypeDescription,
                TestTypeFees
            FROM TestTypes
            WHERE TestTypeTitle = @TestTypeTitle";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new stTestTypeInfo
                                {
                                    TestTypeID =
                                            Convert.ToInt32(reader["TestTypeID"]),
                                    TestTypeTitle = TestTypeTitle,
                                    TestTypeDescription =
                                            reader["TestTypeDescription"].ToString(),
                                    TestTypeFees =
                                            Convert.ToSingle(reader["TestTypeFees"])
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
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }



        }


        public static stTestTypeInfo GetTestTypeInfoByTitle(
    string TestTypeTitle)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT
                TestTypeID,
                TestTypeDescription,
                TestTypeFees
            FROM TestTypes
            WHERE TestTypeTitle = @TestTypeTitle";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new stTestTypeInfo
                                {
                                    TestTypeID =
                                            Convert.ToInt32(reader["TestTypeID"]),
                                    TestTypeTitle = TestTypeTitle,
                                    TestTypeDescription =
                                            reader["TestTypeDescription"].ToString(),
                                    TestTypeFees =
                                            Convert.ToSingle(reader["TestTypeFees"])
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
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }



        }






        /// <summary>
        /// Retrieves all test types from the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with the test type records.
        /// Returns an empty table if no records are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and handled
        /// by returning the current data table.
        /// </exception>
        public static async Task<DataTable> GetAllTestTypesAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT
                TestTypeID,
                TestTypeTitle,
                TestTypeDescription,
                TestTypeFees
            FROM TestTypes
            ORDER BY TestTypeID";

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
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }



            return dt;
        }


        /// <summary>
        /// Determines whether a test type exists using the specified test type ID.
        /// </summary>
        /// <param name="TestTypeID">
        /// The unique identifier of the test type.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the
        /// test type exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<bool> IsTestTypeExistAsync(int TestTypeID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckTestTypeExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }



            return isFound;
        }


        /// <summary>
        /// Determines whether a test type exists using the specified test type title.
        /// </summary>
        /// <param name="TestTypeTitle">
        /// The title of the test type.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the
        /// test type exists; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<bool> IsTestTypeExistAsync(string TestTypeTitle)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckTestTypeExistsByTitle", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
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
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }
     


            return isFound;
        }


        /// <summary>
        /// Updates the information of an existing test type.
        /// </summary>
        /// <param name="TestTypeID">
        /// The unique identifier of the test type to update.
        /// </param>
        /// <param name="TestTypeTitle">
        /// The updated title of the test type.
        /// </param>
        /// <param name="TestTypeDescription">
        /// The updated description of the test type.
        /// </param>
        /// <param name="TestTypeFees">
        /// The updated fees associated with the test type.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if at
        /// least one database record was updated; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<bool> UpdateTestTypeAsync(
            int TestTypeID,
            string TestTypeTitle,
            string TestTypeDescription,
            float TestTypeFees)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            UPDATE TestTypes
            SET
                TestTypeTitle = @TestTypeTitle,
                TestTypeDescription = @TestTypeDescription,
                TestTypeFees = @TestTypeFees
            WHERE TestTypeID = @TestTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                        command.Parameters.AddWithValue(
                            "@TestTypeDescription", TestTypeDescription);
                        command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

                        await connection.OpenAsync();

                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }
   


            return rowsAffected > 0;
        }


        // Get All Test Types Count
        /// <summary>
        /// Retrieves the total number of test types in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of test types as a byte value.
        /// Returns zero if no test types are found.
        /// </returns>
        /// <exception cref="Exception">
        /// An exception encountered during database access is logged and rethrown
        /// to the caller.
        /// </exception>
        public static async Task<byte> GetAllTestsTypesCountAsync()
        {
            byte testTypesCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT COUNT(*)
                FROM TestTypes";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int parsedCount))
                        {
                            testTypesCount = Convert.ToByte(parsedCount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsTestTypesData");
                throw;
            }
    


            return testTypesCount;
        }
    }
}

