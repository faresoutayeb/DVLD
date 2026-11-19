using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class clsValidExpirationDateAttribute : Attribute, ICustomValidationAttribute
    {
        public string ErrorMessage { get; }

        public clsValidExpirationDateAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (!(value is DateTime))
                return false;

            DateTime expirationDate = (DateTime)value;

            return expirationDate != DateTime.MinValue &&
                   expirationDate.Date > DateTime.Today;
        }
    }
}
