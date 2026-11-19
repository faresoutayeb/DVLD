using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class clsValidSignUpDateTimeAttribute : Attribute, ICustomValidationAttribute
    {
        public string ErrorMessage { get; }

        public clsValidSignUpDateTimeAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (!(value is DateTime))
                return false;

            DateTime signUpDateTime = (DateTime)value;

            return signUpDateTime != DateTime.MinValue &&
                   signUpDateTime <= DateTime.Now;
        }
    }
}
