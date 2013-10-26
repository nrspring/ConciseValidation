using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation.Extensions
{
    public static class DoubleExtensions
    {
        public static ValidatorItem<rootType, double> MaxValue<rootType>(this ValidatorItem<rootType, double> item, double value, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, double>()
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

        public static ValidatorItem<rootType, double> MaxValue<rootType>(this ValidatorItem<rootType, double> item, double value)
        {
            return item.MaxValue(value, string.Format("{0} has a maximum value of {1}.", item.FieldDescription, value));
        }

        public static ValidatorItem<rootType, double> MinValue<rootType>(this ValidatorItem<rootType, double> item, double value, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, double>()
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

        public static ValidatorItem<rootType, double> MinValue<rootType>(this ValidatorItem<rootType, double> item, double value)
        {
            return item.MinValue(value, string.Format("{0} has a minimum value of {1}.", item.FieldDescription, value));
        }
    }
}
