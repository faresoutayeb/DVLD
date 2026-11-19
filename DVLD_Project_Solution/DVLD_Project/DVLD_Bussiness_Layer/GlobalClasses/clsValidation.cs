using DVLD_Bussiness_Layer.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.GlobalClasses
{
    public class clsValidation
    {
        public static event EventHandler<clsValidationErrorEventArgs> OnValidationError;

        public static void FireValidationError(string PropertyName,object AttributID,string ErrorMessage)
        {
            OnValidationError?.Invoke(null, new clsValidationErrorEventArgs(PropertyName, AttributID, ErrorMessage));

        }

        public static bool IsValidAge(DateTime birthDate, int minimumAge)
        {
            if (birthDate.Date > DateTime.Today)
                return false;

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Today.AddYears(-age))
                age--;

            return age >= minimumAge;
        }

        public static bool IsValid(object CurrentObject)
        {
            bool IsObjectValid = true;
            PropertyInfo[] PropertyList = CurrentObject.GetType().GetProperties();

            foreach (PropertyInfo CurrentProperty in PropertyList)
            {
                Attribute[] Attributes = (Attribute[])CurrentProperty.GetCustomAttributes<Attribute>();

                foreach (Attribute CurrentAttribute in Attributes)
                {
                    if (CurrentAttribute is ICustomValidationAttribute)
                    {
                        ICustomValidationAttribute ValidationAttribute = (ICustomValidationAttribute)CurrentAttribute;
                        object Value = CurrentProperty.GetValue(CurrentObject);

                        if (!ValidationAttribute.IsValid(Value))
                        {

                            FireValidationError(CurrentProperty.Name, CurrentAttribute.TypeId, ValidationAttribute.ErrorMessage);
                            IsObjectValid = false;
                        }
                    }
                }
            }

            return IsObjectValid;
        }

        public static bool IsValidEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        public static bool IsValidInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsValidFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (IsValidInteger(Number) || IsValidFloat(Number));
        }


    }

}
