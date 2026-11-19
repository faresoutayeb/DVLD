using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer
{

    /// <summary>
    /// Represents a test appointment associated with a local driving license
    /// application, including its test type, scheduled date, fees, creator,
    /// lock status, and retake application information.
    /// </summary>
    public class clsTestAppointment
    {
        /// <summary>
        /// Specifies whether the test appointment is being created or updated.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Indicates that a new test appointment is being created.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates that an existing test appointment is being updated.
            /// </summary>
            Update = 1
        };

        /// <summary>
        /// Gets or sets the current operation mode of the test appointment.
        /// Defaults to <see cref="enMode.AddNew"/>.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the test appointment.
        /// </summary>
        public int TestAppointmentID { get; set; }

        /// <summary>
        /// Gets or sets the type of test associated with this appointment.
        /// </summary>
        public clsTestType.enTestType TestTypeID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the local driving license application
        /// associated with this appointment.
        /// </summary>
        public int LocalDrivingLicenseApplicationID { get; set; }

        /// <summary>
        /// Gets or sets the scheduled date and time of the test appointment.
        /// </summary>
        
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// Gets or sets the fees paid for the test appointment.
        /// </summary>
        [clsValidPositiveNumberAttribute("Paid Fees must be positive")]

        public float PaidFees { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the appointment.
        /// </summary>
        public int CreatedByUserID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the appointment is locked,
        /// meaning it can no longer be used to conduct a test.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the application created for a retake.
        /// </summary>
        public int RetakeTestApplicationID { get; set; }

        private clsTestType _TestType;
        private clsUser _UserInfo;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;
        private clsApplication _RetakeTestInfo;

        /// <summary>
        /// Gets the test type information associated with this appointment.
        /// The information is loaded lazily when first accessed.
        /// </summary>
        public clsTestType TestType
        {
            get
            {
                if (_TestType == null && TestTypeID > 0)
                    _TestType = clsTestType.FindTestType(TestTypeID);

                return _TestType;
            }
            private set { _TestType = value; }
        }

        /// <summary>
        /// Gets the user information for the user who created the appointment.
        /// The information is loaded lazily when first accessed.
        /// </summary>
        public clsUser UserInfo
        {
            get
            {
                if (_UserInfo == null && CreatedByUserID > 0)
                    _UserInfo = clsUser.FindByUserID(CreatedByUserID);

                return _UserInfo;
            }
            private set { _UserInfo = value; }
        }

        /// <summary>
        /// Gets the local driving license application associated with this
        /// appointment. The information is loaded lazily when first accessed.
        /// </summary>
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo
        {
            get
            {
                if (_LocalDrivingLicenseApplicationInfo == null &&
                    LocalDrivingLicenseApplicationID > 0)
                {
                    _LocalDrivingLicenseApplicationInfo =
                        clsLocalDrivingLicenseApplication
                            .FindByLocalDrivingLicenseAppID(
                                LocalDrivingLicenseApplicationID);
                }

                return _LocalDrivingLicenseApplicationInfo;
            }
            private set { _LocalDrivingLicenseApplicationInfo = value; }
        }

        /// <summary>
        /// Gets the application information associated with a retake.
        /// The information is loaded lazily when first accessed.
        /// </summary>
        public clsApplication RetakeTestInfo
        {
            get
            {
                if (_RetakeTestInfo == null && RetakeTestApplicationID > 0)
                    _RetakeTestInfo =
                        clsApplication.FindApplication(RetakeTestApplicationID);

                return _RetakeTestInfo;
            }
            private set { _RetakeTestInfo = value; }
        }

        /// <summary>
        /// Initializes a new test appointment with default values.
        /// Sets the operation mode to <see cref="enMode.AddNew"/>.
        /// </summary>
        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = clsTestType.enTestType.WrittenTest;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;
            TestType = null;
            UserInfo = null;
            LocalDrivingLicenseApplicationInfo = null;
            RetakeTestInfo = null;
            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing test appointment with the specified values.
        /// Sets the operation mode to <see cref="enMode.Update"/>.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The unique identifier of the test appointment.
        /// </param>
        /// <param name="TestTypeID">
        /// The type of test associated with the appointment.
        /// </param>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the associated local driving license application.
        /// </param>
        /// <param name="AppointmentDate">
        /// The scheduled date and time of the appointment.
        /// </param>
        /// <param name="PaidFees">The fees paid for the appointment.</param>
        /// <param name="CreatedByUserID">
        /// The identifier of the user who created the appointment.
        /// </param>
        /// <param name="IsLocked">
        /// Indicates whether the appointment is locked.
        /// </param>
        /// <param name="RetakeTestID">
        /// The identifier of the application created for a retake.
        /// </param>
        private clsTestAppointment(
            int TestAppointmentID,
            clsTestType.enTestType TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            float PaidFees,
            int CreatedByUserID,
            bool IsLocked,
            int RetakeTestID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestID;

            Mode = enMode.Update;
        }

        /// <summary>
        /// Adds a new test appointment to the database.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment was
        /// successfully added; otherwise, <see langword="false"/>.
        /// </returns>
        private async Task<bool> _AddNewTestAppointmentAsync()
        {
            this.TestAppointmentID =
                await clsTestAppointmentData.AddNewTestAppointmentAsync(
                    (byte)this.TestTypeID,
                    this.LocalDrivingLicenseApplicationID,
                    this.AppointmentDate,
                    this.PaidFees,
                    this.CreatedByUserID,
                    this.IsLocked,
                    this.RetakeTestApplicationID);

            return this.TestAppointmentID != -1;
        }

        /// <summary>
        /// Updates an existing test appointment in the database.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment
        /// was successfully updated; otherwise, <see langword="false"/>.
        /// </returns>
        private Task<bool> _UpdateTestAppointmentAsync()
        {
            return clsTestAppointmentData.UpdateTestAppointmentAsync(
                this.TestAppointmentID,
                (byte)this.TestTypeID,
                this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.IsLocked,
                this.RetakeTestApplicationID);
        }

        /// <summary>
        /// Finds a test appointment using its unique identifier.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The identifier of the appointment to retrieve.
        /// </param>
        /// <returns>
        /// A task containing the matching appointment if found;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        public static async Task<clsTestAppointment> FindAsync(int TestAppointmentID)
        {
            clsTestAppointmentData.clsTestAppointmentInfo Result =
                await clsTestAppointmentData.GetTestAppointmentInfoByIDAsync(
                    TestAppointmentID);

            if (Result == null )
                return null;

            return new clsTestAppointment(
                TestAppointmentID,
                (clsTestType.enTestType)Result.TestTypeID,
                Result.LocalDrivingLicenseApplicationID,
                Result.AppointmentDate,
                Result.PaidFees,
                Result.CreatedByUserID,
                Result.IsLocked,
                Result.RetakeTestApplicationID);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            clsTestAppointmentData.clsTestAppointmentInfo Result =
                 clsTestAppointmentData.GetTestAppointmentInfoByID(
                    TestAppointmentID);

            if (Result == null )
                return null;

            return new clsTestAppointment(
                TestAppointmentID,
                (clsTestType.enTestType)Result.TestTypeID,
                Result.LocalDrivingLicenseApplicationID,
                Result.AppointmentDate,
                Result.PaidFees,
                Result.CreatedByUserID,
                Result.IsLocked,
                Result.RetakeTestApplicationID);
        }

        /// <summary>
        /// Saves the test appointment by inserting a new record or updating
        /// an existing record according to the current <see cref="Mode"/>.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the operation succeeds;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewTestAppointmentAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateTestAppointmentAsync();
            }

            return false;
        }

        /// <summary>
        /// Retrieves all test appointments from the database.
        /// </summary>
        /// <returns>
        /// A task containing a <see cref="DataTable"/> with all test appointments.
        /// </returns>
        public static Task<DataTable> GetAllTestAppointmentsAsync()
        {
            return clsTestAppointmentData.GetAllTestsAppointmentsAsync();
        }

        /// <summary>
        /// Retrieves test appointments associated with a specific local driving
        /// license application and test type.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <returns>
        /// A task containing a <see cref="DataTable"/> with the matching
        /// test appointments.
        /// </returns>
        public static Task<DataTable> GetAllTestsAppointmentsViewAsync(
            int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            return clsTestAppointmentData.GetAllTestsAppointmentsAsync(
                LocalDrivingLicenseApplicationID, TestTypeID);
        }

        /// <summary>
        /// Retrieves the total number of test trials for a local driving license
        /// application and a specified test type.
        /// </summary>
        /// <param name="LocalDrivingLicenseID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <returns>
        /// A task containing the total number of trials.
        /// </returns>
        public static Task<int> GetAllTrialsCountAsync(
            int LocalDrivingLicenseID,
            int TestTypeID)
        {
            return clsTestAppointmentData.GetAllTrialsCountAsync(
                LocalDrivingLicenseID, TestTypeID);
        }

        /// <summary>
        /// Retrieves the total number of trials for this appointment's local
        /// driving license application and test type.
        /// </summary>
        /// <returns>A task containing the total number of trials.</returns>
        public Task<int> GetAllTrialsCountAsync()
        {
            return clsTestAppointmentData.GetAllTrialsCountAsync(
                this.LocalDrivingLicenseApplicationID,
                (byte)this.TestTypeID);
        }

        /// <summary>
        /// Deletes a test appointment using its identifier.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The identifier of the appointment to delete.
        /// </param>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment
        /// was deleted; otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> DeleteTestAppointmentAsync(int TestAppointmentID)
        {
            return clsTestAppointmentData.DeleteTestAppointmentAsync(
                TestAppointmentID);
        }

        /// <summary>
        /// Deletes the current test appointment from the database.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment
        /// was deleted; otherwise, <see langword="false"/>.
        /// </returns>
        public Task<bool> DeleteAsync()
        {
            return clsTestAppointmentData.DeleteTestAppointmentAsync(
                this.TestAppointmentID);
        }

        /// <summary>
        /// Deletes all test appointments associated with a specified local driving
        /// license application.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointments were
        /// successfully deleted; otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> DeleteTestsAppointmentsAsync(  int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentData.DeleteTestAppointmentsAsync(
                LocalDrivingLicenseApplicationID);
        }

        /// <summary>
        /// Determines whether a test appointment exists with the specified identifier.
        /// </summary>
        /// <param name="TestAppointmentID">
        /// The identifier of the test appointment.
        /// </param>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment exists;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsTestAppointmentExistAsync(int TestAppointmentID)
        {
            return clsTestAppointmentData.IsTestAppointmentExistAsync(  TestAppointmentID);
        }


        public static Task<bool> IsTestAppointmentExistAsync(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            return clsTestAppointmentData.IsTestAppointmentExistAsync(LocalDrivingLicenseApplicationID,  LicenseClassID);
        }


        /// <summary>
        /// Determines whether an active appointment exists for the specified local
        /// driving license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The identifier of the test type.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if an active appointment exists;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsHasActiveAppointmentAsync( int LocalDrivingLicenseApplicationID,int TestTypeID,int LicenseClassID)
        {
            return clsTestAppointmentData.IsHasActiveAppointmentAsync(
                LocalDrivingLicenseApplicationID, TestTypeID, LicenseClassID);
        }

        /// <summary>
        /// Determines whether an active appointment exists for the current local
        /// driving license application and test type.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if an active appointment exists;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> IsHasActiveAppointmentAsync()
        {
            return await clsTestAppointmentData.IsHasActiveAppointmentAsync(
                this.LocalDrivingLicenseApplicationID,
                (byte)this.TestTypeID,
                this.LocalDrivingLicenseApplicationInfo.LicenseClassInfo.LicenseClassID);
        }

        /// <summary>
        /// Locks a test appointment using its identifier.
        /// </summary>
        /// <param name="AppointmentID">
        /// The identifier of the appointment to lock.
        /// </param>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment was
        /// successfully locked; otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> LockedAppointmentAsync(int AppointmentID)
        {
            return clsTestAppointmentData.LockAppointmentAsync(AppointmentID);
        }

        /// <summary>
        /// Locks the current test appointment.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment was
        /// successfully locked; otherwise, <see langword="false"/>.
        /// </returns>
        public Task<bool> LockedAppointmentAsync()
        {
            return LockedAppointmentAsync(this.TestAppointmentID);
        }

        /// <summary>
        /// Determines whether a test appointment is locked.
        /// </summary>
        /// <param name="AppointmentID">
        /// The identifier of the appointment to check.
        /// </param>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment is locked;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsLockedAppointmentAsync(int AppointmentID)
        {
            return clsTestAppointmentData.IsLockedAppointmentAsync(AppointmentID);
        }

        /// <summary>
        /// Determines whether the current test appointment is locked.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the appointment is locked;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public Task<bool> IsLockedAppointmentAsync()
        {
            return clsTestAppointmentData.IsLockedAppointmentAsync(
                this.TestAppointmentID);
        }

        /// <summary>
        /// Retrieves the most recent test appointment for a specified local driving
        /// license application and test type.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The type of test to retrieve.</param>
        /// <returns>
        /// A task containing the most recent test appointment if found;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        public static async Task<clsTestAppointment> GetLastTestAppointmentAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID)
        {
            var Result = await clsTestAppointmentData.GetLastTestAppointmentAsync(
                LocalDrivingLicenseApplicationID, (byte)TestTypeID);

            if (Result == null )
                return null;

            return new clsTestAppointment(
                Result.TestAppointmentID,
                TestTypeID,
                LocalDrivingLicenseApplicationID,
                Result.AppointmentDate,
                Result.PaidFees,
                Result.CreatedByUserID,
                Result.IsLocked,
                Result.RetakeTestApplicationID);
        }

        /// <summary>
        /// Retrieves the most recent test appointment for the current local driving
        /// license application and test type.
        /// </summary>
        /// <returns>
        /// A task containing the most recent test appointment if found;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        public Task<clsTestAppointment> GetLastTestAppointmentAsync()
        {
            return GetLastTestAppointmentAsync(
                this.LocalDrivingLicenseApplicationID, this.TestTypeID);
        }

        /// <summary>
        /// Retrieves appointment information for a specified local driving license
        /// application and test type.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The type of test to retrieve.</param>
        /// <returns>
        /// A task containing a <see cref="DataTable"/> with the matching appointment
        /// information.
        /// </returns>
        public static Task<DataTable> GetTestAppointmentsInfoAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData
                .GetApplicationTestAppointmentsPerTestTypeAsync(
                    LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        /// <summary>
        /// Retrieves the total number of appointments for the specified local driving
        /// license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The type of test.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>A task containing the total number of appointments.</returns>
        public static Task<int> TotalAppointmentsCountAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID,
            int LicenseClassID)
        {
            return clsTestAppointmentData.TotalAppointmentsCountAsync(
                LocalDrivingLicenseApplicationID, (byte)TestTypeID, LicenseClassID);
        }

        /// <summary>
        /// Retrieves the total number of appointments for the current local driving
        /// license application, test type, and license class.
        /// </summary>
        /// <returns>A task containing the total number of appointments.</returns>
        public Task<int> TotalAppointmentsCountAsync()
        {
            return clsTestAppointmentData.TotalAppointmentsCountAsync(
                this.LocalDrivingLicenseApplicationID,
                (byte)this.TestTypeID,
                this.LocalDrivingLicenseApplicationInfo.LicenseClassID);
        }

        /// <summary>
        /// Retrieves the number of locked appointments for the specified local driving
        /// license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The type of test.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>A task containing the number of locked appointments.</returns>
        public static Task<int> TotalLockedAppointmentsCountAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID,
            int LicenseClassID)
        {
            return clsTestAppointmentData.TotalLockedAppointmentsCountAsync(
                LocalDrivingLicenseApplicationID, (byte)TestTypeID, LicenseClassID);
        }

        /// <summary>
        /// Retrieves the number of locked appointments for the current local driving
        /// license application, test type, and license class.
        /// </summary>
        /// <returns>A task containing the number of locked appointments.</returns>
        public Task<int> GetLockedAppointmentsCountAsync()
        {
            return clsTestAppointmentData.TotalLockedAppointmentsCountAsync(
                this.LocalDrivingLicenseApplicationID,
                (byte)this.TestTypeID,
                this.LocalDrivingLicenseApplicationInfo.LicenseClassID);
        }

        /// <summary>
        /// Retrieves the number of unlocked appointments for the specified local
        /// driving license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The type of test.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>A task containing the number of unlocked appointments.</returns>
        public static Task<int> GetUnLockedAppointmentsCountAsync(
            int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID,
            int LicenseClassID)
        {
            return clsTestAppointmentData.TotalUnLockedAppointmentsCountAsync(
                LocalDrivingLicenseApplicationID, (byte)TestTypeID, LicenseClassID);
        }

        /// <summary>
        /// Retrieves the number of unlocked appointments for the current local driving
        /// license application, test type, and license class.
        /// </summary>
        /// <returns>A task containing the number of unlocked appointments.</returns>
        public Task<int> GetUnLockedAppointmentsCountAsync()
        {
            return clsTestAppointmentData.TotalUnLockedAppointmentsCountAsync(
                this.LocalDrivingLicenseApplicationID,
                (byte)this.TestTypeID,
                this.LocalDrivingLicenseApplicationInfo.LicenseClassID);
        }

        /// <summary>
        /// Retrieves the total number of unlocked test appointments in the system.
        /// </summary>
        /// <returns>
        /// A task containing the total number of unlocked appointments.
        /// </returns>
        public static Task<int> GetAllUnLockedAppointmentsCountAsync()
        {
            return clsTestAppointmentData.GetAllUnLockedAppointmentsCountAsync();
        }

        /// <summary>
        /// Retrieves the date and time of the most recent appointment for the
        /// specified local driving license application, test type, and license class.
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">
        /// The identifier of the local driving license application.
        /// </param>
        /// <param name="TestTypeID">The type of test.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>
        /// A task containing the date and time of the most recent appointment.
        /// </returns>
        public static  Task<DateTime?> LastAppointmentDateTimeAsync( int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID,  int LicenseClassID)
        {

            return  clsTestAppointmentData.LastAppointmentsDateAsync(  LocalDrivingLicenseApplicationID, (byte)TestTypeID, LicenseClassID);
        }

        /// <summary>
        /// Retrieves the date and time of the most recent appointment for the current
        /// local driving license application, test type, and license class.
        /// </summary>
        /// <returns>
        /// A task containing the date and time of the most recent appointment.
        /// </returns>
        public Task<DateTime?> LastAppointmentDateTimeAsync()
        {
            return clsTestAppointmentData.LastAppointmentsDateAsync(
                this.LocalDrivingLicenseApplicationID,
                (byte)this.TestTypeID,
                this.LocalDrivingLicenseApplicationInfo.LicenseClassInfo.LicenseClassID);
        }
    }
}