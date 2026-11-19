using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    public class clsValidIssueDateAttribute : Attribute, ICustomValidationAttribute
    {
        public string ErrorMessage { get; }

        public clsValidIssueDateAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (!(value is DateTime))
                return false;

            DateTime issueDate = (DateTime)value;

            return issueDate != DateTime.MinValue &&
                   issueDate.Date <= DateTime.Today;
        }
    }
}
