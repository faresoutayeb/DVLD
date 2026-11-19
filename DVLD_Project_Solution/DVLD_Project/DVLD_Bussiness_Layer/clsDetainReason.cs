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
    /// Represents a reason for detaining a driving license and provides operations
    /// for retrieving, creating, and updating detention reasons.
    /// </summary>
    public class clsDetainReason
    {
        /// <summary>
        /// Gets or sets the unique identifier of the detention reason.
        /// </summary>
        public int DetainReasonID { get; set; }

        /// <summary>
        /// Gets or sets the text describing the detention reason.
        /// </summary>
        public string ReasonText { get; set; }

        /// <summary>
        /// Specifies whether the object represents a new record or an existing record.
        /// </summary>
        public enum enMode { AddNew = 0, Update = 1 };

        /// <summary>
        /// Gets or sets the current operation mode of the object.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Initializes a new detention reason with default values.
        /// </summary>
        public clsDetainReason()
        {
            DetainReasonID = -1;
            ReasonText = "";
        }

        /// <summary>
        /// Initializes a detention reason with the specified identifier and description.
        /// </summary>
        /// <param name="DetainReasonID">The unique identifier of the detention reason.</param>
        /// <param name="ReasonText">The description of the detention reason.</param>
        private clsDetainReason(int DetainReasonID, string ReasonText)
        {
            this.DetainReasonID = DetainReasonID;
            this.ReasonText = ReasonText;

            Mode = enMode.Update;
        }

        /// <summary>
        /// Adds a new detention reason to the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the detention reason is added successfully;
        /// otherwise, false.
        /// </returns>
        private async Task<bool> _AddNewDetainReasonAsync()
        {
            this.DetainReasonID = await DVLD_Data_Access_Layer.clsDetainReasonData.AddNewDetainReasonAsync(
                this.ReasonText
            );

            return (this.DetainReasonID != -1);
        }

        /// <summary>
        /// Updates the current detention reason in the database.
        /// </summary>
        /// <returns>
        /// A task containing true if the detention reason is updated successfully;
        /// otherwise, false.
        /// </returns>
        private Task<bool> _UpdateDetainReasonAsync()
        {
            return DVLD_Data_Access_Layer.clsDetainReasonData.UpdateDetainReasonAsync(
                this.DetainReasonID,
                this.ReasonText
            );
        }

        /// <summary>
        /// Retrieves all detention reasons.
        /// </summary>
        /// <returns>A task containing a data table with all detention reasons.</returns>
        public static Task<DataTable> GetAllDetainReasonsAsync()
        {
            return DVLD_Data_Access_Layer.clsDetainReasonData.GetAllDetainReasonsAsync();
        }

        /// <summary>
        /// Finds a detention reason by its identifier.
        /// </summary>
        /// <param name="DetainReasonID">The identifier of the detention reason.</param>
        /// <returns>
        /// A task containing the matching detention reason, or null if no matching
        /// record is found.
        /// </returns>
        public static async Task<clsDetainReason> FindAsync(int DetainReasonID)
        {

            clsDetainReasonData.clsDetainReasonInfo Result = await DVLD_Data_Access_Layer.clsDetainReasonData.GetDetainReasonInfoByIDAsync(DetainReasonID);

            if (Result != null)
            {
                return new clsDetainReason(
                    Result.DetainReasonID,
                    Result.ReasonText
                );
            }
            else
                return null;
        }
        public static async Task<clsDetainReason> FindAsync(string DetainReasonText)
        {

            clsDetainReasonData.clsDetainReasonInfo Result = await DVLD_Data_Access_Layer.clsDetainReasonData.GetDetainReasonInfoByNameAsync(  DetainReasonText);

            if (Result != null)
            {
                return new clsDetainReason(
                    Result.DetainReasonID,
                    Result.ReasonText
                );
            }
            else
                return null;
        }

        public static clsDetainReason Find(int DetainReasonID)
        {

            clsDetainReasonData.clsDetainReasonInfo Result =  DVLD_Data_Access_Layer.clsDetainReasonData.GetDetainReasonInfoByID(DetainReasonID);

            if (Result != null)
            {
                return new clsDetainReason(
                    Result.DetainReasonID,
                    Result.ReasonText
                );
            }
            else
                return null;
        }

        public static clsDetainReason Find(string  DetainReasonText)
        {

            clsDetainReasonData.clsDetainReasonInfo Result = DVLD_Data_Access_Layer.clsDetainReasonData.GetDetainReasonInfoByName(DetainReasonText);

            if (Result != null)
            {
                return new clsDetainReason(
                    Result.DetainReasonID,
                    Result.ReasonText
                );
            }
            else
                return null;
        }

        /// <summary>
        /// Saves the current detention reason by adding a new record or updating
        /// an existing record according to the current mode.
        /// </summary>
        /// <returns>
        /// A task containing true if the operation succeeds; otherwise, false.
        /// </returns>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewDetainReasonAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdateDetainReasonAsync();
            }

            return false;
        }

    }
}