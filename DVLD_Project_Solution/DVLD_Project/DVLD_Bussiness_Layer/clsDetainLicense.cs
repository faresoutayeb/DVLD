using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Bussiness_Layer.clsDetainedLicense;
namespace DVLD_Bussiness_Layer
{

    /// <summary>
    /// Represents a detained driving license and provides operations for
    /// managing license detention and release information.
    /// </summary>
    public class clsDetainedLicense
    {
        /// <summary>
        /// Specifies the operating mode of a detained license object.
        /// </summary>
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Specifies the possible results of checking whether a license can be detained.
        /// </summary>
        public enum enCanDetainLicenseResult
        {
            LicenseNotFound,
            LicenseInactive,
            LicenseExpired,
            LicenseAlreadyDetained,
            YesWeCan
        }

        /// <summary>
        /// Specifies the possible results of checking whether a license can be released.
        /// </summary>
        public enum enCanReleaseLicenseResult
        {
            LicenseNotFound,
            LicenseInactive,
            LicenseExpired,
            LicenseNotDetained,
            YesWeCan
        }

        /// <summary>
        /// Specifies the possible states of a license regarding its readiness for use.
        /// </summary>
        public enum enLicenseReadyToUse
        {
            LicenseNotExist,
            LicenseNotActive,
            LicenseExpired,
            LicenseReadyToUsed
        }

        /// <summary>
        /// Gets or sets the unique identifier of the detention record.
        /// </summary>
        public int DetainID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the detained license.
        /// </summary>
        public int LicenseID { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the license was detained.
        /// </summary>
        public DateTime DetainDate { get; set; }

        /// <summary>
        /// Gets or sets the fine fees associated with the detention.
        /// </summary>
        [clsValidPositiveNumberAttribute("Fine Fees must be positive")]

        public float FineFees { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the detention record.
        /// </summary>
        public int CreatedByUserID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the detention has been released.
        /// </summary>
        public bool IsReleased { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the detention was released.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who released the detention.
        /// </summary>
        public int? ReleasedByUserID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the application associated with the release.
        /// </summary>
        public int? ReleaseApplicationID { get; set; }

        /// <summary>
        /// Gets the date and time of the last action performed on the detention record.
        /// </summary>
        public DateTime LastActionDateTime { get; private set; }

        /// <summary>
        /// Gets or sets the identifier of the reason for detention.
        /// </summary>
        public int DetainReasonID { get; set; }

        private clsDetainReason _DetainReasonInfo;
        private clsLicense _LicenseInfo;
        private clsUser _UserInfo;
        private clsApplication _ReleaseApplicationInfo;

        /// <summary>
        /// Gets or sets the information about the detention reason.
        /// The information is retrieved when needed.
        /// </summary>
        public clsDetainReason DetainReasonInfo
        {
            get
            {
                if (_DetainReasonInfo == null && DetainReasonID > 0)
                    _DetainReasonInfo = clsDetainReason.Find(DetainReasonID);

                return _DetainReasonInfo;
            }
            set
            {
                _DetainReasonInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the information about the detained license.
        /// The information is retrieved when needed.
        /// </summary>
        public clsLicense LicenseInfo
        {
            get
            {
                if (_LicenseInfo == null && LicenseID > 0)
                    _LicenseInfo = clsLicense.Find(LicenseID);

                return _LicenseInfo;
            }
            set
            {
                _LicenseInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the information about the user who created the detention record.
        /// The information is retrieved when needed.
        /// </summary>
        public clsUser UserInfo
        {
            get
            {
                if (_UserInfo == null && CreatedByUserID > 0)
                    _UserInfo = clsUser.FindByUserID(CreatedByUserID);

                return _UserInfo;
            }
            set
            {
                _UserInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the application information associated with the license release.
        /// The information is retrieved when needed.
        /// </summary>
        public clsApplication ReleaseApplicationInfo
        {
            get
            {
                if (_ReleaseApplicationInfo == null && ReleaseApplicationID > 0)
                    _ReleaseApplicationInfo = clsApplication.FindApplication((int)ReleaseApplicationID);

                return _ReleaseApplicationInfo;
            }
            set
            {
                _ReleaseApplicationInfo = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="clsDetainedLicense"/> class
        /// with default values for a new detention record.
        /// </summary>
        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;
            LastActionDateTime = DateTime.Now;
            DetainReasonID = -1;
            Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID, DateTime LastActionDateTime, int DetainReasonID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.LastActionDateTime = LastActionDateTime;
            this.DetainReasonID = DetainReasonID;
            Mode = enMode.Update;
        }

        /// <summary>
        /// Adds a new detained license record to the data source.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the record was added successfully;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        private async Task<bool> _AddNewDetainedLicenseAsync()
        {
            this.DetainID = await DVLD_Data_Access_Layer.clsDetaindLicenseData.AddNewDetainedLicenseAsync(
                this.LicenseID,
                this.DetainDate,
                this.FineFees,
                this.CreatedByUserID,
                this.IsReleased,
                this.ReleaseDate,
                this.ReleasedByUserID,
                this.ReleaseApplicationID,
                this.DetainReasonID
                );

            return (this.DetainID != -1);
        }

        /// <summary>
        /// Updates an existing detained license record in the data source.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous update operation, containing
        /// <see langword="true"/> if the record was updated successfully;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        private Task<bool> _UpdateDetainedLicenseAsync()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.UpdateDetainedLicenseAsync(
                this.DetainID,
                this.LicenseID,
                this.DetainDate,
                this.FineFees,
                this.CreatedByUserID,
                this.IsReleased,
                this.ReleaseDate,
                this.ReleasedByUserID,
                this.ReleaseApplicationID,
                this.DetainReasonID
                );
        }

        /// <summary>
        /// Retrieves a detained license record by its detention identifier.
        /// </summary>
        /// <param name="DetainID">The unique identifier of the detention record.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// detained license if found; otherwise, <see langword="null"/>.
        /// </returns>
        public static async Task<clsDetainedLicense> FindByDetainIDAsync(int DetainID)
        {
            clsDetaindLicenseData.DetainedLicenseInfoResult Result = await DVLD_Data_Access_Layer.clsDetaindLicenseData.GetDetainedLicenseInfoByIDAsync(DetainID);
            if (Result != null)
            {
                return new clsDetainedLicense(
                    Result.DetainID,
                    Result.LicenseID,
                    Result.DetainDate,
                    Result.FineFees,
                    Result.CreatedByUserID,
                    Result.IsReleased,
                    Result.ReleaseDate,
                    Result.ReleasedByUserID,
                    Result.ReleaseApplicationID,
                    Result.LastActionDateTime,
                    Result.DetainReasonID
                    );
            }

            return null;
        }

        public static clsDetainedLicense FindByDetainID(int DetainID)
        {
            clsDetaindLicenseData.DetainedLicenseInfoResult Result =  DVLD_Data_Access_Layer.clsDetaindLicenseData.GetDetainedLicenseInfoByID(DetainID);
            if (Result != null)
            {
                return new clsDetainedLicense(
                    Result.DetainID,
                    Result.LicenseID,
                    Result.DetainDate,
                    Result.FineFees,
                    Result.CreatedByUserID,
                    Result.IsReleased,
                    Result.ReleaseDate,
                    Result.ReleasedByUserID,
                    Result.ReleaseApplicationID,
                    Result.LastActionDateTime,
                    Result.DetainReasonID
                    );
            }

            return null;
        }


        /// <summary>
        /// Retrieves detention information associated with a license identifier.
        /// </summary>
        /// <param name="LicenseID">The identifier of the license.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// detained license if found; otherwise, <see langword="null"/>.
        /// </returns>
        public static async Task<clsDetainedLicense> FindByLicenseIDAsync(int LicenseID)
        {
            clsDetaindLicenseData.DetainedLicenseInfoResult Result = await DVLD_Data_Access_Layer.clsDetaindLicenseData.GetDetainedLicenseInfoByLicenseIDAsync(LicenseID);
            if (Result != null)
            {
                return new clsDetainedLicense(
                    Result.DetainID,
                    Result.LicenseID,
                    Result.DetainDate,
                    Result.FineFees,
                    Result.CreatedByUserID,
                    Result.IsReleased,
                    Result.ReleaseDate,
                    Result.ReleasedByUserID,
                    Result.ReleaseApplicationID,
                    Result.LastActionDateTime,
                    Result.DetainReasonID
                    );
            }

            return null;
        }
        

        public static  clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            clsDetaindLicenseData.DetainedLicenseInfoResult Result =  DVLD_Data_Access_Layer.clsDetaindLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID);
            if (Result != null)
            {
                return new clsDetainedLicense(
                    Result.DetainID,
                    Result.LicenseID,
                    Result.DetainDate,
                    Result.FineFees,
                    Result.CreatedByUserID,
                    Result.IsReleased,
                    Result.ReleaseDate,
                    Result.ReleasedByUserID,
                    Result.ReleaseApplicationID,
                    Result.LastActionDateTime,
                    Result.DetainReasonID
                    );
            }

            return null;
        }

        /// <summary>
        /// Saves the detention record according to the current operating mode.
        /// Adds a new record or updates an existing record.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the save operation succeeds; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewDetainedLicenseAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateDetainedLicenseAsync();
            }

            return false;
        }

        /// <summary>
        /// Retrieves all detained license records.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with all detained license records.
        /// </returns>
        public static Task<DataTable> GetAllDetainedLicensesViewAsync()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.GetAllDetainedLicensesViewAsync();
        }

        /// <summary>
        /// Retrieves the data used to display and manage detained licenses.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with detained license management information.
        /// </returns>
        public static Task<DataTable> GetAllDetainedLicensesAsync()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.GetAllDetainedLicensesAsync();
        }

        /// <summary>
        /// Retrieves the most frequent detention reasons.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with the top detention reasons.
        /// </returns>
        public static Task<DataTable> GetTopDetainReasonsAsync()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.GetTopDetainReasonsAsync();
        }

        /// <summary>
        /// Retrieves recent activity related to detained licenses.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with recent detention activity.
        /// </returns>
        public static Task<DataTable> GetRecenttActivityAsync()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.GetRecenttActivityAsync();
        }



        /// <summary>
        /// Deletes a detained license record by its detention identifier.
        /// </summary>
        /// <param name="DetainID">The unique identifier of the detention record.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the record was deleted successfully;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> DeleteDetainedLicenseAsync(int DetainID)
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.DeleteDetainedLicenseAsync(DetainID);
        }

        /// <summary>
        /// Determines whether a license can be detained based on its existence,
        /// expiration status, and current detention status.
        /// </summary>
        /// <param name="LicenseID">The identifier of the license to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the result
        /// of the license detention eligibility check.
        /// </returns>
        static public async Task<enCanDetainLicenseResult> CanWeDetainThisLicenseAsync(int LicenseID)
        {
            if (!await clsLicense.IsLicenseExistAsync(LicenseID))
            {
                return enCanDetainLicenseResult.LicenseNotFound;
            }
            //if(!clsLicense.IsActiveLicenseExist(LicenseID))
            //{
            //    return enCanDetainLicenseResult.LicenseInactive;

            //}
            if (await clsLicense.IsLicenseExpiredAsync(LicenseID))
            {
                return enCanDetainLicenseResult.LicenseExpired;
            }
            if (await clsDetainedLicense.IsLicenseDetainedAsync(LicenseID))
            {
                return enCanDetainLicenseResult.LicenseAlreadyDetained;

            }

            return enCanDetainLicenseResult.YesWeCan;
        }

        /// <summary>
        /// Determines whether a detained license can be released based on its existence,
        /// expiration status, and current detention status.
        /// </summary>
        /// <param name="LicenseID">The identifier of the license to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the result
        /// of the license release eligibility check.
        /// </returns>
        static public async Task<enCanReleaseLicenseResult> CanWeReleaseThisLicenseAsync(int LicenseID)
        {
            if (!await clsLicense.IsLicenseExistAsync(LicenseID))
            {
                return enCanReleaseLicenseResult.LicenseNotFound;
            }
            //if (!clsLicense.IsActiveLicenseExist(LicenseID))
            //{
            //    return enCanReleaseLicenseResult.LicenseInactive;

            //}
            if (await clsLicense.IsLicenseExpiredAsync(LicenseID))
            {
                return enCanReleaseLicenseResult.LicenseExpired;
            }
            if (!await clsDetainedLicense.IsLicenseDetainedAsync(LicenseID))
            {
                return enCanReleaseLicenseResult.LicenseNotDetained;

            }

            return enCanReleaseLicenseResult.YesWeCan;
        }

        /// <summary>
        /// Determines whether a license is ready to be used based on its existence
        /// and expiration status.
        /// </summary>
        /// <param name="LicenseID">The identifier of the license to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the license
        /// readiness status.
        /// </returns>
        static public async Task<enLicenseReadyToUse> IsLicenseReadyToUse(int LicenseID)
        {
            if (!await clsLicense.IsLicenseExistAsync(LicenseID))
            {

                return enLicenseReadyToUse.LicenseNotExist;
            }

            //if (!clsLicense.IsActiveLicenseExist(LicenseID))
            //{

            //    return enLicenseReadyToUse.LicenseNotActive;
            //}

            if (await clsLicense.IsLicenseExpiredAsync(LicenseID))
            {
                return enLicenseReadyToUse.LicenseExpired;
            }

            return enLicenseReadyToUse.LicenseReadyToUsed;
        }


        public static bool IsLicenseDetained(int LicenseID)
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.IsLicenseDetained(LicenseID);
        }

        public  bool IsLicenseDetained()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.IsLicenseDetained(this.LicenseID);
        }


        /// <summary>
        /// Determines whether a license is currently detained.
        /// </summary>
        /// <param name="LicenseID">The identifier of the license to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the license is detained; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsLicenseDetainedAsync(int LicenseID)
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.IsLicenseDetainedAsync(LicenseID);
        }
        /// <summary>
        /// Determines whether the license associated with the current object is detained.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the license is detained; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public Task<bool> IsLicenseDetainedAsync()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.IsLicenseDetainedAsync(this.LicenseID);
        }

        /// <summary>
        /// Determines whether a license has been released from detention.
        /// </summary>
        /// <param name="LicenseID">The identifier of the license to check.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the license is released; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsLicenseReleasedAsync(int LicenseID)
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.IsLicenseDetainedAsync(LicenseID, true);
        }

        public static bool IsLicenseReleased(int LicenseID)
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.IsLicenseDetained(LicenseID, true);
        }
        public  bool IsLicenseReleased()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.IsLicenseDetained(this.LicenseID, true);
        }

        /// <summary>
        /// Determines whether the license associated with the current object has been released.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the license is released; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public Task<bool> IsLicenseReleasedAsync()
        {
            return DVLD_Data_Access_Layer.clsDetaindLicenseData.IsLicenseDetainedAsync(this.LicenseID, true);
        }

        /// <summary>
        /// Releases the detention associated with the current object.
        /// </summary>
        /// <param name="ReleasedByUserID">The identifier of the user releasing the detention.</param>
        /// <param name="ReleaseApplicationID">The identifier of the application associated with the release.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the detention was released successfully;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public Task<bool> ReleaseDetainedLicenseAsync(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetaindLicenseData.ReleaseDetainedLicenseAsync(this.DetainID,
                   ReleasedByUserID, ReleaseApplicationID);
        }

        /// <summary>
        /// Releases a detention record by its identifier.
        /// </summary>
        /// <param name="DetainID">The identifier of the detention record to release.</param>
        /// <param name="ReleasedByUserID">The identifier of the user releasing the detention.</param>
        /// <param name="ReleaseApplicationID">The identifier of the application associated with the release.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the detention was released successfully;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> ReleaseDetainedLicenseAsync(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetaindLicenseData.ReleaseDetainedLicenseAsync(DetainID,
                   ReleasedByUserID, ReleaseApplicationID);
        }

        /// <summary>
        /// Retrieves the total number of currently detained licenses.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing the number
        /// of currently detained licenses.
        /// </returns>
        public static Task<int> GetCurrentlyDetainedLicensesCountAsync()
        {
            return clsDetaindLicenseData.DetainedLicensesCountAsync();
        }
        /// <summary>
        /// Gets the total number of licenses that have been released from detention.
        /// </summary>
        /// <returns>A task containing the number of released licenses.</returns>
        public static Task<int> ReleasedLicenseCountAsync()
        {
            return clsDetaindLicenseData.DetainedLicensesCountAsync(true);
        }

        /// <summary>
        /// Gets the total fees associated with currently detained licenses.
        /// </summary>
        /// <returns>A task containing the total fees of currently detained licenses.</returns>
        public static Task<float> TotalCurrentlyDetainedLicensesFeesAsync()
        {
            return clsDetaindLicenseData.TotalCurrentlyDetainedLicensesFeesAsync();
        }

        /// <summary>
        /// Gets the total fees associated with all detained licenses.
        /// </summary>
        /// <returns>A task containing the total fees associated with detained licenses.</returns>
        public static Task<float> GetAllDetainedLicensesFeesAsync()
        {
            return clsDetaindLicenseData.GetAllDetainedLicensesFeesAsync();
        }

        /// <summary>
        /// Gets the number of licenses detained during the last 30 days.
        /// </summary>
        /// <returns>A task containing the number of licenses detained during the last 30 days.</returns>
        public static Task<int> DetainedLicensesCountLast30DaysAsync()
        {
            return clsDetaindLicenseData.GetDetainedLicensesCountInLast30DaysAsync();
        }

        /// <summary>
        /// Gets the number of licenses detained during the current month.
        /// </summary>
        /// <returns>A task containing the number of licenses detained during the current month.</returns>
        public static Task<int> GetDetainedLicensesCountThisMonthAsync()
        {
            return clsDetaindLicenseData.GetDetainedLicensesCountThisMonthAsync();
        }

        /// <summary>
        /// Gets the number of licenses released during the previous month.
        /// </summary>
        /// <returns>A task containing the number of licenses released during the previous month.</returns>
        public static Task<int> ReleasedLicensesCountLastMonthAsync()
        {
            return clsDetaindLicenseData.ReleasedLicensesCountInLastMonthAsync();
        }

        /// <summary>
        /// Gets the date and time of the most recent license detention.
        /// </summary>
        /// <returns>A task containing the date and time of the most recent detention.</returns>
        public static Task<DateTime> LastDetainedDateTimeAsync()
        {
            return clsDetaindLicenseData.LastDetainedDateTimeAsync();
        }

        /// <summary>
        /// Gets the date and time of the most recent license release.
        /// </summary>
        /// <returns>A task containing the date and time of the most recent release.</returns>
        public static Task<DateTime> LastReleasedDateTimeAsync()
        {
            return clsDetaindLicenseData.LastReleasedDateTimeAsync();
        }

        /// <summary>
        /// Gets the total fees collected from license detentions.
        /// </summary>
        /// <returns>A task containing the total collected fees.</returns>
        public static Task<float> CollectedFeesAsync()
        {
            return clsDetaindLicenseData.CollectedFeesAsync();
        }

        /// <summary>
        /// Gets the total number of detained license records.
        /// </summary>
        /// <returns>A task containing the total number of detained license records.</returns>
        public static Task<int> GetAllDetainedLicensesCountAsync()
        {
            return clsDetaindLicenseData.TotalDetainedLicensesCountAsync();
        }

    }
}