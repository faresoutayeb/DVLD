using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    public class clsValidationErrorEventArgs :EventArgs
    {
        public string PropertyName { get; }
        public object AttributeID { get; set; }
        public string ErrorMessage { get; }

        public clsValidationErrorEventArgs(string propertyName,object AttributeID, string errorMessage)
        {
            this.PropertyName = propertyName;
            this.ErrorMessage = errorMessage;
            this.AttributeID = AttributeID;
        }


    }
}
