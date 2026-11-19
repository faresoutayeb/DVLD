using DVLD_Bussiness_Layer.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class clsRequiredAttribute : Attribute, ICustomValidationAttribute
    {
        public string ErrorMessage { get; }

        public clsRequiredAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            return value != null &&
                   !string.IsNullOrWhiteSpace(value.ToString());
        }
    }
}
