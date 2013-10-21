using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation.Extensions
{
    public static class DateExtensions
    {

        public static ValidatorItem<rootType, DateTime> MaxDate<rootType>(this ValidatorItem<rootType, DateTime> item, DateTime value, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, DateTime>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };

            if (item.CanContinue)
            {
                if (value < item.FieldValue)
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

        public static ValidatorItem<rootType, DateTime> MaxDate<rootType>(this ValidatorItem<rootType, DateTime> item, DateTime value)
        {
            return item.MaxDate(value,
                                string.Format("{0} has a maximum date of {1}.", item.FieldDescription,
                                              value.ToString("MM/dd/yyyy")));
        }


        public static ValidatorItem<rootType, DateTime> MinDate<rootType>(this ValidatorItem<rootType, DateTime> item, DateTime value, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, DateTime>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };

            if (item.CanContinue)
            {
                if (value > item.FieldValue)
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

        public static ValidatorItem<rootType, DateTime> MinDate<rootType>(this ValidatorItem<rootType, DateTime> item, DateTime value)
        {
            return item.MinDate(value,
                                string.Format("{0} has a minimum date of {1}.", item.FieldDescription,
                                              value.ToString("MM/dd/yyyy")));
        }
    }
}
