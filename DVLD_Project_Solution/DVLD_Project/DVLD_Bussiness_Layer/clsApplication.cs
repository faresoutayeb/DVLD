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
    /// Represents an application and provides operations for creating, updating,
    /// retrieving, deleting, and changing its status.
    /// </summary>
    public class clsApplication
    {

        public event Action OnApplicationSaved;
        protected virtual void ApplicationSaved()
        {
            OnApplicationSaved?.Invoke();
        }
        public event Action OnApplicationNotSaved;
        protected virtual void ApplicationNotSaved()
        {
            OnApplicationNotSaved?.Invoke();
        }
        /// <summary>
        /// Specifies whether the application is being created or updated.
        /// </summary>
        public enum enMode { AddNew = 0, Update = 1 };

        /// <summary>
        /// Gets or sets the current operation mode of the application.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Specifies the possible statuses of an application.
        /// </summary>
        public enum enApplicationStatus { New = 1, Canceled = 2, completed = 3 }

        /// <summary>
        /// Gets or sets the unique identifier of the application.
        /// </summary>
        public int ApplicationID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the person who submitted the application.
        /// </summary>
        public int ApplicantPersonID { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the application was created.
        /// </summary>
        public DateTime ApplicationDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the application type.
        /// </summary>
        public int ApplicationTypeID { get; set; }

        /// <summary>
        /// Gets or sets the current status of the application.
        /// </summary>
        public enApplicationStatus ApplicationStatus { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the application status was last changed.
        /// </summary>
        public DateTime LastStatusDate { get; set; }

        /// <summary>
        /// Gets or sets the fees paid for the application.
        /// </summary>
        [clsValidPositiveNumberAttribute("PaidFees must be positive")]
        public float PaidFees { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the application.
        /// </summary>
        public int CreatedByUserID { get; set; }

        /// <summary>
        /// Gets the display name corresponding to the current application status.
        /// </summary>
        public string ApplicationStatusName
        {
            get
            {
                return ApplicationStatusString((enApplicationStatus)ApplicationStatus);
            }
        }

        /// <summary>
        /// Stores the user associated with the application.
        /// </summary>
        private clsUser _UserInfo;

        /// <summary>
        /// Stores information about the applicant.
        /// </summary>
        private clsPerson _personInfo;

        /// <summary>
        /// Stores information about the application type.
        /// </summary>
        private clsApplicationType _ApplicationType;

        /// <summary>
        /// Gets the user who created the application, loading the information
        /// when necessary.
        /// </summary>
        public clsUser UserInfo
        {
            get
            {
                if (_UserInfo == null && CreatedByUserID > 0)
                {
                    _UserInfo = clsUser.FindByUserID(CreatedByUserID);

                }

                return _UserInfo;
            }
            private set
            {
                _UserInfo = value;
            }
        }

        /// <summary>
        /// Gets the applicant's person information, loading it when necessary.
        /// </summary>
        public clsPerson PersonInfo
        {
            get
            {
                if (_personInfo == null && ApplicantPersonID > 0)
                    _personInfo = clsPerson.Find(ApplicantPersonID);

                return _personInfo;
            }
            private set
            {
                _personInfo = value;
            }
        }

        /// <summary>
        /// Gets the application type information, loading it when necessary.
        /// </summary>
        public clsApplicationType ApplicationType
        {
            get
            {
                if (_ApplicationType == null && ApplicationTypeID > 0)
                    _ApplicationType = clsApplicationType.FindApplicationType((clsApplicationType.enApplicationType)ApplicationTypeID);

                return _ApplicationType;
            }
            private set
            {
                _ApplicationType = value;
            }
        }

        /// <summary>
        /// Initializes a new application with default values and sets its mode
        /// to <see cref="enMode.AddNew"/>.
        /// </summary>
        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.UserInfo = null;
            this.ApplicationType = null;

            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Deletes the current application asynchronously.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the application was deleted; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public Task<bool> DeleteAsync()
        {
            return clsApplicationData.DeleteApplicationAsync(this.ApplicationID);
        }

        /// <summary>
        /// Initializes an application with the specified data and sets its mode
        /// to <see cref="enMode.Update"/>.
        /// </summary>
        /// <param name="ID">The unique identifier of the application.</param>
        /// <param name="ApplicantPersonID">The identifier of the applicant.</param>
        /// <param name="ApplicationDate">The date and time the application was created.</param>
        /// <param name="ApplicationTypeID">The identifier of the application type.</param>
        /// <param name="ApplicationStatus">The current application status.</param>
        /// <param name="LastStatusDate">The date and time of the last status change.</param>
        /// <param name="PaidFees">The fees paid for the application.</param>
        /// <param name="CreatedByUserID">The identifier of the user who created the application.</param>
        private clsApplication(int ID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        /// <summary>
        /// Converts an application status to its corresponding display string.
        /// </summary>
        /// <param name="ApplicationStatus">The application status to convert.</param>
        /// <returns>The display string corresponding to the specified status.</returns>
        public static string ApplicationStatusString(enApplicationStatus ApplicationStatus)
        {
            switch (ApplicationStatus)
            {
                case enApplicationStatus.New:
                    return "New App";
                case enApplicationStatus.Canceled:
                    return "Canceled App";
                case enApplicationStatus.completed:
                    return "Completd App";
                default:
                    return "Unknow";
            }
        }

        //-------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Creates a new application asynchronously using the current instance data.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the application was created
        /// successfully; otherwise, <see langword="false"/>.
        /// </returns>
        private async Task<bool> _AddNewApplicationAsync()
        {
            this.ApplicationID = await DVLD_Data_Access_Layer.clsApplicationData.AddNewApplicationAsync
               (
                   this.ApplicantPersonID,
                   this.ApplicationDate,
                   this.ApplicationTypeID,
                   (byte)this.ApplicationStatus,
                   this.LastStatusDate,
                   this.PaidFees,
                   this.CreatedByUserID
               );

            return (this.ApplicationID != -1);
        }

        /// <summary>
        /// Updates the existing application asynchronously using the current instance data.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the application was updated
        /// successfully; otherwise, <see langword="false"/>.
        /// </returns>
        private Task<bool> _UpdateApplicationAsync()
        {
            return DVLD_Data_Access_Layer.clsApplicationData.UpdateApplicationAsync
                (
                    this.ApplicationID,
                    this.ApplicantPersonID,
                    this.ApplicationDate,
                    this.ApplicationTypeID,
                    (byte)this.ApplicationStatus,
                    this.LastStatusDate,
                    this.PaidFees,
                    this.CreatedByUserID
                );
        }

        /// <summary>
        /// Retrieves an application by its unique identifier.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application to retrieve.</param>
        /// <returns>
        /// A task containing the application if found; otherwise, <see langword="null"/>.
        /// </returns>
        public static async Task<clsApplication> FindApplicationAsync(int ApplicationID)
        {
            clsApplicationData.ApplicationInfoResult Result =
                await clsApplicationData.GetApplicationInfoByIDAsync(ApplicationID);

            if (Result == null)
                return null;

            return new clsApplication(
                ApplicationID,
                Result.ApplicationPersonID,
                Result.ApplicationDate,
                Result.ApplicationTypeID,
                (enApplicationStatus)Result.ApplicationStatus,
                Result.LastStatusDate,
                Result.PaidFees,
                Result.CreatedByUserID
            );
        }

        public static  clsApplication FindApplication(int ApplicationID)
        {
            clsApplicationData.ApplicationInfoResult Result =
                 clsApplicationData.GetApplicationInfoByID(ApplicationID);

            if (Result == null)
                return null;

            return new clsApplication(
                ApplicationID,
                Result.ApplicationPersonID,
                Result.ApplicationDate,
                Result.ApplicationTypeID,
                (enApplicationStatus)Result.ApplicationStatus,
                Result.LastStatusDate,
                Result.PaidFees,
                Result.CreatedByUserID
            );
        }


        /// <summary>
        /// Deletes an application using its unique identifier.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application to delete.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if the application was deleted;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> DeleteApplicationAsync(int ApplicationID)
        {
            return DVLD_Data_Access_Layer.clsApplicationData.DeleteApplicationAsync(ApplicationID);
        }

        /// <summary>
        /// Saves the application by creating a new record or updating an existing one,
        /// depending on the current mode.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the operation succeeded;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
 
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        if (await _AddNewApplicationAsync())
                        {
                            Mode = enMode.Update;
                            ApplicationSaved();
                            return true;
                        }
                        else
                        {
                            ApplicationNotSaved();
                            return false;
                        }
                        break;
                    }

                case enMode.Update:

                    {
                        if(await _UpdateApplicationAsync())
                        {
                            ApplicationNotSaved();
                            return true;
                        }

                    }
                    break ;

            }

            return false;
        }

        //-------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Updates the status of the specified application asynchronously.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application.</param>
        /// <param name="NewStatus">The new status to assign to the application.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if the status was updated;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> UpdateStatusAsync(int ApplicationID, enApplicationStatus NewStatus)
        {
            return DVLD_Data_Access_Layer.clsApplicationData.UpdateStatusAsync(ApplicationID, (byte)NewStatus);
        }

        /// <summary>
        /// Updates the status of the current application asynchronously.
        /// </summary>
        /// <param name="NewStatus">The new status to assign to the application.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if the status was updated;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public Task<bool> UpdateStatusAsync(enApplicationStatus NewStatus)
        {
            return UpdateStatusAsync(this.ApplicationID, NewStatus);
        }

        //-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Cancels the current application asynchronously.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the application status
        /// was updated successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> CanselAsync()
        {
            if(await UpdateStatusAsync(this.ApplicationID, enApplicationStatus.Canceled))
            {
                this.ApplicationStatus = enApplicationStatus.Canceled;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Marks the current application as completed asynchronously.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the application status
        /// was updated successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public async Task<bool> CompletedAsync()
        {
            if (await UpdateStatusAsync(this.ApplicationID, enApplicationStatus.completed))
            {
                this.ApplicationStatus = enApplicationStatus.Canceled;

                return true;
            }
            else
            {
                return false;
            }
        }

        //-------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Determines whether an application with the specified identifier exists.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if the application exists;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsApplicationExistAsync(int ApplicationID)
        {
            return DVLD_Data_Access_Layer.clsApplicationData.IsApplicationExistAsync(ApplicationID);
        }

        /// <summary>
        /// Retrieves the identifier of the person associated with the specified application.
        /// </summary>
        /// <param name="ApplicationID">The unique identifier of the application.</param>
        /// <returns>
        /// A task containing the identifier of the applicant.
        /// </returns>
        public static Task<int> GetApplicationPersonIDAsync(int ApplicationID)
        {
            return DVLD_Data_Access_Layer.clsApplicationData.GetApplicationPersonIDAsync(ApplicationID);
        }

        //-------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Retrieves all applications asynchronously.
        /// </summary>
        /// <returns>
        /// A task containing a <see cref="DataTable"/> with all application records.
        /// </returns>
        public static Task<DataTable> GetAllApplicationsAsync()
        {
            return DVLD_Data_Access_Layer.clsApplicationData.GetAllApplicationsAsync();
        }

        /// <summary>
        /// Retrieves basic information for all applications asynchronously.
        /// </summary>
        /// <returns>
        /// A task containing a <see cref="DataTable"/> with basic application information.
        /// </returns>
        public static Task<DataTable> GetAllApplicationsBasicInfoAsync()
        {
            return DVLD_Data_Access_Layer.clsApplicationData.GetAllApplicationsBasicInfoAsync();
        }

        /// <summary>
        /// Retrieves all applications associated with the specified person.
        /// </summary>
        /// <param name="ApplicantPersonID">The identifier of the applicant.</param>
        /// <returns>
        /// A task containing a <see cref="DataTable"/> with the person's applications.
        /// </returns>
        public static Task<DataTable> GetApplicationsByPersonIDAsync(int ApplicantPersonID)
        {
            return DVLD_Data_Access_Layer.clsApplicationData.GetApplicationsByPersonIDAsync(ApplicantPersonID);
        }

        //-------------------------------------------------------------------------------------------------------------

        //static 

        /// <summary>
        /// Determines whether the specified person has an active application
        /// of the specified application type.
        /// </summary>
        /// <param name="PersonID">The identifier of the person.</param>
        /// <param name="ApplicationTypeID">The identifier of the application type.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if the person has an active
        /// application of the specified type; otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> DoesPersonHaveActiveApplicationAsync(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplicationAsync(PersonID, ApplicationTypeID);
        }
        /// <summary>
        /// Determines whether the current applicant has an active application
        /// of the specified application type.
        /// </summary>
        /// <param name="ApplicationTypeID">The identifier of the application type.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if the applicant has an active
        /// application of the specified type; otherwise, <see langword="false"/>.
        /// </returns>
        // the same but using the current object
        public Task<bool> DoesPersonHaveActiveApplicationAsync(int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplicationAsync(this.ApplicantPersonID, ApplicationTypeID);
        }

        //-------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Retrieves the identifier of the active application for the specified person
        /// and application type.
        /// </summary>
        /// <param name="PersonID">The identifier of the person.</param>
        /// <param name="ApplicationTypeID">The type of application to search for.</param>
        /// <returns>A task containing the active application identifier.</returns>
        //static 
        public static Task<int> GetActiveApplicationIDAsync(int PersonID, clsApplicationType.enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationIDAsync(PersonID, (int)ApplicationTypeID);
        }

        /// <summary>
        /// Retrieves the identifier of the active application for the current applicant
        /// and the specified application type.
        /// </summary>
        /// <param name="ApplicationTypeID">The type of application to search for.</param>
        /// <returns>A task containing the active application identifier.</returns>
        // the same but using the current object
        public Task<int> GetActiveApplicationIDAsync(clsApplicationType.enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationIDAsync(this.ApplicantPersonID, ApplicationTypeID);
        }

        //-------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Retrieves the identifier of the active application for the specified person,
        /// application type, and license class.
        /// </summary>
        /// <param name="PersonID">The identifier of the person.</param>
        /// <param name="ApplicationTypeID">The type of application to search for.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>A task containing the active application identifier.</returns>
        //static 
        public static Task<int> GetActiveApplicationIDForLicenseClassAsync(int PersonID, clsApplicationType.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClassAsync(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        /// <summary>
        /// Retrieves the identifier of the active application for the current applicant,
        /// specified application type, and license class.
        /// </summary>
        /// <param name="ApplicationTypeID">The type of application to search for.</param>
        /// <param name="LicenseClassID">The identifier of the license class.</param>
        /// <returns>A task containing the active application identifier.</returns>
        // the same but using the current object
        public Task<int> GetActiveApplicationIDForLicenseClassAsync(clsApplicationType.enApplicationType ApplicationTypeID, int LicenseClassID)

        {
            return clsApplication.GetActiveApplicationIDForLicenseClassAsync(this.ApplicantPersonID, (clsApplicationType.enApplicationType)ApplicationTypeID, LicenseClassID);

        }

        //-------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Retrieves recent application records asynchronously.
        /// </summary>
        /// <returns>A task containing a <see cref="DataTable"/> with recent applications.</returns>
        static public Task<DataTable> GetRecentApplicationAsync()
        {
            return clsApplicationData.GetRecentApplicationsAsync();
        }

        /// <summary>
        /// Retrieves the number of applications with the specified status.
        /// </summary>
        /// <param name="Status">The application status used to filter the count.</param>
        /// <returns>A task containing the number of applications with the specified status.</returns>
        static public Task<int> GetApplicationsCountAsync(enApplicationStatus Status)
        {
            return clsApplicationData.GetApplicationCountByStatusAsync((byte)Status);
        }

        /// <summary>
        /// Retrieves the total number of applications.
        /// </summary>
        /// <returns>A task containing the total number of applications.</returns>
        static public Task<int> GetApplicationsCountAsync()
        {
            return clsApplicationData.GetApplicationsCountAsync();
        }
    }
}