using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness_Layer.CustomAttributes
{
    public interface ICustomValidationAttribute
    {
        string ErrorMessage { get; }
        bool IsValid(object value);
    }
}
