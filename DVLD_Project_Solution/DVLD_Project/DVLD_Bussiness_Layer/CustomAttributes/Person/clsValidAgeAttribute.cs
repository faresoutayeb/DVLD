using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    public class clsValidAgeAttribute : Attribute, ICustomValidationAttribute
    {
        public int MinimumAge { get; }
        public string ErrorMessage { get; }

        public clsValidAgeAttribute(int minimumAge, string errorMessage)
        {
            MinimumAge = minimumAge;
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (!(value is DateTime))
                return false;

            DateTime birthDate = (DateTime)value;

            if (birthDate.Date > DateTime.Today)
                return false;

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Today.AddYears(-age))
                age--;

            return age >= MinimumAge;
        }
    }
}
