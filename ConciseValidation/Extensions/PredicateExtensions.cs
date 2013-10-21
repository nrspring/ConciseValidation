using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation.Extensions
{
    public static class PredicateExtensions
    {
        public static ValidatorItem<rootType, fieldType> ValidateByFunction<rootType, fieldType>(this ValidatorItem<rootType, fieldType> item, Func<ValidatorItem<rootType, fieldType>, Boolean> function, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, fieldType>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };

            if (item.CanContinue)
            {
                var executeValue = function(item);
                if (!executeValue)
                {
                    var newError = new ValidatorError()
                    {
                        Field = item.FieldName,
                        Message = errorMessage
                    };

                    item.ParentValidator.ValidatorErrors.Add(newError);
                }
                else
                {
                    returnResponse.CanContinue = true;
                }
            }

            return returnResponse;
        }
    }
}
