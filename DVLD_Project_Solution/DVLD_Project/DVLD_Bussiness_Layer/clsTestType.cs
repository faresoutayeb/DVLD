using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Provides business logic for managing test types, including retrieving,
    /// updating, and checking the existence of test types.
    /// </summary>
    public class clsTestType
    {
        /// <summary>
        /// Specifies the operation mode of a test type.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Indicates a newly created test type.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates an existing test type that can be updated.
            /// </summary>
            Update = 1
        }

        /// <summary>
        /// Stores the current operation mode of the test type.
        /// </summary>
        private enMode _Mode = enMode.AddNew;

        /// <summary>
        /// Defines the available driving test types.
        /// </summary>
        public enum enTestType
        {
            /// <summary>
            /// Represents the vision test.
            /// </summary>
            VisionTest = 1,

            /// <summary>
            /// Represents the written test.
            /// </summary>
            WrittenTest = 2,

            /// <summary>
            /// Represents the street test.
            /// </summary>
            StreetTest = 3
        }

        /// <summary>
        /// Gets or sets the unique identifier of the test type.
        /// </summary>
        public enTestType TestTypeID { get; set; }

        /// <summary>
        /// Gets or sets the title of the test type.
        /// </summary>
        public string TestTypeTitle { get; set; }

        /// <summary>
        /// Gets or sets the description of the test type.
        /// </summary>
        public string TestTypeDescription { get; set; }

        /// <summary>
        /// Gets or sets the fees charged for the test type.
        /// </summary>
        [clsValidPositiveNumber("Test Type Fees  must be positive")]

        public float TestTypeFees { get; set; }

        /// <summary>
        /// Initializes a new test type with default values.
        /// The test type is initialized in AddNew mode.
        /// </summary>
        public clsTestType()
        {
            this.TestTypeID = enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;

            _Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing test type with the specified information.
        /// The test type is initialized in Update mode.
        /// </summary>
        /// <param name="TestTypeID">The unique identifier of the test type.</param>
        /// <param name="TestTypeTitle">The title of the test type.</param>
        /// <param name="TestTypeDescription">The description of the test type.</param>
        /// <param name="TestTypeFees">The fees charged for the test type.</param>
        private clsTestType(
            enTestType TestTypeID,
            string TestTypeTitle,
            string TestTypeDescription,
            float TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            _Mode = enMode.Update;
        }

        /// <summary>
        /// Updates the current test type in the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing true
        /// if the update succeeds; otherwise, false.
        /// </returns>
        private Task<bool> _UpdateTestTypeAsync()
        {
            return DVLD_Data_Access_Layer.clsTestTypesData.UpdateTestTypeAsync(
                (int)this.TestTypeID,
                this.TestTypeTitle,
                this.TestTypeDescription,
                this.TestTypeFees
            );
        }

        /// <summary>
        /// Retrieves a test type using its unique identifier.
        /// </summary>
        /// <param name="TestTypeID">The identifier of the test type to retrieve.</param>
        /// <returns>
        /// A task containing the matching test type if found; otherwise, null.
        /// </returns>
        public static async Task<clsTestType> FindTestTypeAsync(
            enTestType TestTypeID)
        {
            clsTestTypesData.stTestTypeInfo Result =
                await DVLD_Data_Access_Layer.clsTestTypesData
                    .GetTestTypeInfoByIDAsync((int)TestTypeID);

            if (Result != null)
            {
                return new clsTestType(
                    (enTestType)Result.TestTypeID,
                    Result.TestTypeTitle,
                    Result.TestTypeDescription,
                    Result.TestTypeFees
                );
            }

            return null;
        }

        public static clsTestType FindTestType(
    enTestType TestTypeID)
        {
            clsTestTypesData.stTestTypeInfo Result =
                 DVLD_Data_Access_Layer.clsTestTypesData
                    .GetTestTypeInfoByID((int)TestTypeID);

            if (Result != null)
            {
                return new clsTestType(
                    (enTestType)Result.TestTypeID,
                    Result.TestTypeTitle,
                    Result.TestTypeDescription,
                    Result.TestTypeFees
                );
            }

            return null;
        }

        /// <summary>
        /// Retrieves a test type using its title.
        /// </summary>
        /// <param name="TestTypeTitle">The title of the test type to retrieve.</param>
        /// <returns>
        /// A task containing the matching test type if found; otherwise, null.
        /// </returns>
        public static async Task<clsTestType> FindTestTypeAsync(
            string TestTypeTitle)
        {
            clsTestTypesData.stTestTypeInfo Result =
                await DVLD_Data_Access_Layer.clsTestTypesData
                    .GetTestTypeInfoByTitleAsync(TestTypeTitle);

            if (Result != null)
            {
                return new clsTestType(
                    (enTestType)Result.TestTypeID,
                    Result.TestTypeTitle,
                    Result.TestTypeDescription,
                    Result.TestTypeFees
                );
            }

            return null;
        }
        public static clsTestType FindTestType(
    string TestTypeTitle)
        {
            clsTestTypesData.stTestTypeInfo Result =
                 DVLD_Data_Access_Layer.clsTestTypesData.GetTestTypeInfoByTitle(TestTypeTitle);

            if (Result != null)
            {
                return new clsTestType(
                    (enTestType)Result.TestTypeID,
                    Result.TestTypeTitle,
                    Result.TestTypeDescription,
                    Result.TestTypeFees
                );
            }

            return null;
        }
        /// <summary>
        /// Saves the current test type according to its operation mode.
        /// Existing test types are updated in the database.
        /// Adding a new test type is not implemented in this method.
        /// </summary>
        /// <returns>
        /// A task containing true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    _Mode = enMode.Update;
                    return false;

                case enMode.Update:
                    return await _UpdateTestTypeAsync();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Retrieves all test types from the database.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with all available test types.
        /// </returns>
        public static Task<DataTable> GetAllTestTypesAsync()
        {
            return DVLD_Data_Access_Layer.clsTestTypesData
                .GetAllTestTypesAsync();
        }

        /// <summary>
        /// Determines whether a test type exists using its identifier.
        /// </summary>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <returns>
        /// A task containing true if the test type exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsTestTypeExistAsync(
            enTestType TestTypeID)
        {
            return DVLD_Data_Access_Layer.clsTestTypesData
                .IsTestTypeExistAsync((int)TestTypeID);
        }

        /// <summary>
        /// Determines whether a test type exists using its title.
        /// </summary>
        /// <param name="TestTypeTitle">The title of the test type.</param>
        /// <returns>
        /// A task containing true if a test type with the specified title
        /// exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsTestTypeExistAsync(
            string TestTypeTitle)
        {
            return DVLD_Data_Access_Layer.clsTestTypesData
                .IsTestTypeExistAsync(TestTypeTitle);
        }

        /// <summary>
        /// Retrieves the total number of test types stored in the database.
        /// </summary>
        /// <returns>
        /// A task containing the total number of test types as a byte.
        /// </returns>
        public static Task<byte> GetTestsTypesCountAsync()
        {
            return DVLD_Data_Access_Layer.clsTestTypesData
                .GetAllTestsTypesCountAsync();
        }
    }
}