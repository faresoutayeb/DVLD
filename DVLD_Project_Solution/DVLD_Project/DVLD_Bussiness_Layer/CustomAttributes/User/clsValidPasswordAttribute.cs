using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DVLD_Bussiness_Layer.CustomAttributes
{        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]

    public class clsValidPasswordAttribute : Attribute, ICustomValidationAttribute
    {
        public int MinLength { get; }
        public int MaxLength { get; }

        public string ErrorMessage { get; }

        public clsValidPasswordAttribute(int minLength, int MaxLength, string errorMessage)
        {
            this.MinLength = minLength;
            this.MaxLength = MaxLength;
            this.ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            return value != null &&   value.ToString().Length >= MinLength && value.ToString().Length <= MaxLength;
        }
    }
}
