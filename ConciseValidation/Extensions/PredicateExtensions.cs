using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation.Extensions
{
    public static class PredicateExtensions
    {
        public static ValidatorItem<t> ValidateByFunction<t>(this ValidatorItem<t> item, Func<ValidatorItem<t>, Boolean> function, string errorMessage)
        {
            var returnResponse = new ValidatorItem<t>()
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
