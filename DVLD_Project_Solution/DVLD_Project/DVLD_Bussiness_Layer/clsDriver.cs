using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Data_Access_Layer.clsDriverData;

namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Represents a driver and provides operations for retrieving, creating,
    /// updating, and accessing driver-related license information.
    /// </summary>
    public class clsDriver
    {
        /// <summary>
        /// Specifies whether the driver is being added or updated.
        /// </summary>
        private enum _enMode { AddNew = 0, Update = 1 };

        private _enMode _Mode = _enMode.AddNew;

        /// <summary>
        /// Gets or sets the unique identifier of the driver.
        /// </summary>
        public int DriverID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the person associated with the driver.
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the driver record.
        /// </summary>
        public int CreatedByUserID { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the driver record was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        private clsPerson _PersonInfo;

        /// <summary>
        /// Gets or sets the person information associated with this driver.
        /// The information is retrieved when first accessed if it has not been loaded.
        /// </summary>
        public clsPerson PersonInfo
        {
            get
            {
                if (_PersonInfo == null && PersonID > 0)
                    _PersonInfo = clsPerson.Find(PersonID);

                return _PersonInfo;
            }
            set
            {
                _PersonInfo = value;
            }
        }

        public clsUser _UserInfo;

        /// <summary>
        /// Gets the user information associated with the user who created this driver.
        /// The information is retrieved when first accessed if it has not been loaded.
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
        /// Initializes a new driver with default values.
        /// </summary>
        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            PersonInfo = null;
            UserInfo = null;
            _Mode = _enMode.AddNew;
        }

        /// <summary>
        /// Initializes an existing driver with the specified information.
        /// </summary>
        /// <param name="DriverID">The unique identifier of the driver.</param>
        /// <param name="PersonID">The identifier of the associated person.</param>
        /// <param name="CreatedByUserID">The identifier of the user who created the record.</param>
        /// <param name="CreatedDate">The date and time when the record was created.</param>
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            _Mode = _enMode.Update;
        }

        /// <summary>
        /// Adds a new driver record to the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the driver is added successfully; otherwise, false.
        /// </returns>
        private async Task<bool> _AddNewDriverAsync()
        {
            this.DriverID = await DVLD_Data_Access_Layer.clsDriverData.AddNewDriverAsync(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID != -1);
        }

        /// <summary>
        /// Updates the current driver's information in the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the driver is updated successfully; otherwise, false.
        /// </returns>
        private Task<bool> _UpdateDriverAsync()
        {
            return DVLD_Data_Access_Layer.clsDriverData.UpdateDriverAsync(
                this.DriverID,
                this.PersonID,
                this.CreatedByUserID,
                this.CreatedDate);
        }

        /// <summary>
        /// Finds a driver by the driver's unique identifier.
        /// </summary>
        /// <param name="DriverID">The identifier of the driver to find.</param>
        /// <returns>
        /// A task containing the matching driver, or null if no driver is found.
        /// </returns>
        public static async Task<clsDriver> FindByDriverIDAsync(int DriverID)
        {
            clsDriverData.clsDriverInfo Result = await DVLD_Data_Access_Layer.clsDriverData.GetDriverInfoByDriverIDAsync(DriverID);
            if (Result != null)
            {
                return new clsDriver(
                    Result.DriverID,
                    Result.PersonID,
                    Result.CreatedByUserID,
                    Result.CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public static clsDriver FindByDriverID(int DriverID)
        {
            clsDriverData.clsDriverInfo Result =  DVLD_Data_Access_Layer.clsDriverData.GetDriverInfoByDriverID(DriverID);
            if (Result != null)
            {
                return new clsDriver(
                    Result.DriverID,
                    Result.PersonID,
                    Result.CreatedByUserID,
                    Result.CreatedDate);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Finds a driver using the identifier of the associated person.
        /// </summary>
        /// <param name="PersonID">The identifier of the person associated with the driver.</param>
        /// <returns>
        /// A task containing the matching driver, or null if no driver is found.
        /// </returns>
        public static async Task<clsDriver> FindByPersonIDAsync(int PersonID)
        {
            clsDriverData.clsDriverInfo Result = await DVLD_Data_Access_Layer.clsDriverData.GetDriverInfoByPersonIDAsync(PersonID);
            if (Result != null)
            {
                return new clsDriver(
                    Result.DriverID,
                    Result.PersonID,
                    Result.CreatedByUserID,
                    Result.CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            clsDriverData.clsDriverInfo Result =  DVLD_Data_Access_Layer.clsDriverData.GetDriverInfoByPersonID(PersonID);
            if (Result != null)
            {
                return new clsDriver(
                    Result.DriverID,
                    Result.PersonID,
                    Result.CreatedByUserID,
                    Result.CreatedDate);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Saves the current driver by adding a new record or updating an existing one,
        /// depending on the current mode.
        /// </summary>
        /// <returns>
        /// A task containing true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:

                    if (await _AddNewDriverAsync())
                    {
                        _Mode = _enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case _enMode.Update:

                    return await _UpdateDriverAsync();
            }

            return false;
        }

        /// <summary>
        /// Retrieves all driver records.
        /// </summary>
        /// <returns>A task containing a data table with all drivers.</returns>
        public static Task<DataTable> GetAllDriversAsync()
        {
            return DVLD_Data_Access_Layer.clsDriverData.GetAllDriversAsync();
        }

        /// <summary>
        /// Retrieves driver records using the driver's view.
        /// </summary>
        /// <returns>A task containing a data table with driver information.</returns>
        public static Task<DataTable> GetAllDrivers_ViewAsync()
        {
            return DVLD_Data_Access_Layer.clsDriverData.GetAllDriversViewAsync();
        }

        //public static bool DeleteDriver(int DriverID)
        //{
        //    return DVLD_Data_Access_Layer.clsDriverData.DeleteDriver(DriverID);
        //}

        /// <summary>
        /// Determines whether a driver exists with the specified driver identifier.
        /// </summary>
        /// <param name="DriverID">The identifier of the driver to check.</param>
        /// <returns>A task containing true if the driver exists; otherwise, false.</returns>
        public static Task<bool> IsDriverExistAsync(int DriverID)
        {
            return DVLD_Data_Access_Layer.clsDriverData.IsDriverExistByDriverIDAsync(DriverID);
        }

        /// <summary>
        /// Determines whether a driver record exists for the specified person.
        /// </summary>
        /// <param name="PersonID">The identifier of the person to check.</param>
        /// <returns>A task containing true if a driver record exists; otherwise, false.</returns>
        public static Task<bool> IsDriverExistByPersonIDAsync(int PersonID)
        {
            return DVLD_Data_Access_Layer.clsDriverData.IsDriverExistByPersonIDAsync(PersonID);
        }

        /// <summary>
        /// Gets the driver identifier associated with the specified person.
        /// </summary>
        /// <param name="PersonId">The identifier of the person.</param>
        /// <returns>A task containing the driver identifier.</returns>
        public static Task<int> GetDriverIDAsync(int PersonId)
        {
            return DVLD_Data_Access_Layer.clsDriverData.GetDriverIDAsync(PersonId);
        }

        /// <summary>
        /// Gets the driver identifier associated with the specified national number.
        /// </summary>
        /// <param name="NationalNo">The national number of the person.</param>
        /// <returns>A task containing the driver identifier.</returns>
        public static Task<int> GetDriverIDAsync(string NationalNo)
        {
            return DVLD_Data_Access_Layer.clsDriverData.GetDriverIDAsync(NationalNo);
        }

        /// <summary>
        /// Gets the national number associated with the specified driver.
        /// </summary>
        /// <param name="DriverID">The identifier of the driver.</param>
        /// <returns>A task containing the national number.</returns>
        public static Task<string> GetNationalNoAsync(int DriverID)
        {
            return DVLD_Data_Access_Layer.clsDriverData.GetNationalNoByDriverIDAsync(DriverID);
        }

        /// <summary>
        /// Retrieves the driving licenses associated with the specified driver.
        /// </summary>
        /// <param name="DriverID">The identifier of the driver.</param>
        /// <returns>A task containing a data table with the driver's licenses.</returns>
        public static Task<DataTable> GetLicensesAsync(int DriverID)
        {
            return clsLicense.GetAllDriverLicensesAsync(DriverID);
        }

        /// <summary>
        /// Retrieves the international licenses associated with the specified driver.
        /// </summary>
        /// <param name="DriverID">The identifier of the driver.</param>
        /// <returns>A task containing a data table with the driver's international licenses.</returns>
        public static Task<DataTable> GetInternationalLicensesAsync(int DriverID)
        {
            return clsInternationalLicense.GetDriverInternationalLicensesAsync(DriverID);
        }

        /// <summary>
        /// Gets the total number of drivers.
        /// </summary>
        /// <returns>A task containing the total driver count.</returns>
        public static Task<int> GetAllDriversCountAsync()
        {
            return clsDriverData.GetAllDriversCountAsync();
        }

        /// <summary>
        /// Gets the number of drivers filtered by their active status.
        /// </summary>
        /// <param name="IsActive">Indicates whether to count active or inactive drivers.</param>
        /// <returns>A task containing the driver count matching the specified status.</returns>
        public static Task<int> GetAllDriversCountAsync(bool IsActive = true)
        {
            return clsDriverData.GetAllDriversCountAsync(IsActive);
        }

        /// <summary>
        /// Gets the number of recently added drivers.
        /// </summary>
        /// <returns>A task containing the count of recently added drivers.</returns>
        public static Task<int> GetRecentlyDriversCountAsync()
        {
            return clsDriverData.GetRecentlyAddedDriversCountAsync();
        }

        /// <summary>
        /// Gets the date and time of the most recent driver update.
        /// </summary>
        /// <returns>A task containing the last update date and time.</returns>
        public static Task<DateTime> GetLastUpdateDateTimeAsync()
        {
            return clsDriverData.GetLastUpdateDateTimeAsync();
        }
    }
}