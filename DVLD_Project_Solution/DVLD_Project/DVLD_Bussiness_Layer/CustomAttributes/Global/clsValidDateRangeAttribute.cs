using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    public class clsValidDateRangeAttribute : Attribute, ICustomValidationAttribute
    {
        public DateTime MinimumDate { get; }
        public DateTime MaximumDate { get; }
        public string ErrorMessage { get; }

        public clsValidDateRangeAttribute(
            string minimumDate,
            string maximumDate,
            string errorMessage)
        {
            MinimumDate = DateTime.Parse(minimumDate);
            MaximumDate = DateTime.Parse(maximumDate);
            ErrorMessage = errorMessage;
        }

        public bool IsValid(object value)
        {
            if (!(value is DateTime))
                return false;

            DateTime date = ((DateTime)value).Date;

            return date >= MinimumDate.Date &&
                   date <= MaximumDate.Date;
        }
    }
}
