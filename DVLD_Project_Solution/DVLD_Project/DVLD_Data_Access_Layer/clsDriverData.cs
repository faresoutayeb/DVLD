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
    /// Provides data access operations for drivers.
    /// </summary>
    static public class clsDriverData
    {
        /// <summary>
        /// Represents driver information and its retrieval status.
        /// </summary>
        public class clsDriverInfo
        {

            /// <summary>
            /// Gets or sets the driver identifier.
            /// </summary>
            public int DriverID { get; set; }

            /// <summary>
            /// Gets or sets the person identifier associated with the driver.
            /// </summary>
            public int PersonID { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the user who created the driver record.
            /// </summary>
            public int CreatedByUserID { get; set; }

            /// <summary>
            /// Gets or sets the date the driver record was created.
            /// </summary>
            public DateTime CreatedDate { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="clsDriverInfo"/> class with default values.
            /// </summary>
            public clsDriverInfo()
            {
                DriverID = -1;
                PersonID = -1;
                CreatedByUserID = -1;
                CreatedDate = DateTime.MinValue;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="clsDriverInfo"/> class with the specified values.
            /// </summary>
            /// <param name="IsFound">Indicates whether the driver record was found.</param>
            /// <param name="driverID">The driver identifier.</param>
            /// <param name="personID">The associated person identifier.</param>
            /// <param name="createdByUserID">The identifier of the user who created the record.</param>
            /// <param name="createdDate">The date the driver record was created.</param>
            public clsDriverInfo(
                int driverID,
                int personID,
                int createdByUserID,
                DateTime createdDate)
            {
                DriverID = driverID;
                PersonID = personID;
                CreatedByUserID = createdByUserID;
                CreatedDate = createdDate;
            }
        }

        /// <summary>
        /// Retrieves driver information using the driver identifier.
        /// </summary>
        /// <param name="DriverID">The driver identifier.</param>
        /// <returns>A task containing the driver information, or null if no record is found.</returns>
        public static async Task<clsDriverInfo> GetDriverInfoByDriverIDAsync(
            int DriverID)
        {

 
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT DriverID, PersonID, CreatedByUserID, CreatedDate
                FROM dbo.Drivers
                WHERE DriverID = @DriverID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsDriverInfo
                                {
                                    DriverID = DriverID,
                                    PersonID = (int)reader["PersonID"],
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    CreatedDate = (DateTime)reader["CreatedDate"]
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
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }


        }


        public static   clsDriverInfo GetDriverInfoByDriverID(
    int DriverID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT DriverID, PersonID, CreatedByUserID, CreatedDate
                FROM dbo.Drivers
                WHERE DriverID = @DriverID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsDriverInfo
                                {
                                    DriverID = DriverID,
                                    PersonID = (int)reader["PersonID"],
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    CreatedDate = (DateTime)reader["CreatedDate"]
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
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }


        }


        /// <summary>
        /// Retrieves driver information using the associated person identifier.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <returns>A task containing the driver information, or null if no record is found.</returns>
        public static async Task<clsDriverInfo> GetDriverInfoByPersonIDAsync(
            int PersonID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT DriverID, PersonID, CreatedByUserID, CreatedDate
                FROM dbo.Drivers
                WHERE PersonID = @PersonID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsDriverInfo
                                {
                                    DriverID = (int)reader["DriverID"],
                                    PersonID = PersonID,
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    CreatedDate = (DateTime)reader["CreatedDate"],

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
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }



        }


        public static clsDriverInfo GetDriverInfoByPersonID(
    int PersonID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT DriverID, PersonID, CreatedByUserID, CreatedDate
                FROM dbo.Drivers
                WHERE PersonID = @PersonID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsDriverInfo
                                {
                                    DriverID = (int)reader["DriverID"],
                                    PersonID = PersonID,
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    CreatedDate = (DateTime)reader["CreatedDate"],

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
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }



        }

        /// <summary>
        /// Adds a new driver record.
        /// </summary>
        /// <param name="PersonID">The associated person identifier.</param>
        /// <param name="CreatedByUserID">The identifier of the user creating the record.</param>
        /// <param name="CreatedDate">The creation date of the driver record.</param>
        /// <returns>A task containing the new driver identifier, or -1 if no identifier is obtained.</returns>
        public static async Task<int> AddNewDriverAsync(
            int PersonID,
            int CreatedByUserID,
            DateTime CreatedDate)
        {
            int DriverID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command =
                    new SqlCommand("SP_AddNewDriver", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                    command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                    command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate;

                    SqlParameter outputIdParam =
                        new SqlParameter("@NewDriverID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                    command.Parameters.Add(outputIdParam);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (outputIdParam.Value != DBNull.Value)
                        DriverID = Convert.ToInt32(outputIdParam.Value);
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
 


            return DriverID;
        }

        /// <summary>
        /// Updates an existing driver record.
        /// </summary>
        /// <param name="DriverID">The driver identifier.</param>
        /// <param name="PersonID">The associated person identifier.</param>
        /// <param name="CreatedByUserID">The identifier of the user who created the record.</param>
        /// <param name="CreatedDate">The creation date of the driver record.</param>
        /// <returns>A task containing true if one or more rows were updated; otherwise, false.</returns>
        public static async Task<bool> UpdateDriverAsync(
            int DriverID,
            int PersonID,
            int CreatedByUserID,
            DateTime CreatedDate)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                UPDATE Drivers
                SET PersonID = @PersonID,
                    CreatedByUserID = @CreatedByUserID,
                    CreatedDate = @CreatedDate
                WHERE DriverID = @DriverID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                        command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                        command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                        command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate;

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }



            return rowsAffected > 0;
        }

        /// <summary>
        /// Retrieves all driver records.
        /// </summary>
        /// <returns>A task containing a DataTable with all driver records.</returns>
        public static async Task<DataTable> GetAllDriversAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM Drivers";

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
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
  


            return dt;
        }


        /// <summary>
        /// Retrieves all driver records from the drivers view.
        /// </summary>
        /// <returns>A task containing a DataTable with all driver view records.</returns>
        public static async Task<DataTable> GetAllDriversViewAsync()
        {
            DataTable dt = new DataTable();



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM dbo.Drivers_View";

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
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
            




            return dt;
        }

        /// <summary>
        /// Deletes a driver record using its driver identifier.
        /// </summary>
        /// <param name="DriverID">The identifier of the driver to delete.</param>
        /// <returns>A task containing true if one or more rows were deleted; otherwise, false.</returns>
        public static async Task<bool> DeleteDriverAsync(int DriverID)
        {
            int rowsAffected = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(
                    "DELETE FROM Drivers WHERE DriverID = @DriverID", connection))
                {
                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                    await connection.OpenAsync();
                    rowsAffected = await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }



            return rowsAffected > 0;
        }

        /// <summary>
        /// Checks whether a driver exists using the driver identifier.
        /// </summary>
        /// <param name="DriverID">The driver identifier to check.</param>
        /// <returns>A task containing true if the driver exists; otherwise, false.</returns>
        public static async Task<bool> IsDriverExistByDriverIDAsync(int DriverID)
        {
            bool IsFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckDriverExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@DriverID", SqlDbType.Int) .Value = DriverID;
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
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
 


            return IsFound;
        }

        /// <summary>
        /// Checks whether a driver exists using the associated person identifier.
        /// </summary>
        /// <param name="PersonID">The person identifier to check.</param>
        /// <returns>A task containing true if a driver exists for the person; otherwise, false.</returns>
        public static async Task<bool> IsDriverExistByPersonIDAsync(int PersonID)
        {
            bool IsFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckDriverExistsByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@PersonID", SqlDbType.Int)
                            .Value = PersonID;
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
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
  


            return IsFound;
        }

        /// <summary>
        /// Retrieves a driver identifier using the associated person identifier.
        /// </summary>
        /// <param name="PersonID">The person identifier.</param>
        /// <returns>A task containing the driver identifier, or -1 if no identifier is found.</returns>
        public static async Task<int> GetDriverIDAsync(int PersonID)
        {
            int DriverID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = @"
   SELECT TOP 1 DriverID
   FROM dbo.Drivers
   WHERE PersonID = @PersonID;";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.Add("@PersonID", SqlDbType.Int)
                            .Value = PersonID;

                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null && Result != DBNull.Value)
                        {
                            DriverID = Convert.ToInt32(Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }



            return DriverID;
        }

        /// <summary>
        /// Retrieves a driver identifier using a person's national number.
        /// </summary>
        /// <param name="NationalNo">The national number of the person.</param>
        /// <returns>A task containing the driver identifier, or -1 if no identifier is found.</returns>
        public static async Task<int> GetDriverIDAsync(string NationalNo)
        {
            int DriverID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = @"
   SELECT TOP 1 D.DriverID
   FROM dbo.Drivers AS D
   INNER JOIN dbo.People AS P
       ON D.PersonID = P.PersonID
   WHERE P.NationalNo = @NationalNo;";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.Add("@NationalNo", SqlDbType.NVarChar)
                            .Value = (object)NationalNo ?? DBNull.Value;

                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null && Result != DBNull.Value)
                        {
                            DriverID = Convert.ToInt32(Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
 



            return DriverID;
        }



        /// <summary>
        /// Retrieves the national number associated with a driver identifier.
        /// </summary>
        /// <param name="DriverID">The driver identifier.</param>
        /// <returns>A task containing the national number, or an empty string if no value is found.</returns>
        public static async Task<string> GetNationalNoByDriverIDAsync(int DriverID)
        {
            string NationalNo = string.Empty;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = @"
SELECT NationalNo
FROM dbo.Drivers_View
WHERE DriverID = @DriverID;";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.Add("@DriverID", SqlDbType.Int)
                            .Value = DriverID;

                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null && Result != DBNull.Value)
                        {
                            NationalNo = Result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
   


            return NationalNo;
        }

        /// <summary>
        /// Retrieves the total number of driver records.
        /// </summary>
        /// <returns>A task containing the total number of drivers.</returns>
        public static async Task<int> GetAllDriversCountAsync()
        {
            int DriversCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = @"
SELECT COUNT(*)
FROM dbo.Drivers;";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null && Result != DBNull.Value)
                        {
                            DriversCount = Convert.ToInt32(Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
     


            return DriversCount;
        }

        /// <summary>
        /// Retrieves the number of distinct drivers with licenses matching the specified active status.
        /// </summary>
        /// <param name="Active">Indicates whether to count drivers with active licenses. Defaults to true.</param>
        /// <returns>A task containing the number of matching drivers.</returns>
        public static async Task<int> GetAllDriversCountAsync(bool Active = true)
        {
            int DriversCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = @"
SELECT COUNT(DISTINCT D.DriverID)
FROM dbo.Drivers AS D
INNER JOIN dbo.Licenses AS L
    ON D.DriverID = L.DriverID
WHERE L.IsActive = @Active;";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.Add("@Active", SqlDbType.Bit)
                            .Value = Active;

                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null && Result != DBNull.Value)
                        {
                            DriversCount = Convert.ToInt32(Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }



            return DriversCount;
        }

        /// <summary>
        /// Retrieves the number of drivers added during the last month.
        /// </summary>
        /// <returns>A task containing the number of recently added drivers.</returns>
        public static async Task<int> GetRecentlyAddedDriversCountAsync()
        {
            int DriversCount = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = @"
SELECT  COUNT(*)
FROM dbo.Drivers
WHERE CreatedDate >= DATEADD(MONTH, -1, GETDATE())
  AND CreatedDate <= GETDATE();";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null && Result != DBNull.Value)
                        {
                            DriversCount = Convert.ToInt32(Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
  


            return DriversCount;
        }

        /// <summary>
        /// Retrieves the creation date of the most recently created driver record.
        /// </summary>
        /// <returns>A task containing the latest creation date, or the current date and time if no value is found.</returns>
        public static async Task<DateTime> GetLastUpdateDateTimeAsync()
        {
            DateTime LastUpdateDateTime = DateTime.Now;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = @"
                            SELECT TOP 1 CreatedDate
                            FROM dbo.Drivers
                            ORDER BY CreatedDate DESC;";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null && Result != DBNull.Value)
                        {
                            LastUpdateDateTime = Convert.ToDateTime(Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDriverData");
                throw;
            }
  


            return LastUpdateDateTime;
        }

    }


}
