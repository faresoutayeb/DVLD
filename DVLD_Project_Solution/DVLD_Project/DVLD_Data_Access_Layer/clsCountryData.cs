
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
    /// Provides data access operations for retrieving and checking country information.
    /// </summary>
    public static class clsCountryData
    {
        /// <summary>
        /// Represents the result of retrieving country information.
        /// </summary>
        public class CountryInfoResult
        {


            /// <summary>
            /// Gets or sets the unique identifier of the country.
            /// </summary>
            public int CountryID { get; set; } = -1;

            /// <summary>
            /// Gets or sets the name of the country.
            /// </summary>
            public string CountryName { get; set; } = string.Empty;
        }

        /// <summary>
        /// Retrieves country information using its unique identifier.
        /// </summary>
        /// <param name="CountryID">The ID of the country to retrieve.</param>
        /// <returns>A result containing the country information and whether it was found.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<CountryInfoResult> GetCountryInfoByIDAsync(  int CountryID)
        {
      

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT dbo.Countries.CountryName FROM dbo.Countries WHERE dbo.Countries.CountryID = @CountryID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryID", CountryID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new CountryInfoResult
                                {

                                   CountryID= CountryID,
                                   CountryName= reader["CountryName"].ToString()
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
                clsDataAccessEventLog.LogError(ex, "clsCountryData");
                throw;
            }
 

   
        }
        public static  CountryInfoResult GetCountryInfoByID(int CountryID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT dbo.Countries.CountryName FROM dbo.Countries WHERE dbo.Countries.CountryID = @CountryID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryID", CountryID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CountryInfoResult
                                {
                                    CountryID = CountryID,
                                    CountryName = reader["CountryName"].ToString()
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
                clsDataAccessEventLog.LogError(ex, "clsCountryData");
                throw;
            }
        }
        /// <summary>
        /// Retrieves country information using its name.
        /// </summary>
        /// <param name="CountryName">The name of the country to retrieve.</param>
        /// <returns>A result containing the country information and whether it was found.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static  async Task<CountryInfoResult> GetCountryInfoByNameAsync(
            string CountryName)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT CountryID FROM Countries WHERE CountryName = @CountryName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryName", CountryName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new CountryInfoResult
                                {
                                    CountryID = (int)reader[ "CountryID"],
                                    CountryName = CountryName.ToString()
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
                clsDataAccessEventLog.LogError(ex, "clsCountryData");
                throw;
            }

        }

        public static CountryInfoResult GetCountryInfoByName(
    string CountryName)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT CountryID FROM Countries WHERE CountryName = @CountryName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryName", CountryName);

                         connection.Open();

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new CountryInfoResult
                                {
                                    CountryID = (int)reader["CountryID"],
                                    CountryName = reader["CountryName"].ToString()
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
                clsDataAccessEventLog.LogError(ex, "clsCountryData");
                throw;
            }

        }

        /// <summary>
        /// Retrieves all countries from the database.
        /// </summary>
        /// <returns>A DataTable containing country IDs and names.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<DataTable> GetAllCountriesAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT CountryID,CountryName FROM Countries";

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
                clsDataAccessEventLog.LogError(ex, "clsCountryData");
                throw;
            }


            return dt;
        }


        public static async Task<DataTable> GetAllCountriesNameAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT CountryName FROM Countries";

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
                clsDataAccessEventLog.LogError(ex, "clsCountryData");
                throw;
            }


            return dt;
        }

        /// <summary>
        /// Checks whether a country exists using its ID.
        /// </summary>
        /// <param name="CountryID">The ID of the country to check.</param>
        /// <returns>True if the country exists; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<bool> IsCountryExistByIDAsync(int CountryID)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckCountryExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CountryID", CountryID);

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
                clsDataAccessEventLog.LogError(ex, "clsCountryData");
                throw;
            }
  

            return isFound;
        }

        /// <summary>
        /// Checks whether a country exists using its name.
        /// </summary>
        /// <param name="CountryName">The name of the country to check.</param>
        /// <returns>True if the country exists; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when a database operation fails.</exception>
        public static async Task<bool> IsCountryExistByNameAsync(
            string CountryName)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckCountryExistsByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CountryName", CountryName);
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
                clsDataAccessEventLog.LogError(ex, "clsCountryData");
                throw;
            }

            return isFound;
        }
    }
}

