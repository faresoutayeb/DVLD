using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Data_Access_Layer;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Represents a license class in the DVLD system.
    /// Stores license class information, including its name, description,
    /// minimum allowed age, default validity period, and fees.
    /// Provides methods to find, add, update, delete, and retrieve license classes.
    /// </summary>
    public class clsLicenseClass
    {
        /// <summary>
        /// Specifies the operation mode of the license class object.
        /// </summary>
        public enum enMode
        {
            /// <summary>
            /// Indicates that the license class is new and has not been saved.
            /// </summary>
            AddNew = 0,

            /// <summary>
            /// Indicates that the license class already exists in the database.
            /// </summary>
            Update = 1
        };

        /// <summary>
        /// Gets or sets the current operation mode of the license class.
        /// The default value is AddNew.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the license class.
        /// A value of -1 indicates that the license class has not been saved.
        /// </summary>
        public int LicenseClassID { get; set; }

        /// <summary>
        /// Gets or sets the name of the license class.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets the description of the license class.
        /// </summary>
        public string ClassDescription { get; set; }

        /// <summary>
        /// Gets or sets the minimum age required to obtain this license class.
        /// </summary>

        public byte MinimumAllowedAge { get; set; }

        /// <summary>
        /// Gets or sets the default validity period of the license in years.
        /// </summary>

        [clsValidPositiveNumberAttribute("Default Validity Length  must be positive")]

        public byte DefaultValidityLength { get; set; }

        /// <summary>
        /// Gets or sets the fees associated with this license class.
        /// </summary>
        [clsValidPositiveNumberAttribute("Class Fees must be positive")]

        public float ClassFees { get; set; }

        /// <summary>
        /// Defines the available license classes in the DVLD system.
        /// Each value corresponds to a license class identifier.
        /// </summary>
        public enum enLicenseClasses
        {
            /// <summary>
            /// Class 1: Small motorcycle license.
            /// </summary>
            Class1_SmallMotorcycle = 1,

            /// <summary>
            /// Class 2: Heavy motorcycle license.
            /// </summary>
            Class2_HeavyMotorcycleLicense = 2,

            /// <summary>
            /// Class 3: Ordinary driving license.
            /// </summary>
            Class3_OrdinaryDrivingLicense = 3,

            /// <summary>
            /// Class 4: Commercial driving license.
            /// </summary>
            Class4_Commercial = 4,

            /// <summary>
            /// Class 5: Agricultural vehicle license.
            /// </summary>
            Class5_Agricultural = 5,

            /// <summary>
            /// Class 6: Small and medium bus license.
            /// </summary>
            Class6_SmallAndMediumBus = 6,

            /// <summary>
            /// Class 7: Truck and heavy vehicle license.
            /// </summary>
            Class7_TruckAndHeavyVehicle = 7
        }

        /// <summary>
        /// Initializes a new license class object with default values.
        /// Sets the operation mode to AddNew.
        /// </summary>
        public clsLicenseClass()
        {
            LicenseClassID = -1;
            ClassName = "";
            ClassDescription = "";
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;

            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing license class object with the specified values.
        /// Sets the operation mode to Update.
        /// </summary>
        /// <param name="LicenseClassID">
        /// The unique identifier of the license class.
        /// </param>
        /// <param name="ClassName">
        /// The name of the license class.
        /// </param>
        /// <param name="ClassDescription">
        /// The description of the license class.
        /// </param>
        /// <param name="MinimumAllowedAge">
        /// The minimum age required to obtain this license class.
        /// </param>
        /// <param name="DefaultValidityLength">
        /// The default validity period of the license in years.
        /// </param>
        /// <param name="ClassFees">
        /// The fees associated with the license class.
        /// </param>
        private clsLicenseClass(
            int LicenseClassID,
            string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge,
            byte DefaultValidityLength,
            float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;
        }

        /// <summary>
        /// Adds a new license class to the database.
        /// Updates LicenseClassID with the generated identifier.
        /// </summary>
        /// <returns>
        /// A task containing true if the license class was added successfully;
        /// otherwise, false.
        /// </returns>
        private async Task<bool> _AddNewLicenseClassAsync()
        {
            LicenseClassID =
                await clsLicensesClassData.AddNewLicenseClassAsync(
                    ClassName,
                    ClassDescription,
                    MinimumAllowedAge,
                    DefaultValidityLength,
                    ClassFees);

            return LicenseClassID != -1;
        }

        /// <summary>
        /// Updates the existing license class in the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the update succeeds; otherwise, false.
        /// </returns>
        private Task<bool> _UpdateLicenseClassAsync()
        {
            return clsLicensesClassData.UpdateLicenseClassAsync(
                LicenseClassID,
                ClassName,
                ClassDescription,
                MinimumAllowedAge,
                DefaultValidityLength,
                ClassFees);
        }

        /// <summary>
        /// Retrieves a license class using its unique identifier.
        /// </summary>
        /// <param name="LicenseClassID">
        /// The identifier of the license class to retrieve.
        /// </param>
        /// <returns>
        /// A task containing the matching license class if found;
        /// otherwise, null.
        /// </returns>
        public static async Task<clsLicenseClass> FindAsync(int LicenseClassID)
        {
            clsLicensesClassData.clsLicenseClassInfo Result =
                await clsLicensesClassData.GetLicenseClassInfoByIDAsync(
                    LicenseClassID);

            if (Result != null)
            {
                return new clsLicenseClass(
                    Result.LicenseClassID,
                    Result.ClassName,
                    Result.ClassDescription,
                    Result.MinimumAllowedAge,
                    Result.DefaultValidityLength,
                    Result.ClassFees);
            }

            return null;
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            clsLicensesClassData.clsLicenseClassInfo Result =
                 clsLicensesClassData.GetLicenseClassInfoByID(
                    LicenseClassID);

            if (Result != null)
            {
                return new clsLicenseClass(
                    Result.LicenseClassID,
                    Result.ClassName,
                    Result.ClassDescription,
                    Result.MinimumAllowedAge,
                    Result.DefaultValidityLength,
                    Result.ClassFees);
            }

            return null;
        }


        /// <summary>
        /// Retrieves a license class using its name.
        /// </summary>
        /// <param name="LicenseClassName">
        /// The name of the license class to retrieve.
        /// </param>
        /// <returns>
        /// A task containing the matching license class if found;
        /// otherwise, null.
        /// </returns>
        public static async Task<clsLicenseClass> FindAsync(string LicenseClassName)
        {
            clsLicensesClassData.clsLicenseClassInfo Result =
                await clsLicensesClassData.GetLicenseClassInfoByClassNameAsync(
                    LicenseClassName);

            if (Result != null)
            {
                return new clsLicenseClass(
                    Result.LicenseClassID,
                    Result.ClassName,
                    Result.ClassDescription,
                    Result.MinimumAllowedAge,
                    Result.DefaultValidityLength,
                    Result.ClassFees);
            }

            return null;
        }
        public static clsLicenseClass Find(string LicenseClassName)
        {
            clsLicensesClassData.clsLicenseClassInfo Result =
                 clsLicensesClassData.GetLicenseClassInfoByClassName(
                    LicenseClassName);

            if (Result != null)
            {
                return new clsLicenseClass(
                    Result.LicenseClassID,
                    Result.ClassName,
                    Result.ClassDescription,
                    Result.MinimumAllowedAge,
                    Result.DefaultValidityLength,
                    Result.ClassFees);
            }

            return null;
        }

        /// <summary>
        /// Saves the current license class to the database.
        /// Adds a new record when Mode is AddNew or updates an existing
        /// record when Mode is Update.
        /// </summary>
        /// <returns>
        /// A task containing true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewLicenseClassAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:
                    return await _UpdateLicenseClassAsync();
            }

            return false;
        }

        /// <summary>
        /// Retrieves all license classes from the database.
        /// </summary>
        /// <returns>
        /// A task containing a DataTable with all license class records.
        /// </returns>
        public static Task<DataTable> GetAllLicenseClassesNamesAsync()
        {
            return clsLicensesClassData.GetAllLicenseClassesNameAsync();
        }

        public static Task<DataTable> GetAllLicenseClassesAsync()
        {
            return clsLicensesClassData.GetAllLicenseClassesAsync();
        }

        /// <summary>
        /// Deletes a license class from the database using its identifier.
        /// </summary>
        /// <param name="LicenseClassID">
        /// The identifier of the license class to delete.
        /// </param>
        /// <returns>
        /// A task containing true if the deletion succeeds; otherwise, false.
        /// </returns>
        public static Task<bool> DeleteLicenseClassAsync(int LicenseClassID)
        {
            return clsLicensesClassData.DeleteLicenseClassAsync(
                LicenseClassID);
        }

        /// <summary>
        /// Determines whether a license class exists using its identifier.
        /// </summary>
        /// <param name="LicenseClassID">
        /// The identifier of the license class to check.
        /// </param>
        /// <returns>
        /// A task containing true if the license class exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsLicenseClassExistAsync(int LicenseClassID)
        {
            return clsLicensesClassData.IsLicenseClassExistAsync(
                LicenseClassID);
        }

        /// <summary>
        /// Determines whether a license class exists using its name.
        /// </summary>
        /// <param name="LicenseClassName">
        /// The name of the license class to check.
        /// </param>
        /// <returns>
        /// A task containing true if the license class exists; otherwise, false.
        /// </returns>
        public static Task<bool> IsLicenseClassExistAsync(string LicenseClassName)
        {
            return clsLicensesClassData.IsLicenseClassExistAsync(
                LicenseClassName);
        }

        /// <summary>
        /// Retrieves the fees associated with a license class.
        /// </summary>
        /// <param name="LicenseClassID">
        /// The identifier of the license class.
        /// </param>
        /// <returns>
        /// A task containing the fees of the specified license class.
        /// </returns>
        public static Task<float> GetLicenseClassFeesByIDAsync(int LicenseClassID)
        {
            return clsLicensesClassData.GetLicenseClassFeesByIDAsync(
                LicenseClassID);
        }

        /// <summary>
        /// Retrieves the name of a license class using its identifier.
        /// </summary>
        /// <param name="LicenseClassID">
        /// The identifier of the license class.
        /// </param>
        /// <returns>
        /// A task containing the name of the specified license class.
        /// </returns>
        public static Task<string> GetLicenseClassNameAsync(int LicenseClassID)
        {
            return clsLicensesClassData.GetLicenseClassNameByIDAsync(
                LicenseClassID);
        }

        /// <summary>
        /// Retrieves the identifier of a license class using its name.
        /// </summary>
        /// <param name="LicenseClassName">
        /// The name of the license class.
        /// </param>
        /// <returns>
        /// A task containing the identifier of the specified license class.
        /// </returns>
        public static Task<int> GetLicenseCLassIDAsync(string LicenseClassName)
        {
            return clsLicensesClassData.GetLicenseClassIDByNameAsync(
                LicenseClassName);
        }

    }
}