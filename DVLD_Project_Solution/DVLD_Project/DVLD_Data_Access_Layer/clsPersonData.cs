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
    /// Provides asynchronous data access operations for retrieving and managing
    /// person records in the database.
    /// </summary>
    static public class clsPersonData
    {
        /// <summary>
        /// Represents the information associated with a person retrieved from
        /// the database, including personal details and record status.
        /// </summary>
        public class clsPersonInfo
        {


            /// <summary>
            /// Gets or sets the unique identifier of the person.
            /// </summary>
            public int PersonID { get; set; }

            /// <summary>
            /// Gets or sets the person's national identification number.
            /// </summary>
            public string NationalNo { get; set; }

            /// <summary>
            /// Gets or sets the person's first name.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Gets or sets the person's second name.
            /// </summary>
            public string SecondName { get; set; }

            /// <summary>
            /// Gets or sets the person's third name.
            /// </summary>
            public string ThirdName { get; set; }

            /// <summary>
            /// Gets or sets the person's last name.
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Gets or sets the person's date of birth.
            /// </summary>
            public DateTime DateOfBirth { get; set; }

            /// <summary>
            /// Gets or sets the person's gender value.
            /// </summary>
            public bool Gendor { get; set; }

            /// <summary>
            /// Gets or sets the person's residential address.
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Gets or sets the person's contact phone number.
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// Gets or sets the person's email address.
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the person's nationality country.
            /// </summary>
            public int NationalityCountryID { get; set; }

            /// <summary>
            /// Gets or sets the file path of the person's image.
            /// </summary>
            public string ImagePath { get; set; }

            /// <summary>
            /// Gets or sets the date and time when the person record was created.
            /// </summary>
            public DateTime CreatedDateTime { get; set; }

            /// <summary>
            /// Initializes a person information object with default values.
            /// Numeric identifiers are initialized to -1, strings to empty strings,
            /// and dates to DateTime.MinValue.
            /// </summary>
            public clsPersonInfo()
            {
                PersonID = -1;
                NationalNo = string.Empty;
                FirstName = string.Empty;
                SecondName = string.Empty;
                ThirdName = string.Empty;
                LastName = string.Empty;
                DateOfBirth = DateTime.MinValue;
                Gendor = false;
                Address = string.Empty;
                Phone = string.Empty;
                Email = string.Empty;
                NationalityCountryID = -1;
                ImagePath = string.Empty;
                CreatedDateTime = DateTime.MinValue;
            }
        }

        /// <summary>
        /// Retrieves a person's information using the person's unique identifier.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains
        /// the person's information if found, or null if the record does not exist
        /// or an exception occurs.
        /// </returns>
        public static async Task<clsPersonInfo> GetPersonInfoByIDAsync(int PersonID)
        {
 

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT
                    PersonID,
                    NationalNo,
                    FirstName,
                    SecondName,
                    ThirdName,
                    LastName,
                    DateOfBirth,
                    Gendor,
                    Address,
                    Phone,
                    Email,
                    NationalityCountryID,
                    ImagePath,
                    CreatedDateTime
                FROM People
                WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsPersonInfo
                                {
                                    PersonID = PersonID,
                                    NationalNo = (string)reader["NationalNo"],
                                    FirstName = (string)reader["FirstName"],
                                    SecondName = reader["SecondName"] != DBNull.Value
                                        ? (string)reader["SecondName"] : "",
                                    ThirdName = reader["ThirdName"] != DBNull.Value
                                        ? (string)reader["ThirdName"] : "",
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    Gendor = Convert.ToBoolean(reader["Gendor"]),
                                    Address = (string)reader["Address"],
                                    Phone = (string)reader["Phone"],
                                    Email = reader["Email"] != DBNull.Value
                                        ? (string)reader["Email"] : "",
                                    NationalityCountryID =
                                        (int)reader["NationalityCountryID"],
                                    ImagePath = reader["ImagePath"] != DBNull.Value
                                        ? (string)reader["ImagePath"] : "",
                                    CreatedDateTime =
                                        (DateTime)reader["CreatedDateTime"]


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
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;
            }


        }
        public static clsPersonInfo GetPersonInfoByID(int PersonID)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT
                    PersonID,
                    NationalNo,
                    FirstName,
                    SecondName,
                    ThirdName,
                    LastName,
                    DateOfBirth,
                    Gendor,
                    Address,
                    Phone,
                    Email,
                    NationalityCountryID,
                    ImagePath,
                    CreatedDateTime
                FROM People
                WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsPersonInfo
                                {
                                    PersonID = PersonID,
                                    NationalNo = (string)reader["NationalNo"],
                                    FirstName = (string)reader["FirstName"],
                                    SecondName = reader["SecondName"] != DBNull.Value
                                        ? (string)reader["SecondName"] : "",
                                    ThirdName = reader["ThirdName"] != DBNull.Value
                                        ? (string)reader["ThirdName"] : "",
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    Gendor = Convert.ToBoolean(reader["Gendor"]),
                                    Address = (string)reader["Address"],
                                    Phone = (string)reader["Phone"],
                                    Email = reader["Email"] != DBNull.Value
                                        ? (string)reader["Email"] : "",
                                    NationalityCountryID =
                                        (int)reader["NationalityCountryID"],
                                    ImagePath = reader["ImagePath"] != DBNull.Value
                                        ? (string)reader["ImagePath"] : "",
                                    CreatedDateTime =
                                        (DateTime)reader["CreatedDateTime"]


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
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;
            }


        }


        /// <summary>
        /// Retrieves a person's information using the person's national identification number.
        /// </summary>
        /// <param name="NationalNo">The national identification number of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains
        /// the person's information if found, or null if the record does not exist
        /// or an exception occurs.
        /// </returns>
        public static async Task<clsPersonInfo> GetPersonInfoByNationalNoAsync(
            string NationalNo)
        {
 

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT *
                FROM People
                WHERE NationalNo = @NationalNo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new clsPersonInfo
                                {
                                    PersonID = (int)reader["PersonID"],
                                    NationalNo = NationalNo,
                                    FirstName = (string)reader["FirstName"],
                                    SecondName = reader["SecondName"] != DBNull.Value
                                        ? (string)reader["SecondName"] : "",
                                    ThirdName = reader["ThirdName"] != DBNull.Value
                                        ? (string)reader["ThirdName"] : "",
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    Gendor = Convert.ToBoolean(reader["Gendor"]),
                                    Address = (string)reader["Address"],
                                    Phone = (string)reader["Phone"],
                                    Email = reader["Email"] != DBNull.Value
                                        ? (string)reader["Email"] : "",
                                    NationalityCountryID =
                                        (int)reader["NationalityCountryID"],
                                    ImagePath = reader["ImagePath"] != DBNull.Value
                                        ? (string)reader["ImagePath"] : "",
                                    CreatedDateTime =
                                        (DateTime)reader["CreatedDateTime"]


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
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;
            }


        }


        public static clsPersonInfo GetPersonInfoByNationalNo(
    string NationalNo)
        {


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT *
                FROM People
                WHERE NationalNo = @NationalNo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                         connection.Open();

                        using (SqlDataReader reader =
                             command.ExecuteReader())
                        {
                            if ( reader.Read())
                            {
                                return new clsPersonInfo
                                {
                                    PersonID = (int)reader[" PersonID"],
                                    NationalNo = NationalNo,
                                    FirstName = (string)reader["FirstName"],
                                    SecondName = reader["SecondName"] != DBNull.Value
                                        ? (string)reader["SecondName"] : "",
                                    ThirdName = reader["ThirdName"] != DBNull.Value
                                        ? (string)reader["ThirdName"] : "",
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    Gendor = Convert.ToBoolean(reader["Gendor"]),
                                    Address = (string)reader["Address"],
                                    Phone = (string)reader["Phone"],
                                    Email = reader["Email"] != DBNull.Value
                                        ? (string)reader["Email"] : "",
                                    NationalityCountryID =
                                        (int)reader["NationalityCountryID"],
                                    ImagePath = reader["ImagePath"] != DBNull.Value
                                        ? (string)reader["ImagePath"] : "",
                                    CreatedDateTime =
                                        (DateTime)reader["CreatedDateTime"]


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
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;
            }


        }


        /// <summary>
        /// Adds a new person record to the database by executing the
        /// SP_AddNewPerson stored procedure.
        /// </summary>
        /// <param name="NationalNo">The person's national identification number.</param>
        /// <param name="FirstName">The person's first name.</param>
        /// <param name="SecondName">The person's second name.</param>
        /// <param name="ThirdName">The person's third name.</param>
        /// <param name="LastName">The person's last name.</param>
        /// <param name="DateOfBirth">The person's date of birth.</param>
        /// <param name="Gendor">The person's gender value.</param>
        /// <param name="Address">The person's residential address.</param>
        /// <param name="Phone">The person's contact phone number.</param>
        /// <param name="Email">The person's email address.</param>
        /// <param name="NationalityCountryID">The identifier of the person's nationality country.</param>
        /// <param name="ImagePath">The file path of the person's image, if available.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains
        /// the newly created person's identifier, or -1 if the operation fails.
        /// </returns>
        public static async Task<int> AddNewPersonAsync(
            string NationalNo,
            string FirstName,
            string   SecondName,
            string ThirdName,
            string LastName,
            DateTime DateOfBirth,
            bool Gendor,
            string Address,
            string Phone,
            string Email,
            int NationalityCountryID,
            string ImagePath)
        {
            int PersonID = -1;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@FirstName", FirstName);

                        if(SecondName == "")
                        {
                            command.Parameters.AddWithValue("@SecondName",  (object)DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@SecondName", SecondName);

                        }
                        if(ThirdName == "")
                        {
                            command.Parameters.AddWithValue("@ThirdName", (object)DBNull.Value);

                        }

                        else
                        {
                            command.Parameters.AddWithValue("@ThirdName", ThirdName);

                        }


                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Gendor);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@CreatedDateTime", DateTime.Now);
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                        if(ImagePath =="")
                        {
                              command.Parameters.AddWithValue( "@ImagePath",(object)DBNull.Value);      

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);

                        }

                        SqlParameter outputIdParam =
                                new SqlParameter("@NewPersonID", SqlDbType.Int)
                                {
                                    Direction = ParameterDirection.Output
                                };

                        command.Parameters.Add(outputIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        PersonID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;
            }


            return PersonID;
        }

        //=============================================================
        // Update Person Information
        //=============================================================

        /// <summary>
        /// Updates the existing person's information in the database using the specified person ID.
        /// Updates personal details, contact information, nationality, and image path.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to update.</param>
        /// <param name="NationalNo">The person's national identification number.</param>
        /// <param name="FirstName">The person's first name.</param>
        /// <param name="SecondName">The person's second name.</param>
        /// <param name="ThirdName">The person's third name.</param>
        /// <param name="LastName">The person's last name.</param>
        /// <param name="DateOfBirth">The person's date of birth.</param>
        /// <param name="Gendor">The person's gender, represented as a Boolean value.</param>
        /// <param name="Address">The person's residential address.</param>
        /// <param name="Phone">The person's phone number.</param>
        /// <param name="Email">The person's email address.</param>
        /// <param name="NationalityCountryID">The identifier of the person's nationality country.</param>
        /// <param name="ImagePath">The file path of the person's image, or null if no image path is provided.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is true if at least one
        /// database row was affected; otherwise, false.
        /// </returns>
        /// <remarks>
        /// Uses parameterized SQL to update the People table and acquires the shared data access

        /// is released in the finally block.
        /// </remarks>
        public static async Task<bool> UpdatePersonAsync(
          int PersonID,
          string NationalNo,
          string FirstName,
          string SecondName,
          string ThirdName,
          string LastName,
          DateTime DateOfBirth,
          bool Gendor,
          string Address,
          string Phone,
          string Email,
          int NationalityCountryID,
          string ImagePath)
        {
            int rowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
           UPDATE People
           SET NationalNo = @NationalNo,
               FirstName = @FirstName,
               SecondName = @SecondName,
               ThirdName = @ThirdName,
               LastName = @LastName,
               DateOfBirth = @DateOfBirth,
               Gendor = @Gendor,
               Address = @Address,
               Phone = @Phone,
               Email = @Email,
               NationalityCountryID = @NationalityCountryID,
               ImagePath = @ImagePath
           WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@FirstName", FirstName);

                        if (SecondName == "")
                        {
                            command.Parameters.AddWithValue("@SecondName", (object)DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@SecondName", SecondName);

                        }
                        if (ThirdName == "")
                        {
                            command.Parameters.AddWithValue("@ThirdName", (object)DBNull.Value);

                        }

                        else
                        {
                            command.Parameters.AddWithValue("@ThirdName", ThirdName);

                        }


                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Gendor);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@CreatedDateTime", DateTime.Now);
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                        if (ImagePath == "")
                        {
                            command.Parameters.AddWithValue("@ImagePath", (object)DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);

                        }

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and preserve the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;
            }


            return rowsAffected > 0;
        }


        //=============================================================
        // Get All People
        //=============================================================

        /// <summary>
        /// Retrieves all people from the database along with their nationality country information.
        /// Converts the stored gender value into a readable gender caption and orders the results
        /// alphabetically by first name.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is a DataTable containing
        /// the retrieved people and their associated country information. An empty DataTable is
        /// returned if no records are found or an exception occurs.
        /// </returns>
        /// <remarks>
        /// Uses an INNER JOIN between the People and Countries tables. The shared data access

        /// </remarks>
        public static async Task<DataTable> GetAllPeopleAsync()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
           SELECT
               PersonID,
               NationalNo,
               FirstName,
               SecondName,
               ThirdName,
               LastName,
              DateOfBirth= cast(DateOfBirth as date),
               Gendor =
                   CASE
                       WHEN People.Gendor = 0 THEN 'Male'
                       ELSE 'Female'
                   END,
               Address,
               Phone,
               Email,
               Countries.CountryID,
               Countries.CountryName,
               People.ImagePath
           FROM People
           INNER JOIN Countries
               ON Countries.CountryID = People.NationalityCountryID
           ORDER BY People.FirstName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader =
                            await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception without changing the existing error-handling behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }

            return dt;
        }


        //=============================================================
        // Delete Person By ID
        //=============================================================

        /// <summary>
        /// Deletes a person from the People table using the specified person ID.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is true if at least one
        /// database row was deleted; otherwise, false.
        /// </returns>
        /// <remarks>

        /// to coordinate database access. Exceptions are logged.
        /// </remarks>
        public static async Task<bool> DeletePersonAsync(int PersonID)
        {
            int rowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"DELETE FROM People WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and preserve the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }


            return rowsAffected > 0;
        }


        //=============================================================
        // Delete Person By National Number
        //=============================================================

        /// <summary>
        /// Deletes a person from the People table using the specified national identification number.
        /// </summary>
        /// <param name="NationalNo">The national identification number of the person to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is true if at least one
        /// database row was deleted; otherwise, false.
        /// </returns>
        /// <remarks>
        /// Executes a parameterized DELETE statement using the person's national identification

        /// the finally block.
        /// </remarks>
        public static async Task<bool> DeletePersonAsync(string NationalNo)
        {
            int rowsAffected = 0;


            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"DELETE FROM People WHERE NationalNo = @NationalNo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await connection.OpenAsync();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and preserve the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }


            return rowsAffected > 0;
        }


        //=============================================================
        // Check If Person Exists By ID
        //=============================================================

        /// <summary>
        /// Checks whether a person with the specified ID exists in the database.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is true if the stored
        /// procedure reports that the person exists; otherwise, false.
        /// </returns>
        /// <remarks>
        /// Executes the SP_CheckPersonExistsByID stored procedure and passes the person ID as

        /// in the finally block.
        /// </remarks>
        public static async Task<bool> IsPersonExistAsync(int PersonID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckPersonExistsByID", connection))
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
                // Log the exception and preserve the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }



            return isFound;
        }
        //=============================================================
        // Check If Image Belongs To Another Person
        //=============================================================


        /// <summary>
        /// Checks whether a person with the specified NationalNo exists in the database.
        /// </summary>
        /// <param name="NationalNo">The unique identifier of the person to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is true if the stored
        /// procedure reports that the person exists; otherwise, false.
        /// </returns>
        /// <remarks>
        /// Executes the SP_CheckPersonExists stored procedure and passes the person ID as




        /// in the finally block.
        /// </remarks>
        public static async Task<bool> IsPersonExistAsync(string NationalNo)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =   new SqlCommand("SP_CheckPersonExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
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
                // Log the exception and preserve the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }


            return isFound;
        }
        //=============================================================
        // Check If Image Belongs To Another Person
        //=============================================================


        /// <summary>
        /// Checks whether the specified image path is associated with another person
        /// in the database, excluding the person identified by the specified person ID.
        /// </summary>
        /// <param name="ImagePath">The image path to check for association with another person.</param>
        /// <param name="PersonID">The ID of the person to exclude from the check.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is true if the
        /// image belongs to another person; otherwise, false.
        /// </returns>
        /// <remarks>
        /// Executes the SP_CheckImageBelongsToOtherPerson stored procedure with the
        /// specified image path and person ID. Exceptions are logged, and the shared

        /// </remarks>
        public static async Task<bool> IsImageBelongToOtherPersonAsync(
        string ImagePath, int PersonID)
        {
            bool isFound = false;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command =
                        new SqlCommand("SP_CheckImageBelongsToOtherPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
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
                // Log the exception without changing the existing error-handling behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }
    


            return isFound;
        }


        //=============================================================
        // Get Person ID By National Number
        //=============================================================

        /// <summary>
        /// Retrieves the person ID associated with the specified national identification number.
        /// </summary>
        /// <param name="NationalNo">The national identification number to search for.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is the person's ID
        /// if a matching record is found; otherwise, -1.
        /// </returns>
        /// <remarks>
        /// Executes a parameterized SELECT query against the People table. Exceptions are logged,

        /// </remarks>
        public static async Task<int> GetPersonIDByNationalNoAsync(
        string NationalNo)
        {
            int PersonID = -1;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT PersonID
            FROM People
            WHERE NationalNo = @NationalNo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value &&
                            int.TryParse(result.ToString(), out int personIDParsed))
                        {
                            PersonID = personIDParsed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception without changing the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }
 


            return PersonID;
        }


        //=============================================================
        // Get National Number By Person ID
        //=============================================================

        /// <summary>
        /// Retrieves the national identification number associated with the specified person ID.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to search for.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is the person's
        /// national identification number if found; otherwise, an empty string.
        /// </returns>
        /// <remarks>
        /// Executes a parameterized SELECT query against the People table. Exceptions are logged,

        /// </remarks>
        public static async Task<string> GetNationalNoByPersonIDAsync(
        int PersonID)
        {
            string NationalNo = "";



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT NationalNo
            FROM People
            WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                            NationalNo = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception without changing the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }
    


            return NationalNo;
        }


        //=============================================================
        // Get All People Count
        //=============================================================

        /// <summary>
        /// Retrieves the total number of people stored in the People table.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is the total
        /// number of people, or 0 if an exception occurs.
        /// </returns>
        /// <remarks>
        /// Executes a COUNT aggregate query against the People table. Exceptions are logged,

        /// </remarks>
        public static async Task<int> GetAllPeopleCountAsync()
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT COUNT(*) FROM People";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        Count = Convert.ToInt32(
                            await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception without changing the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }
  


            return Count;
        }


        //=============================================================
        // Get People Count By Gender
        //=============================================================

        /// <summary>
        /// Retrieves the number of people whose stored gender value matches the specified value.
        /// </summary>
        /// <param name="Gendor">The gender value used to filter people records.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is the number of
        /// matching people, or 0 if no count is retrieved or an exception occurs.
        /// </returns>
        /// <remarks>
        /// Executes a parameterized COUNT query against the People table. The gender parameter
        /// is passed to the database, and the result is converted to an integer. Exceptions

        /// </remarks>
        public static async Task<int> GetPeopleCountByGenderAsync(bool Gendor)
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            SELECT COUNT(*)
            FROM People
            WHERE Gendor = @Gendor";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Gendor", Gendor);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Count = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception without changing the existing return behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }
 

            return Count;
        }


        //=============================================================
        // Get People Registered Count Between Dates
        //=============================================================

        /// <summary>
        /// Retrieves the total number of people registered within the specified date range.
        /// The start date is inclusive, and the end date is exclusive after conversion to Date.
        /// </summary>
        /// <param name="StartDate">The starting date of the registration period, inclusive.</param>
        /// <param name="EndDate">The ending date of the registration period, exclusive.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is the number of
        /// people registered within the specified date range, or 0 if an exception occurs.
        /// </returns>
        /// <remarks>
        /// Executes a parameterized COUNT query against the People table using CreatedDateTime.

        /// </remarks>
        public static async Task<int> GetPeopleRegisteredCountBetweenAsync(
            DateTime StartDate, DateTime EndDate)
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
          SELECT COUNT(*)
          FROM People
          WHERE CreatedDateTime >= CAST(@StartDate AS Date)
            AND CreatedDateTime < CAST(@EndDate AS Date)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Count = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception without changing the existing error-handling behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }
            




            return Count;
        }


        //=============================================================
        // Get People Registered Count By Gender Between Dates
        //=============================================================

        /// <summary>
        /// Retrieves the number of people of the specified gender who were registered
        /// within the specified date range.
        /// The start date is inclusive, and the end date is exclusive after conversion to Date.
        /// </summary>
        /// <param name="Gendor">The gender value used to filter the people records.</param>
        /// <param name="StartDate">The starting date of the registration period, inclusive.</param>
        /// <param name="EndDate">The ending date of the registration period, exclusive.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is the number of
        /// matching people, or 0 if an exception occurs.
        /// </returns>
        /// <remarks>
        /// Executes a parameterized COUNT query against the People table, filtering by gender

        /// is released in the finally block.
        /// </remarks>
        public static async Task<int> GetPeopleRegisteredCountBetweenAsync(
            bool Gendor, DateTime StartDate, DateTime EndDate)
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
          SELECT COUNT(*)
          FROM People
          WHERE Gendor = @Gendor
            AND CreatedDateTime >= CAST(@StartDate AS Date)
            AND CreatedDateTime < CAST(@EndDate AS Date)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@Gendor", Gendor);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Count = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception without changing the existing error-handling behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;

            }
   


            return Count;
        }


        //=============================================================
        // Get Created People Count By Date and Time Period
        //=============================================================

        /// <summary>
        /// Retrieves the number of people whose registration timestamps fall within
        /// the specified date and time range.
        /// The start timestamp is inclusive, and the end timestamp is exclusive.
        /// </summary>
        /// <param name="StartDateTime">The starting date and time of the period, inclusive.</param>
        /// <param name="EndDateTime">The ending date and time of the period, exclusive.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is the number of
        /// people created within the specified period, or 0 if an exception occurs.
        /// </returns>
        /// <remarks>
        /// Executes a parameterized COUNT query against the People table using the CreatedDateTime
        /// column without converting the supplied timestamps to dates. Exceptions are logged,

        /// </remarks>
        public static async Task<int> GetCreatedPeopleCountByPeriodAsync(
            DateTime StartDateTime, DateTime EndDateTime)
        {
            int Count = 0;



            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
          SELECT COUNT(*)
          FROM People
          WHERE CreatedDateTime >= @StartDateTime
            AND CreatedDateTime < @EndDateTime";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@StartDateTime", StartDateTime);

                        command.Parameters.AddWithValue(
                            "@EndDateTime", EndDateTime);

                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int parsedInt))
                        {
                            Count = parsedInt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception without changing the existing error-handling behavior.
                clsDataAccessEventLog.LogError(ex, "clsPersonData");
                throw;
            }


            return Count;
        }
    }
}