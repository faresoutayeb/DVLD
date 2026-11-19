using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Bussiness_Layer.GlobalClasses;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_Bussiness_Layer
{

    /// <summary>
    /// Represents a local driving license application in the DVLD system.
    /// Inherits from clsApplication and manages the relationship between
    /// a general application and its requested license class.
    /// Provides functionality to create, retrieve, update, and delete
    /// local driving license applications.
    /// </summary>
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        /// <summary>
        /// Specifies the operation mode of a local driving license application.
        /// </summary>
        public enum enLocalDrivingLicenseApplicationMode
        {
            /// <summary>
            /// Indicates that the application is new and has not been saved.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates that the application already exists in the database.
            /// </summary>
            Update = 1
        };

        /// <summary>
        /// Gets or sets the current operation mode of the local driving
        /// license application. The default value is AddNew.
        /// </summary>
        public enLocalDrivingLicenseApplicationMode LocalDrivingLicenseApplicationMode =
            enLocalDrivingLicenseApplicationMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the local driving
        /// license application.
        /// </summary>
        public int LocalDrivingLicenseApplicationID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the requested license class.
        /// </summary>
        public int LicenseClassID { get; set; }

        /// <summary>
        /// Stores the loaded license class information to avoid
        /// retrieving it repeatedly from the database.
        /// </summary>
        private clsLicenseClass _LicenseClassInfo;

        /// <summary>
        /// Gets or sets the license class information associated with
        /// this local driving license application.
        /// Loads the information when accessed for the first time.
        /// </summary>
        public clsLicenseClass LicenseClassInfo
        {
            get
            {
                if (_LicenseClassInfo == null && LicenseClassID > 0)
                    _LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);

                return _LicenseClassInfo;
            }
            private set
            {
                _LicenseClassInfo = value;
            }
        }

        /// <summary>
        /// Initializes a new local driving license application with default values.
        /// Sets the application identifiers to -1 and the operation mode to AddNew.
        /// </summary>
        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            LicenseClassInfo = null;
            LocalDrivingLicenseApplicationMode =
                enLocalDrivingLicenseApplicationMode.AddNew;
            clsValidation.OnValidationError += _WhenLicenseObjectNotValid;

        }

        /// <summary>
        /// Initializes an existing local driving license application with
        /// its application details and requested license class.
        /// Sets the operation mode to Update.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The unique identifier of the local driving license application.
        /// </param>
        /// <param name="ApplicationID">
        /// The identifier of the associated base application.
        /// </param>
        /// <param name="ApplicantPersonID">
        /// The identifier of the person submitting the application.
        /// </param>
        /// <param name="ApplicationDate">
        /// The date the application was submitted.
        /// </param>
        /// <param name="ApplicationTypeID">
        /// The identifier of the application type.
        /// </param>
        /// <param name="ApplicationStatus">
        /// The current status of the application.
        /// </param>
        /// <param name="LastStatusDate">
        /// The date the application status was last updated.
        /// </param>
        /// <param name="PaidFees">
        /// The fees paid for the application.
        /// </param>
        /// <param name="CreatedByUserID">
        /// The identifier of the user who created the application.
        /// </param>
        /// <param name="LicenseClassID">
        /// The identifier of the requested license class.
        /// </param>
        private clsLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate,
            float PaidFees,
            int CreatedByUserID,
            int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;

            LocalDrivingLicenseApplicationMode =
                enLocalDrivingLicenseApplicationMode.Update;
            clsValidation.OnValidationError += _WhenLicenseObjectNotValid;

        }

        /// <summary>
        /// Adds a new local driving license application record to the database.
        /// Updates LocalDrivingLicenseApplicationID with the generated identifier.
        /// </summary>
        /// <returns>
        /// A task containing true if the record is added successfully;
        /// otherwise, false.
        /// </returns>
        private async Task<bool> _AddNewLocalDrivingLicenseApplicationAsync()
        {
            this.LocalDrivingLicenseApplicationID =
                await DVLD_Data_Access_Layer.clsLocalDrivingLicenseApplicationData
                    .AddNewLocalDrivingLicenseApplicationAsync(
                        this.ApplicationID,
                        this.LicenseClassID);

            return this.LocalDrivingLicenseApplicationID != -1;
        }

        /// <summary>
        /// Updates an existing local driving license application in the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the update succeeds; otherwise, false.
        /// </returns>
        private Task<bool> _UpdateLocalDrivingLicenseApplicationAsync()
        {
            return DVLD_Data_Access_Layer.clsLocalDrivingLicenseApplicationData
                .UpdateLocalDrivingLicenseApplicationAsync(
                    this.LocalDrivingLicenseApplicationID,
                    this.ApplicationID,
                    this.LicenseClassID);
        }

        /// <summary>
        /// Retrieves a local driving license application using its unique identifier.
        /// Also retrieves the associated base application information.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application to retrieve.
        /// </param>
        /// <returns>
        /// A task containing the matching application if found; otherwise, null.
        /// </returns>
        public static async Task<clsLocalDrivingLicenseApplication>
            FindByLocalAppIDAsync(
                int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplicationData
                .clsLocalDrivingLicenseApplicationInfo Result =
                await clsLocalDrivingLicenseApplicationData
                    .GetLocalDrivingLicenseApplicationInfoByIDAsync(
                        LocalDrivingLicenseApplicationID);

            if (Result != null)
            {
                clsApplication Application =  await clsApplication.FindApplicationAsync(Result.ApplicationID);
                if (Application != null)
                {
                    return new clsLocalDrivingLicenseApplication(
                        LocalDrivingLicenseApplicationID,
                        Application.ApplicationID,
                        Application.ApplicantPersonID,
                        Application.ApplicationDate,
                        Application.ApplicationTypeID,
                        (enApplicationStatus)Application.ApplicationStatus,
                        Application.LastStatusDate,
                        Application.PaidFees,
                        Application.CreatedByUserID,
                        Result.LicenseClassID);
                }
                else
                    return null;

            }

            return null;
        }


        public static clsLocalDrivingLicenseApplication
    FindByLocalDrivingLicenseAppID(
        int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplicationData
                .clsLocalDrivingLicenseApplicationInfo Result =
                 clsLocalDrivingLicenseApplicationData
                    .GetLocalDrivingLicenseApplicationInfoByID(
                        LocalDrivingLicenseApplicationID);

            if (Result != null)
            {
                clsApplication Application =
                     clsApplication.FindApplication(Result.ApplicationID);

                return new clsLocalDrivingLicenseApplication(
                    LocalDrivingLicenseApplicationID,
                    Application.ApplicationID,
                    Application.ApplicantPersonID,
                    Application.ApplicationDate,
                    Application.ApplicationTypeID,
                    (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID,
                    Result.LicenseClassID);
            }

            return null;
        }


        /// <summary>
        /// Retrieves a local driving license application using its base
        /// application identifier.
        /// </summary>
        /// <param name="ApplicationID">
        /// The identifier of the associated base application.
        /// </param>
        /// <returns>
        /// A task containing the matching local driving license application
        /// if found; otherwise, null.
        /// </returns>
        public static async Task<clsLocalDrivingLicenseApplication>
            FindByApplicationIDAsync(int ApplicationID)
        {
            clsLocalDrivingLicenseApplicationData
                .clsLocalDrivingLicenseApplicationInfo Result =
                await clsLocalDrivingLicenseApplicationData
                    .GetLocalDrivingLicenseApplicationInfoByApplicationIDAsync(
                        ApplicationID);

            if (Result != null)
            {
                clsApplication Application =
                    await clsApplication.FindApplicationAsync(Result.ApplicationID);

                return new clsLocalDrivingLicenseApplication(
                    Result.LocalDrivingLicenseApplicationID,
                    Application.ApplicationID,
                    Application.ApplicantPersonID,
                    Application.ApplicationDate,
                    Application.ApplicationTypeID,
                    (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID,
                    Result.LicenseClassID);
            }

            return null;
        }


        public static clsLocalDrivingLicenseApplication
    FindByApplicationID(int ApplicationID)
        {
            clsLocalDrivingLicenseApplicationData
                .clsLocalDrivingLicenseApplicationInfo Result =
                 clsLocalDrivingLicenseApplicationData
                    .GetLocalDrivingLicenseApplicationInfoByApplicationID(
                        ApplicationID);

            if (Result != null)
            {
                clsApplication Application =
                     clsApplication.FindApplication(Result.ApplicationID);

                return new clsLocalDrivingLicenseApplication(
                    Result.LocalDrivingLicenseApplicationID,
                    Application.ApplicationID,
                    Application.ApplicantPersonID,
                    Application.ApplicationDate,
                    Application.ApplicationTypeID,
                    (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID,
                    Result.LicenseClassID);
            }

            return null;
        }




        /// <summary>
        /// Deletes a local driving license application record using its identifier.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application to delete.
        /// </param>
        /// <returns>
        /// A task containing true if the deletion succeeds; otherwise, false.
        /// </returns>
        public static Task<bool> DeleteLocalDrivingLicenseApplicationsAsync(
            int LocalDrivingLicenseApplicationID)
        {
            return DVLD_Data_Access_Layer.clsLocalDrivingLicenseApplicationData
                .DeleteLocalDrivingLicenseApplicationAsync(
                    LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Saves the local driving license application.
        /// First saves the inherited base application, then adds or updates
        /// the local driving license application record according to its mode.
        /// </summary>
        /// <returns>
        /// A task containing true if both required save operations succeed;
        /// otherwise, false.
        /// </returns>
        public async Task<bool> SaveLocalDrivingAppAsync()
        {
            base.Mode = (clsApplication.enMode)LocalDrivingLicenseApplicationMode;

            if (!await base.SaveAsync())
                return false;

            switch (LocalDrivingLicenseApplicationMode)
            {
                case enLocalDrivingLicenseApplicationMode.AddNew:
                    if (await _AddNewLocalDrivingLicenseApplicationAsync())
                    {
                        LocalDrivingLicenseApplicationMode =
                            enLocalDrivingLicenseApplicationMode.Update;

                        return true;
                    }

                    return false;

                case enLocalDrivingLicenseApplicationMode.Update:
                    return await _UpdateLocalDrivingLicenseApplicationAsync();
            }

            return false;
        }

        /// <summary>
        /// Retrieves all local driving license applications from the database.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with all local driving license applications.
        /// </returns>
        public static Task<DataTable> GetAllLocalDrivingLicenseApplicationsAsync()
        {
            return DVLD_Data_Access_Layer.clsLocalDrivingLicenseApplicationData
                .GetAllLocalDrivingLicenseApplicationsAsync();
        }

        /// <summary>
        /// Retrieves local driving license applications using the data
        /// prepared for the application management view.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with the application view records.
        /// </returns>
        public static Task<DataTable> GetAllLocalDrivingLicenseApplicationsViewAsync()
        {
            return DVLD_Data_Access_Layer.clsLocalDrivingLicenseApplicationData
                .GetAllLocalDrivingLicenseApplicationViewAsync();
        }

        /// <summary>
        /// Deletes the current local driving license application and its
        /// associated base application.
        /// </summary>
        /// <returns>
        /// A task containing true if both deletion operations succeed;
        /// otherwise, false.
        /// </returns>
        public async Task<bool> DeleteLocalApplAsync()
        {
            return await clsLocalDrivingLicenseApplicationData
                       .DeleteLocalDrivingLicenseApplicationAsync(  this.LocalDrivingLicenseApplicationID) && await base.DeleteAsync();
        }

        /// <summary>
        /// Determines whether a local driving license application exists.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The ID of the local driving license application.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the
        /// application exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsLocalDrivingLicenseApplicationExistAsync(
            int LocalDrivingLicenseApplicationID)
        {
            return DVLD_Data_Access_Layer.clsLocalDrivingLicenseApplicationData
                .IsLocalDrivingLicenseApplicationExistAsync(
                    LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Determines whether the applicant has passed a specific test type
        /// for the given local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The ID of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The type of test to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the applicant has passed the specified test; otherwise, false.
        /// </returns>
        public static Task<bool> DoesPassTestTypeAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestTypeAsync(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        /// <summary>
        /// Retrieves the total number of trials performed for a specific test type
        /// associated with a local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The ID of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The type of test for which the trial count is requested.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of trials as a byte.
        /// </returns>
        public static Task<byte> TotalTrialsPerTestAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTestAsync(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        /// <summary>
        /// Determines whether the applicant has attended a specific test type
        /// for the given local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The ID of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The type of test to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// at least one trial has been recorded for the specified test type;
        /// otherwise, false.
        /// </returns>
        public static async Task<bool> AttendedTestAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID)
        {
            return await clsLocalDrivingLicenseApplicationData.TotalTrialsPerTestAsync(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID) > 0;
        }

        /// <summary>
        /// Determines whether an active scheduled test exists for a specific
        /// test type and local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The ID of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">
        /// The type of test to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// an active scheduled test exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsThereAnActiveScheduledTestAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData
                .IsThereAnActiveScheduledTestAsync(
                    LocalDrivingLicenseApplicationID,
                    (int)TestTypeID);
        }

        /// <summary>
        /// Retrieves the number of tests passed for a local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The ID of the local driving license application.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of tests passed as a byte.
        /// </returns>
        public static Task<byte> GetPassedTestsCountAsync(
            int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassedTestsCountAsync(
                LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Determines whether the applicant has passed all required tests
        /// for a local driving license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The ID of the local driving license application.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// all required tests have been passed; otherwise, false.
        /// </returns>
        public static Task<bool> PassedAllTestsAsync(
            int LocalDrivingLicenseApplicationID)
        {
            return clsTest.IsPassedAllTestsAsync(
                LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Retrieves the most recent test record for a specific test type,
        /// applicant, and license class.
        /// </summary>
        /// <param name="ApplicantPersonID">
        /// The ID of the applicant.
        /// </param>
        /// <param name="LicenseClassID">
        /// The ID of the license class associated with the test.
        /// </param>
        /// <param name="TestTypeID">
        /// The type of test for which the most recent record is requested.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the most
        /// recent test record as a clsTest object, or null if no matching test exists.
        /// </returns>
        public static Task<clsTest> GetLastTestPerTestTypeAsync(
            int ApplicantPersonID,
            int LicenseClassID,
            clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestPerPersonAndLicenseClassAsync(
                ApplicantPersonID,
                LicenseClassID,
                TestTypeID);
        }
        /// <summary>
        /// Determines whether the applicant has passed a specific test type
        /// for this local driving license application.
        /// </summary>
        /// <param name="TestTypeID">
        /// The type of test to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the applicant has passed the specified test; otherwise, false.
        /// </returns>
        public Task<bool> DoesPassTestTypeAsync(
            clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestTypeAsync(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        /// <summary>
        /// Determines whether the applicant has passed the test required
        /// immediately before the specified test type.
        /// </summary>
        /// <param name="CurrentTestType">
        /// The type of test for which the previous test must be checked.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the required previous test has been passed or the current test is
        /// the vision test; otherwise, false.
        /// </returns>
        public async Task<bool> DoesPassPreviousTestAsync(
            clsTestType.enTestType CurrentTestType)
        {
            switch (CurrentTestType)
            {
                case clsTestType.enTestType.VisionTest:
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    return await this.DoesPassTestTypeAsync(
                        clsTestType.enTestType.VisionTest);

                case clsTestType.enTestType.StreetTest:
                    return await this.DoesPassTestTypeAsync(
                        clsTestType.enTestType.WrittenTest);

                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines whether the applicant has attended a specific test type
        /// for this local driving license application.
        /// </summary>
        /// <param name="TestTypeID">
        /// The type of test to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// at least one trial has been recorded for the specified test type;
        /// otherwise, false.
        /// </returns>
        public Task<bool> AttendedTestAsync(clsTestType.enTestType TestTypeID)
        {
            return CheckAttendedTestAsync(TestTypeID);
        }

        /// <summary>
        /// Checks whether the applicant has attended a specific test type
        /// by determining whether at least one trial has been recorded.
        /// </summary>
        /// <param name="TestTypeID">
        /// The type of test to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// at least one trial exists; otherwise, false.
        /// </returns>
        private async Task<bool> CheckAttendedTestAsync(
            clsTestType.enTestType TestTypeID)
        {
            return await clsLocalDrivingLicenseApplicationData.TotalTrialsPerTestAsync(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID) > 0;
        }

        /// <summary>
        /// Determines whether the applicant has attended a specific test type
        /// according to the test attendance records.
        /// </summary>
        /// <param name="TestTypeID">
        /// The type of test to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the applicant has attended the specified test; otherwise, false.
        /// </returns>
        public Task<bool> DoesAttendTestTypeAsync(
            clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestTypeAsync(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        /// <summary>
        /// Determines whether an active scheduled test exists for a specific
        /// test type in this local driving license application.
        /// </summary>
        /// <param name="TestTypeID">
        /// The type of test to check.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// an active scheduled test exists; otherwise, false.
        /// </returns>
        public Task<bool> IsThereAnActiveScheduledTestAsync(  clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTestAsync(
                this.LocalDrivingLicenseApplicationID,
           
                (int)TestTypeID);
        }

        /// <summary>
        /// Retrieves the total number of trials recorded for a specific test type
        /// in this local driving license application.
        /// </summary>
        /// <param name="TestTypeID">
        /// The type of test for which the trial count is requested.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total
        /// number of trials as a byte.
        /// </returns>
        public Task<byte> TotalTrialsPerTestAsync(
            clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTestAsync(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        /// <summary>
        /// Retrieves the total number of tests passed for this local driving
        /// license application.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of tests passed as a byte.
        /// </returns>
        public Task<byte> GetPassedTestCountAsync()
        {
            return clsTest.GetPassedTestsCountAsync(
                this.LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Determines whether the applicant has passed all required tests
        /// for this local driving license application.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// all required tests have been passed; otherwise, false.
        /// </returns>
        public Task<bool> PassedAllTestsAsync()
        {
            return clsTest.IsPassedAllTestsAsync(
                this.LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Retrieves the most recent test record for a specific test type,
        /// applicant, and license class associated with this application.
        /// </summary>
        /// <param name="TestTypeID">
        /// The type of test for which the latest record is requested.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the most
        /// recent matching test as a clsTest object, or null if no matching test exists.
        /// </returns>
        public Task<clsTest> GetLastTestPerTestTypeAsync(
            clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplication.GetLastTestPerTestTypeAsync(
                this.ApplicantPersonID,
                this.LicenseClassID,
                TestTypeID);
        }

        /// <summary>
        /// Determines whether an active license has been issued to the applicant
        /// for the license class associated with this application.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// an active license exists; otherwise, false.
        /// </returns>
        public async Task<bool> IsLicenseIssuedAsync()
        {
            return await GetActiveLicenseIDAsync() != -1;
        }

        /// <summary>
        /// Retrieves the ID of the applicant's active license for the license
        /// class associated with this application.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the active
        /// license ID, or -1 if no active license exists.
        /// </returns>
        public Task<int> GetActiveLicenseIDAsync()
        {
            return clsLicense.GetActiveLicenseIDAsync(
                this.ApplicantPersonID,
                this.LicenseClassID);
        }

        /// <summary>
        /// Determines whether a person meets the minimum age requirement for
        /// a specified license class.
        /// </summary>
        /// <param name="PersonID">
        /// The ID of the person whose age eligibility is being checked.
        /// </param>
        /// <param name="LicenseClassID">
        /// The license class for which the minimum age requirement is checked.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if
        /// the person meets the minimum age requirement; otherwise, false.
        /// </returns>
        public static Task<bool> IsHasMinimumAgeForLicenseClassAsync(
            int PersonID,
            clsLicenseClass.enLicenseClasses LicenseClassID)
        {
            return DVLD_Data_Access_Layer.clsLocalDrivingLicenseApplicationData
                .IsHasMinimaumAgeRequireAsync(PersonID, (byte)LicenseClassID);
        }

        /// <summary>
        /// Issues a driving license to the applicant for the first time.
        /// Creates a driver record if the applicant does not already have one,
        /// then creates the license and completes the application.
        /// </summary>
        /// <param name="Notes">
        /// Additional notes to associate with the issued license.
        /// </param>
        /// <param name="CreatedByUserID">
        /// The ID of the user issuing the license.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the new
        /// license ID if the license is issued successfully; otherwise, -1.
        /// </returns>
        public async Task<int> IssueLicenseForTheFirtTimeAsync(
            string Notes,
            int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = await clsDriver.FindByPersonIDAsync(
                this.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                if (await Driver.SaveAsync())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }

            clsLicense License = new clsLicense();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.Notes = Notes;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReasons.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            clsLicenseClass LicenseClass = await clsLicenseClass.FindAsync(License.LicenseClassID);

            if (LicenseClass != null)
            {
                License.ExpirationDate =  DateTime.Now.AddYears(LicenseClass.DefaultValidityLength);

                License.PaidFees = LicenseClass.ClassFees;
            }
            if(!clsValidation.IsValid(License))
            {
                return -1;
            }
            if (await License.SaveAsync())
            {
                await this.CompletedAsync();
                return License.LicenseID;
            }

            return -1;
        }

        
        public static  event Action<object, clsValidationErrorEventArgs > OnLicenseObjectNotValid;

        private void _WhenLicenseObjectNotValid(object sender, clsValidationErrorEventArgs e)
        {
            OnLicenseObjectNotValid?.Invoke(sender,e);


        }


    }
}