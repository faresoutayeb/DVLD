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
    /// Represents an application type and provides operations for creating,
    /// updating, retrieving, and managing application types.
    /// </summary>
    public class clsApplicationType
    {
        /// <summary>
        /// Specifies whether the application type is being created or updated.
        /// </summary>
        public enum enMode { AddNew = 0, Update = 1 };

        /// <summary>
        /// Stores the current operation mode of the application type.
        /// </summary>
        private enMode _Mode = enMode.AddNew;

        /// <summary>
        /// Defines the available application types supported by the system.
        /// </summary>
        public enum enApplicationType
        {
            /// <summary>
            /// Represents a new local driving license application.
            /// </summary>
            NewLocalDrivingLicenseService = 1,

            /// <summary>
            /// Represents a driving license renewal application.
            /// </summary>
            RenewDrivingLicense = 2,

            /// <summary>
            /// Represents an application to replace a lost driving license.
            /// </summary>
            ReplacementForLostDrivingLicense = 3,

            /// <summary>
            /// Represents an application to replace a damaged driving license.
            /// </summary>
            ReplacementForDamagedDrivingLicense = 4,

            /// <summary>
            /// Represents an application to release a detained driving license.
            /// </summary>
            ReleaseDetainedDrivingLicense = 5,

            /// <summary>
            /// Represents a new international driving license application.
            /// </summary>
            NewInternationalLicense = 6,

            /// <summary>
            /// Represents an application to retake a test.
            /// </summary>
            RetakeTest = 7,

            /// <summary>
            /// Represents the absence of an application type.
            /// </summary>
            NoApp = 0,
        }

        /// <summary>
        /// Gets or sets the identifier of the application type.
        /// </summary>
        public clsApplicationType.enApplicationType ApplicationTypeID { get; set; }

        /// <summary>
        /// Gets or sets the title of the application type.
        /// </summary>
        public string ApplicationTypeTitle { get; set; }

        /// <summary>
        /// Gets or sets the fees associated with the application type.
        /// </summary>
        [clsValidPositiveNumberAttribute("Application Fees must be positive")]
        public float ApplicationFees { get; set; }

        /// <summary>
        /// Initializes a new application type with default values
        /// and sets its mode to <see cref="enMode.AddNew"/>.
        /// </summary>
        public clsApplicationType()
        {
            this.ApplicationTypeID = enApplicationType.NoApp;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;

            _Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an application type with the specified information
        /// and sets its mode to <see cref="enMode.Update"/>.
        /// </summary>
        /// <param name="ApplicationTypeID">The identifier of the application type.</param>
        /// <param name="ApplicationTypeTitle">The title of the application type.</param>
        /// <param name="ApplicationFees">The fees associated with the application type.</param>
        private clsApplicationType(clsApplicationType.enApplicationType ApplicationTypeID,
            string ApplicationTypeTitle, float ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;

            _Mode = enMode.Update;
        }

        /// <summary>
        /// Updates the current application type asynchronously.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the update succeeds;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        private Task<bool> _UpdateApplicationTypeAsync()
        {
            return DVLD_Data_Access_Layer.clsApplicationsTypesData.UpdateApplicationTypeAsync(
                (byte)this.ApplicationTypeID,
                this.ApplicationTypeTitle,
                this.ApplicationFees
            );
        }

        /// <summary>
        /// Creates a new application type asynchronously using the current instance data.
        /// </summary>
        /// <returns>
        /// A task containing <see langword="true"/> if the application type is created
        /// successfully; otherwise, <see langword="false"/>.
        /// </returns>
        private async Task<bool> _AddNewApplicationTypeAsync()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = (clsApplicationType.enApplicationType)await clsApplicationsTypesData.AddNewApplicationTypeAsync(this.ApplicationTypeTitle, this.ApplicationFees);

            return ((sbyte)this.ApplicationTypeID != -1);
        }

        /// <summary>
        /// Retrieves an application type by its identifier.
        /// </summary>
        /// <param name="ApplicationTypeID">The identifier of the application type to retrieve.</param>
        /// <returns>
        /// A task containing the application type if found; otherwise,
        /// <see langword="null"/>.
        /// </returns>
        public static async Task<clsApplicationType> FindApplicationTypeAsync(clsApplicationType.enApplicationType ApplicationTypeID)
        {

            clsApplicationsTypesData.ApplicationTypeInfoResult Result = await DVLD_Data_Access_Layer.clsApplicationsTypesData.GetApplicationTypeInfoByIDAsync(
                    (byte)ApplicationTypeID);

            if (Result  != null)
                return new clsApplicationType(
                   (enApplicationType) Result.ApplicationTypeID,
                    Result.ApplicationTypeTitle,
                    Result.ApplicationFees
                );
            else
                return null;
        }
        public static clsApplicationType FindApplicationType(clsApplicationType.enApplicationType ApplicationTypeID)
        {

            clsApplicationsTypesData.ApplicationTypeInfoResult Result =  DVLD_Data_Access_Layer.clsApplicationsTypesData.GetApplicationTypeInfoByID(
                    (byte)ApplicationTypeID);

            if (Result != null)
                return new clsApplicationType(
                   (enApplicationType)Result.ApplicationTypeID,
                    Result.ApplicationTypeTitle,
                    Result.ApplicationFees
                );
            else
                return null;
        }
        /// <summary>
        /// Retrieves an application type by its title.
        /// </summary>
        /// <param name="ApplicationTypeTitle">The title of the application type to retrieve.</param>
        /// <returns>
        /// A task containing the application type if found; otherwise,
        /// <see langword="null"/>.
        /// </returns>
        public static async Task<clsApplicationType> FindApplicationTypeAsync(string ApplicationTypeTitle)
        {
   

            clsApplicationsTypesData.ApplicationTypeInfoResult Result = await DVLD_Data_Access_Layer.clsApplicationsTypesData.GetApplicationTypeInfoByTitleAsync(ApplicationTypeTitle);

            if (Result != null)
                return new clsApplicationType(
                   (enApplicationType)Result.ApplicationTypeID,
                    Result.ApplicationTypeTitle,
                    Result.ApplicationFees
                );
            else
                return null;
        }
        public static clsApplicationType FindApplicationType(string ApplicationTypeTitle)
        {


            clsApplicationsTypesData.ApplicationTypeInfoResult Result =  DVLD_Data_Access_Layer.clsApplicationsTypesData.GetApplicationTypeInfoByTitle(ApplicationTypeTitle);

            if (Result != null)
                return new clsApplicationType(
                   (enApplicationType)Result.ApplicationTypeID,
                    Result.ApplicationTypeTitle,
                    Result.ApplicationFees
                );
            else
                return null;
        }

        /// <summary>
        /// Saves the application type by creating a new record or updating
        /// an existing record according to the current mode.
        /// </summary>
        /// <returns>
        /// A task containing the result of the save operation.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewApplicationTypeAsync())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    _Mode = enMode.Update;
                    return true;

                //return false;

                case enMode.Update:
                    return await _UpdateApplicationTypeAsync();
            }

            return false;
        }

        /// <summary>
        /// Retrieves all application types asynchronously.
        /// </summary>
        /// <returns>
        /// A task containing a <see cref="DataTable"/> with all application types.
        /// </returns>
        public static Task<DataTable> GetAllApplicationTypesAsync()
        {
            return DVLD_Data_Access_Layer.clsApplicationsTypesData.GetAllApplicationTypesAsync();
        }

        /// <summary>
        /// Retrieves the total number of application types.
        /// </summary>
        /// <returns>A task containing the number of application types.</returns>
        public static Task<byte> GetApplicationsTypesCountAsync()
        {
            return DVLD_Data_Access_Layer.clsApplicationsTypesData.GetAllApplicationTypesCountAsync();
        }

        /// <summary>
        /// Determines whether an application type with the specified identifier exists.
        /// </summary>
        /// <param name="ApplicationTypeID">The identifier of the application type.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if the application type exists;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsApplicationTypeExistAsync(int ApplicationTypeID)
        {
            return DVLD_Data_Access_Layer.clsApplicationsTypesData.IsApplicationTypeExistAsync(ApplicationTypeID);
        }

        /// <summary>
        /// Determines whether an application type with the specified title exists.
        /// </summary>
        /// <param name="ApplicationTypeTitle">The title of the application type.</param>
        /// <returns>
        /// A task containing <see langword="true"/> if the application type exists;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsApplicationTypeExistAsync(string ApplicationTypeTitle)
        {
            return DVLD_Data_Access_Layer.clsApplicationsTypesData.IsApplicationTypeExistAsync(ApplicationTypeTitle);
        }

        /// <summary>
        /// Retrieves the fees associated with the specified application type.
        /// </summary>
        /// <param name="ApplicationTypeID">The identifier of the application type.</param>
        /// <returns>A task containing the application fees.</returns>
        public static async Task<float> GetApplicationFeesByIDAsync(clsApplicationType.enApplicationType ApplicationTypeID)
        {
            return await clsApplicationsTypesData.GetApplicationFeesByIDAsync((byte)ApplicationTypeID);
        }
    }
}