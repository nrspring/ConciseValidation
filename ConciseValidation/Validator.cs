using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation
{
    public class Validator<t>
    {
        public List<ValidatorError> ValidatorErrors { get; set; }
        public t FieldObject { get; set; }

        public Validator(t fieldobject)
        {
            ValidatorErrors = new List<ValidatorError>();
            FieldObject = fieldobject;
        }

        public ValidatorItem<t> ValidateField(Expression<Func<t, string>> propertyName)
        {
            var propertyReference = propertyName.Body as MemberExpression;
            string fieldName = propertyReference.Member.Name;

            var returnResponse = new ValidatorItem<t>()
            {
                ParentValidator = this,
                FieldName = fieldName,
                CanContinue = true,
                FieldValue = string.Empty,
                FieldDescription = fieldName
            };

            var property = FieldObject.GetType().GetProperty(fieldName);
            if (property.GetValue(FieldObject, null) != null)
            {
                returnResponse.FieldValue = property.GetValue(FieldObject, null).ToString();
            }

            return returnResponse;
        }
    }
}
