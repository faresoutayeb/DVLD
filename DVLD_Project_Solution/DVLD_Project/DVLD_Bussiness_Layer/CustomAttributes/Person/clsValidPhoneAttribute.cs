using DVLD_Bussiness_Layer.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace DVLD_Bussiness_Layer.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]

    public class clsValidPhoneAttribute : Attribute, ICustomValidationAttribute
    {
        public string ErrorMessage { get; }

        public clsValidPhoneAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return true;

            return System.Text.RegularExpressions.Regex.IsMatch(
                value.ToString(), @"^\+?[0-9]{8,15}$");
        }
    }
}
