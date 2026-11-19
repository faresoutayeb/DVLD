using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Bussiness_Layer.GlobalClasses;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Bussiness_Layer.clsLicense;
namespace DVLD_Bussiness_Layer
{

    /// <summary>
    /// Represents a driving license and provides operations for retrieving,
    /// saving, deleting, and checking license information.
    /// </summary>
    public class clsLicense
    {
        /// <summary>
        /// Specifies whether the license is being added or updated.
        /// </summary>
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Gets or sets the ID of the license.
        /// </summary>
        public int LicenseID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the application associated with the license.
        /// </summary>
        public int ApplicationID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the driver who owns the license.
        /// </summary>
        public int DriverID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the license class.
        /// </summary>
        public int LicenseClassID { get; set; }

        /// <summary>
        /// Gets or sets the date on which the license was issued.
        /// </summary>
        [clsValidIssueDate("Issue date Local license cannot be in the future!")]

        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the license.
        /// </summary>
        [clsValidExpirationDate("Expiration date must be after today!")]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets additional notes associated with the license.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the fees paid for the license.
        /// </summary>
        [clsValidPositiveNumberAttribute("Number must be positive")]
        public float PaidFees { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the license is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the reason for issuing the license.
        /// </summary>
        public clsLicense.enIssueReasons IssueReason { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the license.
        /// </summary>
        public int CreatedByUserID { get; set; }

        /// <summary>
        /// Gets the textual description of the license issuance reason.
        /// </summary>
        public string IssueReasonString
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }


            


        /// <summary>
        /// Gets a value indicating whether the license is currently detained.
        /// </summary>
        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }
        
        /// <summary>
        /// Gets a value indicating whether the license has expired.
        /// </summary>
        public bool IsExpired
        {
            get
            {
                return this.ExpirationDate < DateTime.Now;
            }
        }

        private clsDriver _DriverInfo;
        private clsLicenseClass _LicenseClassInfo;
        private clsApplication _ApplicationInfo;
        private clsUser _UserInfo;
        private clsDetainedLicense _DetainedInfo;

        /// <summary>
        /// Gets or sets the detention information associated with the license.
        /// </summary>
        public clsDetainedLicense DetainedInfo
        {
            set
            {
                _DetainedInfo = value;
            }

            get
            {
                if (_DetainedInfo == null && this.LicenseID > 0)
                {
                    _DetainedInfo = clsDetainedLicense.FindByLicenseID(LicenseID);
                }
                return _DetainedInfo;
            }
        }

        /// <summary>
        /// Gets or sets the driver information associated with the license.
        /// </summary>
        public clsDriver DriverInfo
        {
            get
            {
                if (_DriverInfo == null && DriverID > 0)
                    _DriverInfo = clsDriver.FindByDriverID(DriverID);

                return _DriverInfo;
            }
            set
            {
                _DriverInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the license class information.
        /// </summary>
        public clsLicenseClass LicenseClassInfo
        {
            get
            {
                if (_LicenseClassInfo == null && LicenseClassID > 0)
                    _LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);

                return _LicenseClassInfo;
            }
            set
            {
                _LicenseClassInfo = value;
            }
        }




        /// <summary>
        /// Gets or sets the application information associated with the license.
        /// </summary>
        public clsApplication ApplicationInfo
        {
            get
            {
                if (_ApplicationInfo == null && ApplicationID > 0)
                    _ApplicationInfo = clsApplication.FindApplication(ApplicationID);

                return _ApplicationInfo;
            }
            set
            {
                _ApplicationInfo = value;
            }
        }

        /// <summary>
        /// Gets the information of the user who created the license.
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
        /// Specifies the possible reasons for issuing a license.
        /// </summary>
        public enum enIssueReasons
        {
            NoReasonSet = 0,
            FirstTime = 1,
            Renew = 2,
            ReplacementForLostOrStolen = 3,
            ReplacementForDamaged = 4
        }

        /// <summary>
        /// Converts a license issuance reason into its textual description.
        /// </summary>
        /// <param name="CurrentIssueReason">The issuance reason to describe.</param>
        /// <returns>The textual description of the specified issuance reason.</returns>
        static public string GetIssueReasonText(enIssueReasons CurrentIssueReason)
        {
            switch (CurrentIssueReason)
            {
                case enIssueReasons.FirstTime:
                    return "First Time";
                case enIssueReasons.Renew:
                    return "Renewal";

                case enIssueReasons.ReplacementForLostOrStolen:
                    return "Replacement For Lost Or Stolen";

                case enIssueReasons.ReplacementForDamaged:
                    return "Replacement For Damaged";
                default:
                    return "No Reason Set";
            }
        }

        /// <summary>
        /// Initializes a new license with default values.
        /// </summary>
        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
            clsValidation.OnValidationError += ObjectNotValid;
            _DetainedInfo = null;
        _LicenseClassInfo = null;
         _ApplicationInfo = null;
         _UserInfo = null;
         _DetainedInfo = null;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, clsLicense.enIssueReasons IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
            clsValidation.OnValidationError += ObjectNotValid;
            _DetainedInfo = null;
            _LicenseClassInfo = null;
            _ApplicationInfo = null;
            _UserInfo = null;
            _DetainedInfo = null;

        }

        private async Task<bool> _AddNewLicenseAsync()
        {
            LicenseID = await clsLicenseData.AddNewLicenseAsync(
                ApplicationID,
                DriverID,
                LicenseClassID,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                (byte)IssueReason,
                CreatedByUserID
            );

            return LicenseID != -1;
        }

        private async Task<bool> _UpdateLicenseAsync()
        {
            return await clsLicenseData.UpdateLicenseAsync(
                LicenseID,
                ApplicationID,
                DriverID,
                LicenseClassID,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                (byte)IssueReason,
                CreatedByUserID
            );
        }

        /// <summary>
        /// Finds a license by its ID.
        /// </summary>
        /// <param name="LicenseID">The ID of the license to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the license
        /// if found; otherwise, <see langword="null"/>.
        /// </returns>
        public static async Task<clsLicense> FindByAsync(int LicenseID)
        {
            clsLicenseData.clsLicenseInfo Result =
                await clsLicenseData.GetLicenseInfoByIDAsync(LicenseID);

            if (Result == null)
                return null;

            return new clsLicense(
                LicenseID,
                Result.ApplicationID,
                Result.DriverID,
                Result.LicenseClassID,
                Result.IssueDate,
                Result.ExpirationDate,
                Result.Notes,
                Result.PaidFees,
                Result.IsActive,
                (enIssueReasons)Result.IssueReason,
                Result.CreatedByUserID
            );
        }
        public static clsLicense Find(int LicenseID)
        {
            clsLicenseData.clsLicenseInfo Result =
                 clsLicenseData.GetLicenseInfoByID(LicenseID);

            if (Result == null)
                return null;

            return new clsLicense(
                LicenseID,
                Result.ApplicationID,
                Result.DriverID,
                Result.LicenseClassID,
                Result.IssueDate,
                Result.ExpirationDate,
                Result.Notes,
                Result.PaidFees,
                Result.IsActive,
                (enIssueReasons)Result.IssueReason,
                Result.CreatedByUserID
            );
        }


        /// <summary>
        /// Finds the most recent license associated with a person.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the license
        /// if found; otherwise, <see langword="null"/>.
        /// </returns>
        public static async Task<clsLicense> GetLastLicenseInfoByPersonIDAsync(int PersonID)
        {
            clsLicenseData.clsLicenseInfo Result =
                await clsLicenseData.GetLastLicenseInfoByPersonIDAsync(PersonID);

            if (Result == null)
                return null;

            return new clsLicense(
                Result.LicenseID,
                Result.ApplicationID,
                Result.DriverID,
                Result.LicenseClassID,
                Result.IssueDate,
                Result.ExpirationDate,
                Result.Notes,
                Result.PaidFees,
                Result.IsActive,
                (enIssueReasons)Result.IssueReason,
                Result.CreatedByUserID
            );
        }

        public static clsLicense GetLastLicenseInfoByPersonID(int PersonID)
        {
            clsLicenseData.clsLicenseInfo Result =
                 clsLicenseData.GetLastLicenseInfoByPersonID(PersonID);

            if (Result == null)
                return null;

            return new clsLicense(
                Result.LicenseID,
                Result.ApplicationID,
                Result.DriverID,
                Result.LicenseClassID,
                Result.IssueDate,
                Result.ExpirationDate,
                Result.Notes,
                Result.PaidFees,
                Result.IsActive,
                (enIssueReasons)Result.IssueReason,
                Result.CreatedByUserID
            );
        }

        /// <summary>
        /// Saves the license by adding a new record or updating an existing record.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the operation succeeds; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (!await _AddNewLicenseAsync())
                        return false;

                    Mode = enMode.Update;
                    return true;

                case enMode.Update:
                    return await _UpdateLicenseAsync();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Retrieves all license records.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with the license records.
        /// </returns>
        public static async Task<DataTable> GetAllLicensesAsync()
        {
            return await clsLicenseData.GetAllLicensesAsync();
        }

        /// <summary>
        /// Deletes a license by its ID.
        /// </summary>
        /// <param name="LicenseID">The ID of the license to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if deletion succeeds; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static async Task<bool> DeleteLicenseAsync(int LicenseID)
        {
            return await clsLicenseData.DeleteLicenseAsync(LicenseID);
        }

        /// <summary>
        /// Determines whether a license exists with the specified ID.
        /// </summary>
        /// <param name="LicenseID">The ID of the license to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the license exists; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static async Task<bool> IsLicenseExistAsync(int LicenseID)
        {
            return await clsLicenseData.IsLicenseExistAsync(LicenseID);
        }

        /// <summary>
        /// Determines whether a person has a license associated with the specified license class.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <param name="LicenseClassID">The ID of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if a matching license exists; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static async Task<bool> IsLicenseExistAsync(
            int PersonID,
            int LicenseClassID)
        {
            return await clsLicenseData.IsLicenseExistAsync(
                PersonID,
                LicenseClassID
            );
        }



        /// <summary>
        /// Determines whether the specified person has an active license
        /// for the specified license class.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <param name="LicenseClassID">The ID of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if an active
        /// license exists; otherwise, false.
        /// </returns>
        public static async Task<bool> IsActiveLicenseExistAsync(
            int PersonID,
            int LicenseClassID)
        {
            return await GetActiveLicenseIDAsync(PersonID, LicenseClassID) != -1;
        }

        /// <summary>
        /// Determines whether the specified license has expired.
        /// </summary>
        /// <param name="LicenseID">The ID of the license.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the license
        /// has expired; otherwise, false.
        /// </returns>
        public static async Task<bool> IsLicenseExpiredAsync(int LicenseID)
        {
            return await clsLicenseData.IsExpiredLicenseByLicenseIDAsync(LicenseID);
        }

        /// <summary>
        /// Retrieves all licenses associated with the specified driver.
        /// </summary>
        /// <param name="DriverID">The ID of the driver.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a DataTable
        /// with the driver's license information.
        /// </returns>
        public static async Task<DataTable> GetAllDriverLicensesAsync(int DriverID)
        {
            return await clsLicenseData.GetAllDriverLicensesInfoByDriverIDAsync(DriverID);
        }

        /// <summary>
        /// Determines whether the specified license was issued for the given reason.
        /// </summary>
        /// <param name="LicenseID">The ID of the license.</param>
        /// <param name="IssueLicenseReason">The reason to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the license
        /// was issued for the specified reason; otherwise, false.
        /// </returns>
        public static async Task<bool> IsIssueLicenseReasonAsync(
            int LicenseID,
            enIssueReasons IssueLicenseReason)
        {
            return await clsLicenseData.IsIssueLicenseReasonAsync(
                LicenseID,
                (byte)IssueLicenseReason
            );
        }

        /// <summary>
        /// Retrieves the expiration date and time of the specified license.
        /// </summary>
        /// <param name="LicenseID">The ID of the license.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the license's
        /// expiration date and time.
        /// </returns>
        public static async Task<DateTime> GetLicenseExpirationDateTimeAsync(int LicenseID)
        {
            return await clsLicenseData.GetLicenseExpirationDateByLicenseIDAsync(LicenseID);
        }

        /// <summary>
        /// Determines whether the specified license was issued as a replacement
        /// for a lost, stolen, or damaged license.
        /// </summary>
        /// <param name="LicenseID">The ID of the license.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the license
        /// was issued for a replacement reason; otherwise, false.
        /// </returns>
        public static async Task<bool> IsLicenseIssuedForReplacementReasonAsync(int LicenseID)
        {
            return await clsLicenseData.IsLicenseIssuedForReplacementByLicenseIDAsync(LicenseID);
        }

        /// <summary>
        /// Retrieves the ID of the active license belonging to the specified person
        /// for the specified license class.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <param name="LicenseClassID">The ID of the license class.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the active license ID,
        /// or -1 if no matching active license is found, depending on the data access implementation.
        /// </returns>
        public static async Task<int> GetActiveLicenseIDAsync(
            int PersonID,
            int LicenseClassID)
        {
            return await clsLicenseData.GetActiveLicenseIDByPersonIDAndClassIDAsync(
                PersonID,
                LicenseClassID
            );
        }

        /// <summary>
        /// Deactivates the current license.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing true if the license
        /// was successfully deactivated; otherwise, false.
        /// </returns>
        public async Task<bool> DeactivateCurrentLicenseAsync()
        {
            return await clsLicenseData.DeactivateLicenseAsync(LicenseID);
        }

        /// <summary>
        /// Retrieves the number of licenses matching the specified active status.
        /// </summary>
        /// <param name="IsActive">true to count active licenses; false to count inactive licenses.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number of matching licenses.
        /// </returns>
        public static async Task<int> GetAllLicensesCountAsync(bool IsActive)
        {
            return await clsLicenseData.GetAllLicensesCountAsync(IsActive);
        }

        /// <summary>
        /// Retrieves the total number of licenses, regardless of their active status.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total number of licenses.
        /// </returns>
        public static async Task<int> GetAllLocalLicensesCountAsync()
        {
            return await clsLicenseData.GetTotalLocalLicensesCountAsync();
        }

        /// <summary>
        /// Retrieves the total number of active ordinary licenses for the specified license class.
        /// </summary>
        /// <param name="LicenseClassID">The license class to count active licenses for.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number of active licenses
        /// in the specified class.
        /// </returns>
        public static async Task<int> GetTotalActiveOrdinaryLicensesCountAsync(
            clsLicenseClass.enLicenseClasses LicenseClassID)
        {
            return await clsLicenseData.GetTotalActiveOrdinaryLicensesCountAsync(
                (int)LicenseClassID
            );
        }

        /// <summary>
        /// Retrieves the total number of active licenses across all license classes.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the total number of active licenses.
        /// </returns>
        public static async Task<int> GetTotalActiveLocalLicensesCountAsync()
        {
            return await clsLicenseData.GetTotalActiveLicensesCountAsync();
        }
        public static async Task<int> GetTotalActiveExpiredLocalLicensesCountAsync()
        {
            return await clsLicenseData.GetTotalActiveExpiredLocalLicensesCountAsync();
        }
        
        public static async Task<int> GetTotalInActiveLicensesCountAsync()
        {
            return await clsLicenseData.GetTotalInActiveLicensesCountAsync();
        }
        /// <summary>
        /// Retrieves the number of licenses belonging to the specified person
        /// that match the specified active status.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <param name="IsActive">true to count active licenses; false to count inactive licenses.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number of matching licenses.
        /// </returns>
        public static async Task<int> GetLicensesCountAsync(
            int PersonID,
            bool IsActive)
        {
            return await clsLicenseData.GetLicensesCountAsync(PersonID, IsActive);
        }

        /// <summary>
        /// Retrieves the number of licenses belonging to the specified person
        /// that match the active status and issue reason.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <param name="IsActive">Indicates whether to count active or inactive licenses.</param>
        /// <param name="IssueReason">The reason for which the license was issued.</param>
        /// <returns>A task containing the number of matching licenses.</returns>
        public static async Task<int> GetLicensesCountAsync(
            int PersonID,
            bool IsActive,
            enIssueReasons IssueReason)
        {
            return await clsLicenseData.GetLicensesCountAsync(
                PersonID,
                IsActive,
                (byte)IssueReason
            );
        }

        /// <summary>
        /// Retrieves the total number of licenses belonging to the specified person.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>A task containing the number of licenses.</returns>
        public static async Task<int> GetLicensesCountAsync(int PersonID)
        {
            return await clsLicenseData.GetLicensesCountAsync(PersonID);
        }
        
         public static async Task<int> GetTotalLocalLicensesCountAsync()
        {
            return await clsLicenseData.GetTotalLocalLicensesCountAsync();
        }


        /// <summary>
        /// Retrieves the number of expired licenses belonging to the specified person.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>A task containing the number of expired licenses.</returns>
        public static async Task<int> GetExpiredLicensesCountAsync(int PersonID)
        {
            return await clsLicenseData.GetExpiredLicensesCountAsync(PersonID);
        }

        /// <summary>
        /// Retrieves the total number of expired licenses.
        /// </summary>
        /// <returns>A task containing the total number of expired licenses.</returns>
        public static async Task<int> GetAllExpiredLicensesCountAsync()
        {
            return await clsLicenseData.GetAllExpiredLicensesCountAsync();
        }

        /// <summary>
        /// Retrieves the number of licenses that expired within the specified date range.
        /// </summary>
        /// <param name="StartDate">The beginning of the date range.</param>
        /// <param name="EndDate">The end of the date range.</param>
        /// <returns>A task containing the number of expired licenses within the specified range.</returns>
        public static async Task<int> GetExpiredLicensesCountBetweenAsync(
            DateTime StartDate,
            DateTime EndDate)
        {
            return await clsLicenseData.GetExpiredLicensesCountBetweenAsync(
                StartDate,
                EndDate
            );
        }

        /// <summary>
        /// Retrieves the number of expired licenses for the date range calculated
        /// from the current date to the end of the current month.
        /// </summary>
        /// <returns>A task containing the number of expired licenses in the calculated date range.</returns>
        public static async Task<int> GetExpiredLicensesCountThisMonthAsync()
        {
            DateTime StartDate = DateTime.Now.Date;
            DateTime EndDate = StartDate.AddMonths(1).AddDays(-1);

            return await clsLicenseData.GetExpiredLicensesCountBetweenAsync(
                StartDate,
                EndDate
            );
        }

        /// <summary>
        /// Retrieves the number of expired licenses for the date range calculated
        /// from the current date through the end of the following month.
        /// </summary>
        /// <returns>A task containing the number of expired licenses in the calculated date range.</returns>
        public static async Task<int> GetExpiredLicensesCountToNextMonthAsync()
        {
            DateTime StartDate = DateTime.Now.Date;
            DateTime EndDate = StartDate.AddMonths(2).AddDays(-1);

            return await clsLicenseData.GetExpiredLicensesCountBetweenAsync(
                StartDate,
                EndDate
            );
        }

        /// <summary>
        /// Retrieves the date and time when the specified person was first issued a license.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>A task containing the date and time of the first license issuance.</returns>
        public static async Task<DateTime> GetFirstLicenseIssuedDateAsync(int PersonID)
        {
            return await clsLicenseData.GetFirstLicenseIssuedDateAsync(PersonID);
        }




        /// <summary>
        /// Detains the current license and records the associated fine and reason.
        /// </summary>
        /// <param name="FineFees">The fine amount associated with the detention.</param>
        /// <param name="CreatedByUserID">The ID of the user creating the detention record.</param>
        /// <param name="DetainReasonID">The ID of the detention reason.</param>
        /// <returns>
        /// A task containing the detention record ID if the operation succeeds;
        /// otherwise, -1.
        /// </returns>
        public async Task<int> DetainAsync(
            float FineFees,
            int CreatedByUserID,
            int DetainReasonID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense
            {
                LicenseID = LicenseID,
                DetainDate = DateTime.Now,
                FineFees = FineFees,
                CreatedByUserID = CreatedByUserID,
                DetainReasonID = DetainReasonID
            };
            if(!clsValidation.IsValid(detainedLicense))
            {
                return -1;
            }

            if (!await detainedLicense.SaveAsync())
                return -1;

            return detainedLicense.DetainID;
        }


        public static Action<object, clsValidationErrorEventArgs> OnObjectNotValid;
        protected void ObjectNotValid(object sender, clsValidationErrorEventArgs e)
        {
            OnObjectNotValid?.Invoke(sender, e);
        }

        /// <summary>
        /// Represents the result of a detained-license release operation.
        /// </summary>
        public class clsReleaseInfo
        {
            /// <summary>
            /// Gets or sets a value indicating whether the license was successfully released.
            /// </summary>
            public bool IsRelease { get; set; }

            /// <summary>
            /// Gets or sets the ID of the application associated with the release.
            /// </summary>
            public int ReleaseApplicationID { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="clsReleaseInfo"/> class
            /// with default release information.
            /// </summary>
            public clsReleaseInfo()
            {
                IsRelease = false;
                ReleaseApplicationID = -1;
            }
        }

        /// <summary>
        /// Releases the current detained license by creating a release application
        /// and updating the detention record.
        /// </summary>
        /// <param name="ReleasedByUserID">The ID of the user performing the release.</param>
        /// <returns>
        /// A task containing the release information, including the release status
        /// and associated application ID.
        /// </returns>
        public async Task<clsReleaseInfo> ReleaseDetainedLicenseAsync(  int ReleasedByUserID)
        {

            float applicationTypeFees =await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense);

            clsApplication application = new clsApplication
            {
                ApplicationID = -1,
                ApplicantPersonID = DriverInfo.PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense,
                ApplicationStatus = clsApplication.enApplicationStatus.completed,
                LastStatusDate = DateTime.Now,
                PaidFees = applicationTypeFees,
                CreatedByUserID = ReleasedByUserID
            };

            if (!await application.SaveAsync())
                return null;
            clsReleaseInfo releaseInfo = new clsReleaseInfo();

            releaseInfo.ReleaseApplicationID = application.ApplicationID;

            if (DetainedInfo == null || !await DetainedInfo.ReleaseDetainedLicenseAsync(ReleasedByUserID, application.ApplicationID))
            {
                releaseInfo.IsRelease = false;
                return releaseInfo;
            }

            releaseInfo.IsRelease = true;
            return releaseInfo;
        }

        /// <summary>
        /// Renews the current license by creating a renewal application and issuing
        /// a new license with the validity period defined by the license class.
        /// </summary>
        /// <param name="Notes">The notes to associate with the renewed license.</param>
        /// <param name="CreatedByUserID">The ID of the user creating the renewal.</param>
        /// <returns>
        /// A task containing the newly issued license if the renewal succeeds;
        /// otherwise, null.
        /// </returns>
        public async Task<clsLicense> RenewLicenseAsync(
            string Notes,
            int CreatedByUserID)
        {
            clsLicenseClass licenseClass = LicenseClassInfo;

            if (DriverInfo == null || licenseClass == null)
                return null;

            float applicationTypeFees = await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense);

            clsApplication application = new clsApplication
            {
                ApplicantPersonID = DriverInfo.PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.RenewDrivingLicense,
                ApplicationStatus = clsApplication.enApplicationStatus.completed,
                LastStatusDate = DateTime.Now,
                PaidFees = applicationTypeFees,
                CreatedByUserID = CreatedByUserID
            };

            if (!await application.SaveAsync())
                return null;

            clsLicense newLicense = new clsLicense
            {
                ApplicationID = application.ApplicationID,
                DriverID = DriverID,
                LicenseClassID = LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(
                    licenseClass.DefaultValidityLength),
                Notes = Notes,
                PaidFees = licenseClass.ClassFees,
                IsActive = true,
                IssueReason = enIssueReasons.Renew,
                CreatedByUserID = CreatedByUserID
            };

            if (!await newLicense.SaveAsync())
                return null;

            if (!await DeactivateCurrentLicenseAsync())
                return null;

            return newLicense;
        }

        /// <summary>
        /// Replaces the current license because it was lost, stolen, or damaged,
        /// creating the corresponding application and issuing a replacement license.
        /// </summary>
        /// <param name="IssueReason">The reason for replacing the license.</param>
        /// <param name="CreatedByUserID">The ID of the user creating the replacement.</param>
        /// <returns>
        /// A task containing the newly issued replacement license if the operation succeeds;
        /// otherwise, null.
        /// </returns>
        /// 
        
        public async Task<clsLicense> ReplaceAsync(
            enIssueReasons IssueReason,
            int CreatedByUserID)
        {
            if (DriverInfo == null)
                return null;

            clsApplicationType.enApplicationType applicationTypeID =
                IssueReason == enIssueReasons.ReplacementForDamaged
                    ? clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense
                    : clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense;

            float applicationTypeFees = await clsApplicationType.GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense);

            clsApplication application = new clsApplication
            {
                ApplicantPersonID = DriverInfo.PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = (int)applicationTypeID,
                ApplicationStatus = clsApplication.enApplicationStatus.completed,
                LastStatusDate = DateTime.Now,
                PaidFees = applicationTypeFees,
                CreatedByUserID = CreatedByUserID
            };

            if (!await application.SaveAsync())
                return null;

            clsLicense newLicense = new clsLicense
            {
                ApplicationID = application.ApplicationID,
                DriverID = DriverID,
                LicenseClassID = LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = ExpirationDate,
                Notes = this.Notes,
                PaidFees = 0,
                IsActive = true,
                IssueReason = IssueReason,
                CreatedByUserID = CreatedByUserID
            };

            if (!await newLicense.SaveAsync())
                return null;

            if (!await DeactivateCurrentLicenseAsync())
                return null;

            return newLicense;
        }

    }
}
