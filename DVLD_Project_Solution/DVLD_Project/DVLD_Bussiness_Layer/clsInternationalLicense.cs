using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Represents an international driving license and its associated application.
    /// </summary>
    public class clsInternationalLicense : clsApplication
    {
        /// <summary>
        /// Specifies whether the international license is being added or updated.
        /// </summary>
        public enum enMode { AddNew = 0, Update = 1 };

        /// <summary>
        /// Gets or sets the current operation mode.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the international license.
        /// </summary>
        public int InternationalLicenseID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the driver who owns the international license.
        /// </summary>
        public int DriverID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the local license used to issue the international license.
        /// </summary>
        public int IssuedUsingLocalLicenseID { get; set; }

        /// <summary>
        /// Gets or sets the date on which the international license was issued.
        /// </summary>

        [clsValidIssueDate("Issue date international license cannot be in the future!")]

        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the international license.
        /// </summary>
          [clsValidExpirationDate("Expiration date about international license must be after today!")]

        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the international license is active.
        /// </summary>
        public bool IsActive { get; set; }

        private clsApplication _ApplicationInfo;
        private clsDriver _DriverInfo;
        private clsLicense _LicenseInfoIssuedWith;


        /// <summary>
        /// Gets the application associated with this international license.
        /// The application information is loaded when needed.
        /// </summary>
        public clsApplication ApplicationInfo
        {
            get
            {
                if (_ApplicationInfo == null && ApplicationID > 0)
                    _ApplicationInfo = clsApplication.FindApplication(ApplicationID);

                return _ApplicationInfo;
            }
            private set
            {
                _ApplicationInfo = value;
            }
        }

        /// <summary>
        /// Gets the driver who owns this international license.
        /// The driver information is loaded when needed.
        /// </summary>
        public clsDriver DriverInfo
        {
            get
            {
                if (_DriverInfo == null && DriverID > 0)
                    _DriverInfo = clsDriver.FindByDriverID(DriverID);

                return _DriverInfo;
            }
            private set
            {
                _DriverInfo = value;
            }
        }

        /// <summary>
        /// Gets the local license used to issue this international license.
        /// The local license information is loaded when needed.
        /// </summary>
        public clsLicense LocalLicenseIssuedWith
        {
            get
            {
                if (_LicenseInfoIssuedWith == null && IssuedUsingLocalLicenseID > 0)
                    _LicenseInfoIssuedWith = clsLicense.Find(IssuedUsingLocalLicenseID);

                return _LicenseInfoIssuedWith;
            }
            private set
            {
                _LicenseInfoIssuedWith = value;
            }
        }

        /// <summary>
        /// Initializes a new international license with default values.
        /// </summary>
        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            ApplicationDate = DateTime.Now;
            IsActive = true;
            CreatedByUserID = -1;
            ApplicationInfo = null;
            LocalLicenseIssuedWith = null;
            DriverInfo = null;
            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing international license using its application and license information.
        /// </summary>
        /// <param name="ApplicationID">The identifier of the associated application.</param>
        /// <param name="ApplicantPersonID">The identifier of the applicant's person record.</param>
        /// <param name="ApplicationDate">The date the application was created.</param>
        /// <param name="ApplicationStatus">The current status of the application.</param>
        /// <param name="LastStatusDate">The date of the last application status change.</param>
        /// <param name="PaidFees">The fees paid for the application.</param>
        /// <param name="CreatedByUserID">The identifier of the user who created the application.</param>
        /// <param name="InternationalLicenseID">The identifier of the international license.</param>
        /// <param name="DriverID">The identifier of the driver.</param>
        /// <param name="IssuedUsingLocalLicenseID">The identifier of the local license used for issuance.</param>
        /// <param name="IssueDate">The issue date of the international license.</param>
        /// <param name="ExpirationDate">The expiration date of the international license.</param>
        /// <param name="IsActive">Indicates whether the international license is active.</param>
        private clsInternationalLicense(
            int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID,
            int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive
            )
        {
            //this is for the base clase
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplicationType.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        /// <summary>
        /// Adds a new international license using the current object's information.
        /// </summary>
        /// <returns>
        /// A task whose result is <see langword="true"/> if the license was added successfully;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        private async Task<bool> _AddNewInternationalLicenseAsync()
        {
            this.InternationalLicenseID =
                await DVLD_Data_Access_Layer.clsInternationalLicenseData.AddNewInternationalLicenseAsync(
                    this.ApplicationID,
                    this.DriverID,
                    this.IssuedUsingLocalLicenseID,
                    this.IssueDate,
                    this.ExpirationDate,
                    this.IsActive,
                    this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        /// <summary>
        /// Updates the current international license in the data source.
        /// </summary>
        /// <returns>
        /// A task whose result indicates whether the update succeeded.
        /// </returns>
        private Task<bool> _UpdateInternationalLicenseAsync()
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.UpdateInternationalLicenseAsync(
                this.InternationalLicenseID,
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID);
        }

        /// <summary>
        /// Finds an international license by its identifier.
        /// </summary>
        /// <param name="InternationalLicenseID">The identifier of the international license to find.</param>
        /// <returns>
        /// A task containing the matching international license, or <see langword="null"/> if it is not found.
        /// </returns>
        public static async Task<clsInternationalLicense> FindAsync(int InternationalLicenseID)
        {
            clsInternationalLicenseData.clsInternationalLicenseInfo Result =
                await clsInternationalLicenseData.GetInternationalLicenseInfoByIDAsync(InternationalLicenseID);

            if (Result != null)
            {
                //now we find the base application
                clsApplication Application = await clsApplication.FindApplicationAsync(Result.ApplicationID);

                return new clsInternationalLicense(
                    Application.ApplicationID,
                    Application.ApplicantPersonID,
                    Application.ApplicationDate,
                    (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID,
                    InternationalLicenseID,
                    Result.DriverID,
                    Result.IssuedUsingLocalLicenseID,
                    Result.IssueDate,
                    Result.ExpirationDate,
                    Result.IsActive);
            }

            else
                return null;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            clsInternationalLicenseData.clsInternationalLicenseInfo Result =
                 clsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID);

            if (Result != null)
            {
                //now we find the base application
                clsApplication Application =  clsApplication.FindApplication(Result.ApplicationID);

                return new clsInternationalLicense(
                    Application.ApplicationID,
                    Application.ApplicantPersonID,
                    Application.ApplicationDate,
                    (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID,
                    InternationalLicenseID,
                    Result.DriverID,
                    Result.IssuedUsingLocalLicenseID,
                    Result.IssueDate,
                    Result.ExpirationDate,
                    Result.IsActive);
            }

            else
                return null;
        }


        /// <summary>
        /// Finds an international license associated with a specified local driving license.
        /// </summary>
        /// <param name="OrdinaryLicenseID">The identifier of the local driving license.</param>
        /// <returns>
        /// A task containing the matching international license, or <see langword="null"/> if it is not found.
        /// </returns>
        public static async Task<clsInternationalLicense> FindByActiveOrdinaryLicenseAsync(int OrdinaryLicenseID)
        {
            clsInternationalLicenseData.clsInternationalLicenseInfo Result =
                await clsInternationalLicenseData.GetInternationalLicenseInfoByOrdinaryLicenseIDAsync(OrdinaryLicenseID);

            if (Result != null)
            {
                //now we find the base application
                clsApplication Application = await clsApplication.FindApplicationAsync(Result.ApplicationID);

                return new clsInternationalLicense(
                    Application.ApplicationID,
                    Application.ApplicantPersonID,
                    Application.ApplicationDate,
                    (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID,
                    Result.InternationalLicenseID,
                    Result.DriverID,
                    Result.IssuedUsingLocalLicenseID,
                    Result.IssueDate,
                    Result.ExpirationDate,
                    Result.IsActive);
            }

            else
                return null;
        }

        public static clsInternationalLicense FindByActiveOrdinaryLicense(int OrdinaryLicenseID)
        {
            clsInternationalLicenseData.clsInternationalLicenseInfo Result =
                 clsInternationalLicenseData.GetInternationalLicenseInfoByOrdinaryLicenseID(OrdinaryLicenseID);

            if (Result != null)
            {
                //now we find the base application
                clsApplication Application =  clsApplication.FindApplication(Result.ApplicationID);

                return new clsInternationalLicense(
                    Application.ApplicationID,
                    Application.ApplicantPersonID,
                    Application.ApplicationDate,
                    (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID,
                    Result.InternationalLicenseID,
                    Result.DriverID,
                    Result.IssuedUsingLocalLicenseID,
                    Result.IssueDate,
                    Result.ExpirationDate,
                    Result.IsActive);
            }

            else
                return null;
        }


        /// <summary>
        /// Saves the application and international license information.
        /// Adds a new license or updates an existing one according to the current mode.
        /// </summary>
        /// <returns>
        /// A task whose result is <see langword="true"/> if the save operation succeeds;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> SaveInternationalLicenseAsync()
        {
            base.Mode = (clsApplication.enMode)this.Mode;

            if (!await base.SaveAsync())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewInternationalLicenseAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return await _UpdateInternationalLicenseAsync();
            }

            return false;
        }

        /// <summary>
        /// Retrieves all international licenses.
        /// </summary>
        /// <returns>A task containing a <see cref="DataTable"/> with all international licenses.</returns>
        public static Task<DataTable> GetAllInternationalLicensesAsync()
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.GetAllInternationalLicensesAsync();
        }

        /// <summary>
        /// Retrieves the international licenses belonging to a specific driver.
        /// </summary>
        /// <param name="DriverID">The identifier of the driver.</param>
        /// <returns>A task containing a <see cref="DataTable"/> with the driver's international licenses.</returns>
        public static Task<DataTable> GetDriverInternationalLicensesAsync(int DriverID)
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.GetDriverInternationalLicensesByDriverIDAsync(DriverID);
        }

        /// <summary>
        /// Retrieves international license information for the license management screen.
        /// </summary>
        /// <returns>A task containing a <see cref="DataTable"/> with the information required by the management screen.</returns>
        public static Task<DataTable> GetSpecialInternationalLicenseInfoToManageScreenAsync()
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.GetSpecialInternationalLicensesInfoAsync();
        }


        /// <summary>
        /// Retrieves the ID of the active international license belonging to a driver.
        /// </summary>
        /// <param name="DriverID">The ID of the driver.</param>
        /// <returns>A task representing the asynchronous operation, containing the active international license ID.</returns>
        public static Task<int> GetActiveInternationalLicenseIDByDriverIDAsync(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverIDAsync(DriverID);
        }

        /// <summary>
        /// Deletes an international license by its ID.
        /// </summary>
        /// <param name="InternationalLicenseID">The ID of the international license to delete.</param>
        /// <returns>A task representing the asynchronous operation, containing <see langword="true"/> if the license was deleted successfully; otherwise, <see langword="false"/>.</returns>
        public static Task<bool> DeleteInternationalLicenseAsync(int InternationalLicenseID)
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.DeleteInternationalLicenseAsync(InternationalLicenseID);
        }

        /// <summary>
        /// Determines whether an international license exists.
        /// </summary>
        /// <param name="InternationalLicenseID">The ID of the international license.</param>
        /// <returns>A task representing the asynchronous operation, containing <see langword="true"/> if the license exists; otherwise, <see langword="false"/>.</returns>
        public static Task<bool> IsInternationalLicenseExistAsync(int InternationalLicenseID)
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.IsInternationalLicenseExistAsync(InternationalLicenseID);
        }

        /// <summary>
        /// Determines whether an international license exists for the specified ordinary license.
        /// </summary>
        /// <param name="OrdinaryLicenseID">The ID of the ordinary license.</param>
        /// <returns>A task representing the asynchronous operation, containing <see langword="true"/> if an international license exists for the ordinary license; otherwise, <see langword="false"/>.</returns>
        public static Task<bool> IsActiveInterLicenseExistAsync(int OrdinaryLicenseID)
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.IsInternationalLicenseExistByOrdinarylLicenseIDAsync(OrdinaryLicenseID);
        }

        /// <summary>
        /// Retrieves the number of international licenses associated with a person.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>A task representing the asynchronous operation, containing the number of international licenses.</returns>
        public static Task<int> GetInternationalDriverLicensesCountAsync(int PersonID)
        {
            return clsInternationalLicenseData.GetInternationalDriverLicensesCountAsync(PersonID);
        }

        /// <summary>
        /// Retrieves the number of active international licenses associated with a person.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>A task representing the asynchronous operation, containing the number of active international licenses.</returns>
        public static Task<int> GetActiveInternationalDriverLicensesCountAsync(int PersonID)
        {
            return clsInternationalLicenseData.GetActiveInternationalDriverLicensesCountAsync(PersonID);
        }

        /// <summary>
        /// Retrieves the total number of active international licenses.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing the number of active international licenses.</returns>
        public static Task<int> GetActiveInternationalLicensesCountAsync()
        {
            return clsInternationalLicenseData.GetActiveInternationalLicensesCountAsync();
        }

        /// <summary>
        /// Retrieves the total number of international licenses.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing the total number of international licenses.</returns>
        public static Task<int> GetAllInternationalLicensesCountAsync()
        {
            return clsInternationalLicenseData.GetAllInternationalLicensesCountAsync();
        }

        /// <summary>
        /// Retrieves the number of expired international licenses.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing the number of expired international licenses.</returns>
        public static Task<int> GetExpiredInternationalLicensesCountAsync()
        {
            return clsInternationalLicenseData.GetExpiredInternationalLicensesCountAsync();
        }

        /// <summary>
        /// Retrieves the number of international licenses expiring within a specified day range.
        /// </summary>
        /// <param name="LatsDaysFrom">The starting day of the range.</param>
        /// <param name="LastDaysTo">The ending day of the range.</param>
        /// <returns>A task representing the asynchronous operation, containing the number of international licenses expiring within the specified range.</returns>
        public static Task<int> GetInterLicensesCountExpiringLastDaysBetweenAsync(int LatsDaysFrom, int LastDaysTo)
        {
            return clsInternationalLicenseData.GetInterLicensesCountExpiringBetweenNextDaysAsync(LatsDaysFrom, LastDaysTo);
        }

        /// <summary>
        /// Retrieves the number of international licenses issued within a specified day range.
        /// </summary>
        /// <param name="LastDaysFrom">The starting day of the range.</param>
        /// <param name="LastDaysTo">The ending day of the range.</param>
        /// <returns>A task representing the asynchronous operation, containing the number of international licenses issued within the specified range.</returns>
        public static Task<int> GetInterLicensesCountIssuedLastDaysBetweenAsync(int LastDaysFrom, int LastDaysTo)
        {
            return clsInternationalLicenseData.GetInterLicensesCountIssuedBetweenNextDaysAsync(LastDaysFrom, LastDaysTo);
        }

        /// <summary>
        /// Retrieves records of international licenses that are approaching their expiration dates.
        /// </summary>
        /// <param name="GetJustFirst_5Licenses">Indicates whether to retrieve only the first five license records.</param>
        /// <returns>A task representing the asynchronous operation, containing a <see cref="DataTable"/> of license records.</returns>
        public static Task<DataTable> GetSoonExpirationLicensesRecordsAsync(bool GetJustFirst_5Licenses = false)
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.GetSoonExpirationLicensesRecordsAsync(GetJustFirst_5Licenses);
        }

        /// <summary>
        /// Retrieves the date and time when the last international license was issued.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing the last issuance date and time.</returns>
        public static Task<DateTime> GetLastIssuedLicenseDateTimeAsync()
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.GetLastIssuedLicenseDateTimeAsync();
        }

        /// <summary>
        /// Retrieves information about the most recently expired international license.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing a <see cref="DataTable"/> with the expired license information.</returns>
        public static Task<DataTable> GetLastExpiredLicenseInfoAsync()
        {
            return DVLD_Data_Access_Layer.clsInternationalLicenseData.GetLastExpiredInterLicenseInfoAsync();
        }
    }
}