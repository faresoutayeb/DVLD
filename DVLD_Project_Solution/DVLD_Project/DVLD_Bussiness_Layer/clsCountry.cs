using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Bussiness_Layer
{
    /// <summary>
    /// Provides business logic for retrieving country information.
    /// </summary>
    public class clsCountry
    {
        /// <summary>
        /// Gets or sets the unique identifier of the country.
        /// </summary>
        public int CountryID { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="clsCountry"/> class
        /// with default values.
        /// </summary>
        public clsCountry()
        {
            CountryID = -1;
            CountryName = "";
        }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        /// <summary>
        /// Retrieves country information by its unique identifier.
        /// </summary>
        /// <param name="CountryID">The unique identifier of the country.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// country if found; otherwise, <see langword="null"/>.
        /// </returns>
        /// 

        public static async Task<clsCountry> FindAsync(int CountryID)
        {
            clsCountryData.CountryInfoResult Result = await DVLD_Data_Access_Layer.clsCountryData.GetCountryInfoByIDAsync(CountryID);
            if (Result !=null)
            {
                return new clsCountry(Result.CountryID, Result.CountryName);
            }

            return null;
        }
        public static clsCountry Find(int CountryID)
        {
            clsCountryData.CountryInfoResult Result =  DVLD_Data_Access_Layer.clsCountryData.GetCountryInfoByID(CountryID);
            if (Result !=null)
            {
                return new clsCountry(Result.CountryID, Result.CountryName);
            }

            return null;
        }
        /// <summary>
        /// Retrieves country information by its name.
        /// </summary>
        /// <param name="CountryName">The name of the country.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the
        /// country if found; otherwise, <see langword="null"/>.
        /// </returns>
        public static  async Task<clsCountry> FindAsync(string CountryName)
        {
            clsCountryData.CountryInfoResult Result = await DVLD_Data_Access_Layer.clsCountryData.GetCountryInfoByNameAsync(CountryName);
            if (Result != null)
            {
                return new clsCountry(Result.CountryID, Result.CountryName);
            }

            return null;
        }
        public static clsCountry Find(string CountryName)
        {
            clsCountryData.CountryInfoResult Result =  DVLD_Data_Access_Layer.clsCountryData.GetCountryInfoByName(CountryName);
            if (Result != null)
            {
                return new clsCountry(Result.CountryID, Result.CountryName);
            }

            return null;
        }
        /// <summary>
        /// Retrieves all countries.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing a
        /// <see cref="DataTable"/> with the country records.
        /// </returns>
        public static Task<DataTable> GetAllCountriesNamesAsync()
        {
            return DVLD_Data_Access_Layer.clsCountryData.GetAllCountriesNameAsync();
        }
        public static Task<DataTable> GetAllCountriesAsync()
        {
            return DVLD_Data_Access_Layer.clsCountryData.GetAllCountriesAsync();
        }
        /// <summary>
        /// Determines whether a country exists with the specified identifier.
        /// </summary>
        /// <param name="CountryID">The unique identifier of the country.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing
        /// <see langword="true"/> if the country exists; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static Task<bool> IsCountryExistAsync(int CountryID)
        {
            return DVLD_Data_Access_Layer.clsCountryData.IsCountryExistByIDAsync(CountryID);
        }
    }
}