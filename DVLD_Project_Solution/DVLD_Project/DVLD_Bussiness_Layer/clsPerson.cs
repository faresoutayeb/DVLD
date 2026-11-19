
using System;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Data_Access_Layer;




namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Represents a person in the DVLD system and provides operations
    /// for managing personal information, retrieving records, and
    /// creating, updating, or deleting person records.
    /// </summary>
    public class clsPerson
    {
        /// <summary>
        /// Specifies whether the person record is new or already exists.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Indicates that a new person record will be created.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates that an existing person record will be updated.
            /// </summary>
            Update = 1
        }

        /// <summary>
        /// Specifies the gender of a person.
        /// </summary>
        public enum enGender
        {
            /// <summary>
            /// Represents the male gender.
            /// </summary>
            Male = 0,

            /// <summary>
            /// Represents the female gender.
            /// </summary>
            Female = 1
        }

        /// <summary>
        /// Gets or sets the current operation mode of the person record.
        /// Defaults to <see cref="enMode.AddNew"/>.
        /// </summary>
        public enMode _Mode = enMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the person.
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// Gets or sets the person's national identification number.
        /// </summary>
        [clsValidNationalNo("National number must contain 5–20 letters or numbers!")]
        public string NationalNo { get; set; }

        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>
        [clsRequired("First name is required!")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the person's second name.
        /// </summary>
        public  string SecondName { get; set; }
        /// <summary>
        /// Gets or sets the person's third name.
        /// </summary>
        public string ThirdName { get; set; }

        /// <summary>
        /// Gets or sets the person's last name.
        /// </summary>
        [clsRequired("Last name is required!")]

        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the person's date of birth.
        /// </summary>
        [clsValidBirthDate("Date of birth is required and cannot be in the future!")]
        [clsValidAge(14, "The person must be at least 18 years old!")]

        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the person's gender.
        /// </summary>
        public enGender Gender { get; set; }

        /// <summary>
        /// Gets or sets the person's residential address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the person's phone number.
        /// </summary>
        [clsValidPhone("Invalid phone number!")]

        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the person's email address.
        /// </summary>
        [clsValidEmail("Invalid email address!")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the person's nationality country.
        /// </summary>
        public int NationalityCountryID { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the person record was created.
        /// </summary>
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Stores the path of the person's image.
        /// </summary>

        /// <summary>
        /// Gets or sets the country information associated with the person's nationality.
        /// </summary>
        public clsCountry CountryInfo
            {
            get
            {
                if(_CountryInfo ==null && NationalityCountryID >0)
                {
                    _CountryInfo = clsCountry.Find(NationalityCountryID);
                }
                return _CountryInfo;
            }
            set
            {
                _CountryInfo = value;
            }
        }
        private clsCountry _CountryInfo;

        

        /// <summary>
        /// Gets or sets the file path of the person's image.
        /// </summary>
        public string ImagePath
        {
            get;
            set ;
        }

        /// <summary>
        /// Gets the person's full name, including the first, second,
        /// third, and last names.
        /// </summary>
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " +
                       ThirdName + " " + LastName;
            }
        }

        /// <summary>
        /// Gets the person's name using only the first and last names.
        /// </summary>
        public string Name
        {
            get { return FirstName + " " + LastName; }
        }

        /// <summary>
        /// Initializes a new person record with default values.
        /// The record is configured for insertion.
        /// </summary>
        public clsPerson()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = enGender.Male;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";
            CreatedDateTime = DateTime.Now;
            _Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing person record with the specified information.
        /// The record is configured for updating.
        /// </summary>
        /// <param name="ID">The unique identifier of the person.</param>
        /// <param name="NationalNo">The person's national identification number.</param>
        /// <param name="FirstName">The person's first name.</param>
        /// <param name="SecondName">The person's second name.</param>
        /// <param name="ThirdName">The person's third name.</param>
        /// <param name="LastName">The person's last name.</param>
        /// <param name="DateOfBirth">The person's date of birth.</param>
        /// <param name="Gender">The person's gender.</param>
        /// <param name="Address">The person's residential address.</param>
        /// <param name="Phone">The person's phone number.</param>
        /// <param name="Email">The person's email address.</param>
        /// <param name="NationalityCountryID">The nationality country identifier.</param>
        /// <param name="ImagePath">The path of the person's image.</param>
        /// <param name="CreatedDateTime">The date and time the record was created.</param>
        /// <param name="CountryInfo">The country information associated with the person.</param>
        private clsPerson(
            int ID,
            string NationalNo,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            DateTime DateOfBirth,
            enGender Gender,
            string Address,
            string Phone,
            string Email,
            int NationalityCountryID,
            string ImagePath,
            DateTime CreatedDateTime
            )
        {
            PersonID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CreatedDateTime = CreatedDateTime;

            _Mode = enMode.Update;
        }



        /// <summary>
        /// Inserts a new person record into the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is <see langword="true"/> if the record is created successfully;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        private async Task<bool> _AddNewPersonAsync()
        {
            this.PersonID = await clsPersonData.AddNewPersonAsync(
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                DateOfBirth,
                Convert.ToBoolean(Gender),
                Address,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath);

            return (this.PersonID != -1);
        }

        /// <summary>
        /// Updates an existing person record in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// indicates whether the update succeeded.
        /// </returns>
        private Task<bool> _UpdatePersonAsync()
        {
            return clsPersonData.UpdatePersonAsync(
                PersonID,
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                DateOfBirth,
                Convert.ToBoolean(Gender),
                Address,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath);
        }

        /// <summary>
        /// Retrieves a person record using its unique identifier.
        /// </summary>
        /// <param name="PersonID">The identifier of the person to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// contains the matching <see cref="clsPerson"/> object, or
        /// <see langword="null"/> if the person does not exist.
        /// </returns>
        public static async Task<clsPerson> FindAsync(int PersonID)
        {
            clsPersonData.clsPersonInfo Result =  await clsPersonData.GetPersonInfoByIDAsync(PersonID);

            if (Result ==null)
                return null;

  
            return new clsPerson(
                PersonID,
                Result.NationalNo,
                Result.FirstName,
                Result.SecondName,
                Result.ThirdName,
                Result.LastName,
                Result.DateOfBirth,
                Result.Gendor ? enGender.Female : enGender.Male,
                Result.Address,
                Result.Phone,
                Result.Email,
                Result.NationalityCountryID,
                Result.ImagePath,
                Result.CreatedDateTime
                );
        }

        public static clsPerson Find(int PersonID)
        {
            clsPersonData.clsPersonInfo Result =  clsPersonData.GetPersonInfoByID(PersonID);

            if (Result == null)
                return null;


            return new clsPerson(
                PersonID,
                Result.NationalNo,
                Result.FirstName,
                Result.SecondName,
                Result.ThirdName,
                Result.LastName,
                Result.DateOfBirth,
                Result.Gendor ? enGender.Female : enGender.Male,
                Result.Address,
                Result.Phone,
                Result.Email,
                Result.NationalityCountryID,
                Result.ImagePath,
                Result.CreatedDateTime
                );
        }



        /// <summary>
        /// Retrieves a person record using their national identification number.
        /// </summary>
        /// <param name="NationalNo">The national identification number to search for.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// contains the matching <see cref="clsPerson"/> object, or
        /// <see langword="null"/> if the person does not exist.
        /// </returns>
        public static async Task<clsPerson> FindAsync(string NationalNo)
        {
            clsPersonData.clsPersonInfo Result =
                await clsPersonData.GetPersonInfoByNationalNoAsync(NationalNo);

            if (Result ==null)
                return null;


            return new clsPerson(
                Result.PersonID,
                NationalNo,
                Result.FirstName,
                Result.SecondName,
                Result.ThirdName,
                Result.LastName,
                Result.DateOfBirth,
                Result.Gendor ? enGender.Female : enGender.Male,
                Result.Address,
                Result.Phone,
                Result.Email,
                Result.NationalityCountryID,
                Result.ImagePath,
                Result.CreatedDateTime
                );
        }

        public static clsPerson Find(string NationalNo)
        {
            clsPersonData.clsPersonInfo Result =
                 clsPersonData.GetPersonInfoByNationalNo(NationalNo);

            if (Result ==null)
                return null;


            return new clsPerson(
                Result.PersonID,
                NationalNo,
                Result.FirstName,
                Result.SecondName,
                Result.ThirdName,
                Result.LastName,
                Result.DateOfBirth,
                Result.Gendor ? enGender.Female : enGender.Male,
                Result.Address,
                Result.Phone,
                Result.Email,
                Result.NationalityCountryID,
                Result.ImagePath,
                Result.CreatedDateTime
                );
        }


        /// <summary>
        /// Saves the current person record.
        /// Inserts a new record when the mode is <see cref="enMode.AddNew"/>,
        /// or updates an existing record when the mode is
        /// <see cref="enMode.Update"/>.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is <see langword="true"/> if the operation succeeds; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewPersonAsync())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:
                    return await _UpdatePersonAsync();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Retrieves all person records from the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is a <see cref="DataTable"/> containing the person records.
        /// </returns>
        public static Task<DataTable> GetAllPeopleAsync()
        {
            return clsPersonData.GetAllPeopleAsync();
        }

        /// <summary>
        /// Deletes a person record using its unique identifier.
        /// </summary>
        /// <param name="ID">The identifier of the person to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// indicates whether the deletion succeeded.
        /// </returns>
        public static Task<bool> DeletePersonAsync(int ID)
        {
            return clsPersonData.DeletePersonAsync(ID);
        }

        /// <summary>
        /// Deletes a person record using their national identification number.
        /// </summary>
        /// <param name="NationalNo">The national identification number of the person to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// indicates whether the deletion succeeded.
        /// </returns>
        public static Task<bool> DeletePersonAsync(string NationalNo)
        {
            return clsPersonData.DeletePersonAsync(NationalNo);
        }

        /// <summary>
        /// Checks whether a person record exists with the specified identifier.
        /// </summary>
        /// <param name="PersonID">The identifier of the person to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is <see langword="true"/> if the person exists; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsPersonExistAsync(int PersonID)
        {
            return clsPersonData.IsPersonExistAsync(PersonID);
        }

        /// <summary>
        /// Checks whether a person record exists with the specified national number.
        /// </summary>
        /// <param name="NationalNo">The national identification number to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is <see langword="true"/> if the person exists; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsPersonExistAsync(string NationalNo)
        {
            return clsPersonData.IsPersonExistAsync(NationalNo);
        }

        /// <summary>
        /// Checks whether the specified image path is associated with another person.
        /// </summary>
        /// <param name="ImagePath">The image path to check.</param>
        /// <param name="PersonID">
        /// The identifier of the person to exclude from the check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result
        /// is <see langword="true"/> if another person uses the image path;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsImageBelongToOtherPersonAsync(
            string ImagePath,
            int PersonID)
        {
            return clsPersonData.IsImageBelongToOtherPersonAsync(
                ImagePath,
                PersonID);
        }


        /// <summary>
        /// Retrieves the person ID associated with the specified national number.
        /// </summary>
        /// <param name="NationalNo">The national number of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the person's ID.
        /// </returns>
        public static Task<int> GetPersonIDAsync(string NationalNo)
        {
            return clsPersonData.GetPersonIDByNationalNoAsync(NationalNo);
        }

        /// <summary>
        /// Retrieves the national number associated with the specified person ID.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the person's national number.
        /// </returns>
        public static Task<string> GetNationalNoAsync(int PersonID)
        {
            return clsPersonData.GetNationalNoByPersonIDAsync(PersonID);
        }

        /// <summary>
        /// Retrieves the total number of people registered in the system.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total number of people.
        /// </returns>
        public static Task<int> GetAllPeopleCountAsync()
        {
            return clsPersonData.GetAllPeopleCountAsync();
        }

        /// <summary>
        /// Retrieves the number of people registered within the specified date range.
        /// </summary>
        /// <param name="StartDate">The beginning of the registration date range.</param>
        /// <param name="EndDate">The end of the registration date range.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number of registered people.
        /// </returns>
        public static Task<int> GetPeopleRegisteredCountBetweenAsync(
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsPersonData.GetPeopleRegisteredCountBetweenAsync(
                StartDate,
                EndDate);
        }

        /// <summary>
        /// Retrieves the number of people of the specified gender registered within the given date range.
        /// </summary>
        /// <param name="Gender">The gender used to filter registered people.</param>
        /// <param name="StartDate">The beginning of the registration date range.</param>
        /// <param name="EndDate">The end of the registration date range.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number of people matching the specified criteria.
        /// </returns>
        public static Task<int> GetPeopleRegisteredCountBetweenAsync(
            enGender Gender,
            DateTime StartDate,
            DateTime EndDate)
        {
            return clsPersonData.GetPeopleRegisteredCountBetweenAsync(
                Gender == enGender.Female,
                StartDate,
                EndDate);
        }

        /// <summary>
        /// Retrieves the number of people registered today.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing today's registration count.
        /// </returns>
        public static Task<int> GetPeopleRegisteredTodayCountAsync()
        {
            DateTime Start = DateTime.Today;

            return GetPeopleRegisteredCountBetweenAsync(
                Start,
                Start.AddDays(1));
        }

        /// <summary>
        /// Retrieves the number of people registered during the current month.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the current month's registration count.
        /// </returns>
        public static Task<int> GetPeopleRegisteredThisMonthCountAsync()
        {
            DateTime Start = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                1);

            return GetPeopleRegisteredCountBetweenAsync(
                Start,
                Start.AddMonths(1));
        }

        /// <summary>
        /// Retrieves the number of people registered from the beginning of the current year until now.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the current year's registration count.
        /// </returns>
        public static Task<int> GetPeopleRegisteredThisYearCountAsync()
        {
            DateTime Start = new DateTime(DateTime.Now.Year, 1, 1);

            return GetPeopleRegisteredCountBetweenAsync(
                Start,
                DateTime.Now);
        }

        /// <summary>
        /// Retrieves the number of people created within the specified date and time range.
        /// </summary>
        /// <param name="StartDateTime">The beginning of the date and time range.</param>
        /// <param name="EndDateTime">The end of the date and time range.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number of people created during the specified period.
        /// </returns>
        public static Task<int> GetPeopleCountByPeriodAsync(
            DateTime StartDateTime,
            DateTime EndDateTime)
        {
            return clsPersonData.GetCreatedPeopleCountByPeriodAsync(
                StartDateTime,
                EndDateTime);
        }

        /// <summary>
        /// Retrieves the total number of people belonging to the specified gender.
        /// </summary>
        /// <param name="Gender">The gender used to filter people.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number of people of the specified gender.
        /// </returns>
        public static Task<int> GetPeopleCountByGenderAsync(
            enGender Gender)
        {
            return clsPersonData.GetPeopleCountByGenderAsync(
                Gender == enGender.Female);
        }
    }
}