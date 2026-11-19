using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{


    static public class clsApplicationsTypesData
    {
        public class ApplicationTypeInfoResult
        {
            public int ApplicationTypeID { get; set; }
            public string ApplicationTypeTitle { get; set; } = "";
            public float ApplicationFees { get; set; }
        }

        // The application type information, including its title, fees, and
        /// whether the record was found.
        /// </returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<ApplicationTypeInfoResult>
            GetApplicationTypeInfoByIDAsync(int ApplicationTypeID)
        {
 


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT ApplicationTypeTitle, ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {


                            if (await reader.ReadAsync())
                            {
                                return new ApplicationTypeInfoResult
                                {

                                    ApplicationTypeID = ApplicationTypeID,

                                    ApplicationTypeTitle =
                                        (string)reader["ApplicationTypeTitle"],
                                    

                                    ApplicationFees =
                                        Convert.ToSingle(reader["ApplicationFees"])
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }


        }


        public static ApplicationTypeInfoResult
    GetApplicationTypeInfoByID(int ApplicationTypeID)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT ApplicationTypeTitle, ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {


                            if ( reader.Read())
                            {
                                return new ApplicationTypeInfoResult
                                {

                                    ApplicationTypeID = ApplicationTypeID,

                                    ApplicationTypeTitle =
                                        (string)reader["ApplicationTypeTitle"],

                                    ApplicationFees =
                                        Convert.ToSingle(reader["ApplicationFees"])
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }


        }

        /// <summary>
        /// Retrieves application type information using its title.
        /// </summary>
        /// <param name="ApplicationTypeTitle">The title of the application type.</param>
        /// <returns>
        /// The application type information, including its ID, fees, and
        /// whether the record was found.
        /// </returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<ApplicationTypeInfoResult>
            GetApplicationTypeInfoByTitleAsync(string ApplicationTypeTitle)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeTitle = @ApplicationTypeTitle";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {

                                return new ApplicationTypeInfoResult
                                {

                                    ApplicationTypeID = (int)reader["ApplicationTypeID"],

                                    ApplicationTypeTitle =
                                          ApplicationTypeTitle,

                                    ApplicationFees =
                                          Convert.ToSingle(reader["ApplicationFees"])
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }


        }

        public static ApplicationTypeInfoResult
    GetApplicationTypeInfoByTitle(string ApplicationTypeTitle)
        {



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeTitle = @ApplicationTypeTitle";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {

                                return new ApplicationTypeInfoResult
                                {

                                    ApplicationTypeID = (int)reader["ApplicationTypeID"],

                                    ApplicationTypeTitle =
                                          ApplicationTypeTitle,

                                    ApplicationFees =
                                          Convert.ToSingle(reader["ApplicationFees"])
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }


        }


        /// <summary>
        /// Creates a new application type using the SP_AddNewApplicationType
        /// stored procedure.
        /// </summary>
        /// <param name="Title">The title of the application type.</param>
        /// <param name="Fees">The fees associated with the application type.</param>
        /// <returns>The newly created application type ID, or -1 if no ID is assigned.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<int> AddNewApplicationTypeAsync(string Title, float Fees)
        {
            int ApplicationTypeID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewApplicationType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@Fees", Fees);

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewApplicationTypeID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        ApplicationTypeID =
                            (int)command.Parameters["@NewApplicationTypeID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }


            return ApplicationTypeID;
        }




        /// <summary>
        /// Retrieves all application types from the database.
        /// </summary>
        /// <returns>A DataTable containing all application type records.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<DataTable> GetAllApplicationTypesAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM ApplicationTypes";

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
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }


            return dt;
        }

        /// <summary>
        /// Retrieves the total number of application types and converts it to a byte.
        /// </summary>
        /// <returns>The total application type count as a byte.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<byte> GetAllApplicationTypesCountAsync()
        {
            byte TotalApplicationTypeCount = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT top 1 TotalApplicationTypeCount = count(*) FROM ApplicationTypes";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object Result = await command.ExecuteScalarAsync();

                        if (Result != null && int.TryParse(Result.ToString(), out int ParsedCount))
                        {
                            TotalApplicationTypeCount = Convert.ToByte(ParsedCount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }
 

            return TotalApplicationTypeCount;
        }

        /// <summary>
        /// Checks whether an application type exists using its ID.
        /// </summary>
        /// <param name="ApplicationTypeID">The ID of the application type.</param>
        /// <returns>True if the application type exists; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<bool> IsApplicationTypeExistAsync(int ApplicationTypeID)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckApplicationTypeExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(
                            "@ApplicationTypeID", ApplicationTypeID);
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }


            return isFound;
        }

        /// <summary>
        /// Checks whether an application type exists using its title.
        /// </summary>
        /// <param name="ApplicationTypeTitle">The title of the application type.</param>
        /// <returns>True if the application type exists; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<bool> IsApplicationTypeExistAsync(string ApplicationTypeTitle)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckApplicationTypeExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(
                            "@ApplicationTypeTitle", ApplicationTypeTitle);
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
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }

            return isFound;
        }

        /// <summary>
        /// Updates the title and fees of an existing application type.
        /// </summary>
        /// <param name="ApplicationTypeID">The ID of the application type to update.</param>
        /// <param name="ApplicationTypeTitle">The new title of the application type.</param>
        /// <param name="ApplicationFees">The new fees for the application type.</param>
        /// <returns>True if at least one row was updated; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<bool> UpdateApplicationTypeAsync(
            int ApplicationTypeID,
            string ApplicationTypeTitle,
            float ApplicationFees)
        {
            int RowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE ApplicationTypes
         SET
             ApplicationTypeTitle = @ApplicationTypeTitle,
             ApplicationFees = @ApplicationFees
         WHERE ApplicationTypeID = @ApplicationTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                        command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                        command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

                        await connection.OpenAsync();

                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }
 

            return (RowsAffected > 0);
        }

        /// <summary>
        /// Retrieves the fees associated with an application type.
        /// </summary>
        /// <param name="ApplicationTypeID">The ID of the application type.</param>
        /// <returns>The application fees, or zero if no result is found.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<float> GetApplicationFeesByIDAsync(int ApplicationTypeID)
        {
            float Fees = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"select  Top 1  ApplicationFees from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        await connection.OpenAsync();

                        Object Result = await command.ExecuteScalarAsync();

                        if (Result != null)
                        {
                            Fees = Convert.ToSingle(Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsApplicationsTypesData");
                throw;
            }

            return Fees;
        }
    }
}