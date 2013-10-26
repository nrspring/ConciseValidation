using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation.Extensions
{
    public static class IntegerExtensions
    {
        public static ValidatorItem<rootType, int> MaxValue<rootType>(this ValidatorItem<rootType, int> item, int value, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, int>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };


            if (item.CanContinue)
            {
                if (item.FieldValue > value)
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

        public static ValidatorItem<rootType, int> MaxValue<rootType>(this ValidatorItem<rootType, int> item, int value)
        {
            return item.MaxValue(value, string.Format("{0} has a maximum value of {1}.", item.FieldDescription, value));
        }

        public static ValidatorItem<rootType, int> MinValue<rootType>(this ValidatorItem<rootType, int> item, int value, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, int>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };


            if (item.CanContinue)
            {
                if (item.FieldValue < value)
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

        public static ValidatorItem<rootType, int> MinValue<rootType>(this ValidatorItem<rootType, int> item, int value)
        {
            return item.MinValue(value, string.Format("{0} has a minimum value of {1}.", item.FieldDescription, value));
        }
    }
}
