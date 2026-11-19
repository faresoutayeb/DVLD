
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Represents a test taken by an applicant as part of the driving license
    /// application process. Provides functionality for retrieving, adding,
    /// updating, and saving test records.
    /// </summary>
    public class clsTest
    {
        /// <summary>
        /// Specifies whether the test object represents a new or existing record.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Indicates that a new test record will be created.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates that an existing test record will be updated.
            /// </summary>
            Update = 1
        };

        /// <summary>
        /// Gets or sets the current operating mode of the test object.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the test.
        /// </summary>
        public int TestID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the test appointment associated with this test.
        /// </summary>
        public int TestAppointmentID { get; set; }

        /// <summary>
        /// Gets or sets the result of the test.
        /// True indicates that the applicant passed; otherwise, false.
        /// </summary>
        public bool TestResult { get; set; }

        /// <summary>
        /// Gets or sets additional notes or remarks about the test.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the test record.
        /// </summary>
        public int CreatedByUserID { get; set; }

        private clsTestAppointment _TestAppointments;
        private clsUser _UserInfo;

        /// <summary>
        /// Gets or sets the information of the test appointment associated with this test.
        /// The appointment information is loaded when first accessed if it has not
        /// already been loaded and the appointment ID is valid.
        /// </summary>
        public clsTestAppointment TestAppointmentInfo
        {
            get
            {
                if (_TestAppointments == null && TestAppointmentID > 0)
                    _TestAppointments = clsTestAppointment.Find(TestAppointmentID);

                return _TestAppointments;
            }
            private set
            {
                _TestAppointments = value;
            }
        }

        /// <summary>
        /// Gets or sets the information of the user who created this test.
        /// The user information is loaded when first accessed if it has not
        /// already been loaded and the user ID is valid.
        /// </summary>
        public clsUser UserInfo
        {
            get
            {
                if (_UserInfo == null && CreatedByUserID > 0)
                    _UserInfo = clsUser.FindByUserID(CreatedByUserID);

                return _UserInfo;
            }
            private set
            {
                _UserInfo = value;
            }
        }

        /// <summary>
        /// Initializes a new test object with default values.
        /// Sets the test ID, appointment ID, and creator ID to -1,
        /// the test result to false, and notes to an empty string.
        /// The object is initialized in AddNew mode.
        /// </summary>
        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
            TestAppointmentInfo = null;
            UserInfo = null;
            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes a test object with the specified existing test information.
        /// Sets the object to Update mode.
        /// </summary>
        /// <param name="TestID">The unique identifier of the test.</param>
        /// <param name="TestAppointmentID">The identifier of the associated test appointment.</param>
        /// <param name="TestResult">The result of the test.</param>
        /// <param name="Notes">Additional notes or remarks about the test.</param>
        /// <param name="CreatedByUserID">The identifier of the user who created the test.</param>
        private clsTest(
            int TestID,
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }

        /// <summary>
        /// Retrieves the latest test for a person, license class, and test type.
        /// </summary>
        /// <param name="PersonID">The identifier of the applicant.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <param name="TestTypeID">The type of test to retrieve.</param>
        /// <returns>
        /// A task containing the latest matching test if found; otherwise, null.
        /// </returns>
        public static async Task<clsTest> FindLastTestPerPersonAndLicenseClassAsync(
            int PersonID,
            int LicenseClassID,
            clsTestType.enTestType TestTypeID)
        {
            clsTestData.clsTestInfo Result =
                await clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClassAsync(
                    PersonID,
                    LicenseClassID,
                    (int)TestTypeID);

            if (Result != null)
            {
                return new clsTest(
                    Result.TestID,
                    Result.TestAppointmentID,
                    Result.TestResult,
                    Result.Notes,
                    Result.CreatedByUserID);
            }

            return null;
        }

        public static clsTest  FindLastTestPerPersonAndLicenseClass(
          int PersonID,
          int LicenseClassID,
          clsTestType.enTestType TestTypeID)
        {
            clsTestData.clsTestInfo Result =
                 clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass(
                    PersonID,
                    LicenseClassID,
                    (int)TestTypeID);

            if (Result != null)
            {
                return new clsTest(
                    Result.TestID,
                    Result.TestAppointmentID,
                    Result.TestResult,
                    Result.Notes,
                    Result.CreatedByUserID);
            }

            return null;
        }

        /// <summary>
        /// Adds a new test record to the database using the current object's values.
        /// Updates TestID with the generated identifier when the operation succeeds.
        /// </summary>
        /// <returns>
        /// A task containing true if the test is added successfully; otherwise, false.
        /// </returns>
        private async Task<bool> _AddNewTestAsync()
        {
            this.TestID = await clsTestData.AddNewTestAsync(
                this.TestAppointmentID,
                this.TestResult,
                this.Notes,
                this.CreatedByUserID);

            return this.TestID != -1;
        }

        /// <summary>
        /// Updates the existing test record in the database using the current object's values.
        /// </summary>
        /// <returns>
        /// A task containing true if the test is updated successfully; otherwise, false.
        /// </returns>
        private async Task<bool> _UpdateTestAsync()
        {
            return await clsTestData.UpdateTestAsync(
                this.TestID,
                this.TestAppointmentID,
                this.TestResult,
                this.Notes,
                this.CreatedByUserID);
        }

        /// <summary>
        /// Retrieves a test record using its unique test ID.
        /// </summary>
        /// <param name="TestID">The identifier of the test to retrieve.</param>
        /// <returns>
        /// A task containing the test if found; otherwise, null.
        /// </returns>
        public static async Task<clsTest> FindByTestIDAsync(int TestID)
        {
            clsTestData.clsTestInfo Result =
                await clsTestData.GetTestInfoByIDAsync(TestID);

            if (Result !=null)
            {
                return new clsTest(
                    TestID,
                    Result.TestAppointmentID,
                    Result.TestResult,
                    Result.Notes,
                    Result.CreatedByUserID);
            }

            return null;
        }

        /// <summary>
        /// Retrieves a test record associated with the specified test appointment.
        /// </summary>
        /// <param name="TestAppointmentID">The identifier of the test appointment.</param>
        /// <returns>
        /// A task containing the associated test if found; otherwise, null.
        /// </returns>
        public static async Task<clsTest> FindByTestAppointmentIDAsync(
            int TestAppointmentID)
        {
            clsTestData.clsTestInfo Result =
                await clsTestData.GetTestByTestAppointmentIDAsync(TestAppointmentID);

            if (Result != null)
            {
                return new clsTest(
                    Result.TestID,
                    Result.TestAppointmentID,
                    Result.TestResult,
                    Result.Notes,
                    Result.CreatedByUserID);
            }

            return null;
        }

        /// <summary>
        /// Saves the current test object to the database.
        /// Adds a new record when the object is in AddNew mode or updates an
        /// existing record when the object is in Update mode.
        /// After a successful insertion, changes the mode to Update.
        /// </summary>
        /// <returns>
        /// A task containing true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewTestAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:
                    return await _UpdateTestAsync();

                default:
                    return false;
            }
        }


        /// <summary>
        /// Retrieves all tests from the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with all test records.
        /// </returns>
        public static Task<DataTable> GetAllTestsAsync()
        {
            return clsTestData.GetAllTestsAsync();
        }

        /// <summary>
        /// Deletes a test using its unique identifier.
        /// </summary>
        /// <param name="TestID">The unique identifier of the test to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the test was deleted successfully; otherwise, false.
        /// </returns>
        public static Task<bool> DeleteTestAsync(int TestID)
        {
            return clsTestData.DeleteTestAsync(TestID);
        }

        /// <summary>
        /// Deletes all tests associated with a local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The unique identifier of the local driving license application.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the deletion succeeded; otherwise, false.
        /// </returns>
        public static Task<bool> DeleteTestsAsync(
            int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.DeleteTestsAsync(
                LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Determines whether a test exists using its unique identifier.
        /// </summary>
        /// <param name="TestID">The unique identifier of the test.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the test exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsTestExistAsync(int TestID)
        {
            return clsTestData.IsTestExistAsync(TestID);
        }

        /// <summary>
        /// Determines whether a test exists for a specific test appointment.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// a test exists for the specified appointment; otherwise, false.
        /// </returns>
        public static Task<bool> IsTestExistByAppointmentAsync(
            int TestAppointmentID)
        {
            return clsTestData.IsTestExistByTestAppointmentIDAsync(
                TestAppointmentID);
        }

        /// <summary>
        /// Determines whether a person has any test records.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the person has at least one test record; otherwise, false.
        /// </returns>
        public static Task<bool> IsPersonHasTestBeforeAsync(int PersonID)
        {
            return clsTestData.IsTestExistByPersonIDAsync(PersonID);
        }

        /// <summary>
        /// Determines whether a person has a test record for a specific test
        /// type and license class.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person.</param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// a matching test record exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsPersonHasTestBeforeAsync(
            int PersonID,
            int TestTypeID,
            int LicenseClassID)
        {
            return clsTestData
                .IsTestExistByPersonIDAndTestTypeIDAndLicenseClassIDAsync(
                    PersonID,
                    TestTypeID,
                    LicenseClassID);
        }

        /// <summary>
        /// Retrieves the latest test record associated with a person.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// latest <see cref="clsTest"/> if found; otherwise, null.
        /// </returns>
        public static async Task<clsTest> FindLatestTestInfoAsync(int PersonID)
        {
            clsTestData.clsTestInfo Result =
                await clsTestData.GetLatestTestInfoByPersonIDAsync(PersonID);

            if (Result != null)
            {
                return new clsTest(
                    Result.TestID,
                    Result.TestAppointmentID,
                    Result.TestResult,
                    Result.Notes,
                    Result.CreatedByUserID);
            }

            return null;
        }

        /// <summary>
        /// Retrieves the latest test record associated with a national number.
        /// </summary>
        /// <param name="NationalNo">The national identification number of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// latest <see cref="clsTest"/> if found; otherwise, null.
        /// </returns>
        public static async Task<clsTest> FindLatestTestInfoAsync(string NationalNo)
        {
            clsTestData.clsTestInfo Result =
                await DVLD_Data_Access_Layer.clsTestData
                    .GetLatestTestInfoByNationalNoAsync(NationalNo);

            if (Result != null)
            {
                return new clsTest(
                    Result.TestID,
                    Result.TestAppointmentID,
                    Result.TestResult,
                    Result.Notes,
                    Result.CreatedByUserID);
            }

            return null;
        }

        /// <summary>
        /// Retrieves the latest test record for a person identified by their
        /// national number, filtered by test type and license class.
        /// </summary>
        /// <param name="NationalNo">The national identification number of the person.</param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// latest matching <see cref="clsTest"/> if found; otherwise, null.
        /// </returns>
        public static async Task<clsTest> FindLatestTestInfoAsync(
            string NationalNo,
            int TestTypeID,
            int LicenseClassID)
        {
            clsTestData.clsTestInfo Result =
                await DVLD_Data_Access_Layer.clsTestData
                    .GetLatestTestInfoByNationalNoAndTestTypeIDAndLicenseClassIDAsync(
                        NationalNo,
                        TestTypeID,
                        LicenseClassID);

            if (Result != null)
            {
                return new clsTest(
                    Result.TestID,
                    Result.TestAppointmentID,
                    Result.TestResult,
                    Result.Notes,
                    Result.CreatedByUserID);
            }

            return null;
        }

        /// <summary>
        /// Retrieves the latest test record for a person identified by their
        /// person ID, filtered by test type and license class.
        /// </summary>
        /// <param name="PersonId">The unique identifier of the person.</param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// latest matching <see cref="clsTest"/> if found; otherwise, null.
        /// </returns>
        public static async Task<clsTest> FindLatestTestInfoAsync(
            int PersonId,
            int TestTypeID,
            int LicenseClassID)
        {
            clsTestData.clsTestInfo Result =
                await DVLD_Data_Access_Layer.clsTestData
                    .GetLatestTestInfoByPersonIDAndTestTypeIDAndLicenseClassIDAsync(
                        PersonId,
                        TestTypeID,
                        LicenseClassID);

            if (Result != null)
            {
                return new clsTest(
                    Result.TestID,
                    Result.TestAppointmentID,
                    Result.TestResult,
                    Result.Notes,
                    Result.CreatedByUserID);
            }

            return null;
        }

        /// <summary>
        /// Determines whether a person passed their latest test for a specific
        /// test type and license class.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person.</param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the latest matching test was passed; otherwise, false.
        /// </returns>
        public static async Task<bool> IsPassInLatestTestAsync(
            int PersonID,
            int TestTypeID,
            int LicenseClassID)
        {
            clsTest Test = await FindLatestTestInfoAsync(
                PersonID,
                TestTypeID,
                LicenseClassID);

            return Test.TestResult;
        }

        /// <summary>
        /// Determines whether a person identified by their national number
        /// passed their latest test for a specific test type and license class.
        /// </summary>
        /// <param name="NationalNo">The national identification number of the person.</param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the latest matching test was passed; otherwise, false.
        /// </returns>
        public static async Task<bool> IsPassInLatestTestAsync(
            string NationalNo,
            int TestTypeID,
            int LicenseClassID)
        {
            clsTest Test = await FindLatestTestInfoAsync(
                NationalNo,
                TestTypeID,
                LicenseClassID);

            return Test.TestResult;
        }

        /// <summary>
        /// Determines whether a person passed their latest recorded test.
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the latest test was passed; otherwise, false.
        /// </returns>
        public static async Task<bool> IsPassInLatestTestAsync(int PersonID)
        {
            clsTest Test = await FindLatestTestInfoAsync(PersonID);

            return Test.TestResult;
        }

        /// <summary>
        /// Counts the test trials associated with a person identified by their
        /// national number.
        /// </summary>
        /// <param name="NationalNo">The national identification number of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of test trials.
        /// </returns>
        public static Task<int> CountTestTrialsAsync(string NationalNo)
        {
            return DVLD_Data_Access_Layer.clsTestData
                .CountTestTrialsByNationalNoAsync(NationalNo);
        }

        /// <summary>
        /// Determines whether a local driving license application has passed
        /// all three required tests.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The unique identifier of the local driving license application.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the application has passed all three required tests; otherwise, false.
        /// </returns>
        public static async Task<bool> IsPassedAllTestsAsync(
            int LocalDrivingLicenseApplicationID)
        {
            return await GetPassedTestsCountAsync(
                LocalDrivingLicenseApplicationID) == 3;
        }

        /// <summary>
        /// Retrieves the number of tests passed for a local driving license
        /// application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The unique identifier of the local driving license application.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of tests passed by the applicant.
        /// </returns>
        public static async Task<byte> GetPassedTestsCountAsync(
            int LocalDrivingLicenseApplicationID)
        {
            return await clsTestData.GetPassedTestCountAsync(
                LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Retrieves the total number of test records in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of test records.
        /// </returns>
        public static Task<int> GetAllTestsCountAsync()
        {
            return clsTestData.GetAllTestsCountAsync();
        }
    }
}