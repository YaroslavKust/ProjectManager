using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.DTO;

namespace ProjectManager.BL
{
    public abstract class PropertyValidateModel : NotifyObject, IDataErrorInfo

    {
    public string Error => null;

    public string this[string fieldName]
    {
        get
        {
            var validationResults = new List<ValidationResult>();

            var fieldValue = GetType().GetProperty(fieldName).GetValue(this);
            var validationContext = new ValidationContext(this) { MemberName = fieldName };

            if (Validator.TryValidateProperty(fieldValue, validationContext, validationResults))
                return null;

            return validationResults.First().ErrorMessage;
        }
    }
    }
}
