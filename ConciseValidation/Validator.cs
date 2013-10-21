using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation
{
    public class Validator<rootType>
    {
        public List<ValidatorError> ValidatorErrors { get; set; }
        public rootType FieldObject { get; set; }

        public Validator(rootType fieldobject)
        {
            ValidatorErrors = new List<ValidatorError>();
            FieldObject = fieldobject;
        }

        public ValidatorItem<rootType, fieldType> ValidateField<fieldType>(Expression<Func<rootType, fieldType>> propertyName)
        {
            var propertyReference = propertyName.Body as MemberExpression;
            string fieldName = propertyReference.Member.Name;

            var returnResponse = new ValidatorItem<rootType,fieldType>()
            {
                ParentValidator = this,
                FieldName = fieldName,
                CanContinue = true,
                FieldValue = default(fieldType),
                FieldDescription = fieldName
            };

            var property = FieldObject.GetType().GetProperty(fieldName);
            if (property.GetValue(FieldObject, null) != null)
            {
                returnResponse.FieldValue = (fieldType)property.GetValue(FieldObject, null);
            }

            return returnResponse;
        }
    }
}
