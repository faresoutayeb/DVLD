using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]

    public class clsValidLengthAttribute : Attribute, ICustomValidationAttribute
    {
        public int MinLength { get; }
        public int MaxLength { get; }
        public string ErrorMessage { get; }

        public clsValidLengthAttribute(
            int minLength, int maxLength, string errorMessage)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (value == null)
                return false;

            string text = value.ToString();

            return text.Length >= MinLength &&
                   text.Length <= MaxLength;
        }
    }
}
