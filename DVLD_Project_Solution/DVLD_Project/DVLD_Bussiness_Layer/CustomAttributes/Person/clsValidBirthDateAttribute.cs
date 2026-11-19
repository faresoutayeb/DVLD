using DVLD_Bussiness_Layer.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class clsValidBirthDateAttribute : Attribute, ICustomValidationAttribute
    {
        public string ErrorMessage { get; }

        public clsValidBirthDateAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (!(value is DateTime))
                return false;

            DateTime date = (DateTime)value;

            return date != DateTime.MinValue &&
                   date.Date <= DateTime.Today;
        }
    }
}
