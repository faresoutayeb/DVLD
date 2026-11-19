using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    public class clsValidPositiveNumberAttribute : Attribute, ICustomValidationAttribute
    {
        public string ErrorMessage { get; }

        public clsValidPositiveNumberAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (value == null )
                return false;

            try
            {
                return Convert.ToDecimal(value) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
