using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace DVLD_Bussiness_Layer.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class clsValidUsernameAttribute : Attribute, ICustomValidationAttribute
    {
        public int MinLength { get; }
        public int MaxLength { get; }
        public string ErrorMessage { get; }

        public clsValidUsernameAttribute(
            int minLength, int maxLength, string errorMessage)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return false;

            string username = value.ToString();

            return username.Length >= MinLength &&
                   username.Length <= MaxLength &&
                   System.Text.RegularExpressions.Regex.IsMatch(
                       username, @"^[a-zA-Z0-9_]+$");
        }
    }
}
