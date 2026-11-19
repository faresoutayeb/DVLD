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
    /// Provides data access operations for detention reasons.
    /// </summary>
    public class clsDetainReasonData
    {
        /// <summary>
        /// Represents detention reason information and its retrieval status.
        /// </summary>
        public class clsDetainReasonInfo
        {


            /// <summary>
            /// Gets or sets the detention reason identifier.
            /// </summary>
            public int DetainReasonID { get; set; }

            /// <summary>
            /// Gets or sets the detention reason text.
            /// </summary>
            public string ReasonText { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="clsDetainReasonInfo"/> class
            /// with default values.
            /// </summary>
            public clsDetainReasonInfo()
            {
                DetainReasonID = -1;
                ReasonText = string.Empty;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="clsDetainReasonInfo"/> class
            /// with the specified detention reason information.
            /// </summary>
            /// <param name="IsFound">Indicates whether the detention reason was found.</param>
            /// <param name="detainReasonID">The detention reason identifier.</param>
            /// <param name="reasonText">The detention reason text.</param>
            public clsDetainReasonInfo(bool IsFound, int detainReasonID, string reasonText)
            {
                DetainReasonID = detainReasonID;
                ReasonText = reasonText;
            }
        }

        /// <summary>
        /// Retrieves detention reason information by its identifier.
        /// </summary>
        /// <param name="DetainReasonID">The detention reason identifier.</param>
        /// <returns>A task containing the detention reason information, or null if no record is found.</returns>
        public static async Task<clsDetainReasonInfo> GetDetainReasonInfoByIDAsync(
            int DetainReasonID)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                        SELECT DetainReasonID, ReasonText
                        FROM dbo.DetainReasons
                        WHERE DetainReasonID = @DetainReasonID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DetainReasonID", SqlDbType.Int)
                            .Value = DetainReasonID;

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {

                                return new clsDetainReasonInfo
                                {
                                    DetainReasonID = (int)DetainReasonID,
                                    ReasonText = reader["ReasonText"].ToString()
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
                clsDataAccessEventLog.LogError(ex, "clsDetainReasonData");
                throw;
            }


        }


        public static clsDetainReasonInfo GetDetainReasonInfoByID(
    int DetainReasonID)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                        SELECT DetainReasonID, ReasonText
                        FROM dbo.DetainReasons
                        WHERE DetainReasonID = @DetainReasonID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DetainReasonID", SqlDbType.Int)
                            .Value = DetainReasonID;

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {

                                return new clsDetainReasonInfo
                                {
                                    DetainReasonID = DetainReasonID,
                                    ReasonText = reader["ReasonText"].ToString()
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
                clsDataAccessEventLog.LogError(ex, "clsDetainReasonData");
                throw;
            }


        }

        public static clsDetainReasonInfo GetDetainReasonInfoByName(
string DetainReasonName)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                        SELECT DetainReasonID, ReasonText
                        FROM dbo.DetainReasons
                        WHERE ReasonText = @ReasonText;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DetainReasonID", SqlDbType.Int)
                            .Value = DetainReasonName;

                        connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                return new clsDetainReasonInfo
                                {
                                    DetainReasonID = (int)reader["DetainReasonID"],
                                    ReasonText = DetainReasonName
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
                clsDataAccessEventLog.LogError(ex, "clsDetainReasonData");
                throw;
            }


        }


        public static async Task<clsDetainReasonInfo> GetDetainReasonInfoByNameAsync(
string DetainReasonName)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                        SELECT DetainReasonID, ReasonText
                        FROM dbo.DetainReasons
                        WHERE ReasonText = @ReasonText;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DetainReasonID", SqlDbType.Int)
                            .Value = DetainReasonName;

                      await  connection.OpenAsync();

                        using (SqlDataReader reader =await  command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {

                                return new clsDetainReasonInfo
                                {
                                    DetainReasonID = (int)reader["DetainReasonID"],
                                    ReasonText = DetainReasonName
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
                clsDataAccessEventLog.LogError(ex, "clsDetainReasonData");
                throw;
            }


        }


        /// <summary>
        /// Updates the text of an existing detention reason.
        /// </summary>
        /// <param name="DetainReasonID">The detention reason identifier.</param>
        /// <param name="ReasonText">The new detention reason text.</param>
        /// <returns>A task containing true if one or more rows were updated; otherwise, false.</returns>
        public static async Task<bool> UpdateDetainReasonAsync(
            int DetainReasonID,
            string ReasonText)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                        UPDATE dbo.DetainReasons
                        SET ReasonText = @ReasonText
                        WHERE DetainReasonID = @DetainReasonID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DetainReasonID", SqlDbType.Int)
                            .Value = DetainReasonID;

                        command.Parameters.Add("@ReasonText", SqlDbType.NVarChar)
                            .Value = (object)ReasonText ?? DBNull.Value;

                        await connection.OpenAsync();

                        return await command.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetainReasonData");
                throw;
            }

        }

        /// <summary>
        /// Retrieves all detention reasons.
        /// </summary>
        /// <returns>A task containing a DataTable with all detention reasons.</returns>
        public static async Task<DataTable> GetAllDetainReasonsAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                        SELECT DetainReasonID, ReasonText
                        FROM dbo.DetainReasons;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetainReasonData");
                throw;
            }
   

            return dt;
        }

        /// <summary>
        /// Adds a new detention reason.
        /// </summary>
        /// <param name="ReasonText">The text of the detention reason to add.</param>
        /// <returns>A task containing the new detention reason identifier, or -1 if no identifier is obtained.</returns>
        public static async Task<int> AddNewDetainReasonAsync(string ReasonText)
        {
            int DetainReasonID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewDetainReason", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@ReasonText", SqlDbType.NVarChar)
                            .Value = (object)ReasonText ?? DBNull.Value;

                        SqlParameter outputIdParam =
                            new SqlParameter("@NewDetainReasonID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (outputIdParam.Value != DBNull.Value &&
                            outputIdParam.Value != null)
                        {
                            DetainReasonID = Convert.ToInt32(outputIdParam.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetainReasonData");
                throw;
            }
            
 

            return DetainReasonID;
        }

        /// <summary>
        /// Deletes a detention reason by its identifier.
        /// </summary>
        /// <param name="DetainReasonID">The detention reason identifier.</param>
        /// <returns>A task containing true if one or more rows were deleted; otherwise, false.</returns>
        public static async Task<bool> DeleteDetainReasonAsync(int DetainReasonID)
        {

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                        DELETE FROM dbo.DetainReasons
                        WHERE DetainReasonID = @DetainReasonID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DetainReasonID", SqlDbType.Int)
                            .Value = DetainReasonID;

                        await connection.OpenAsync();

                        return await command.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsDetainReasonData");
                throw;
            }
 
        }
    }
}

